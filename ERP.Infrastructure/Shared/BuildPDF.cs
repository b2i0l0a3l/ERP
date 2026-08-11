using System.Globalization;
using ERP.Core.Interfaces;
using ERP.Core.enums;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ERP.Core.Models.InvoiceModels;

namespace ERP.Infrastructure.Shared
{
    public class BuildPDF : IBuildPdf
    {
        private static readonly CultureInfo MoneyCulture = CultureInfo.InvariantCulture;
        private const string CurrencyCode = "درهم";

        private static string Money(decimal value) =>
            $"{value.ToString("N2", MoneyCulture)} {CurrencyCode}";

        private static (string Label, string Hex) StatusStyle(enInvoiceStatus? status) => status switch
        {
            enInvoiceStatus.Paid => ("مدفوعة", "#16A34A"),
            enInvoiceStatus.Issued => ("صادرة", "#D97706"),
            enInvoiceStatus.Draft => ("مسودة", "#6B7280"),
            enInvoiceStatus.Cancelled => ("ملغاة", "#6B7280"),
            _ => ("غير محدد", "#374151")
        };

        private static string InvoiceTypeLabel(enInvoiceType type) => type switch
        {
            enInvoiceType.Sale => "فاتورة بيع",
            enInvoiceType.CreditNote => "إشعار دائن",
            enInvoiceType.Purchase => "فاتورة شراء",
            _ => type.ToString()
        };

        public Stream BuildPdf(InvoiceDTO invoice, List<InvoiceItemDTO> items)
        {
            const string BaseFont = "Cairo";
            const string primary = "#1E3A8A";
            const string accent = "#2563EB";
            const string ink = "#111827";
            const string muted = "#6B7280";
            const string border = "#E5E7EB";
            const string zebra = "#F9FAFB";

            var (statusLabel, statusHex) = StatusStyle(invoice.Status);

            string billToName = invoice.CustomerId.HasValue
                ? (invoice.CustomerName ?? "غير محدد")
                : invoice.SupplierId.HasValue
                    ? (invoice.SupplierName ?? "غير محدد")
                    : "غير محدد";

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(0);
                    page.PageColor(Colors.White);
                    page.ContentFromRightToLeft();
                    page.DefaultTextStyle(x => x.FontFamily(BaseFont).FontSize(10).FontColor(ink));

                    page.Header().Background(primary).Padding(30).Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text("فاتورة")
                                .FontSize(28).Bold().FontColor(Colors.White).LetterSpacing(0.02f);
                            col.Item().PaddingTop(4).Text($"رقم: {invoice.InvoiceNumber}")
                                .FontSize(11).FontColor("#BFDBFE");
                        });

                        row.ConstantItem(140).AlignLeft().Column(col =>
                        {
                            col.Item().AlignLeft().Background(Colors.White).PaddingVertical(4).PaddingHorizontal(10)
                                .Text(statusLabel).Bold().FontSize(10).FontColor(statusHex);
                        });
                    });

                    page.Content().Padding(30).Column(col =>
                    {
                        col.Spacing(0);

                        col.Item().PaddingTop(10).Row(row =>
                        {
                            row.RelativeItem(2).Column(billTo =>
                            {
                                billTo.Item().Text("إلى").Bold().FontSize(9)
                                    .FontColor(muted).LetterSpacing(0.02f);
                                billTo.Item().PaddingTop(4).Text(billToName).Bold().FontSize(13).FontColor(ink);
                                billTo.Item().PaddingTop(2).Text(InvoiceTypeLabel(invoice.Type)).FontSize(9).FontColor(muted);
                            });

                            row.RelativeItem(1).Column(dates =>
                            {
                                dates.Item().AlignLeft().Text("تاريخ الإصدار").Bold().FontSize(9)
                                    .FontColor(muted).LetterSpacing(0.02f);
                                dates.Item().AlignLeft().PaddingTop(4)
                                    .Text($"{invoice.IssueDate:dd MMM yyyy}").FontSize(11);

                                if (invoice.DueDate.HasValue)
                                {
                                    dates.Item().AlignLeft().PaddingTop(10).Text("تاريخ الاستحقاق").Bold().FontSize(9)
                                        .FontColor(muted).LetterSpacing(0.02f);
                                    dates.Item().AlignLeft().PaddingTop(4)
                                        .Text($"{invoice.DueDate.Value:dd MMM yyyy}").FontSize(11);
                                }
                            });
                        });

                        col.Item().PaddingTop(20).LineHorizontal(1).LineColor(border);

                        col.Item().PaddingTop(20).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(4);
                                columns.RelativeColumn(1.2f);
                                columns.RelativeColumn(2);
                                columns.RelativeColumn(1.5f);
                                columns.RelativeColumn(2);
                            });

                            table.Header(header =>
                            {
                                void HeaderCell(string text, bool left = false)
                                {
                                    var cell = header.Cell().Background(primary).Padding(8);
                                    var aligned = left ? cell.AlignLeft() : cell;
                                    aligned.Text(text).Bold().FontSize(9).FontColor(Colors.White).LetterSpacing(0.01f);
                                }

                                HeaderCell("المنتج");
                                HeaderCell("الكمية", left: true);
                                HeaderCell("سعر الوحدة", left: true);
                                HeaderCell("الضريبة", left: true);
                                HeaderCell("الإجمالي", left: true);
                            });

                            for (int i = 0; i < items.Count; i++)
                            {
                                InvoiceItemDTO item = items[i];
                                string bg = i % 2 == 0 ? Colors.White : zebra;

                                table.Cell().Background(bg).Padding(8)
                                    .Text(item.ProductName ?? item.Description ?? "غير محدد").FontSize(9.5f);
                                table.Cell().Background(bg).Padding(8).AlignLeft()
                                    .Text(item.Quantity.ToString(MoneyCulture)).FontSize(9.5f);
                                table.Cell().Background(bg).Padding(8).AlignLeft()
                                    .Text(Money(item.UnitPrice)).FontSize(9.5f);
                                table.Cell().Background(bg).Padding(8).AlignLeft()
                                    .Text($"{item.TaxRate.ToString(MoneyCulture)}%").FontSize(9.5f).FontColor(muted);
                                table.Cell().Background(bg).Padding(8).AlignLeft()
                                    .Text(Money(item.LineTotal)).Bold().FontSize(9.5f);
                            }
                        });

                        col.Item().PaddingTop(20).Row(row =>
                        {
                            row.RelativeItem(3);
                            row.RelativeItem(2).Border(1).BorderColor(border).Padding(15).Column(summary =>
                            {
                                void SummaryLine(string label, string value, bool bold = false, string? colorHex = null)
                                {
                                    summary.Item().PaddingVertical(3).Row(r =>
                                    {
                                        r.RelativeItem().Text(label)
                                            .FontSize(bold ? 12 : 10)
                                            .FontColor(colorHex ?? (bold ? ink : muted))
                                            .Bold();
                                        r.RelativeItem().AlignLeft().Text(value)
                                            .FontSize(bold ? 12 : 10)
                                            .FontColor(colorHex ?? ink)
                                            .Bold();
                                    });
                                }

                                SummaryLine("المجموع الفرعي", Money(invoice.SubTotal));
                                SummaryLine("الضريبة", Money(invoice.TaxAmount));
                                SummaryLine("الخصم", $"- {Money(invoice.DiscountAmount)}");
                                summary.Item().PaddingTop(6).PaddingBottom(6).LineHorizontal(1).LineColor(border);
                                SummaryLine("الإجمالي المستحق", Money(invoice.TotalAmount), bold: true, colorHex: accent);
                            });
                        });

                        if (!string.IsNullOrEmpty(invoice.Notes))
                        {
                            col.Item().PaddingTop(25).Background(zebra).Padding(12).Column(notes =>
                            {
                                notes.Item().Text("ملاحظات").Bold().FontSize(9).FontColor(muted).LetterSpacing(0.02f);
                                notes.Item().PaddingTop(4).Text(invoice.Notes).FontSize(9.5f).FontColor(ink);
                            });
                        }
                    });

                    page.Footer().Padding(20).Column(col =>
                    {
                        col.Item().LineHorizontal(1).LineColor(border);
                        col.Item().PaddingTop(8).Row(row =>
                        {
                            row.RelativeItem().Text("شكراً لتعاملكم معنا")
                                .FontSize(8.5f).FontColor(muted);

                            row.RelativeItem().AlignLeft().Text(x =>
                            {
                                x.DefaultTextStyle(s => s.FontSize(8.5f).FontColor(muted));
                                x.Span("صفحة ");
                                x.CurrentPageNumber();
                                x.Span(" من ");
                                x.TotalPages();
                            });
                        });
                    });
                });
            });
            var stream = new MemoryStream();
            document.GeneratePdf(stream);
            stream.Position = 0;
            return stream;
        }
    }
}