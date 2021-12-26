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
    public class WithdrawVerify
    {
        private Mock<IAccountService> mockService = new Mock<IAccountService>();
        private AccountsController controller;

        *//*[SetUp]
        public void SetUp()
        {
            mockService = new Mock<IAccountService>();
        }*//*


        [Test]
        public void statusOKforWithdraw()
        {
            int accountId = 101;
            double amount = 200;

            TransactionStatus status = new TransactionStatus()
            {
                accountId = accountId,
                source_Balance = 800,
                destination_Balance = -1,
                message = "Transaction Details : Rs." + amount + " withdrawn from AccountID: " + accountId,
            };

            Task<TransactionStatus> transactionStatus = Task.FromResult(status);

            mockService.Setup(e => e.withdraw(accountId, amount)).Returns(transactionStatus);
            controller = new AccountsController(mockService.Object);
            var result = controller.withdraw(accountId, amount);
            var finalResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, finalResult.StatusCode);
            

        }


        [Test]
        public void statusBadRequestforWithdraw()
        {
            int accountId = 90;
            double amount = 0;
            controller = new AccountsController(mockService.Object);
            var result = controller.withdraw(accountId, amount);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public void statusNoContentforWithdraw()
        {
            int accountId = 101;
            double amount = 10000;

            TransactionStatus status = null;
            Task<TransactionStatus> transactionStatus = Task.FromResult(status);
            mockService.Setup(e => e.withdraw(accountId, amount)).Returns(transactionStatus);
            controller = new AccountsController(mockService.Object);
            var result = controller.withdraw(accountId, amount);
            var finalResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(204, finalResult.StatusCode);
        }


    }
}
*/