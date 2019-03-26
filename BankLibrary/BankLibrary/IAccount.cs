using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public interface IAccount
    {
       //интерфейс который отвечает за функцианальность банковского счета
        
            //положить деньги на счет
            void Put(decimal sum);
            //взять со счета
            decimal Withdraw(decimal sum);
        

    }
}

