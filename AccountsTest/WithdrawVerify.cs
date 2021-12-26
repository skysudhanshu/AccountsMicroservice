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
    public class WithdrawVerify
    {
        private Mock<IAccountService> mockService = new Mock<IAccountService>();
        private AccountsController controller;

        [SetUp]
        public void SetUp()
        {
            mockService = new Mock<IAccountService>();
        }


        [Test]
        public async Task statusOKforWithdraw()
        {
            int accountId = 101;
            double amount = 200;

            TransactionStatus transactionStatus = new TransactionStatus()
            {
                AccountId = accountId,
                Source_Balance = 800,
                Destination_Balance = -1,
                Message = "Transaction Details : Rs." + amount + " withdrawn from AccountID: " + accountId,
            };

            /*Task<TransactionStatus> transactionStatus = Task.FromResult(status);*/

            mockService.Setup(e => e.withdraw(accountId, amount)).ReturnsAsync(transactionStatus);
            controller = new AccountsController(mockService.Object);
            var result = await controller.withdraw(accountId, amount);
            Assert.IsInstanceOf<OkObjectResult>(result);


        }


        [Test]
        public async Task statusBadRequestforWithdraw()
        {
            int accountId = 90;
            double amount = 0;
            controller = new AccountsController(mockService.Object);
            var result = await controller.withdraw(accountId, amount);
            var finalResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(400, finalResult.StatusCode);
        }

        [Test]
        public async Task statusNoContentforWithdraw()
        {
            int accountId = 101;
            double amount = 10000;

            TransactionStatus transactionStatus = null;
            /*Task<TransactionStatus> transactionStatus = Task.FromResult(status);*/

            mockService.Setup(e => e.withdraw(accountId, amount)).ReturnsAsync(transactionStatus);
            controller = new AccountsController(mockService.Object);
            var result = await controller.withdraw(accountId, amount);
            Assert.IsInstanceOf<NoContentResult>(result);
        }


    }
}
