#region part1
//Suma multiplilor de 3 || 5
int n = int.Parse(Console.ReadLine());
int sum = 0;
for (int i = 1; i < n; i++)
    if (i % 3 == 0 || i % 5 == 0)
        sum += i;
System.Console.WriteLine(sum);
#endregion part1

#region part2
//Sirul lui Fibonacci care intoarce suma numerelor pare < n;
int n = int.Parse(Console.ReadLine());
long a = 1, b = 1, s = 0;
while (a + b < n)
{
    long c = a + b;
    if (c % 2 == 0)
    {
        s += c;
    }
    a = b;
    b = c;
}
#endregion part2

#region part3
//Suma nr n numere prime
int n = int.Parse(Console.ReadLine());
int s = 0, c = 0, x = 2;
while (c < n)
{
    int ok = 1;
    for (int d = 2; d * d <= x; d++)
        if (x % d == 0) ok = 0;
    if (ok == 1) { s += x; c++; }
    x++;
}
System.Console.WriteLine(s);
#endregion part3

#region part4
//Vector sortat prin insertie
int n = int.Parse(Console.ReadLine());
int[] v = new int[n];

for (int i = 0; i < n; i++)
{
    v[i] = int.Parse(Console.ReadLine());
}

for (int i = 1; i < n; i++)
{
    int x = v[i];
    int j = i - 1;

    while (j >= 0 && v[j] > x)
    {
        v[j + 1] = v[j];
        j--;
    }
    v[j + 1] = x;
}
for(int i = 0; i < n; i++)
{
    Console.Write(v[i] + " ");
}
#endregion part4

#region part5
//True || False permutare circulara

string s = Console.ReadLine();
string t = Console.ReadLine();

bool ok = s.Length == t.Length && (s + s).Contains(t);

Console.WriteLine(ok);
#endregion part5

#region part6
//Combinarile multimii 1n luate cate k
int n = int.Parse(Console.ReadLine());
int k = int.Parse(Console.ReadLine());

void Bt(int[] a, int p, int start)
{
    if (p == k)
    {
        for (int i = 0; i < k; i++)
            Console.Write(a[i] + " ");
        Console.WriteLine();
        return;
    }

    for (int i = start; i <= n; i++)
    {
        a[p] = i;
        Bt(a, p + 1, i + 1);
    }
}

Bt(new int[k], 0, 1);
#endregion part 6
