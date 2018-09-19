using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Queue<T>
    {
        public ForwardList<T> First { get; set; }
        public ForwardList<T> Last { get; set; }
        public Queue()
        {
            First = null;
            Last = null;
        }

        public void Add(T num)
        {
            ForwardList<T> el = new ForwardList<T>(num);
            if (Last == null)
            {
                First = el;
                Last = el;
                First.Next = First;
                Last.Next = Last;
            }
            else
            {
                Last.Next = el;
                el.Next = First;
                Last = el;
            }
        }

        public T Take()
        {
            T num = First.Numb;
            if (First == Last)
            {
                First = null;
                Last = null;
            }
            else
            {
                First = First.Next;
                Last.Next = First;
            }
            return num;
        }

        public bool IsEmpty()
        {
            if (this.First == null && this.Last == null)
                return true;
            else
                return false;
        }



        public override string ToString()
        {
            if (First == null)
            {
                return "(/)";
            }
            String s = "";
            ForwardList<T> curr = this.First;
            do
            {
                s += curr.Numb + ", ";
                curr = curr.Next;
            } while (curr != this.First);
            return s.Substring(0, s.Length - 2);
        }
    }
}
