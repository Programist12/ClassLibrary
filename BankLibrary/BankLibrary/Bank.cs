using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
  public  class Bank<T>where T:Account
    {
        T[] accounts;

        public string Name { get; private set; }

        public Bank(string name)
        {
           this.Name = name;
        }
       
        //метод создания счета
        public void Open(AccountType accountType,decimal sum,AccountStateHandler addSumHandler,AccountStateHandler withdrawSumHandler,AccountStateHandler calculationHandler,AccountStateHandler closeAccountHandler,AccountStateHandler openAccountHandler)
        {
            T newAccount = null;

            switch (accountType)
            {
                case AccountType.Ordinary:
                    newAccount = new DemandAccount(sum, 1) as T;
                    break;
                case AccountType.Deposit:
                    newAccount = new DepositAccount(sum, 40) as T;
                    break;
            }
            if (newAccount == null)
                throw new Exception("Ошибка создания счета");
            //Добавляем новый счет в массив счетов
            if (accounts == null)
                accounts = new T[] { newAccount};
            else
            {
                T[] tempAccounts = new T[accounts.Length + 1];
                for (int i = 0; i < accounts.Length; i++)
                {
                    tempAccounts[i] = accounts[i];
                    tempAccounts[tempAccounts.Length - 1] = newAccount;
                    accounts = tempAccounts;
                }
            }
            //установка обработчиков событий счета
            newAccount.Added += addSumHandler;
            newAccount.Withdrawed += withdrawSumHandler;
            newAccount.Closed += closeAccountHandler;
            newAccount.Opened += openAccountHandler;
            newAccount.Calculated += calculationHandler;


            newAccount.Open();
        }
        

            public T FindAccount(int id)
        {
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].Id == id)
                    return accounts[i];
            }
            return null;
        }

        public T FindAccount(int id, out int index)//перегруженая версия поиска счета
        {
            for (int i = 0; i <accounts.Length; i++)
            {
                if (accounts[i].Id==id)
                {
                    index = i;
                    return accounts[i];
                }

            }
            index = -1;
            return null;
        }

        public void Put(decimal sum,int id)//добавление средств на счет
        {
            T account = FindAccount(id);
            if (account == null)
                throw new Exception("Счет не найден");
            account.Put(sum);
        }

        public void Withdraw(decimal sum,int id)//снятие со счета
        {
            T account = FindAccount(id);
            if (account == null)
                throw new Exception("Счет не найден");
            account.Withdraw(sum);
        }

        public void Close(int id)
        {
            int index;
            T account = FindAccount(id, out index);
            if (account == null)
                throw new Exception("Счет не найден");
                    account.Close();
            if (accounts.Length <= 1)
                accounts = null;
            else
            {
                //Уменьшаем массив счетов, удаляя из него закрытый счет
                T[] tempAccounts = new T[accounts.Length - 1];
                for (int i = 0,j=0; i < accounts.Length; i++)
                {
                    if (i != index)
                        tempAccounts[j++] = accounts[i];
                }
                accounts = tempAccounts;
            }
        }
        
        public void CalculatePercentage()//Начисление процентов по счетам
        {
            if (accounts == null)
                return;
            for (int i = 0; i < accounts.Length; i++)
            {
                T account = accounts[i];
                account.Calculate();
            }
        }
        
    }
        

    public enum AccountType
            {
                Ordinary, Deposit

            }

}
