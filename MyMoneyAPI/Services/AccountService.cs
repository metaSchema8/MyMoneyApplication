using Microsoft.EntityFrameworkCore;
using MyMoneyAPI.Common;
using MyMoneyAPI.Data;
using MyMoneyAPI.DTO.Request.Account;
using MyMoneyAPI.DTO.Response.Account;
using MyMoneyAPI.Models;
using MyMoneyAPI.Services.Interfaces;
using System.Security.Principal;

namespace MyMoneyAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _appDbContext;

        public AccountService(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ApiResponse<AccountCreationResponse> AddAccount(AccountCreateRequest accCreateReq)
        {
            try
            {
                if (string.IsNullOrEmpty(accCreateReq.AccountName))
                {
                    return new ApiResponse<AccountCreationResponse>(HttpStatusCodes.BadRequest, ErrorMessages.InValidAccountName);
                }

                var accountData = new AccountEntity
                {
                    AccountName = accCreateReq.AccountName,
                    BaseAmount = accCreateReq.BaseAmount,
                    Icon = accCreateReq.Icon,
                    CreatedBy = "System",
                    CreatedDate = DateTimeOffset.Now,
                    ModifiedBy = "System",
                    ModifiedDate = DateTimeOffset.Now,
                    IsActive = true
                };

                _appDbContext.Accounts.Add(accountData);
                _appDbContext.SaveChanges();

                var result = new AccountCreationResponse
                {
                    AccountName = accountData.AccountName,
                    BaseAmount = accountData.BaseAmount,
                    Icon = accountData.Icon,
                    Balance = accountData.BaseAmount
                };

                return new ApiResponse<AccountCreationResponse>(result, HttpStatusCodes.Ok, SuccessMessages.AccountCreated);
            }
            catch (Exception ex)
            {
                return new ApiResponse<AccountCreationResponse>(HttpStatusCodes.InternalServerError, ex.Message);
            }

        }

        public ListApiResponse<AccountInformationResponse> GetAllAccountsDetails()
        {
            try
            {
                var data = _appDbContext.Accounts.ToList();

                var response = data.Select(account => new AccountInformationResponse
                {
                    AccountId = account.AccountId,
                    AccountName = account.AccountName,
                    BaseAmount = account.BaseAmount,
                    Icon = account.Icon,
                    Balance = account.Balance,
                }).ToList();

                return new ListApiResponse<AccountInformationResponse>(response, HttpStatusCodes.Ok);
            }
            catch (Exception ex)
            {
                return new ListApiResponse<AccountInformationResponse>(HttpStatusCodes.InternalServerError, ex.Message);
            }

        }

        public ApiResponse<string> DeleteAccounts(List<long> AccountIds)
        {
            try
            {
                var accounts = _appDbContext.Accounts.Where(x => AccountIds.Contains(x.AccountId)).ToList();

                accounts.ForEach(x =>
                {
                    x.IsActive = false;
                    x.ModifiedBy = "System";
                    x.ModifiedDate = DateTimeOffset.Now;
                });

                _appDbContext.Accounts.UpdateRange(accounts);
                _appDbContext.SaveChanges();

                return new ApiResponse<string>(null, HttpStatusCodes.Ok, SuccessMessages.AccountsDeleted);
            }
            catch (Exception ex)
            {
                return new ApiResponse<string>(ex.Message, HttpStatusCodes.InternalServerError);
            }
        }
    }
}
