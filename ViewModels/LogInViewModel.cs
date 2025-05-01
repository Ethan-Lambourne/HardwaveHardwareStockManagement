namespace HardwaveStockManagement.ViewModels
{
    public class LogInViewModel(string? Username, string? Password, bool FailedLogin)
    {
        public string? Username { get; set; } = Username;

        public string? Password { get; set; } = Password;

        public bool FailedLogin { get; set; } = FailedLogin;
    }
}
