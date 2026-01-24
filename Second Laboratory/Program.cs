using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        while (true)
        {
            Console.WriteLine("Lab 2 (no arrays)  Choose 1..17, 0=exit");
            int p = ReadInt();
            if (p == 0) return;

            switch (p)
            {
                case 1: CountEvens(); break;
                case 2: CountNegZeroPos(); break;
                case 3: SumAndProduct1ToN(); break;
                case 4: PositionOfA(); break;
                case 5: CountEqualIndex(); break;
                case 6: IsStrictlyNondecreasing(); break;
                case 7: MinMax(); break;
                case 8: FibonacciN(); break;
                case 9: IsMonotone(); break;
                case 10: MaxConsecutiveEquals(); break;
                case 11: SumOfReciprocals(); break;
                case 12: CountNonZeroGroups(); break;
                case 13: IsRotatedNondecreasing(); break;
                case 14: IsRotatedMonotone(); break;
                case 15: IsBitonic(); break;
                case 16: IsRotatedBitonic(); break;
                case 17: Parentheses01(); break;
                default: Console.WriteLine("Invalid"); break;
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
            Console.WriteLine("Reenter int");
        }
    }

    static long ReadLong()
    {
        while (true)
        {
            string s = (Console.ReadLine() ?? "").Trim();
            if (long.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out long v)) return v;
            Console.WriteLine("Reenter long");
        }
    }

    static double ReadDouble()
    {
        while (true)
        {
            string s = (Console.ReadLine() ?? "").Trim();
            if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out double v)) return v;
            Console.WriteLine("Reenter double");
        }
    }

    static void ReadN(out int n)
    {
        Console.WriteLine("n");
        n = ReadInt();
        if (n < 0) n = 0;
    }

    static void CountEvens()
    {
        ReadN(out int n);
        int cnt = 0;
        for (int i = 0; i < n; i++)
        {
            long x = ReadLong();
            if (x % 2 == 0) cnt++;
        }
        Console.WriteLine(cnt);
    }

    static void CountNegZeroPos()
    {
        ReadN(out int n);
        int neg = 0, zero = 0, pos = 0;
        for (int i = 0; i < n; i++)
        {
            long x = ReadLong();
            if (x < 0) neg++;
            else if (x == 0) zero++;
            else pos++;
        }
        Console.WriteLine(neg);
        Console.WriteLine(zero);
        Console.WriteLine(pos);
    }

    static void SumAndProduct1ToN()
    {
        Console.WriteLine("n");
        long n = ReadLong();
        if (n < 0)
        {
            Console.WriteLine("0");
            Console.WriteLine("0");
            return;
        }

        long sum = 0;
        decimal prod = 1m;

        for (long i = 1; i <= n; i++)
        {
            sum += i;
            prod *= i;
        }

        Console.WriteLine(sum);
        Console.WriteLine(prod.ToString(CultureInfo.InvariantCulture));
    }

    static void PositionOfA()
    {
        ReadN(out int n);
        Console.WriteLine("a");
        long a = ReadLong();

        int pos = -1;
        for (int i = 0; i < n; i++)
        {
            long x = ReadLong();
            if (pos == -1 && x == a) pos = i;
        }
        Console.WriteLine(pos);
    }

    static void CountEqualIndex()
    {
        ReadN(out int n);
        int cnt = 0;
        for (int i = 0; i < n; i++)
        {
            long x = ReadLong();
            if (x == i) cnt++;
        }
        Console.WriteLine(cnt);
    }

    static void IsStrictlyNondecreasing()
    {
        ReadN(out int n);
        if (n <= 1)
        {
            for (int i = 0; i < n; i++) ReadLong();
            Console.WriteLine("DA");
            return;
        }

        long prev = ReadLong();
        bool ok = true;

        for (int i = 1; i < n; i++)
        {
            long x = ReadLong();
            if (x < prev) ok = false;
            prev = x;
        }

        Console.WriteLine(ok ? "DA" : "NU");
    }

    static void MinMax()
    {
        ReadN(out int n);
        if (n == 0)
        {
            Console.WriteLine("NU");
            return;
        }

        long x0 = ReadLong();
        long mn = x0, mx = x0;

        for (int i = 1; i < n; i++)
        {
            long x = ReadLong();
            if (x < mn) mn = x;
            if (x > mx) mx = x;
        }

        Console.WriteLine(mn);
        Console.WriteLine(mx);
    }

    static void FibonacciN()
    {
        Console.WriteLine("n");
        int n = ReadInt();

        if (n <= 1)
        {
            Console.WriteLine(0);
            return;
        }

        if (n == 2)
        {
            Console.WriteLine(1);
            return;
        }

        long a = 0;
        long b = 1;

        for (int i = 3; i <= n; i++)
        {
            long c = a + b;
            a = b;
            b = c;
        }

        Console.WriteLine(b);
    }

    static void IsMonotone()
    {
        ReadN(out int n);
        if (n <= 2)
        {
            for (int i = 0; i < n; i++) ReadLong();
            Console.WriteLine("DA");
            return;
        }

        long prev = ReadLong();
        bool nondec = true;
        bool noninc = true;

        for (int i = 1; i < n; i++)
        {
            long x = ReadLong();
            if (x < prev) nondec = false;
            if (x > prev) noninc = false;
            prev = x;
        }

        Console.WriteLine((nondec || noninc) ? "DA" : "NU");
    }

    static void MaxConsecutiveEquals()
    {
        ReadN(out int n);
        if (n == 0)
        {
            Console.WriteLine(0);
            return;
        }

        long prev = ReadLong();
        int best = 1;
        int cur = 1;

        for (int i = 1; i < n; i++)
        {
            long x = ReadLong();
            if (x == prev) cur++;
            else cur = 1;
            if (cur > best) best = cur;
            prev = x;
        }

        Console.WriteLine(best);
    }

    static void SumOfReciprocals()
    {
        ReadN(out int n);
        double sum = 0.0;

        for (int i = 0; i < n; i++)
        {
            double x = ReadDouble();
            if (x == 0) continue;
            sum += 1.0 / x;
        }

        Console.WriteLine(sum.ToString("G17", CultureInfo.InvariantCulture));
    }

    static void CountNonZeroGroups()
    {
        ReadN(out int n);
        int groups = 0;
        bool inGroup = false;

        for (int i = 0; i < n; i++)
        {
            long x = ReadLong();
            if (x != 0)
            {
                if (!inGroup)
                {
                    groups++;
                    inGroup = true;
                }
            }
            else
            {
                inGroup = false;
            }
        }

        Console.WriteLine(groups);
    }

    static void IsRotatedNondecreasing()
    {
        ReadN(out int n);
        if (n <= 2)
        {
            for (int i = 0; i < n; i++) ReadLong();
            Console.WriteLine("DA");
            return;
        }

        long first = ReadLong();
        long prev = first;
        int drops = 0;

        for (int i = 1; i < n; i++)
        {
            long x = ReadLong();
            if (x < prev) drops++;
            prev = x;
        }

        if (first < prev) drops++;

        Console.WriteLine(drops <= 1 ? "DA" : "NU");
    }

    static void IsRotatedMonotone()
    {
        ReadN(out int n);
        if (n <= 2)
        {
            for (int i = 0; i < n; i++) ReadLong();
            Console.WriteLine("DA");
            return;
        }

        long first = ReadLong();
        long prev = first;

        int dropsNondec = 0;
        int dropsNoninc = 0;

        for (int i = 1; i < n; i++)
        {
            long x = ReadLong();

            if (x < prev) dropsNondec++;
            if (x > prev) dropsNoninc++;

            prev = x;
        }

        if (first < prev) dropsNondec++;
        if (first > prev) dropsNoninc++;

        Console.WriteLine((dropsNondec <= 1 || dropsNoninc <= 1) ? "DA" : "NU");
    }

    static void IsBitonic()
    {
        ReadN(out int n);
        if (n <= 2)
        {
            for (int i = 0; i < n; i++) ReadLong();
            Console.WriteLine("DA");
            return;
        }

        long prev = ReadLong();
        bool wentDown = false;
        bool ok = true;

        for (int i = 1; i < n; i++)
        {
            long x = ReadLong();

            if (!wentDown)
            {
                if (x < prev) wentDown = true;
            }
            else
            {
                if (x > prev) ok = false;
            }

            prev = x;
        }

        Console.WriteLine(ok ? "DA" : "NU");
    }

    static void IsRotatedBitonic()
    {
        ReadN(out int n);
        if (n <= 2)
        {
            for (int i = 0; i < n; i++) ReadLong();
            Console.WriteLine("DA");
            return;
        }

        long first = ReadLong();
        long prev = first;

        int turnsUpDown = 0;
        int turnsDownUp = 0;

        bool? lastUp = null;

        for (int i = 1; i < n; i++)
        {
            long x = ReadLong();
            bool up = x > prev;
            bool down = x < prev;

            if (up || down)
            {
                if (lastUp.HasValue)
                {
                    if (lastUp.Value && down) turnsUpDown++;
                    if (!lastUp.Value && up) turnsDownUp++;
                }
                lastUp = up;
            }

            prev = x;
        }

        bool upLast = first > prev;
        bool downLast = first < prev;

        if (upLast || downLast)
        {
            if (lastUp.HasValue)
            {
                if (lastUp.Value && downLast) turnsUpDown++;
                if (!lastUp.Value && upLast) turnsDownUp++;
            }
        }

        bool isBitonicCycle = (turnsUpDown <= 1 && turnsDownUp <= 1);
        bool hasAtMostTwoTurns = (turnsUpDown + turnsDownUp) <= 2;

        Console.WriteLine((isBitonicCycle && hasAtMostTwoTurns) ? "DA" : "NU");
    }

    static void Parentheses01()
    {
        ReadN(out int n);

        int balance = 0;
        int maxBalance = 0;
        bool ok = true;

        for (int i = 0; i < n; i++)
        {
            int x = ReadInt();
            if (x == 0) balance++;
            else if (x == 1) balance--;
            else ok = false;

            if (balance < 0) ok = false;
            if (balance > maxBalance) maxBalance = balance;
        }

        if (balance != 0) ok = false;

        if (!ok)
        {
            Console.WriteLine("NU");
            return;
        }

        Console.WriteLine("DA");
        Console.WriteLine(maxBalance);
    }
}
