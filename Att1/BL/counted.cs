using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Counted
    {
        public int N { get; set; }
        public int K { get; set; }
        public Counted (int n,int k)
        {
            if (k <= n && k > 0 && n > 0)
            {
                this.N = n;
                this.K = k;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void SolCount(out int Win, out int[] Los)
        {
            List<int> Gamers = new List<int>();
            var que = new BL.Queue<int>();
                for (int i = 1; i <= N; i++)
                {
                    que.Add(i);
                }

                for (int i = 0; i < N - 1; i++)
                {
                    BL.ForwardList<int> curr = que.First;
                    // считалочка
                    for (int l = 1; l < K; l++)
                    {
                        curr = curr.Next;
                    }

                    var queNew = new BL.Queue<int>();
                    BL.ForwardList<int> currNext = curr.Next;
                    while (currNext != curr)
                    {
                        queNew.Add(currNext.Numb);
                        currNext = currNext.Next;
                    }
                Gamers.Add(curr.Numb);
                que = queNew;
                }
            Win = que.First.Numb;
            Los = Gamers.ToArray();
        }

    }
}
