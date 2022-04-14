/* Есть число N. Сколько групп M, можно получить при разбиении всех чисел на группы, 
так чтобы в одной группе все числа были взаимно просты 
(все числа в группе друг на друга не делятся)? 
Найдите M при заданном N и получите одно из разбиений на группы N ≤ 10²⁰. */

// 1
// 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47
// 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
// 8 12 18 20 27 28 30 42 44 45 50
// 16 24 36 40
// 32 48

int N = 50;
int[] array = new int[N];
for(int m = 0; m < array.Length; m++)
{
    array[m] = m+1; // Делаем массив от 1 до 50
}

int[] info = new int[N];  // служебный массив для использованных чисел
int count = 1;
Console.Write($"{count}: ");
ArraySimpleNumbers(array);  // первая итерация
info = FillInfo(array);  // служебный архив
int start = FindStartNumber(info);  // ищем еще не встречающееся число

while(start != 0) // цикл, пока не останется необработанных чисел
{
    count++;
    array = FillNewArray(array, start);
    Console.Write($"{count}: ");
    ArraySimpleNumbers(array);
    FillInfo(array);
    start = FindStartNumber(info);
}


int[] ArraySimpleNumbers(int[] array) // Вычисляем взаимно простые числа
{
int i = 0;
int j = 0;

while (i < array.Length) // берем по очереди все цивры массива
{
    if(array[i] == 0)  // кроме 0
        {
            i ++;
            continue;
        }
    j = i+1;
    while(j < array.Length) // берем следующую цифру в массиве
    {
        if(array[j] == 0)  // кроме 0
        {
            j ++;
            continue;
        }
        if(array[j] % array[i] == 0) array[j] = 0; // вычисляем остаток и если число делится нацело - удаляем его из массива
        j++;
        
    }
    i++;
}

PrintString(array);
return array;
}

int[] FillNewArray(int[] array, int count) // заполняем массив с которым будем работать на следующей итерации
{
    int[] newarray = new int[array.Length];
    for(int n = count; n < array.Length; n++)
    {
        newarray[n] = n + 1; 
    }
    ReplaceDouble(newarray);  // убираем числа, которые уже встречались
    return newarray;
}


void PrintString(int[] arr)
{
    for(int i = 0; i < arr.Length; i++)
    {
        if(arr[i] != 0) Console.Write($"{arr[i]}, ");
    }
    Console.WriteLine();
}

int[] FillInfo(int[] array)  // Заполняем служебный архив
{
    for(int i = 0; i < array.Length; i++)
    {
        if(info[i] == 0) info[i] = array[i];
    }
    return info;
}

int FindStartNumber(int[] info)  // ищем индекс для старта рассчета
{
    int start = 0;
    for(int i = 0; i < info.Length; i++)
    {
        if(info[i] == 0) 
        {
            start = i;
            return start;
        }
    }
    return start;
}

int[] ReplaceDouble(int[] newarray)  // удаляем уже встречавшиеся числа
{
    for(int i = 0; i < newarray.Length; i++)
    {
        if(newarray[i] == info[i]) newarray[i] = 0;
    }
    return newarray;
}