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
    public class GetAccountstatement
    {
        private Mock<IAccountService> mockService = new Mock<IAccountService>();
        private AccountsController controller;

        public void statusOKforGetAccountStatement()
        {
            int accountId = 101;
            DateTime fromDate = new DateTime(2017, 12, 12);
            DateTime toDate = new DateTime(2025, 12, 12);

            IEnumerable<Statement> statusListObj = new List<Statement>()
            {

                new Statement {accountId=101, transactionDate = new DateTime(2019, 12, 20), chqOrRefno = "111", valueDate = new DateTime(2025, 11, 12), withdrawal = 0, deposit = 0},
                new Statement {accountId=101, transactionDate = new DateTime(2020, 11, 14), chqOrRefno = "222", valueDate = new DateTime(2025, 11, 12), withdrawal = 100, deposit = 1000},

            };

            Task<IEnumerable<Statement>> statementList = Task.FromResult(statusListObj);

            mockService.Setup(e => e.getAccountStatement(accountId, fromDate, toDate)).Returns(statementList);

            controller = new AccountsController(mockService.Object);

            var result = controller.getAccountStatement(accountId, fromDate, toDate);

            var finalResult = (IStatusCodeActionResult)result;

            Assert.AreEqual(200, finalResult.StatusCode);

        }



        public void statusBadRequestforGetAccountStatement()
        {
            int accountId = 90;
            DateTime fromDate = new DateTime(2025 , 12 , 12);
            DateTime toDate = new DateTime(2025, 12, 12);

            controller = new AccountsController(mockService.Object);
            var result = controller.getAccountStatement(accountId, fromDate, toDate);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }


        public void statusNoContentforGetAccountStatement()
        {
            int accountId = 101;
            DateTime fromDate = new DateTime(2017, 12, 12);
            DateTime toDate = new DateTime(2025, 12, 12);

            IEnumerable<Statement> stateList = null;
            Task<IEnumerable<Statement>> statementList = Task.FromResult(stateList);

            mockService.Setup(e => e.getAccountStatement(accountId, fromDate, toDate)).Returns(statementList);
            controller = new AccountsController(mockService.Object);
            var result = controller.getAccountStatement(accountId, fromDate, toDate);
            var finalResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(204, finalResult.StatusCode); 


        }
    }
}
*/