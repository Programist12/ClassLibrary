using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public abstract class Account : IAccount
    {
        //событие, возникающее при выводе денег
        protected internal event AccountStateHandler Withdrawed;

        //событие возникающее при добавлении на счет
        protected internal event AccountStateHandler Added;

        //событие возникающее при открытие счета
        protected internal event AccountStateHandler Opened;

        //событие возникающее при закрытии счета
        protected internal event AccountStateHandler Closed;

        //событие возникающее при начислении процентов
        protected internal event AccountStateHandler Calculated;

        protected int _id;
        static int counter = 0;

        protected decimal _sum;//переменная для хранения суммы
        protected int _percentage;//переменная для хранения процента

        protected int _days = 0;//время с момента открытия счета

        public Account(decimal sum, int percentage)
        {
            _sum = sum;
            _percentage = percentage;
            _id = ++counter;
        }

        //текущая сумма на счету
        public decimal CurrentSum
        {
            get { return _sum; }
        }

        public int Percentage
        {
            get { return _percentage; }
        }

        public int Id
        {
            get { return _id; }
        }

        //вызов событий

        private void CallEvent(AccounEventArgs e,AccountStateHandler handler)
        {
            if(handler !=null && e!=null)
                handler(this, e);
        }
        //вызов отдельных событий

        protected virtual void OnOpened(AccounEventArgs e)
        {
            CallEvent(e, Opened);
        }
        protected virtual void OnWithdrawed(AccounEventArgs e)
        {
            CallEvent(e, Withdrawed);
        }
        protected virtual void OnAdded(AccounEventArgs e)
        {
            CallEvent(e, Added);

        }
        protected virtual void OnClosed(AccounEventArgs e)
        {
            CallEvent(e, Closed);
        }
        protected virtual void OnCalculated(AccounEventArgs e)
        {
            CallEvent(e, Calculated);

        }
         
        public virtual void Put(decimal sum)
        {
            _sum += sum;
            OnAdded(new AccounEventArgs("На счет поступило:"+sum,sum));
        }
        public virtual decimal Withdraw (decimal sum)
        {
            decimal result = 0;
            if (sum <= _sum)
            {
                _sum -= sum;
                result = sum;
                OnWithdrawed(new AccounEventArgs("Сумма" + sum + "Снята со счета" + _id, sum));

            }
            else
            {
                OnWithdrawed(new AccounEventArgs("Недостаточно денег на счете" + _id, 0));
            }
            return result;
        }
        //открытие счета
        protected internal virtual void Open()
        {
            OnOpened(new AccounEventArgs("Открыто новый депозитный счет!Id счета:"+this._id, this._sum));
        }
        //Закрытие счета
        protected internal virtual void Close()
        {
            OnClosed(new AccounEventArgs("Счет" + _id + "закрыт. Итоговая сумма:" + CurrentSum, CurrentSum));
        }
        protected internal virtual void Calculate()
        {
            decimal increment = _sum * _percentage / 100;
            _sum = _sum + increment;
            OnCalculated(new AccounEventArgs("Начислены проценты в размере: " + increment, increment));
        }
    }
} 

