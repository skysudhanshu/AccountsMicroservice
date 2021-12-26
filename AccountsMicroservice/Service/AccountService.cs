using AccountsMicroservice.Models;
using AccountsMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsMicroservice.Service
{
    public class AccountService : IAccountService
    {

        private IAccountRepo accountRepo;

        public AccountService(IAccountRepo accountRepository)
        {
            accountRepo = accountRepository;
        }


        public async Task<AccountCreationStatus> createAccount(int customerId)
        {
            return await accountRepo.createAccount(customerId);
        }

        public async Task<TransactionStatus> deposit(int accountId, double amount)
        {
            return await accountRepo.deposit(accountId, amount);
        }

        public async Task<Account> getAccountById(int accountId)
        {
            return await accountRepo.getAccountById(accountId);
        }

        public async Task<IEnumerable<Statement>> getAccountStatement(int accountId, DateTime fromDate, DateTime toDate)
        {
            return await accountRepo.getAccountStatement(accountId, fromDate, toDate);
        }

        public async Task<IEnumerable<Account>> getCustomerAccounts(int customerId)
        {
            return await accountRepo.getCustomerAccounts(customerId);
        }

        public async Task<TransactionStatus> withdraw(int accountId, double amount)
        {
            return await accountRepo.withdraw(accountId, amount);
        }


        public async Task<TransactionStatus> transfer(int fromAccountId, int toAccountId, double amount)
        {
            return await accountRepo.transfer(fromAccountId, toAccountId, amount);
        }


    }
}
