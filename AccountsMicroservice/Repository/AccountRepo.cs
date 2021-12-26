using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountsMicroservice.Database;
using AccountsMicroservice.Models;
using log4net;
using System.IO;
//using Grpc.Core;

namespace AccountsMicroservice.Repository

{
    public class AccountRepo : IAccountRepo
    {

        List<Account> s_accountList = AccountsDB.s_accountList;
        List<TransactionStatus> s_transactionList = AccountsDB.s_transactionList;
        List<Statement> s_statementList = AccountsDB.s_statementList;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
      

        public async Task<AccountCreationStatus> createAccount(int customerId)
        {
            AccountCreationStatus acs = new AccountCreationStatus();

            Boolean customerAlreadyExists = false; // Boolean check to verify if customer already exists.   

            Account ac;

            foreach (var accDetails in s_accountList)
            {

                // Checking if customer already exists.
                // If customer exists, create additionally 2 accounts (Savings and Current) for the already existing customer.
                if (accDetails.CustomerId == customerId)
                {

                    log.Debug("createAccount() : Customer ID already exists. Creating additional 2 accounts for Customer ID : " + customerId);
                    ac = new Account();
                    //Savings Account Creation
                    var tempacclist = s_accountList.Where(a => a.CustomerId == customerId);
                    int lastid1 = tempacclist.Max(e => e.AccountId);
                    ac.CustomerId = customerId;
                    ac.AccountId = lastid1 + 1;
                    ac.Account_Type = "savings";
                    ac.AccountCreationDate = DateTime.Now;
                    ac.Balance_Amount = 1000;
                    /*ac.TotalAccountBalance = ac.Savings_Balance + ac.Current_Balance;*/

                    s_accountList.Add(ac);

                    Account ac1 = new Account();
                    //Current Account creation
                    var tempacclist2 = s_accountList.Where(a => a.CustomerId == customerId);
                    int lastid2 = tempacclist2.Max(e => e.AccountId);
                    ac1.CustomerId = customerId;
                    ac1.AccountId = lastid2 + 1;
                    ac1.Account_Type = "current";
                    ac1.AccountCreationDate = DateTime.Now;
                    ac1.Balance_Amount = 1000;
                    /*ac.TotalAccountBalance = ac.Savings_Balance + ac.Current_Balance;*/

                    s_accountList.Add(ac1);


                    // Logging done after fresh 2 accounts are created for existing customer.
                    log.Debug("createAccount() : Accounts successfully created for existing customer Id : "+customerId+" -> Savings Account ID : " + ac.AccountId + " and Current Account ID : " + ac1.AccountId);


                    // Account Creation Status getting updated.
                    log.Debug("createAccount(): Account Creation Status getting Updated. - Existing Customer.");
                    acs.Message = "Savings and Current Accounts Created Successfully.";
                    acs.AccountId = ac.AccountId;


                    customerAlreadyExists = true;
                    break;
                }
            }



            //Checking if customer already exists or not. If not, create fresh accounts for the NEW customer. 
            if (customerAlreadyExists != true)
            {

                log.Debug("createAccount() : New Customer. Creating fresh accounts for customer ID : "+customerId);

                //Savings Account Creation
                ac = new Account();               
                int lastid1 = s_accountList.Max(e => e.AccountId);
                ac.CustomerId = customerId;
                ac.AccountId = (customerId*10) + 1;
                ac.Account_Type = "savings";
                ac.AccountCreationDate = DateTime.Now;
                ac.Balance_Amount = 1000;
                

                s_accountList.Add(ac);

                Account ac1 = new Account();
               //Current Account creation
                int lastid2 = s_accountList.Max(e => e.AccountId);
                ac1.CustomerId = customerId;
                ac1.AccountId = (customerId*10) + 2;
                ac1.Account_Type = "current";
                ac1.AccountCreationDate = DateTime.Now;
                ac1.Balance_Amount = 1000;
                

                s_accountList.Add(ac1);

                // Logging after new fresh accounts are created for the new customer. 
                log.Debug("createAccount() : Accounts successfully created for new customer Id : " + customerId + " -> Savings Account ID : " + ac.AccountId + " and Current Account ID : " + ac1.AccountId);

                //Create AccountCreationStatus Object here. 
                log.Debug("createAccount(): Account Creation Status getting Updated. - New Customer.");
                acs.Message = "Account Created Successfully.";
                acs.AccountId = ac.AccountId;

            }

            return acs;
        }





        // Get Account Details using accountId.
        public async Task<Account> getAccountById(int accountId)
        {
            Account ac = new Account();
            ac = s_accountList.Find(e => e.AccountId == accountId);

            if(ac != null)
            {
                // Logging if account with accountID found.
                log.Debug("getAccountById() : Account ID Found.");
            }
            else if(ac == null)
            {
                // Logging if account with accountID not found.
                log.Debug("getAccountById() : Account ID not found.");
                ac = null;
            }

            return ac;
        }




        // Get Account Statements using accountID, fromDate and toDate.
        public async Task<IEnumerable<Statement>> getAccountStatement(int accountId, DateTime fromDate, DateTime toDate)
        {
            string fromDateString = Convert.ToString(fromDate);
            string toDateString = Convert.ToString(toDate);

            Statement st = new Statement();

            Boolean periodsMatch = false; // To check if statement exists within the mentioned time period.
            Boolean statementsfetchedwithinPeriods = false;

            List<Statement> statementsToBeDisplayed = new List<Statement>(); // To store the list of account Statements.

            List<Statement> findLastMonth = new List<Statement>(); // To find the latest month of the accountId. 

            // Check if account with AccountId and if transactionDate falls into the time period mentioned.
            // If exists, return all the account statements with that respective account Id.
            foreach(var statement in s_statementList)
            {
                if(statement.AccountId == accountId && statement.TransactionDate >= fromDate && statement.TransactionDate <= toDate)
                {
                    statementsToBeDisplayed.Add(statement);
                    periodsMatch = true;  // Records identified. Therefore, setting it to true.
                    statementsfetchedwithinPeriods = true;
                }
            }

            //Logging when statements are fetched within time period.
            if(statementsfetchedwithinPeriods == true)
            {
                log.Debug("getAccountStatement(): Statements fetched successfully within mentioned time frame.");
            }

            // If time frame is not mentioned. If the fields are left empty.
            // In that case, list out all the statements of the latest month of that respective AccountId.
            if(fromDateString == "01-01-0001 00:00:00" && toDateString == "01-01-0001 00:00:00")           
            {

                periodsMatch = true;   // Need not worry about time frame here.  So setting it to true. 

                
                // List out all statements of that respective accountId.
                foreach (var statements in s_statementList)
                {
                    if (statements.AccountId == accountId)
                    {
                        findLastMonth.Add(statements);
                    }
                }


                //From that list, find out the date of the most recent statement. 
                DateTime latestDate = findLastMonth.Max(e => e.TransactionDate);

                //Logging when time periods are left empty, returning the most recent month's statements.
                log.Debug("getAccountStatement(): Fetching statements of the most recent month - Dates were not specified.");

                // If the time periods are left empty, list out the latest month's statements.
                foreach (var statement in findLastMonth)
                {
                    if (statement.TransactionDate.Month == latestDate.Month && statement.TransactionDate.Year == latestDate.Year)
                    {
                        statementsToBeDisplayed.Add(statement);
                    }
                }
            }



            //If periods do not match and if no statements exist within the mentioned time frame, throw null reference exception.
            if (periodsMatch == false)
            {
                log.Debug("getAccountStatement() : No statements found within mentioned Time Frame");
                return null;
            }


            
            return statementsToBeDisplayed;
 
            
        }







        // Get Customer Accounts using customer Id.
        public async Task<IEnumerable<Account>> getCustomerAccounts(int customerId)
        {           
            List<Account> customerList = new List<Account>();

            foreach (var account in s_accountList)
            {
                if (account.CustomerId == customerId)
                {
                    customerList.Add(account);
                }
            }

            if(customerList == null)
            {
                // Logging when customers are not found.
                log.Debug("getCustomerAccounts() : No customers found.");
                return null;
            }
            

            // Logging when customer accounts are fetched successfully. 
            log.Debug("getCustomerAccounts() : Customer accounts fetched successfully.");
            return customerList;

        }



        // Deposit amount into account using accountId and amount.
        public async Task<TransactionStatus> deposit(int accountId, double amount) 
        {
            TransactionStatus ts = new TransactionStatus() ;

            Account ac = new Account() ;
            ac = await s_accountList.FindAsync(e => e.AccountId == accountId);


            if(ac != null)
            {

                log.Debug("deposit() : Account Id Found.");
                ac.Balance_Amount += amount;

                // Transaction List Updating
                ts.AccountId = accountId;
                ts.Source_Balance = ac.Balance_Amount;
                ts.Destination_Balance = -1;
                ts.Message = "Transaction Details : Rs." + amount + " deposited into AccountID : " + ts.AccountId;


                //Bank Statement Updating. 
                Statement st = new Statement();
                st.AccountId = accountId;
                st.TransactionDate = DateTime.Now;
                st.Deposit = amount;
                st.Withdrawal = 0;
                st.ChqOrRefno = "CHQ00123";
                st.ValueDate = new DateTime(2025, 10, 10);
                st.ClosingBalance = ac.Balance_Amount;


                // Logging done to check if amount has been successfully deposited. 
                log.Debug("deposit(): Amount Rs."+ amount + " Sucessfully deposited into Account ID : "+accountId);
                

                // Statement List getting Updated.
                s_statementList.Add(st);
                log.Debug("deposit(): Statment list updated");

                // Transaction List getting updated.
                s_transactionList.Add(ts);
                log.Debug("deposit(): Transaction list updated");
            }
            

            else if(ac == null)
            {
                log.Debug("deposit() : Account ID not found. Provide Valid Account Id.");
                ts = null;
            }


            return ts;

        }



        // Withdraw from account using accountId and amount.
        public async Task<TransactionStatus> withdraw(int accountId, double amount)
        {
            TransactionStatus ts = new TransactionStatus();

            Account ac = new Account();
            ac = s_accountList.Find(e => e.AccountId == accountId);
            if(ac != null)
            {
                log.Debug("withdraw() : Account Id Found.");
                ac.Balance_Amount -= amount;

                // Transaction List Updating
                ts.AccountId = accountId;
                ts.Source_Balance = ac.Balance_Amount;
                ts.Destination_Balance = -1;
                ts.Message = "Transaction Details : Rs." + amount + " withdrawn from AccountID : " + ts.AccountId;

                //Bank Statement Updating. 
                Statement st = new Statement();
                st.AccountId = accountId;
                st.TransactionDate = DateTime.Now;
                st.Deposit = 0;
                st.Withdrawal = amount;
                st.ChqOrRefno = "CHQ00123";
                st.ValueDate = new DateTime(2025, 10, 10);
                st.ClosingBalance = ac.Balance_Amount;


                log.Debug("withdraw(): Amount Rs." + amount + " Sucessfully withdrawn from Account ID : " + accountId);

                // Statement List getting Updated.
                s_statementList.Add(st);
                log.Debug("withdraw(): Statment list updated");

                // Transaction List getting updated.
                s_transactionList.Add(ts);
                log.Debug("withdraw(): Transaction list updated");
            }
            

            else if(ac == null)
            {
                log.Debug("withdraw() : Account ID not found. Provide Valid Account Id.");
                ts = null;
            }


            return ts;
        }



        // Transfer from and to account using accountId
        public async Task<TransactionStatus> transfer(int fromAccountId, int toAccountId, double amount)
        {
            TransactionStatus ts = new TransactionStatus();

            Account ac; // Source account object.
            ac = s_accountList.Find(e => e.AccountId == fromAccountId);

            Account ac1; // Destination account object.
            ac1 = s_accountList.Find(e => e.AccountId == toAccountId);

            if(ac != null && ac1 != null)
            {
                log.Debug("transfer() : Source and Destination Account Ids Found.");
                ac.Balance_Amount -= amount;    // Amount withdrawn from source account.
                ac1.Balance_Amount += amount;   // Amount deposited into destination account.


                // Transaction object getting updated.
                ts.AccountId = fromAccountId;
                ts.Source_Balance = ac.Balance_Amount;
                ts.Destination_Balance = ac1.Balance_Amount;
                ts.Message = "Transaction Details : Amount Transferred from " + fromAccountId + " to " + toAccountId;


                //Bank Statement Updating. 
                Statement st = new Statement();
                st.AccountId = fromAccountId;
                st.TransactionDate = DateTime.Now;
                st.Deposit = 0;
                st.Withdrawal = amount;
                st.ChqOrRefno = "CHQ00123";
                st.ValueDate = new DateTime(2025, 10, 10);
                st.ClosingBalance = ac.Balance_Amount;

                s_statementList.Add(st);


                //Bank Statement Updating. 
                Statement st1 = new Statement();
                st1.AccountId = toAccountId;
                st1.TransactionDate = DateTime.Now;
                st1.Deposit = amount;
                st1.Withdrawal = 0;
                st1.ChqOrRefno = "CHQ00124";
                st1.ValueDate = new DateTime(2025, 10, 10);
                st1.ClosingBalance = ac1.Balance_Amount;


                // Logging to show that transaction has taken place from source account to destination account.
                log.Debug("transfer(): Amount Rs." + amount + " Sucessfully withdrawn from Source Account ID : " + fromAccountId);
                log.Debug("transfer(): Amount Rs." + amount + " Sucessfully deposited into Destination Account ID : " + toAccountId);


                // Statement list getting updated.
                s_statementList.Add(st1);
                log.Debug("transfer(): Statment list updated");


                // Transaction List getting updated.
                s_transactionList.Add(ts);
                log.Debug("transfer(): Transaction list updated");

            }


            if(ac == null || ac1 == null)
            {
                log.Debug("transfer() : Account ID not found. Provide Valid Account Id.");
                ts = null;
            }
            

            return ts;
        }
    }
}
