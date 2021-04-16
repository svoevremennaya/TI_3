using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace lab_3
{
    class Keys
    {

        public int GenerateQ()
        {
            Random rnd = new Random();
            int q = 4;
            while (!IsPrime(q))
            {
                q = rnd.Next(10, 1000);
            }

            return q;
        }

        public int GenerateP(int q)
        {
            Random rnd = new Random();
            int p = rnd.Next(10000, 100000);
            do
            {
                p = rnd.Next(10000, 100000);
            } while (!IsPrime(p) || ((p - 1) % q != 0));

            return p;
        }

        public int GenerateG(int q, int p)
        {
            Random rnd = new Random();
            //int h = rnd.Next(1, p - 1);
            int h = 2;
            int g = -1;
            while (g <= 1)
            {
                g = FastExponentiation(p, h, (p - 1) / q);
            }
            return g;
        }

        public int GenerateX(int q)
        {
            Random rnd = new Random();
            int x = rnd.Next(0, q);
            return x;
        }

        private bool IsPrime(int number)
        {
            if (number > 1)
            {
                int sqrt = (int)Math.Ceiling(Math.Sqrt((double)number));
                for (int i = 2; i <= sqrt; i++)
                {
                    if (number % i == 0)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        public int FastExponentiation(BigInteger mod, BigInteger num, BigInteger deg)
        {
            BigInteger y = 1;
            while (deg != 0)
            {
                while (deg % 2 == 0)
                {
                    deg /= 2;
                    num = (num * num) % mod; 
                }
                deg--;
                y = (y * num) % mod;
            }
            return (int)y;
        }

        public int Mul(int a, int b, int n) // a*b mod n - умножение a на b по модулю n
        {
            var sum = 0;
            for (var i = 0; i < b; i++)
            {
                sum += a;
                if (sum >= n)
                {
                    sum -= n;
                }
            }

             return sum;
        }
    }
}
