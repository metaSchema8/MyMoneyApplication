namespace MyMoneyAPI.DTO.Request.Account
{
    public class AccountCreateRequest
    {
        public string AccountName { get; set; } = string.Empty;
        public decimal BaseAmount { get; set; }
        public string Icon { get; set; } = string.Empty;
    }
}
