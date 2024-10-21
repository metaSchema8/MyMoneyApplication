namespace MyMoneyAPI.Common
{
    public static class ErrorMessages
    {
        public const string InvalidData = "The provided data is invalid.";

        #region Account

        public const string NoAccountName = "Entered Account Name is null.";
        public const string InValidAccountName = "Entered Account Name is invalid.";
        public const string AccountCreationFailed = "Account creation failed. Please try again.";

        #endregion
    }

    public static class SuccessMessages
    {
        #region Account

        public const string AccountCreated = "Account created successfully.";
        public const string AccountsDeleted = "Accounts Deleted successfully.";

        #endregion

    }
}
