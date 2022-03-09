using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Account<T>
    {
        public T Number { get; set; }
        public T Balance { get; set; }
    }
}
