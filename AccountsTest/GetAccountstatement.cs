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
    public class GetAccountstatement
    {
        private Mock<IAccountService> mockService = new Mock<IAccountService>();
        private AccountsController controller;


        [Test]
        public async Task statusOKforGetAccountStatement()
        {
            int accountId = 101;
            DateTime fromDate = new DateTime(2017, 12, 12);
            DateTime toDate = new DateTime(2025, 12, 12);

            IEnumerable<Statement> statementList = new List<Statement>()
            {

                new Statement {AccountId=101, TransactionDate = new DateTime(2019, 12, 20), ChqOrRefno = "111", ValueDate = new DateTime(2025, 11, 12), Withdrawal = 0, Deposit = 0},
                new Statement {AccountId=101, TransactionDate = new DateTime(2020, 11, 14), ChqOrRefno = "222", ValueDate = new DateTime(2025, 11, 12), Withdrawal = 100, Deposit = 1000},

            };

            /*Task<IEnumerable<Statement>> statementList = Task.FromResult(statusListObj);*/

            mockService.Setup(e => e.getAccountStatement(accountId, fromDate, toDate)).ReturnsAsync(statementList);

            controller = new AccountsController(mockService.Object);

            var result = await controller.getAccountStatement(accountId, fromDate, toDate);

            Assert.IsInstanceOf<OkObjectResult>(result);

        }


        [Test]
        public async Task statusBadRequestforGetAccountStatement()
        {
            int accountId = 90;
            DateTime fromDate = new DateTime(2025, 12, 12);
            DateTime toDate = new DateTime(2025, 12, 12);

            controller = new AccountsController(mockService.Object);
            var result = await controller.getAccountStatement(accountId, fromDate, toDate);
            var finalResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(400, finalResult.StatusCode);
        }

        [Test]
        public async Task statusNoContentforGetAccountStatement()
        {
            int accountId = 101;
            DateTime fromDate = new DateTime(2017, 12, 12);
            DateTime toDate = new DateTime(2025, 12, 12);

            IEnumerable<Statement> statementList = null;
            /*Task<IEnumerable<Statement>> statementList = Task.FromResult(stateList);*/

            mockService.Setup(e => e.getAccountStatement(accountId, fromDate, toDate)).ReturnsAsync(statementList);
            controller = new AccountsController(mockService.Object);
            var result = await controller.getAccountStatement(accountId, fromDate, toDate);
            Assert.IsInstanceOf<NoContentResult>(result);


        }
    }
}
