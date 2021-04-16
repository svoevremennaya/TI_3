using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3
{
    class DSA
    {
        public Keys key = new Keys();

        public int[] Signature(string src, int q, int p, int g, int x)
        {
            int hi = HashImage(q, src);

            int r = 0, s = 0;
            while ((r == 0) || (s == 0))
            {
                int k = key.GenerateX(q);
                r = key.FastExponentiation(p, g, k) % q;
                int buf = key.FastExponentiation(q, k, q - 2);
                s = key.Mul(buf, (hi + x * r), q);
            }

            int[] result = new int[2];
            result[0] = r;
            result[1] = s;
            return result;
        }

        public bool CheckingSignature(int q, int p, int r, int y, int g, int s, string src)
        {
            int hi = HashImage(q, src);
            int w = key.FastExponentiation(q, s, q - 2);
            int u1 = key.Mul(hi, w, q);
            int u2 = key.Mul(r, w, q);
            int buf_v1 = key.FastExponentiation(p, g, u1);
            int buf_v2 = key.FastExponentiation(p, y, u2);
            int v = key.Mul(buf_v1, buf_v2, p) % q;

            if (v == r)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int HashImage(int q, string src)
        {
            int hi = 100;
            for (int i = 0; i < src.Length; i++)
            {
                int item = Convert.ToInt32(src[i]);
                hi = key.FastExponentiation(q, (hi + item), 2);
            }

            return hi;
        }

    }
}
