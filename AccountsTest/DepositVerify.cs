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
    public class DepositVerify
    {
        private Mock<IAccountService> mockService;
        private AccountsController controller;

        [SetUp]
        public void SetUp()
        {
            mockService = new Mock<IAccountService>();
            controller = new AccountsController(mockService.Object);
        }

        [Test]
        public async Task Deposit_ValidData_ReturnsOkResult()
        {
            int accountId = 101;
            double amount = 3000;

            TransactionStatus transactionStatusObj = new TransactionStatus()
            {
                AccountId = accountId,
                Source_Balance = 4000,
                Destination_Balance = -1,
                Message = "Transaction Details : Rs." + amount + " deposited into AccountID : " + accountId,
            };

            mockService.Setup(s => s.deposit(accountId, amount)).ReturnsAsync(transactionStatusObj);
            controller = new AccountsController(mockService.Object);
            var result = await controller.deposit(accountId, amount);
            var okResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task statusBadRequestforDeposit()
        {
            int accountId = 90;
            double amount = 0;
            var result = await controller.deposit(accountId, amount);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }
        [Test]
        public async Task Deposit_ValidData_ReturnsNoContent()
        {
            int accountId = 101;
            double amount = 3000;
            TransactionStatus status = null;

            mockService.Setup(s => s.deposit(accountId, amount)).ReturnsAsync(status);
            AccountsController control = new AccountsController(mockService.Object);
            var result = await control.deposit(accountId, amount);
            Assert.IsInstanceOf<NoContentResult>(result);
           
        }

    }
}

