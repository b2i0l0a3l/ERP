using QuestPDF.Drawing;
using QuestPDF.Infrastructure;

namespace ERP.Infrastructure.Extensions
{
    public static class FontRegistrationExtensions
    {
        public static void RegisterPdfFonts()
        {
            var fontsPath = Path.Combine(AppContext.BaseDirectory, "Shared", "Fonts");

            RegisterFont(Path.Combine(fontsPath, "Cairo-Regular.ttf"), "Cairo");
            RegisterFont(Path.Combine(fontsPath, "Cairo-Bold.ttf"), "Cairo", FontWeight.Bold);
        }

        private static void RegisterFont(string path, string fontName, FontWeight? weight = null)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"Font file not found: {path}");

            using var stream = File.OpenRead(path);

            if (weight.HasValue)
                FontManager.RegisterFontWithCustomName(fontName, stream);
            else
                FontManager.RegisterFontWithCustomName(fontName, stream);
        }
    }
}