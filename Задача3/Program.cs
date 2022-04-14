/* Напишите программу вычисления функции Аккермана с помощью рекурсии. 
Даны два неотрицательных числа m и n. 
m = 3, n = 2 -> A(m,n) = 29 */

int Akkerman(int m, int n)
{
    if (m == 0) return n + 1;
    if (m != 0 && n == 0) return Akkerman(m - 1, 1);
    if (m > 0 && n > 0) return Akkerman(m - 1, Akkerman(m, n - 1));
    return Akkerman(m,n);
}

Console.WriteLine(Akkerman(3,2));


/* A(0,n) = n+1
   A(m,0) = A(m-1,1)
   A(m,n) = A(m-1,A(m,n-1)) */