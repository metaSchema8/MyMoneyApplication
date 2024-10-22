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
        public IActionResult AddAccount([FromBody] AccountCreateRequest accCreateReq)
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


    }
}
