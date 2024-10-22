using Microsoft.AspNetCore.Mvc;
using MyMoneyAPI.DTO.Request.Account;
using MyMoneyAPI.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace MyMoneyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        #region Add Account

        /// <summary>
        /// Creates a new account
        /// </summary>
        /// <remarks>
        /// Adds a new account to the system using the provided details such as Account Name, BaseAmount, and Icon.
        /// </remarks>
        /// <returns>Account Creation Status.</returns>
        /// <response code="200">Returns Account Creation Successful Message</response>
        /// <response code="400">If Account Name is Empty / Bad Request</response>
        /// <response code="500">If there is an internal server error</response>
        [HttpPost("AddAccount")]
        public IActionResult AddAccount([FromBody] AccountRequest accCreateReq)
        {
            var response = _accountService.AddAccount(accCreateReq);
            return StatusCode(response.StatusCode, response);
        }

        #endregion

        #region Get All Accounts

        /// <summary>
        /// Retrieves all accounts from the system.
        /// </summary>
        /// <remarks>
        /// This endpoint allows you to retrieve a list of all accounts.
        /// </remarks>
        /// <returns>A list of accounts in the system.</returns>
        /// <response code="200">Returns the list of all accounts</response>
        /// <response code="500">If there is an internal server error</response>
        [HttpGet("GetAll")]
        public IActionResult GetAllAccounts()
        {
            var response = _accountService.GetAllAccountsDetails();
            return StatusCode(response.StatusCode, response);
        }

        #endregion

        #region Delete Account

        [HttpPatch("DeleteAccounts")]
        [SwaggerOperation(
            Summary = "Delete accounts by List of Account ID's",
            Description = "Deletes a list of accounts from the database using their Account ID's."
        )]
        public IActionResult DeleteAccounts([FromBody] List<long> AccountIds)
        {
            var response = _accountService.DeleteAccounts(AccountIds);
            return StatusCode(response.StatusCode, response);
        }

        #endregion

        #region Update Account

        /// <summary>
        /// Updates the account information for a specific account.
        /// </summary>
        /// <param name="accountId">The unique identifier of the account to be updated.</param>
        /// <param name="updateAccountReq">The account details to be updated.</param>
        /// <returns>Returns a status message indicating the result of the update operation.</returns>
        /// <response code="200">If the account was successfully updated</response>
        /// <response code="400">If the provided data is invalid</response>
        /// <response code="404">If the account with the specified ID is not found</response>
        /// <response code="500">If an internal server error occurs during the update</response>
        [HttpPut("UpdateAccount/{accountId}")]
        public IActionResult AddAccount(long accountId, [FromBody] AccountRequest updateAccountReq)
        {
            var response = _accountService.UpdateAccount(accountId, updateAccountReq);
            return StatusCode(response.StatusCode, response);
        }

        #endregion
    }
}
