using AccountsMicroservice.Controllers;
using AccountsMicroservice.Models;
using AccountsMicroservice.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsTest
{

    [TestFixture]
    public class GetAccountByIdVerify
    {
        private Mock<IAccountService> mockService = new Mock<IAccountService>();
        private AccountsController controller;

        [Test]
        public async Task statusOKforGetAccountById()
        {
            int accountId = 101;

            Account account = new Account()
            {
                CustomerId = 1,
                AccountId = accountId,
                Account_Type = "savings",
                AccountCreationDate = new DateTime(2021, 6, 27),
                Balance_Amount = 1000,
            };

            /*Task<Account> account = Task.FromResult(accountObj);*/

            mockService.Setup(e => e.getAccountById(accountId)).ReturnsAsync(account);
            controller = new AccountsController(mockService.Object);
            var result = await controller.getAccount(accountId);
            var finalResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, finalResult.StatusCode);
        }


        [Test]
        public async Task statusBadRequestforGetAccountById()
        {
            int accountId = 90;
            controller = new AccountsController(mockService.Object);
            var result = await controller.getAccount(accountId);
            var finalResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(400, finalResult.StatusCode);
        }



        [Test]
        public async Task statusNoContentforGetAccountById()
        {
            int accountId = 101;

            Account account = null;

            /*Task<Account> account = Task.FromResult(accountObj);*/

            mockService.Setup(e => e.getAccountById(accountId)).ReturnsAsync(account);
            controller = new AccountsController(mockService.Object);
            var result = await controller.getAccount(accountId);
            var finalResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(204, finalResult.StatusCode);

        }


    }
}
