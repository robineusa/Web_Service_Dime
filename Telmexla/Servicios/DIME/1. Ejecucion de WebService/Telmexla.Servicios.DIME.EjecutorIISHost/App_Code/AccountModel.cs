
using System.Collections.Generic;


public class AccountModel
{

    private static List<Account> listAccounts = new List<Account>();
    public AccountModel()
    {
        Account account = new Account();
        account.Username = "acc1";
        account.Password = "123";
        listAccounts.Add(account);
        account = new Account();
        account.Username = "acc2";
        account.Password = "123";
        listAccounts.Add(account);
        account.Username = "acc3";
        account.Password = "123";
        listAccounts.Add(account);
    }

    public bool login(string username, string password)
    {
        foreach (Account item in listAccounts)
        {
            if (item.Username.Equals(username) && item.Password.Equals(password))
            {
                return true;
            }
        }
        return false;
    }

}
