namespace MyMoneyAPI.DTO.Response.Account
{
    public class AccountInformationResponse
    {
        public long AccountId { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public decimal BaseAmount { get; set; }
        public decimal Balance { get; set; }
        public string Icon { get; set; } = string.Empty;
    }
}
