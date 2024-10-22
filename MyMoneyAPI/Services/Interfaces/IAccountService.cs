using MyMoneyAPI.Common;
using MyMoneyAPI.DTO.Request.Account;
using MyMoneyAPI.DTO.Response.Account;
using MyMoneyAPI.Models;
using System.Security.Principal;

namespace MyMoneyAPI.Services.Interfaces
{
    public interface IAccountService
    {
        ApiResponse<AccountResponse> AddAccount(AccountRequest accCreateReq);
        ListApiResponse<AccountInformationResponse> GetAllAccountsDetails();
        ApiResponse<AccountResponse> UpdateAccount(long accountId, AccountRequest updateAccountReq);
        ApiResponse<string> DeleteAccounts(List<long> AccountIds);
    }
}
