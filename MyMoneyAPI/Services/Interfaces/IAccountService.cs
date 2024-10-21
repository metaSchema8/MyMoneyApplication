using MyMoneyAPI.Common;
using MyMoneyAPI.DTO.Request.Account;
using MyMoneyAPI.DTO.Response.Account;
using MyMoneyAPI.Models;
using System.Security.Principal;

namespace MyMoneyAPI.Services.Interfaces
{
    public interface IAccountService
    {
        ApiResponse<AccountCreationResponse> AddAccount(AccountCreateRequest accCreateReq);

        ListApiResponse<AccountInformationResponse> GetAllAccountsDetails();

        ApiResponse<string> DeleteAccounts(List<long> AccountIds);
    }
}
