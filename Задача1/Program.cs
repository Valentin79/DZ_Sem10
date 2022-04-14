/* Заданы 2 массива: info и data. В массиве info хранятся двоичные 
представления нескольких чисел (без разделителя). 
В массиве data хранится информация о количестве бит, 
которые занимают числа из массива info. Напишите программу, 
которая составит массив десятичных 
представлений чисел массива data с учётом информации из массива info. */

/* входные данные:
data = {0, 1, 1, 1, 1, 0, 0, 0, 1 }
info = {2, 3, 3, 1 }
выходные данные:
1, 7, 0, 1  */

int[] info = {0, 1, 1, 1, 1, 0, 0, 0, 1 };
int[] data = {2, 3, 3, 1 };
int count = 0;

for(int i = 0; i < data.Length; i++)
{
    int[] array = new int[data[i]];
    for(int j = 0; j < array.Length; j++)
    {
        array[j] = info[j+count];
        Console.Write($"{array[j]},");
    }
    count = count + data[i];
    Console.Write($" = {BinaryToDec(array)}");
    Console.WriteLine();

}

int BinaryToDec(int[] number)  // перевод двоичного в десятичное
{
    int result = 0;
    for (int i = 0; i < number.Length; i++)
    {
        result = result * 2 + number[i];
    }
    return result;
}

