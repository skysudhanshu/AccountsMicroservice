using AccountsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsMicroservice.Service
{
    public interface IAccountService
    {

        Task<AccountCreationStatus> createAccount(int CustomerId); //POST Method.
       
        Task<IEnumerable<Account>> getCustomerAccounts(int CustomerId); //GET Method. 
       
        Task<IEnumerable<Statement>> getAccountStatement(int AccountId, DateTime fromDate, DateTime toDate);
        
        Task<Account> getAccountById(int AccountId);
        
        Task<TransactionStatus> deposit(int AccountId, double amount);
    
        Task<TransactionStatus> withdraw(int AccountId, double amount);

        Task<TransactionStatus> transfer(int fromAccountId, int toAccountId, double amount);

    
    }
}
