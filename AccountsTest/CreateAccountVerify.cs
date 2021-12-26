using System;
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

namespace AccountsTest
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
        public async Task statusOKforCreateAccount()
        {


            AccountCreationStatus statusObj = new AccountCreationStatus()
            {
                AccountId = 105,
                Message = "Savings and Current Accounts Created Successfully."
            };


            



            int customerId = 3;
            mockService.Setup(s => s.createAccount(customerId)).ReturnsAsync(statusObj);
            controller = new AccountsController(mockService.Object);
            var result = await controller.createAccount(customerId);
            var okResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task statusBadRequestforCreateAccount()
        {
            int customerId = 0;
            controller = new AccountsController(mockService.Object);
            var result = await controller.createAccount(customerId);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        //[ExpectedException]
        public async Task StatusNoContentforCreateAccount()
        {
            var customerId = 9999;
            AccountCreationStatus accountCreationStatus = null;
            /*Task<AccountCreationStatus> accountCreationStatus = Task.FromResult(accountCSObject);*/

            mockService.Setup(s => s.createAccount(customerId)).ReturnsAsync(accountCreationStatus);
            controller = new AccountsController(mockService.Object);
            var result = await controller.createAccount(customerId);
            Assert.IsInstanceOf<NoContentResult>(result);
        }
    }
}
