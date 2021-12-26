using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountsMicroservice.Models;




namespace AccountsMicroservice.Repository

{
    public interface IAccountRepo
    {
        public Task<AccountCreationStatus> createAccount(int customerId); //POST Method.

        public Task<IEnumerable<Account>> getCustomerAccounts(int customerId); //GET Method. 

        public Task<Account> getAccountById(int accountId);

        public Task<IEnumerable<Statement>> getAccountStatement(int accountId, DateTime fromDate, DateTime toDate);

        public Task<TransactionStatus> deposit(int accountId, double amount);

        public Task<TransactionStatus> withdraw(int accountId, double amount);


        public Task<TransactionStatus> transfer(int fromAccountId, int toAccountId, double amount);

    }
}
