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
    public class GetCustomerAccounts
    {
        private Mock<IAccountService> mockService = new Mock<IAccountService>();
        private AccountsController controller;

        public void statusOkforGetCustomerAccounts()
        {
            int customerId = 1;

            IEnumerable<Account> accountsListObj = new List<Account>()
            {
                new Account { accountId = 101, customerId = 1, account_Type = "savings", accountCreationDate = new DateTime(2021, 6, 27), balance_Amount = 1000 },
                new Account { accountId = 102, customerId = 1, account_Type = "current", accountCreationDate = new DateTime(2021, 6, 27), balance_Amount = 1000 },
            };

            Task<IEnumerable<Account>> accountsList = Task.FromResult(accountsListObj);

            mockService.Setup(e => e.getCustomerAccounts(customerId)).Returns(accountsList);
            controller = new AccountsController(mockService.Object);
            var result = controller.getCustomerAccounts(customerId);
            var finalResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, finalResult.StatusCode);


        }


        public void statusBadRequestforGetCustomerAccounts()
        {
            int customerId = 0;

            controller = new AccountsController(mockService.Object);
            var result = controller.getCustomerAccounts(customerId);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }



        public void statusNoContentforGetCustomerAccount()
        {
            int customerId = 1;

            IEnumerable<Account> customer = null;

            Task<IEnumerable<Account>> accountsList = Task.FromResult(customer);

            mockService.Setup(e => e.getCustomerAccounts(customerId)).Returns(accountsList);

            controller = new AccountsController(mockService.Object);

            var result = controller.getCustomerAccounts(customerId);

            var finalResult = (IStatusCodeActionResult)result;

            Assert.AreEqual(204, finalResult.StatusCode);


        }

    }
}
*/