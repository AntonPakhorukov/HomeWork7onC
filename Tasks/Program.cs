/*
Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
m = 3, n = 4.
0,5 7 -2 -0,2
1 -3,3 8 -9,9
8 7,8 -7,1 9

Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, 
и возвращает значение этого элемента или же указание, что такого элемента нет.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
17 -> такого числа в массиве нет

Задача 52. Задайте двумерный массив из целых чисел. 
Найдите среднее арифметическое элементов в каждом столбце.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

Дополнительная задача (54): Задайте двумерный массив из целых чисел. Определите, 
есть столбец в массиве, сумма которого, больше суммы элементов расположенных
в четырех "углах" двумерного массива.
Например, задан массив:
4 4 7 5
4 3 5 3
8 1 6 8 -> нет
2 4 7 2
4 3 5 3
2 1 6 2 -> да

Дополнительная задача 2 (56): Вывести первые n строк треугольника Паскаля. 
    Реализовать вывод в виде равнобедренного треугольника.
    N = 7 -> https://ibb.co/yWPZbG7
*/
Console.Clear();
Console.Write("Введите номер задачи: ");
int task = Convert.ToInt32(Console.ReadLine());
switch (task)
{
    case 47:
        Task47();
        break;
    case 50:
        Task50();
        break;
    case 52:
        Task52();
        break;
    case 54:
        Task54();
        break;
    case 56:
        Task56();
        break;
}
int[,] GetArray()
{
    Console.Write("Введите количество строк для двумерного массива: ");
    int row = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите количество столбцов для двумерного массива: ");
    int column = Convert.ToInt32(Console.ReadLine());
    int[,] array = new int[row, column];
    return array;
}
double[,] GetDoubleArray()
{
    Console.Write("Введите количество строк для двумерного массива: ");
    int rowDouble = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите количество столбцов для двумерного массива: ");
    int columnDouble = Convert.ToInt32(Console.ReadLine());
    double[,] array = new double[rowDouble, columnDouble];
    return array;
}
void PrintArray(int[,] inputArray)
{
    for (int i = 0; i < inputArray.GetLength(0); i++)
    {
        for (int j = 0; j < inputArray.GetLength(1); j++)
        {
            Console.Write(inputArray[i, j] + " ");
        }
        Console.WriteLine();
    }
}
void PrintDouble(double[,] newArray)
{
    for (int i = 0; i < newArray.GetLength(0); i++)
    {
        for (int j = 0; j < newArray.GetLength(1); j++)
        {
            Console.Write(newArray[i, j] + " ");
        }
        Console.WriteLine();
    }
}
int[,] GetRandomArray(int[,] inputArray)
{
    for (int i = 0; i < inputArray.GetLength(0); i++)
    {
        for (int j = 0; j < inputArray.GetLength(1); j++)
        {
            inputArray[i, j] = new Random().Next(1, 10);
        }
    }
    return inputArray;
}
double[,] GetRandomDoubleArray(double[,] inputArray)
{
    //double[,] array = new double[row, column];
    for (int i = 0; i < inputArray.GetLength(0); i++)
    {
        for (int j = 0; j < inputArray.GetLength(1); j++)
        {
            inputArray[i, j] = Math.Round(Convert.ToDouble(new Random().Next(-10, 10)) + new Random().NextDouble(), 2);
        }
    }
    return inputArray;
}

void Task47()
{
    /*
    Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
    m = 3, n = 4.
    0,5 7 -2 -0,2
    1 -3,3 8 -9,9
    8 7,8 -7,1 9
    */
    Console.Clear();
    double[,] arrayDouble = GetDoubleArray();
    arrayDouble = GetRandomDoubleArray(arrayDouble);
    PrintDouble(arrayDouble);
}
void Task50()
{
    /*
    Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, 
    и возвращает значение этого элемента или же указание, что такого элемента нет.
    Например, задан массив:
    1 4 7 2
    5 9 2 3
    8 4 2 4
    17 -> такого числа в массиве нет
    */
    int[,] array = GetArray();
    array = GetRandomArray(array);
    Console.Clear();
    PrintArray(array);
    Console.Write("Введите номер позиции элемента в строке (в формате '3,5'): ");
    int[] index = Array.ConvertAll(Console.ReadLine().Split(","), int.Parse);
    Console.WriteLine("[" + String.Join(", ", index) + "]");
    void PrintIndex(int[,] array, int[] index)
    {
        if (array.GetLength(0) > index[0] && array.GetLength(1) > index[1])
        {
            Console.WriteLine(array[index[0], index[1]]);
        }
        else
        {
            Console.WriteLine("Такого числа нет в массиве");
            return;
        }
    }
    PrintIndex(array, index);
}
void Task52()
{
    /*
    Задача 52. Задайте двумерный массив из целых чисел. 
    Найдите среднее арифметическое элементов в каждом столбце.
    Например, задан массив:
    1 4 7 2
    5 9 2 3
    8 4 2 4
    Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
    */
    int[,] array = GetArray();
    array = GetRandomArray(array);
    PrintArray(array);
    Console.WriteLine();
    void GetAverege(int[,] inputArray)
    {
        double[] averege = new double[inputArray.GetLength(0)];
        for (int i = 0; i < inputArray.GetLength(0); i++)
        {
            for (int j = 0; j < inputArray.GetLength(1); j++)
            {
                averege[i] = averege[i] + inputArray[i, j];
            }
            Console.Write(averege[i] / inputArray.GetLength(1) + "; ");
        }
    }
    GetAverege(array);
}
void Task54()
{
    /*
    Дополнительная задача (54): Задайте двумерный массив из целых чисел. Определите, 
    есть столбец в массиве, сумма которого, больше суммы элементов расположенных
    в четырех "углах" двумерного массива.
    Например, задан массив:
    4 4 7 5
    4 3 5 3
    8 1 6 8 -> нет
    2 4 7 2
    4 3 5 3
    2 1 6 2 -> да
    */
    Console.Clear();
    int[,] array = GetArray();
    array = GetRandomArray(array);
    Console.Clear();
    PrintArray(array);
    Console.WriteLine();
    int[] GetNewArray(int[,] inputArray)
    {
        int[] newArray = new int[inputArray.GetLength(1)];
        for (int i = 0; i < inputArray.GetLength(1); i++)
        {
            for (int j = 0; j < inputArray.GetLength(0); j++)
            {
                newArray[i] = newArray[i] + inputArray[j, i];
            }
        }
        return newArray;
    }
    int[] arrayNew = GetNewArray(array);
    //Console.WriteLine("Сумма чисел в столбцах = " + String.Join(", ", arrayNew));
    int GetFourValues(int[,] inputArray)
    {
        int result = 0;
        for (int i = 0; i < inputArray.GetLength(0); i = i + (inputArray.GetLength(0) - 1))
        {
            for (int j = 0; j < inputArray.GetLength(1); j = j + (inputArray.GetLength(1) - 1))
            {
                result = result + inputArray[i, j];
            }
        }
        return result;
    }
    int sum = GetFourValues(array);
    //Console.WriteLine($"Сумма чисел в 4-х углах = {sum}");
    void GetResult(int[] inputArray, int number)
    {
        for (int i = 0; i < arrayNew.Length; i++)
        {
            if (arrayNew[i] > sum)
            {
                Console.WriteLine("Да");
                return;
            }
        }
        Console.WriteLine("Нет");
    }
    GetResult(arrayNew, sum);

}
void Task56()
{
    /*
    Дополнительная задача 2 (56): Вывести первые n строк треугольника Паскаля. 
    Реализовать вывод в виде равнобедренного треугольника.
    N = 7 -> https://ibb.co/yWPZbG7
    */
    

}
