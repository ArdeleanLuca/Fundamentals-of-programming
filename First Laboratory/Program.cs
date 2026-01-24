using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        while (true)
        {
            Console.WriteLine("Alege problema 1..21");
            Console.WriteLine("0 = iesire");
            int p = ReadInt();

            if (p == 0) return;

            try
            {
                switch (p)
                {
                    case 1: Eq1(); break;
                    case 2: Eq2(); break;
                    case 3: Divides(); break;
                    case 4: LeapYear(); break;
                    case 5: KthDigitFromEnd(); break;
                    case 6: Triangle(); break;
                    case 7: Swap(); break;
                    case 8: SwapNoTemp(); break;
                    case 9: Divisors(); break;
                    case 10: Primality(); break;
                    case 11: ReverseDigits(); break;
                    case 12: CountDivisibleInInterval(); break;
                    case 13: CountLeapYearsBetween(); break;
                    case 14: Palindrome(); break;
                    case 15: Sort3(); break;
                    case 16: Sort5(); break;
                    case 17: GcdLcm(); break;
                    case 18: PrimeFactorization(); break;
                    case 19: OnlyTwoDigits(); break;
                    case 20: FractionDecimalWithPeriod(); break;
                    case 21: GuessNumber(); break;
                    default: Console.WriteLine("Problema invalida"); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eroare: " + ex.Message);
            }

            Console.WriteLine();
        }
    }

    static int ReadInt()
    {
        while (true)
        {
            string s = (Console.ReadLine() ?? "").Trim();
            if (int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out int v)) return v;
            Console.WriteLine("Reintrodu un int");
        }
    }

    static long ReadLong()
    {
        while (true)
        {
            string s = (Console.ReadLine() ?? "").Trim();
            if (long.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out long v)) return v;
            Console.WriteLine("Reintrodu un long");
        }
    }

    static double ReadDouble()
    {
        while (true)
        {
            string s = (Console.ReadLine() ?? "").Trim();
            if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out double v)) return v;
            Console.WriteLine("Reintrodu un double (foloseste punct)");
        }
    }

    static void Eq1()
    {
        Console.WriteLine("a");
        double a = ReadDouble();
        Console.WriteLine("b");
        double b = ReadDouble();

        if (a == 0)
        {
            if (b == 0) Console.WriteLine("Infinit de solutii");
            else Console.WriteLine("Fara solutii");
            return;
        }

        double x = -b / a;
        Console.WriteLine(x.ToString("G17", CultureInfo.InvariantCulture));
    }

    static void Eq2()
    {
        Console.WriteLine("a");
        double a = ReadDouble();
        Console.WriteLine("b");
        double b = ReadDouble();
        Console.WriteLine("c");
        double c = ReadDouble();

        if (a == 0)
        {
            if (b == 0)
            {
                if (c == 0) Console.WriteLine("Infinit de solutii");
                else Console.WriteLine("Fara solutii");
            }
            else
            {
                double x = -c / b;
                Console.WriteLine("Ecuatie de grad 1");
                Console.WriteLine(x.ToString("G17", CultureInfo.InvariantCulture));
            }
            return;
        }

        double d = b * b - 4 * a * c;

        if (d < 0)
        {
            Console.WriteLine("Fara solutii reale");
            return;
        }

        if (d == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine("O solutie reala");
            Console.WriteLine(x.ToString("G17", CultureInfo.InvariantCulture));
            return;
        }

        double sqrtD = Math.Sqrt(d);
        double x1 = (-b - sqrtD) / (2 * a);
        double x2 = (-b + sqrtD) / (2 * a);
        Console.WriteLine("Doua solutii reale");
        Console.WriteLine(x1.ToString("G17", CultureInfo.InvariantCulture));
        Console.WriteLine(x2.ToString("G17", CultureInfo.InvariantCulture));
    }

    static void Divides()
    {
        Console.WriteLine("n");
        long n = ReadLong();
        Console.WriteLine("k");
        long k = ReadLong();

        if (k == 0)
        {
            Console.WriteLine("Impartire la 0 nu e definita");
            return;
        }

        Console.WriteLine(n % k == 0 ? "DA" : "NU");
    }

    static bool IsLeap(int y)
    {
        if (y % 400 == 0) return true;
        if (y % 100 == 0) return false;
        return y % 4 == 0;
    }

    static void LeapYear()
    {
        Console.WriteLine("y");
        int y = ReadInt();
        Console.WriteLine(IsLeap(y) ? "DA" : "NU");
    }

    static void KthDigitFromEnd()
    {
        Console.WriteLine("numar n");
        long n = ReadLong();
        Console.WriteLine("k");
        int k = ReadInt();

        if (k <= 0)
        {
            Console.WriteLine("k invalid");
            return;
        }

        long x = Math.Abs(n);
        for (int i = 1; i < k; i++) x /= 10;
        int digit = (int)(x % 10);
        Console.WriteLine(digit);
    }

    static void Triangle()
    {
        Console.WriteLine("a");
        long a = ReadLong();
        Console.WriteLine("b");
        long b = ReadLong();
        Console.WriteLine("c");
        long c = ReadLong();

        if (a <= 0 || b <= 0 || c <= 0)
        {
            Console.WriteLine("NU");
            return;
        }

        Console.WriteLine(a + b > c && a + c > b && b + c > a ? "DA" : "NU");
    }

    static void Swap()
    {
        Console.WriteLine("a");
        long a = ReadLong();
        Console.WriteLine("b");
        long b = ReadLong();
        long t = a;
        a = b;
        b = t;
        Console.WriteLine(a);
        Console.WriteLine(b);
    }

    static void SwapNoTemp()
    {
        Console.WriteLine("a");
        long a = ReadLong();
        Console.WriteLine("b");
        long b = ReadLong();

        a = a + b;
        b = a - b;
        a = a - b;

        Console.WriteLine(a);
        Console.WriteLine(b);
    }

    static void Divisors()
    {
        Console.WriteLine("n");
        long n = ReadLong();
        n = Math.Abs(n);
        if (n == 0)
        {
            Console.WriteLine("0 are infinit de divizori");
            return;
        }

        long r = (long)Math.Sqrt(n);

        for (long i = 1; i <= r; i++)
            if (n % i == 0)
                Console.Write(i + (i == r && i * i == n ? "" : " "));

        for (long i = r; i >= 1; i--)
            if (n % i == 0)
            {
                long d = n / i;
                if (d != i)
                    Console.Write(d + " ");
            }

        Console.WriteLine();
    }

    static bool IsPrime(long n)
    {
        if (n < 2) return false;
        if (n % 2 == 0) return n == 2;
        long r = (long)Math.Sqrt(n);
        for (long i = 3; i <= r; i += 2)
            if (n % i == 0) return false;
        return true;
    }

    static void Primality()
    {
        Console.WriteLine("n");
        long n = ReadLong();
        Console.WriteLine(IsPrime(n) ? "DA" : "NU");
    }

    static void ReverseDigits()
    {
        Console.WriteLine("n");
        long n = ReadLong();

        if (n == 0)
        {
            Console.WriteLine("0");
            return;
        }

        long x = Math.Abs(n);
        var sb = new StringBuilder();
        while (x > 0)
        {
            sb.Append((char)('0' + (x % 10)));
            x /= 10;
        }

        if (n < 0) Console.WriteLine("-" + sb.ToString());
        else Console.WriteLine(sb.ToString());
    }

    static long FloorDiv(long a, long b)
    {
        long q = a / b;
        long r = a % b;
        if (r != 0 && ((r > 0) != (b > 0))) q--;
        return q;
    }

    static long CeilDiv(long a, long b)
    {
        long q = a / b;
        long r = a % b;
        if (r != 0 && ((r > 0) == (b > 0))) q++;
        return q;
    }

    static void CountDivisibleInInterval()
    {
        Console.WriteLine("a");
        long a = ReadLong();
        Console.WriteLine("b");
        long b = ReadLong();
        Console.WriteLine("n");
        long n = ReadLong();

        if (n == 0)
        {
            Console.WriteLine("n invalid");
            return;
        }

        if (a > b)
        {
            long t = a;
            a = b;
            b = t;
        }

        long first = CeilDiv(a, n);
        long last = FloorDiv(b, n);

        long count = last >= first ? (last - first + 1) : 0;
        Console.WriteLine(count);
    }

    static long LeapCountUpTo(long y)
    {
        if (y <= 0) return 0;
        return y / 4 - y / 100 + y / 400;
    }

    static void CountLeapYearsBetween()
    {
        Console.WriteLine("y1");
        long y1 = ReadLong();
        Console.WriteLine("y2");
        long y2 = ReadLong();

        if (y1 > y2)
        {
            long t = y1;
            y1 = y2;
            y2 = t;
        }

        long ans = LeapCountUpTo(y2) - LeapCountUpTo(y1 - 1);
        Console.WriteLine(ans);
    }

    static void Palindrome()
    {
        Console.WriteLine("n");
        long n = ReadLong();
        long x = Math.Abs(n);

        long rev = 0;
        long t = x;
        while (t > 0)
        {
            rev = rev * 10 + (t % 10);
            t /= 10;
        }

        Console.WriteLine(rev == x ? "DA" : "NU");
    }

    static void Sort3()
    {
        Console.WriteLine("a");
        long a = ReadLong();
        Console.WriteLine("b");
        long b = ReadLong();
        Console.WriteLine("c");
        long c = ReadLong();

        if (a > b) SwapRef(ref a, ref b);
        if (b > c) SwapRef(ref b, ref c);
        if (a > b) SwapRef(ref a, ref b);

        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine(c);
    }

    static void Sort5()
    {
        Console.WriteLine("a");
        long a = ReadLong();
        Console.WriteLine("b");
        long b = ReadLong();
        Console.WriteLine("c");
        long c = ReadLong();
        Console.WriteLine("d");
        long d = ReadLong();
        Console.WriteLine("e");
        long e = ReadLong();

        if (a > b) SwapRef(ref a, ref b);
        if (c > d) SwapRef(ref c, ref d);
        if (a > c) SwapRef(ref a, ref c);
        if (b > d) SwapRef(ref b, ref d);
        if (b > c) SwapRef(ref b, ref c);
        if (e < c) SwapRef(ref e, ref c);
        if (e < b) SwapRef(ref e, ref b);
        if (e < a) SwapRef(ref e, ref a);
        if (d < c) SwapRef(ref d, ref c);
        if (d < b) SwapRef(ref d, ref b);
        if (d < a) SwapRef(ref d, ref a);
        if (c < b) SwapRef(ref c, ref b);
        if (b < a) SwapRef(ref b, ref a);

        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine(c);
        Console.WriteLine(d);
        Console.WriteLine(e);
    }

    static void SwapRef(ref long x, ref long y)
    {
        long t = x;
        x = y;
        y = t;
    }

    static long Gcd(long a, long b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        while (b != 0)
        {
            long t = a % b;
            a = b;
            b = t;
        }
        return a;
    }

    static void GcdLcm()
    {
        Console.WriteLine("a");
        long a = ReadLong();
        Console.WriteLine("b");
        long b = ReadLong();

        long g = Gcd(a, b);
        long l = 0;
        if (a != 0 && b != 0)
            l = Math.Abs(a / g * b);

        Console.WriteLine("GCD");
        Console.WriteLine(g);
        Console.WriteLine("LCM");
        Console.WriteLine(l);
    }

    static void PrimeFactorization()
    {
        Console.WriteLine("n");
        long n = ReadLong();
        n = Math.Abs(n);

        if (n < 2)
        {
            Console.WriteLine(n.ToString());
            return;
        }

        bool first = true;

        long p = 2;
        while (p * p <= n)
        {
            if (n % p == 0)
            {
                int exp = 0;
                while (n % p == 0)
                {
                    n /= p;
                    exp++;
                }

                if (!first) Console.Write(" x ");
                Console.Write(p);
                Console.Write("^");
                Console.Write(exp);
                first = false;
            }
            p = (p == 2) ? 3 : p + 2;
        }

        if (n > 1)
        {
            if (!first) Console.Write(" x ");
            Console.Write(n);
            Console.Write("^1");
        }

        Console.WriteLine();
    }

    static void OnlyTwoDigits()
    {
        Console.WriteLine("n");
        long n = ReadLong();
        long x = Math.Abs(n);

        if (x < 10)
        {
            Console.WriteLine("DA");
            return;
        }

        int d1 = -1;
        int d2 = -1;

        while (x > 0)
        {
            int d = (int)(x % 10);
            if (d1 == -1) d1 = d;
            else if (d == d1) { }
            else if (d2 == -1) d2 = d;
            else if (d == d2) { }
            else
            {
                Console.WriteLine("NU");
                return;
            }
            x /= 10;
        }

        Console.WriteLine("DA");
    }

    static void FractionDecimalWithPeriod()
    {
        Console.WriteLine("m");
        long m = ReadLong();
        Console.WriteLine("n");
        long n = ReadLong();

        if (n == 0)
        {
            Console.WriteLine("n invalid");
            return;
        }

        bool neg = (m < 0) ^ (n < 0);
        long a = Math.Abs(m);
        long b = Math.Abs(n);

        long integerPart = a / b;
        long rem = a % b;

        var sb = new StringBuilder();

        if (neg && (integerPart != 0 || rem != 0)) sb.Append("-");
        sb.Append(integerPart);

        if (rem == 0)
        {
            Console.WriteLine(sb.ToString());
            return;
        }

        sb.Append(".");

        var seen = new Dictionary<long, int>();
        var frac = new StringBuilder();

        int pos = 0;
        int repeatStart = -1;

        while (rem != 0)
        {
            if (seen.TryGetValue(rem, out int where))
            {
                repeatStart = where;
                break;
            }

            seen[rem] = pos;

            rem *= 10;
            long digit = rem / b;
            rem = rem % b;

            frac.Append((char)('0' + digit));
            pos++;
        }

        if (repeatStart == -1)
        {
            sb.Append(frac.ToString());
            Console.WriteLine(sb.ToString());
            return;
        }

        string f = frac.ToString();
        sb.Append(f.Substring(0, repeatStart));
        sb.Append("(");
        sb.Append(f.Substring(repeatStart));
        sb.Append(")");
        Console.WriteLine(sb.ToString());
    }

    static void GuessNumber()
    {
        int lo = 1;
        int hi = 1024;

        Console.WriteLine("Gandeste un numar intre 1 si 1024");
        Console.WriteLine("Raspunde cu da sau nu");

        while (lo < hi)
        {
            int mid = (lo + hi + 1) / 2;
            Console.WriteLine($"Numarul este mai mare sau egal decat {mid} ?");
            string ans = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();

            if (ans == "da" || ans == "d" || ans == "yes" || ans == "y")
                lo = mid;
            else if (ans == "nu" || ans == "n" || ans == "no")
                hi = mid - 1;
            else
                Console.WriteLine("Raspunde da sau nu");
        }

        Console.WriteLine("Numarul este");
        Console.WriteLine(lo);
    }
}
