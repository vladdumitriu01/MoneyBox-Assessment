# MoneyBox-Assessment
Time frame for the task:

9:30am 08/06/2019 : Download the project 9:36am 08/06/2019 : Understanding the task 9:52am 08/06/2019 : Finishing the code 9:55am 08/06/2019 : Realizing that I can't change the notification system due to the rules stated on github ( more comments about this down below ) 10:20am 08/06/2019 : Uploading the code on gitHub

All the code have comments on what I understood about it and how I would implement it, considering the model of the transaction, where the user has to be informed if he has less than 500m in his account, or that should receive an error if he doesn't have the right amount.

One thing that I suggest on that model, is adding another notification system:

void NotifyWithdraw(string email address);

and everytime when the function Execute is running to use and to send the information to the user that the "X" amount was withdrawn from his account to avoid fraud.

this.notificationService.NotifyWithdraw(fromAccount.User.Email);

Hopefully is something that you are looking for, if not it's possible that I haven't understood the task corectly, because it is quite simple, considering that I have the model as well from transferMoney.cs
