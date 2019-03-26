using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class DepositAccount:Account
    {
        public DepositAccount(decimal sum, int percentage):base(sum,percentage)
        {

        }
        protected internal override void Open()
        {
            base.OnOpened(new AccounEventArgs("Открыт новый депозитный счет!Id счета: " + this._id, this._sum));
        }
        public override decimal Withdraw(decimal sum)
        {
            if (_days % 30 == 0)
                return base.Withdraw(sum);
            else
                base.OnWithdrawed(new AccounEventArgs("Вывести средства можно только после 30-ти дневного периода", 0));
            return 0;
        }
        protected internal override void Calculate()
        {
            if (_days % 30 == 0)
                base.Calculate();
        }
    }
}
