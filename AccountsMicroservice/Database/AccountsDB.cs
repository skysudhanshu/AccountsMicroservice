using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountsMicroservice.Models;

namespace AccountsMicroservice.Database
{
    public class AccountsDB
    {
        public static List<Account> s_accountList = new List<Account>()
        {
           
            new Account {AccountId=1011, CustomerId=101, Account_Type = "savings", AccountCreationDate = new DateTime(2021, 6, 27), Balance_Amount = 1000},
            new Account {AccountId=1012, CustomerId=101, Account_Type = "current", AccountCreationDate = new DateTime(2021, 6, 27), Balance_Amount = 1000},
            new Account {AccountId=1021, CustomerId=102, Account_Type = "savings", AccountCreationDate = new DateTime(2021, 6, 27), Balance_Amount = 1000},
            new Account {AccountId=1022, CustomerId=102, Account_Type = "current", AccountCreationDate = new DateTime(2021, 6, 27), Balance_Amount = 1000},
            new Account {AccountId=1031, CustomerId=103, Account_Type = "savings", AccountCreationDate = new DateTime(2021, 6, 27), Balance_Amount = 1000},
            new Account {AccountId=1032, CustomerId=103, Account_Type = "current", AccountCreationDate = new DateTime(2021, 6, 27), Balance_Amount = 1000},
            new Account {AccountId=1041, CustomerId=104, Account_Type = "savings", AccountCreationDate = new DateTime(2021, 6, 27), Balance_Amount = 1000},
            new Account {AccountId=1042, CustomerId=104, Account_Type = "current", AccountCreationDate = new DateTime(2021, 6, 27), Balance_Amount = 1000},
            new Account {AccountId=1051, CustomerId=105, Account_Type = "savings", AccountCreationDate = new DateTime(2021, 6, 27), Balance_Amount = 1000},
            new Account {AccountId=1052, CustomerId=105, Account_Type = "current", AccountCreationDate = new DateTime(2021, 6, 27), Balance_Amount = 1000},
            new Account {AccountId=9911, CustomerId=991, Account_Type = "savings", AccountCreationDate = new DateTime(2021, 6, 27), Balance_Amount = 5000},
            new Account {AccountId=9912, CustomerId=991, Account_Type = "current", AccountCreationDate = new DateTime(2021, 6, 27), Balance_Amount = 5000},
            new Account {AccountId=9921, CustomerId=992, Account_Type = "savings", AccountCreationDate = new DateTime(2021, 6, 27), Balance_Amount = 5000},
            new Account {AccountId=9922, CustomerId=992, Account_Type = "current", AccountCreationDate = new DateTime(2021, 6, 27), Balance_Amount = 5000},

        };



        public static List<Statement> s_statementList = new List<Statement>()
        {

            new Statement {AccountId=1011, TransactionDate = new DateTime(2019, 12, 20), ChqOrRefno = "111", ValueDate = new DateTime(2025, 11, 12), Withdrawal = 100, Deposit = 5000},
            new Statement {AccountId=1012, TransactionDate = new DateTime(2020, 11, 14), ChqOrRefno = "222", ValueDate = new DateTime(2025, 11, 12), Withdrawal = 100, Deposit = 1000},
            new Statement {AccountId=1021, TransactionDate = new DateTime(2018, 10, 24), ChqOrRefno = "333", ValueDate = new DateTime(2025, 11, 12), Withdrawal = 20, Deposit = 100},
            new Statement {AccountId=1022, TransactionDate = new DateTime(2020, 4, 11), ChqOrRefno = "444", ValueDate = new DateTime(2025, 11, 12), Withdrawal = 100, Deposit = 500},
            new Statement {AccountId=1031, TransactionDate = new DateTime(2021, 6, 17), ChqOrRefno = "555", ValueDate = new DateTime(2025, 11, 12), Withdrawal = 200, Deposit = 900},
            new Statement {AccountId=1032, TransactionDate = new DateTime(2021, 6, 17), ChqOrRefno = "555", ValueDate = new DateTime(2025, 11, 12), Withdrawal = 200, Deposit = 900},
            new Statement {AccountId=1041, TransactionDate = new DateTime(2021, 6, 17), ChqOrRefno = "555", ValueDate = new DateTime(2025, 11, 12), Withdrawal = 200, Deposit = 900},
            new Statement {AccountId=1042, TransactionDate = new DateTime(2021, 6, 17), ChqOrRefno = "555", ValueDate = new DateTime(2025, 11, 12), Withdrawal = 200, Deposit = 900},
            new Statement {AccountId=1051, TransactionDate = new DateTime(2021, 6, 17), ChqOrRefno = "555", ValueDate = new DateTime(2025, 11, 12), Withdrawal = 200, Deposit = 900},
            new Statement {AccountId=1052, TransactionDate = new DateTime(2021, 6, 17), ChqOrRefno = "555", ValueDate = new DateTime(2025, 11, 12), Withdrawal = 200, Deposit = 900},
            new Statement {AccountId=9911, TransactionDate = new DateTime(2021, 6, 17), ChqOrRefno = "555", ValueDate = new DateTime(2025, 11, 12), Withdrawal = 200, Deposit = 900},
            new Statement {AccountId=9912, TransactionDate = new DateTime(2021, 6, 17), ChqOrRefno = "555", ValueDate = new DateTime(2025, 11, 12), Withdrawal = 200, Deposit = 900},
            new Statement {AccountId=9921, TransactionDate = new DateTime(2021, 6, 17), ChqOrRefno = "555", ValueDate = new DateTime(2025, 11, 12), Withdrawal = 200, Deposit = 900},
            new Statement {AccountId=9922, TransactionDate = new DateTime(2021, 6, 17), ChqOrRefno = "555", ValueDate = new DateTime(2025, 11, 12), Withdrawal = 200, Deposit = 900},


        };
       






        public static List<TransactionStatus> s_transactionList = new List<TransactionStatus>()
        {


            new TransactionStatus {AccountId = 1011, Message = "", Source_Balance = 1000, Destination_Balance = 1000 },
            new TransactionStatus {AccountId = 1012, Message = "", Source_Balance = 1000, Destination_Balance = 1000 },
            new TransactionStatus {AccountId = 1021, Message = "", Source_Balance = 1000, Destination_Balance = 1000 },
            new TransactionStatus {AccountId = 1022, Message = "", Source_Balance = 1000, Destination_Balance = 1000 },
            new TransactionStatus {AccountId = 1031, Message = "", Source_Balance = 1000, Destination_Balance = 1000 },
            new TransactionStatus {AccountId = 1032, Message = "", Source_Balance = 1000, Destination_Balance = 1000 },
            new TransactionStatus {AccountId = 1041, Message = "", Source_Balance = 1000, Destination_Balance = 1000 },
            new TransactionStatus {AccountId = 1042, Message = "", Source_Balance = 1000, Destination_Balance = 1000 },
            new TransactionStatus {AccountId = 1051, Message = "", Source_Balance = 1000, Destination_Balance = 1000 },
            new TransactionStatus {AccountId = 1052, Message = "", Source_Balance = 1000, Destination_Balance = 1000 },
            new TransactionStatus {AccountId = 9911, Message = "", Source_Balance = 1000, Destination_Balance = 1000 },
            new TransactionStatus {AccountId = 9912, Message = "", Source_Balance = 1000, Destination_Balance = 1000 },
            new TransactionStatus {AccountId = 9921, Message = "", Source_Balance = 1000, Destination_Balance = 1000 },
            new TransactionStatus {AccountId = 9922, Message = "", Source_Balance = 1000, Destination_Balance = 1000 },


        };
    }
}
