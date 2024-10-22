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

        private const string ACCOUNTCREATE = "CREATE";
        private const string ACCOUNTUPDATE = "UPDATE";

        public AccountService(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ApiResponse<AccountResponse> AddAccount(AccountRequest accCreateReq)
        {
            try
            {
                if (string.IsNullOrEmpty(accCreateReq.AccountName))
                {
                    return new ApiResponse<AccountResponse>(HttpStatusCodes.BadRequest, ErrorMessages.AccountNameEmpty);
                }

                var accountData = new AccountEntity
                {
                    AccountName = accCreateReq.AccountName,
                    BaseAmount = accCreateReq.BaseAmount,
                    Balance = accCreateReq.BaseAmount,
                    Icon = accCreateReq.Icon,
                    CreatedBy = "System",
                    CreatedDate = DateTimeOffset.Now,
                    ModifiedBy = "System",
                    ModifiedDate = DateTimeOffset.Now,
                    IsActive = true
                };

                _appDbContext.Accounts.Add(accountData);
                _appDbContext.SaveChanges();

                return accountReponse(accountData, ACCOUNTCREATE);

            }
            catch (Exception ex)
            {
                return new ApiResponse<AccountResponse>(HttpStatusCodes.InternalServerError, ex.Message);
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

        public ApiResponse<AccountResponse> UpdateAccount(long accountId, AccountRequest updateAccountReq)
        {
            try
            {
                if (accountId <= 0 )
                {
                    return new ApiResponse<AccountResponse>(HttpStatusCodes.BadRequest, ErrorMessages.InValidAccountId);
                }

                if (string.IsNullOrEmpty(updateAccountReq.AccountName))
                {
                    return new ApiResponse<AccountResponse>(HttpStatusCodes.BadRequest, ErrorMessages.AccountNameEmpty);
                }

                var data = _appDbContext.Accounts.Where(x => x.AccountId == accountId).FirstOrDefault();
                if(data is null)
                {
                    return new ApiResponse<AccountResponse>(HttpStatusCodes.NotFound, ErrorMessages.AccountNotFound);
                }

                var accountData = new AccountEntity
                {
                    AccountName = updateAccountReq.AccountName,
                    BaseAmount = updateAccountReq.BaseAmount,
                    Balance = updateAccountReq.BaseAmount,
                    Icon = updateAccountReq.Icon,
                    ModifiedBy = "System",
                    ModifiedDate = DateTimeOffset.Now,
                    IsActive = true
                };

                _appDbContext.Accounts.Update(accountData);
                _appDbContext.SaveChanges();

                return accountReponse(accountData, ACCOUNTUPDATE);
            }
            catch (Exception ex)
            {
                return new ApiResponse<AccountResponse>(HttpStatusCodes.InternalServerError, ex.Message);
            }
        }

        private ApiResponse<AccountResponse> accountReponse(AccountEntity account, string Status)
        {
            var result = new AccountResponse
            {
                AccountName = account.AccountName,
                BaseAmount = account.BaseAmount,
                Icon = account.Icon,
                Balance = account.BaseAmount
            };

            return new ApiResponse<AccountResponse>(result, HttpStatusCodes.Ok, Status == ACCOUNTCREATE ? SuccessMessages.AccountCreated : SuccessMessages.AccountUpdated);
        }
    }
}
