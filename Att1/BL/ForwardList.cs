using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ForwardList<T>
    {
        public T Numb { get; set; }
        public ForwardList<T> Next { get; set; }
        public ForwardList (T numb)
        {
            Numb = numb;
            Next = null;
        }
    }
}
