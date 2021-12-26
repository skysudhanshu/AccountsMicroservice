/*using AccountsMicroservice.Controllers;
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

namespace AccountsTesting
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
        }

        [Test]
        public void Deposit_ValidData_ReturnsOkResult()
        {
            int accountId = 101;
            double amount = 3000;

            TransactionStatus transactionStatusObj = new TransactionStatus()
            {
                accountId = accountId,
                source_Balance = 4000,
                destination_Balance = -1,
                message = "Transaction Details : Rs." + amount + " deposited into AccountID : " + accountId,
            };

            Task<TransactionStatus> transactionStatusResult = Task.FromResult(transactionStatusObj);
            
            mockService.Setup(s => s.deposit(accountId, amount)).Returns(transactionStatusResult);
            controller = new AccountsController(mockService.Object);
            var result = controller.deposit(accountId, amount);
            var okResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void Deposit_InvalidInput_ReturnsBadRequest()
        {
            int accountId = 90;
            double amount = 0;
            controller = new AccountsController(mockService.Object);
            var result = controller.deposit(accountId, amount);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }
        [Test]
        public void Deposit_ValidData_ReturnsNoContent()
        {
            int accountId = 1001;
            double amount = 3000;
            TransactionStatus status = null;

            Task<TransactionStatus> transactionStatus = Task.FromResult(status); 

            mockService.Setup(s => s.deposit(accountId, amount)).Returns(transactionStatus);
            controller = new AccountsController(mockService.Object);
            var result = controller.deposit(accountId, amount);
            var okResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(204, okResult.StatusCode);
        }

    }
}

*/