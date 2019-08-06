using Moneybox.App.DataAccess;
using Moneybox.App.Domain.Services;
using System;

namespace Moneybox.App.Features
{
    public class WithdrawMoney
    {
        private IAccountRepository accountRepository;
        private INotificationService notificationService;

        public WithdrawMoney(IAccountRepository accountRepository, INotificationService notificationService)
        {
            this.accountRepository = accountRepository;
            this.notificationService = notificationService;
        }

        public void Execute(Guid fromAccountId, decimal amount)
        {
            var fromAccount = this.accountRepository.GetAccountById(fromAccountId); //creating a variable for the account that we want to withdraw money from
            var withdrawBalance = fromAccount.Balance - amount; //variable that makes the difference between the amount that is inside of the account and the withdraw amount

            if (withdrawBalance < 0m) //if the account doesn't have enough money, give error message
            {
                throw new InvalidOperationException("Insufficient funds to withdraw this amount");
            }
            if(withdrawBalance < 500m) //if the account remains with a value of  <500m  , notify the user that he has very low funds on the email
            {
                this.notificationService.NotifyFundsLow(fromAccount.User.Email);
            }

            fromAccount.Balance = fromAccount.Balance - amount;
            fromAccount.Withdrawn = fromAccount.Withdrawn - amount;  //extract the money from the account, the user now should have the cash with him

            this.accountRepository.Update(fromAccount); //update the user details
        }
    }
}
