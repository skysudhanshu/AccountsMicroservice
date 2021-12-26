using AccountsMicroservice.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountsMicroservice.Database;
using AccountsMicroservice.Repository;
using AccountsMicroservice.Service;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController : ControllerBase
    {

        /*private readonly IAccountRepo accountRepo;*/
        private IAccountService _accountService;

        public AccountsController(IAccountService accountServiceObject)
        {
            _accountService = accountServiceObject;
        }


        // GET Request Url : https://localhost:44389/api/Accounts/GetCustomerAccountDetailsById?customerId=2
        [AllowAnonymous]
        [HttpGet("GetCustomerAccountDetailsById")]
        public async Task<IActionResult> getCustomerAccounts(int customerId)
        {
            // customerId starts from 1, any Id less than or equal to 0 will be considered Invalid.
            if (customerId <= 0)
            {
                return BadRequest("Check your Customer ID");
            }

            else
            {
                //Check if customerId exists in database. If exists, show respective accounts, else state No content.
                var customerAccountDetailsList = await _accountService.getCustomerAccounts(customerId);

                if (customerAccountDetailsList == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(customerAccountDetailsList);
                }

            }
        }

        // GET Request Url : https://localhost:44389/api/Accounts/GetAccountById?accountId=102
        [AllowAnonymous]
        [HttpGet("GetAccountById")]
        public async Task<IActionResult> getAccount(int accountId)
        {
            // AccountId starts with 101, any accountId less than or equal to 100 is considered as Invalid.
            if (accountId <= 100)
            {
                return BadRequest("Check your Account ID");
            }
            else
            {
                // Check if account with accountId exists in database, if exists, show respective account, else return No Content.
                var account = await _accountService.getAccountById(accountId);   

                if (account == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(account);
                }
            }
        }


        // GET Request Url : https://localhost:44389/api/Accounts/GetAccountStatement?accountId=102&fromDate=2020-11-14&toDate=2025-10-12  If date is specified as 2020-11-14 (in this format - yyyy-mm-dd)
        [HttpGet("GetAccountStatement")]
        public async Task<IActionResult> getAccountStatement(int accountId, DateTime fromDate, DateTime toDate)
        {
            // AccountId starts with 101.
            // Any Account Id less than or equal to 100, will be considered invalid.
            if (accountId <= 100)
            {
                return BadRequest("Check the details provided for Account Statement");
            }
            
            else
            {
                // Check if account with accountId and transactionDate within the time period mentioned exists in database.
                // If exists, show respective account statements, else return No Content.
                var transactStatement = await _accountService.getAccountStatement(accountId, fromDate, toDate);

                if(transactStatement == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(transactStatement);
                }
            }
        }




        // POST Request Url : https://localhost:44389/api/Accounts/CreateAccountforCustomer?customerId=8
        [AllowAnonymous]
        [HttpPost("CreateAccountforCustomer")]
        public async Task<IActionResult> createAccount(int customerId)
        {
            // customerId starts from 1. 
            // Any Customer Id less than or equal to 0 will be considered as Invalid.
            if(customerId <= 0)
            {
                return BadRequest("Check your Customer Id");
            }
            else
            {
                // Check if account with customerId exists.
                // If exists, create an additional 2 accounts (Savings and Current).
                // If new user, create initial 2 accounts. (Savings and Current).
                var acStatus = await _accountService.createAccount(customerId);
                if(acStatus == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(acStatus);
                }
            }
        }





        // POST Request Url : https://localhost:44389/api/Accounts/DepositAmount?accountId=102&accountType=Current&amount=500
        [AllowAnonymous]
        [HttpPost("DepositAmount")]
        public async Task<IActionResult> deposit(/*[FromBody]*/ int accountId, double amount)
        {
            // AccountId starts with 101. 
            // Ideally, deposit amount should be greater than 0. 
            // If accountId less than or equal to 100 and if amount < 0, will be considered invalid.
            if(accountId <= 100 || amount < 0)
            {
                return BadRequest("Please provide valid details");
            }
            else
            {
                // Check if account with accountId exists in database. 
                // If exists, prepare for deposit transaction.
                // If does not exist, show No Content. 
                var tsStatus = await _accountService.deposit(accountId, amount);

                if(tsStatus == null)
                {
                    return NoContent();

                }
                else
                {
                    return Ok(tsStatus);
                }

            }

        }


        // Post Request Url : https://localhost:44389/api/Accounts/WithdrawAmount?accountId=102&accountType=Current&amount=500
        [AllowAnonymous]
        [HttpPost("WithdrawAmount")]
        public async Task<IActionResult> withdraw(/*[FromBody]*/ int accountId, double amount)
        {

            // AccountId starts with 101. 
            // Ideally withdraw amount should be greater than 0.
            // If accountId less than or equal to 100 and if withdraw amount < 0, will be considered invalid.
            if(accountId <= 100 || amount < 0)
            {
                return BadRequest("Please provide valid Details");
            }
            else
            {
                // Check if account with accountId exists.
                // If exists, prepare for withdrawal transaction.
                // If not exists, show No Content.
                var tsStatus = await _accountService.withdraw(accountId, amount);

                if (tsStatus == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(tsStatus);
                }
            }
        }


        // Post Request Url : https://localhost:44389/api/Accounts/TransferAmount?amount=500&fromAccountId=102&toAccountId=104&fromAccountType=Savings&toAccountType=Current
        [AllowAnonymous]
        [HttpPost("TransferAmount")]
        public async Task<IActionResult> transfer(int fromAccountId, int toAccountId, double amount)
        {

            // AccountId starts from 101. 
            // Ideally transfer amount should be greater than 0.
            // If accountId less than or equal to 100 and if transfer amount less than 0, will be considered invalid. 
            if(amount < 0 || fromAccountId <= 100 || toAccountId <= 100)
            {
                return BadRequest("Please provide Valid Details");
            }
            else
            {
                // Check if account with accountId exists in database.
                // If exists, prepare for transfer transaction.
                // If not exists, show No Content.
                var tsStatus = await _accountService.transfer(fromAccountId, toAccountId, amount);

                if(tsStatus == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(tsStatus);
                }
            }
        }


    }
}
