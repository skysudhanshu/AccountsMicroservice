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
    public class GetAccountByIdVerify
    {
        private Mock<IAccountService> mockService = new Mock<IAccountService>();
        private AccountsController controller;

        [Test]
        public void statusOKforGetAccountById()
        {
            int accountId = 101;

            Account accountObj = new Account()
            {
                customerId = 1,
                accountId = accountId,
                account_Type = "savings",
                accountCreationDate = new DateTime(2021, 6, 27),
                balance_Amount = 1000,
            };

            Task<Account> account = Task.FromResult(accountObj);

            mockService.Setup(e => e.getAccountById(accountId)).Returns(account);
            controller = new AccountsController(mockService.Object);
            var result = controller.getAccount(accountId);
            var finalResult = (IStatusCodeActionResult)result; 
            Assert.AreEqual(200, finalResult.StatusCode);
        }


        [Test]
        public void statusBadRequestforGetAccountById()
        {
            int accountId = 90;
            controller = new AccountsController(mockService.Object);
            var result = controller.getAccount(accountId);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }



        [Test]
        public void statusNoContentforGetAccountById()
        {
            int accountId = 101;

            Account accountObj = null;

            Task<Account> account = Task.FromResult(accountObj);

            mockService.Setup(e => e.getAccountById(accountId)).Returns(account);
            controller = new AccountsController(mockService.Object);
            var result = controller.getAccount(accountId);
            var finalResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(204, finalResult.StatusCode);

        }
            

    }
}
*/