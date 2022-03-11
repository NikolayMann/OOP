using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public interface IAccount<in T, out Tout>
    {

    }
    public class Account<T, Tout> : IAccount<T, Tout>
    {
        public Tout Number { get; set; }
        public Tout Balance { get; set; }

        public Account(T AccountDeposit)
        {
            isDeposit = AccountDeposit;
        }
        public T isDeposit { get; }
    }
}
