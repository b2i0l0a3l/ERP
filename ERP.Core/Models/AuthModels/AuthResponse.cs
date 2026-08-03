namespace ERP.Core.Models.AuthModels
{
    public record AuthResponse
    {
        public string AccessToken { get; init; } = string.Empty;
        public string RefreshToken { get; init; } = string.Empty;
    }
}
