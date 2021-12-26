/*using System;
using AccountsMicroservice;
using AccountsMicroservice.Controllers;
using AccountsMicroservice.Service;
using AccountsMicroservice.Models;
using AccountsMicroservice.Repository;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AccountsTesting
{
    [TestFixture]
    public class CreateAccountVerify
    {
        private Mock<IAccountService> mockService;
        private AccountsController controller;

        [SetUp]
        public void SetUp()
        {
            mockService = new Mock<IAccountService>();
        }

        [Test]
        public void statusOKforCreateAccount()
        {
            

            AccountCreationStatus statusObj = new AccountCreationStatus()
            {
                accountId = 105,
                message = "Savings and Current Accounts Created Successfully."
            };


            Task<AccountCreationStatus> accountCreationStatus = Task.FromResult(statusObj);
            
            

            var customerId = 3;
            mockService.Setup(s => s.createAccount(customerId)).Returns(accountCreationStatus);
            controller = new AccountsController(mockService.Object);
            var result = controller.createAccount(customerId);
            var okResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void statusBadRequestforCreateAccount()
        {
            var customerId = 0;
            controller = new AccountsController(mockService.Object);
            Task<IActionResult> result1 = controller.createAccount(customerId);
            Assert.IsInstanceOf<BadRequestObjectResult>(result1);
        }

        [Test]
        //[ExpectedException]
        public void StatusNoContentforCreateAccount()
        {
            var customerId = 9999;
            AccountCreationStatus accountCSObject = null;
            Task<AccountCreationStatus> accountCreationStatus = Task.FromResult(accountCSObject);

            mockService.Setup(s => s.createAccount(customerId)).Returns(accountCreationStatus);
            controller = new AccountsController(mockService.Object);
            Task<IActionResult> result1 = controller.createAccount(customerId);
            Assert.IsInstanceOf<NoContentResult>(result1);
        }
    }
}
*/