using AccountsMicroservice.Controllers;
using AccountsMicroservice.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountsMicroservice.Models;
using AccountsMicroservice.Repository;
using AccountsMicroservice.Database;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NUnit.Framework;

namespace AccountsTest
{

    [TestFixture]
    public class TransferVerify
    {
        private Mock<IAccountService> mockService = new Mock<IAccountService>();
        private AccountsController controller;


        [Test]
        public async Task statusOkforTransfer()
        {
            int fromAccountId = 101;
            int toAccountId = 103;
            double amount = 500;

            TransactionStatus transactionStatus = new TransactionStatus()
            {
                AccountId = fromAccountId,
                Source_Balance = 500,
                Destination_Balance = 1500,
                Message = "Transaction Details : Amount Transferred from " + fromAccountId + " to " + toAccountId,
            };

            mockService.Setup(e => e.transfer(fromAccountId, toAccountId, amount)).ReturnsAsync(transactionStatus);
            controller = new AccountsController(mockService.Object);
            var result = await controller.transfer(fromAccountId, toAccountId, amount);
            var finalResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, finalResult.StatusCode);
        }


        [Test]
        public async Task statusBadRequestforTransfer()
        {
            int fromAccountId = 0;
            int toAccountId = 0;
            double amount = 0;

            controller = new AccountsController(mockService.Object);
            var result = (IStatusCodeActionResult)await controller.transfer(fromAccountId, toAccountId, amount);
            //var finalResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(400, result.StatusCode);
        }

        [Test]
        public async Task statusNoContentforTransfer()
        {
            int fromAccountId = 101;
            int toAccountId = 103;
            double amount = 500;

            TransactionStatus transactionStatus = null;

            mockService.Setup(e => e.transfer(fromAccountId, toAccountId, amount)).ReturnsAsync(transactionStatus);
            controller = new AccountsController(mockService.Object);
            var result = await controller.transfer(fromAccountId, toAccountId, amount);
            var finalResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(204, finalResult.StatusCode);
        }
    }
}
