using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

class Program
{
    static void Main()
    {
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        while (true)
        {
            Console.WriteLine("Lab 3 Vectors  Choose 1..31, 0=exit");
            int p = ReadInt();
            if (p == 0) return;

            switch (p)
            {
                case 1: SumVector(); break;
                case 2: FirstPositionOfK(); break;
                case 3: PositionsMinMax(); break;
                case 4: MinMaxAndCounts(); break;
                case 5: InsertAtK(); break;
                case 6: DeleteAtK(); break;
                case 7: ReverseVector(); break;
                case 8: RotateLeft1(); break;
                case 9: RotateLeftK(); break;
                case 10: BinarySearchSorted(); break;
                case 11: SievePrimesUpToN(); break;
                case 12: SelectionSort(); break;
                case 13: InsertionSort(); break;
                case 14: MoveZerosToEndInplace(); break;
                case 15: RemoveDuplicatesInplace(); break;
                case 16: GcdOfVector(); break;
                case 17: ConvertBase10ToB(); break;
                case 18: PolynomialValue(); break;
                case 19: CountPatternInSequence(); break;
                case 20: BeadNecklacesMatches(); break;
                case 21: LexicographicOrder(); break;
                case 22: SetOpsUnsortedUnique(); break;
                case 23: SetOpsSortedStrict(); break;
                case 24: SetOpsBinaryVectors(); break;
                case 25: MergeTwoSortedWithDuplicates(); break;
                case 26: BigNumbersOps(); break;
                case 27: KthAfterSorting(); break;
                case 28: QuickSort(); break;
                case 29: MergeSort(); break;
                case 30: BiCriteriaSortEw(); break;
                case 31: MajorityElement(); break;
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

    static void ReadN(out int n)
    {
        Console.WriteLine("n");
        n = ReadInt();
        if (n < 0) n = 0;
    }

    static int[] ReadIntArray(int n)
    {
        int[] a = new int[n];
        for (int i = 0; i < n; i++) a[i] = ReadInt();
        return a;
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

    static void PrintArray(int[] a, int len = -1)
    {
        if (len < 0) len = a.Length;
        for (int i = 0; i < len; i++)
        {
            if (i > 0) Console.Write(" ");
            Console.Write(a[i]);
        }
        Console.WriteLine();
    }

    static void SumVector()
    {
        ReadN(out int n);
        long sum = 0;
        for (int i = 0; i < n; i++) sum += ReadLong();
        Console.WriteLine(sum);
    }

    static void FirstPositionOfK()
    {
        ReadN(out int n);
        Console.WriteLine("k");
        int k = ReadInt();
        int pos = -1;
        for (int i = 0; i < n; i++)
        {
            int x = ReadInt();
            if (pos == -1 && x == k) pos = i;
        }
        Console.WriteLine(pos);
    }

    static void PositionsMinMax()
    {
        ReadN(out int n);
        if (n == 0) { Console.WriteLine("-1"); Console.WriteLine("-1"); return; }
        int x0 = ReadInt();
        int mn = x0, mx = x0;
        int posMn = 0, posMx = 0;

        for (int i = 1; i < n; i++)
        {
            int x = ReadInt();
            if (x < mn) { mn = x; posMn = i; }
            if (x > mx) { mx = x; posMx = i; }
        }

        Console.WriteLine(posMn);
        Console.WriteLine(posMx);
    }

    static void MinMaxAndCounts()
    {
        ReadN(out int n);
        if (n == 0) { Console.WriteLine("0"); return; }

        int x0 = ReadInt();
        int mn = x0, mx = x0;
        int cntMn = 1, cntMx = 1;

        for (int i = 1; i < n; i++)
        {
            int x = ReadInt();

            if (x < mn) { mn = x; cntMn = 1; }
            else if (x == mn) cntMn++;

            if (x > mx) { mx = x; cntMx = 1; }
            else if (x == mx) cntMx++;
        }

        Console.WriteLine(mn);
        Console.WriteLine(cntMn);
        Console.WriteLine(mx);
        Console.WriteLine(cntMx);
    }

    static void InsertAtK()
    {
        ReadN(out int n);
        int[] a = ReadIntArray(n);
        Console.WriteLine("e");
        int e = ReadInt();
        Console.WriteLine("k");
        int k = ReadInt();
        if (k < 0) k = 0;
        if (k > n) k = n;

        int[] b = new int[n + 1];
        for (int i = 0; i < k; i++) b[i] = a[i];
        b[k] = e;
        for (int i = k; i < n; i++) b[i + 1] = a[i];

        PrintArray(b);
    }

    static void DeleteAtK()
    {
        ReadN(out int n);
        int[] a = ReadIntArray(n);
        Console.WriteLine("k");
        int k = ReadInt();

        if (n == 0) { Console.WriteLine(); return; }
        if (k < 0 || k >= n) { PrintArray(a); return; }

        int[] b = new int[n - 1];
        for (int i = 0; i < k; i++) b[i] = a[i];
        for (int i = k + 1; i < n; i++) b[i - 1] = a[i];
        PrintArray(b);
    }

    static void ReverseVector()
    {
        ReadN(out int n);
        int[] a = ReadIntArray(n);
        int i = 0, j = n - 1;
        while (i < j)
        {
            int t = a[i];
            a[i] = a[j];
            a[j] = t;
            i++;
            j--;
        }
        PrintArray(a);
    }

    static void RotateLeft1()
    {
        ReadN(out int n);
        int[] a = ReadIntArray(n);
        if (n <= 1) { PrintArray(a); return; }
        int first = a[0];
        for (int i = 1; i < n; i++) a[i - 1] = a[i];
        a[n - 1] = first;
        PrintArray(a);
    }

    static void ReverseRange(int[] a, int l, int r)
    {
        while (l < r)
        {
            int t = a[l];
            a[l] = a[r];
            a[r] = t;
            l++;
            r--;
        }
    }

    static void RotateLeftK()
    {
        ReadN(out int n);
        int[] a = ReadIntArray(n);
        Console.WriteLine("k");
        int k = ReadInt();
        if (n == 0) { Console.WriteLine(); return; }
        k %= n;
        if (k < 0) k += n;

        ReverseRange(a, 0, k - 1);
        ReverseRange(a, k, n - 1);
        ReverseRange(a, 0, n - 1);

        PrintArray(a);
    }

    static void BinarySearchSorted()
    {
        ReadN(out int n);
        int[] a = ReadIntArray(n);
        Console.WriteLine("k");
        int k = ReadInt();

        int lo = 0, hi = n - 1;
        int ans = -1;
        while (lo <= hi)
        {
            int mid = lo + (hi - lo) / 2;
            if (a[mid] == k) { ans = mid; break; }
            if (a[mid] < k) lo = mid + 1;
            else hi = mid - 1;
        }
        Console.WriteLine(ans);
    }

    static void SievePrimesUpToN()
    {
        Console.WriteLine("n");
        int n = ReadInt();
        if (n < 2) { Console.WriteLine(); return; }

        bool[] isPrime = new bool[n + 1];
        for (int i = 2; i <= n; i++) isPrime[i] = true;

        for (int p = 2; (long)p * p <= n; p++)
            if (isPrime[p])
                for (int m = p * p; m <= n; m += p)
                    isPrime[m] = false;

        bool first = true;
        for (int i = 2; i <= n; i++)
            if (isPrime[i])
            {
                if (!first) Console.Write(" ");
                Console.Write(i);
                first = false;
            }
        Console.WriteLine();
    }

    static void SelectionSort()
    {
        ReadN(out int n);
        int[] a = ReadIntArray(n);

        for (int i = 0; i < n - 1; i++)
        {
            int minPos = i;
            for (int j = i + 1; j < n; j++)
                if (a[j] < a[minPos]) minPos = j;

            int t = a[i];
            a[i] = a[minPos];
            a[minPos] = t;
        }

        PrintArray(a);
    }

    static void InsertionSort()
    {
        ReadN(out int n);
        int[] a = ReadIntArray(n);

        for (int i = 1; i < n; i++)
        {
            int key = a[i];
            int j = i - 1;
            while (j >= 0 && a[j] > key)
            {
                a[j + 1] = a[j];
                j--;
            }
            a[j + 1] = key;
        }

        PrintArray(a);
    }

    static void MoveZerosToEndInplace()
    {
        ReadN(out int n);
        int[] a = ReadIntArray(n);

        int write = 0;
        for (int read = 0; read < n; read++)
            if (a[read] != 0)
                a[write++] = a[read];

        for (int i = write; i < n; i++) a[i] = 0;

        PrintArray(a);
    }

    static void RemoveDuplicatesInplace()
    {
        ReadN(out int n);
        int[] a = ReadIntArray(n);

        int len = n;
        for (int i = 0; i < len; i++)
        {
            int j = i + 1;
            while (j < len)
            {
                if (a[j] == a[i])
                {
                    for (int k = j + 1; k < len; k++) a[k - 1] = a[k];
                    len--;
                }
                else j++;
            }
        }

        PrintArray(a, len);
    }

    static void GcdOfVector()
    {
        ReadN(out int n);
        if (n == 0) { Console.WriteLine(0); return; }

        long g = ReadLong();
        for (int i = 1; i < n; i++)
        {
            long x = ReadLong();
            g = Gcd(g, x);
        }
        Console.WriteLine(g);
    }

    static void ConvertBase10ToB()
    {
        Console.WriteLine("n");
        long n = ReadLong();
        Console.WriteLine("b");
        int b = ReadInt();
        if (b <= 1 || b >= 17) { Console.WriteLine("Invalid base"); return; }

        if (n == 0) { Console.WriteLine("0"); return; }

        bool neg = n < 0;
        ulong x = (ulong)(neg ? -n : n);

        const string digits = "0123456789ABCDEF";
        var sb = new StringBuilder();
        while (x > 0)
        {
            int d = (int)(x % (ulong)b);
            sb.Append(digits[d]);
            x /= (ulong)b;
        }

        if (neg) sb.Append('-');

        char[] arr = sb.ToString().ToCharArray();
        Array.Reverse(arr);
        Console.WriteLine(new string(arr));
    }

    static void PolynomialValue()
    {
        Console.WriteLine("n (degree)");
        int n = ReadInt();
        int len = n + 1;
        int[] coef = new int[len];

        for (int i = 0; i < len; i++) coef[i] = ReadInt();

        Console.WriteLine("x");
        long x = ReadLong();

        long res = 0;
        for (int i = n; i >= 0; i--)
            res = res * x + coef[i];

        Console.WriteLine(res);
    }

    static int[] BuildLps(int[] p)
    {
        int m = p.Length;
        int[] lps = new int[m];
        int len = 0;
        for (int i = 1; i < m; )
        {
            if (p[i] == p[len])
            {
                len++;
                lps[i] = len;
                i++;
            }
            else if (len != 0)
            {
                len = lps[len - 1];
            }
            else
            {
                lps[i] = 0;
                i++;
            }
        }
        return lps;
    }

    static void CountPatternInSequence()
    {
        Console.WriteLine("ns");
        int ns = ReadInt();
        int[] s = ReadIntArray(ns);

        Console.WriteLine("np");
        int np = ReadInt();
        int[] p = ReadIntArray(np);

        if (np == 0 || ns == 0 || np > ns) { Console.WriteLine(0); return; }

        int[] lps = BuildLps(p);

        int i = 0, j = 0, count = 0;
        while (i < ns)
        {
            if (s[i] == p[j])
            {
                i++;
                j++;
                if (j == np)
                {
                    count++;
                    j = lps[j - 1];
                }
            }
            else if (j != 0)
            {
                j = lps[j - 1];
            }
            else
            {
                i++;
            }
        }

        Console.WriteLine(count);
    }

    static void BeadNecklacesMatches()
    {
        Console.WriteLine("n");
        int n = ReadInt();
        string s1 = (Console.ReadLine() ?? "").Trim();
        string s2 = (Console.ReadLine() ?? "").Trim();

        if (s1.Length != n || s2.Length != n) { Console.WriteLine(0); return; }

        int cnt = 0;
        for (int shift = 0; shift < n; shift++)
        {
            bool ok = true;
            for (int i = 0; i < n; i++)
            {
                char c1 = s1[i];
                char c2 = s2[(i + shift) % n];
                if (c1 != c2) { ok = false; break; }
            }
            if (ok) cnt++;
        }

        Console.WriteLine(cnt);
    }

    static void LexicographicOrder()
    {
        Console.WriteLine("n1");
        int n1 = ReadInt();
        int[] a = ReadIntArray(n1);

        Console.WriteLine("n2");
        int n2 = ReadInt();
        int[] b = ReadIntArray(n2);

        int m = Math.Min(n1, n2);
        int cmp = 0;
        for (int i = 0; i < m; i++)
        {
            if (a[i] < b[i]) { cmp = -1; break; }
            if (a[i] > b[i]) { cmp = 1; break; }
        }

        if (cmp == 0)
        {
            if (n1 < n2) cmp = -1;
            else if (n1 > n2) cmp = 1;
        }

        if (cmp < 0) Console.WriteLine("v1");
        else if (cmp > 0) Console.WriteLine("v2");
        else Console.WriteLine("equal");
    }

    static int[] UniqueFromArray(int[] a)
    {
        var set = new HashSet<int>();
        var list = new List<int>();
        foreach (var x in a)
            if (set.Add(x))
                list.Add(x);
        return list.ToArray();
    }

    static void SetOpsUnsortedUnique()
    {
        Console.WriteLine("n1");
        int n1 = ReadInt();
        int[] v1 = ReadIntArray(n1);

        Console.WriteLine("n2");
        int n2 = ReadInt();
        int[] v2 = ReadIntArray(n2);

        var s1 = new HashSet<int>(v1);
        var s2 = new HashSet<int>(v2);

        var inter = new List<int>();
        foreach (var x in s1) if (s2.Contains(x)) inter.Add(x);

        var uni = new HashSet<int>(s1);
        uni.UnionWith(s2);

        var d12 = new List<int>();
        foreach (var x in s1) if (!s2.Contains(x)) d12.Add(x);

        var d21 = new List<int>();
        foreach (var x in s2) if (!s1.Contains(x)) d21.Add(x);

        PrintArray(inter.ToArray());
        PrintArray(new List<int>(uni).ToArray());
        PrintArray(d12.ToArray());
        PrintArray(d21.ToArray());
    }

    static void SetOpsSortedStrict()
    {
        Console.WriteLine("n1");
        int n1 = ReadInt();
        int[] a = ReadIntArray(n1);

        Console.WriteLine("n2");
        int n2 = ReadInt();
        int[] b = ReadIntArray(n2);

        int i = 0, j = 0;
        var inter = new List<int>();
        var uni = new List<int>();
        var d12 = new List<int>();
        var d21 = new List<int>();

        while (i < n1 && j < n2)
        {
            if (a[i] == b[j])
            {
                inter.Add(a[i]);
                uni.Add(a[i]);
                i++; j++;
            }
            else if (a[i] < b[j])
            {
                uni.Add(a[i]);
                d12.Add(a[i]);
                i++;
            }
            else
            {
                uni.Add(b[j]);
                d21.Add(b[j]);
                j++;
            }
        }
        while (i < n1) { uni.Add(a[i]); d12.Add(a[i]); i++; }
        while (j < n2) { uni.Add(b[j]); d21.Add(b[j]); j++; }

        PrintArray(inter.ToArray());
        PrintArray(uni.ToArray());
        PrintArray(d12.ToArray());
        PrintArray(d21.ToArray());
    }

    static void SetOpsBinaryVectors()
    {
        Console.WriteLine("m (universe size)");
        int m = ReadInt();

        Console.WriteLine("v1 (m values 0/1)");
        int[] v1 = ReadIntArray(m);
        Console.WriteLine("v2 (m values 0/1)");
        int[] v2 = ReadIntArray(m);

        int[] inter = new int[m];
        int[] uni = new int[m];
        int[] d12 = new int[m];
        int[] d21 = new int[m];

        for (int i = 0; i < m; i++)
        {
            int a = v1[i] != 0 ? 1 : 0;
            int b = v2[i] != 0 ? 1 : 0;
            inter[i] = (a == 1 && b == 1) ? 1 : 0;
            uni[i] = (a == 1 || b == 1) ? 1 : 0;
            d12[i] = (a == 1 && b == 0) ? 1 : 0;
            d21[i] = (a == 0 && b == 1) ? 1 : 0;
        }

        PrintArray(inter);
        PrintArray(uni);
        PrintArray(d12);
        PrintArray(d21);
    }

    static void MergeTwoSortedWithDuplicates()
    {
        Console.WriteLine("n1");
        int n1 = ReadInt();
        int[] a = ReadIntArray(n1);

        Console.WriteLine("n2");
        int n2 = ReadInt();
        int[] b = ReadIntArray(n2);

        int[] c = new int[n1 + n2];
        int i = 0, j = 0, k = 0;

        while (i < n1 && j < n2)
        {
            if (a[i] <= b[j]) c[k++] = a[i++];
            else c[k++] = b[j++];
        }
        while (i < n1) c[k++] = a[i++];
        while (j < n2) c[k++] = b[j++];

        PrintArray(c);
    }

    static int[] ParseBigDigits(string s)
    {
        s = s.Trim();
        int start = 0;
        while (start < s.Length && s[start] == '0') start++;
        if (start == s.Length) return new int[] { 0 };

        int[] d = new int[s.Length - start];
        for (int i = 0; i < d.Length; i++) d[i] = s[start + i] - '0';
        return d;
    }

    static int CompareBig(int[] a, int[] b)
    {
        if (a.Length != b.Length) return a.Length.CompareTo(b.Length);
        for (int i = 0; i < a.Length; i++)
            if (a[i] != b[i]) return a[i].CompareTo(b[i]);
        return 0;
    }

    static int[] AddBig(int[] a, int[] b)
    {
        int i = a.Length - 1, j = b.Length - 1, carry = 0;
        var res = new List<int>();

        while (i >= 0 || j >= 0 || carry != 0)
        {
            int x = carry;
            if (i >= 0) x += a[i--];
            if (j >= 0) x += b[j--];
            res.Add(x % 10);
            carry = x / 10;
        }
        res.Reverse();
        return res.ToArray();
    }

    static int[] SubBigNonNeg(int[] a, int[] b)
    {
        int i = a.Length - 1, j = b.Length - 1, borrow = 0;
        var res = new List<int>();

        while (i >= 0)
        {
            int x = a[i] - borrow - (j >= 0 ? b[j] : 0);
            if (x < 0) { x += 10; borrow = 1; } else borrow = 0;
            res.Add(x);
            i--; j--;
        }
        while (res.Count > 1 && res[res.Count - 1] == 0) res.RemoveAt(res.Count - 1);
        res.Reverse();
        return res.ToArray();
    }

    static int[] MulBig(int[] a, int[] b)
    {
        int n = a.Length, m = b.Length;
        int[] res = new int[n + m];

        for (int i = n - 1; i >= 0; i--)
            for (int j = m - 1; j >= 0; j--)
            {
                int p = a[i] * b[j];
                int pos = i + j + 1;
                int sum = res[pos] + p;
                res[pos] = sum % 10;
                res[pos - 1] += sum / 10;
            }

        int k = 0;
        while (k < res.Length - 1 && res[k] == 0) k++;
        int[] outD = new int[res.Length - k];
        Array.Copy(res, k, outD, 0, outD.Length);
        return outD;
    }

    static string BigToString(int[] d)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < d.Length; i++) sb.Append((char)('0' + d[i]));
        return sb.ToString();
    }

    static void BigNumbersOps()
    {
        Console.WriteLine("A");
        string sa = Console.ReadLine() ?? "0";
        Console.WriteLine("B");
        string sb = Console.ReadLine() ?? "0";

        int[] a = ParseBigDigits(sa);
        int[] b = ParseBigDigits(sb);

        int[] sum = AddBig(a, b);

        int cmp = CompareBig(a, b);
        bool neg = false;
        int[] diff;
        if (cmp >= 0) diff = SubBigNonNeg(a, b);
        else { diff = SubBigNonNeg(b, a); neg = true; }

        int[] prod = MulBig(a, b);

        Console.WriteLine(BigToString(sum));
        Console.WriteLine((neg ? "-" : "") + BigToString(diff));
        Console.WriteLine(BigToString(prod));
    }

    static int Partition(int[] a, int l, int r)
    {
        int pivot = a[r];
        int i = l;
        for (int j = l; j < r; j++)
            if (a[j] <= pivot)
            {
                int t = a[i]; a[i] = a[j]; a[j] = t;
                i++;
            }
        int t2 = a[i]; a[i] = a[r]; a[r] = t2;
        return i;
    }

    static int QuickSelect(int[] a, int k)
    {
        int l = 0, r = a.Length - 1;
        while (true)
        {
            int p = Partition(a, l, r);
            if (p == k) return a[p];
            if (k < p) r = p - 1;
            else l = p + 1;
        }
    }

    static void KthAfterSorting()
    {
        ReadN(out int n);
        int[] a = ReadIntArray(n);
        Console.WriteLine("index");
        int idx = ReadInt();
        if (idx < 0 || idx >= n) { Console.WriteLine("Invalid"); return; }
        int val = QuickSelect(a, idx);
        Console.WriteLine(val);
    }

    static void QuickSortRec(int[] a, int l, int r)
    {
        if (l >= r) return;
        int p = Partition(a, l, r);
        QuickSortRec(a, l, p - 1);
        QuickSortRec(a, p + 1, r);
    }

    static void QuickSort()
    {
        ReadN(out int n);
        int[] a = ReadIntArray(n);
        QuickSortRec(a, 0, n - 1);
        PrintArray(a);
    }

    static void MergeSortRec(int[] a, int[] tmp, int l, int r)
    {
        if (l >= r) return;
        int mid = l + (r - l) / 2;
        MergeSortRec(a, tmp, l, mid);
        MergeSortRec(a, tmp, mid + 1, r);

        int i = l, j = mid + 1, k = l;
        while (i <= mid && j <= r)
        {
            if (a[i] <= a[j]) tmp[k++] = a[i++];
            else tmp[k++] = a[j++];
        }
        while (i <= mid) tmp[k++] = a[i++];
        while (j <= r) tmp[k++] = a[j++];

        for (int t = l; t <= r; t++) a[t] = tmp[t];
    }

    static void MergeSort()
    {
        ReadN(out int n);
        int[] a = ReadIntArray(n);
        int[] tmp = new int[n];
        MergeSortRec(a, tmp, 0, n - 1);
        PrintArray(a);
    }

    static void BiCriteriaSortEw()
    {
        ReadN(out int n);
        int[] E = new int[n];
        int[] W = new int[n];

        for (int i = 0; i < n; i++) E[i] = ReadInt();
        for (int i = 0; i < n; i++) W[i] = ReadInt();

        Array.Sort(E, W, Comparer<int>.Create((x, y) => x.CompareTo(y)));

        for (int i = 0; i < n; i++)
        {
            int j = i;
            while (j + 1 < n && E[j + 1] == E[i]) j++;
            if (j > i)
            {
                Array.Sort(W, E, i, j - i + 1, Comparer<int>.Create((w1, w2) => w2.CompareTo(w1)));
                Array.Sort(E, W, i, j - i + 1, Comparer<int>.Create((e1, e2) => e1.CompareTo(e2)));
            }
            i = j;
        }

        PrintArray(E);
        PrintArray(W);
    }

    static void MajorityElement()
    {
        ReadN(out int n);
        int[] a = ReadIntArray(n);
        if (n == 0) { Console.WriteLine("nu exista"); return; }

        int cand = 0;
        int cnt = 0;
        for (int i = 0; i < n; i++)
        {
            if (cnt == 0) { cand = a[i]; cnt = 1; }
            else if (a[i] == cand) cnt++;
            else cnt--;
        }

        int occ = 0;
        for (int i = 0; i < n; i++) if (a[i] == cand) occ++;

        if (occ > n / 2) Console.WriteLine(cand);
        else Console.WriteLine("nu exista");
    }
}
