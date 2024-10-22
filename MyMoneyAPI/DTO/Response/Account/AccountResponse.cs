namespace MyMoneyAPI.DTO.Response.Account
{
    public class AccountResponse
    {
        public string AccountName { get; set; } = string.Empty;
        public decimal BaseAmount { get; set; }
        public decimal Balance { get; set; }
        public string Icon { get; set; } = string.Empty;
    }
}
