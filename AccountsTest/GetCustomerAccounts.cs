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
    public class GetCustomerAccounts
    {
        private Mock<IAccountService> mockService = new Mock<IAccountService>();
        private AccountsController controller;


        [Test]
        public async Task statusOkforGetCustomerAccounts()
        {
            int customerId = 1;

            IEnumerable<Account> accountsList = new List<Account>()
            {
                new Account { AccountId = 101, CustomerId = 1, Account_Type = "savings", AccountCreationDate = new DateTime(2021, 6, 27), Balance_Amount = 1000 },
                new Account { AccountId = 102, CustomerId = 1, Account_Type = "current", AccountCreationDate = new DateTime(2021, 6, 27), Balance_Amount = 1000 },
            };

            /*Task<IEnumerable<Account>> accountsList = Task.FromResult(accountsListObj);*/

            mockService.Setup(e => e.getCustomerAccounts(customerId)).ReturnsAsync(accountsList);
            controller = new AccountsController(mockService.Object);
            var result = await controller.getCustomerAccounts(customerId);
            Assert.IsInstanceOf<OkObjectResult>(result);


        }

        [Test]
        public async Task statusBadRequestforGetCustomerAccounts()
        {
            int customerId = -1;
            controller = new AccountsController(mockService.Object);
            var result = await controller.getCustomerAccounts(customerId);
            var finalResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(400, finalResult.StatusCode);
        }


        [Test]
        public async Task statusNoContentforGetCustomerAccount()
        {
            int customerId = 1;

            IEnumerable<Account> accountslist = null;

            /*Task<IEnumerable<Account>> accountsList = Task.FromResult(customer);*/

            mockService.Setup(e => e.getCustomerAccounts(customerId)).ReturnsAsync(accountslist); ;

            controller = new AccountsController(mockService.Object);

            var result = await controller.getCustomerAccounts(customerId);

            Assert.IsInstanceOf<NoContentResult>(result);


        }

    }
}
