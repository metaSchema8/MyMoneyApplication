namespace MyMoneyAPI.Common
{
    public static class ErrorMessages
    {
        public const string InvalidData = "The provided data is invalid.";

        #region Account

        public const string NoAccountName = "Entered Account Name is null.";
        public const string AccountNameEmpty = "Account Name cannot be null.";
        public const string InValidAccountId = "Entered Account Id is invalid.";
        public const string AccountCreationFailed = "Account creation failed. Please try again.";
        public const string AccountNotFound = "Account not found.";

        #endregion
    }

    public static class SuccessMessages
    {
        #region Account

        public const string AccountCreated = "Account Created successfully.";
        public const string AccountUpdated = "Account Updated successfully.";
        public const string AccountsDeleted = "Accounts Deleted successfully.";

        #endregion

    }
}
