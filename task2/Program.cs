// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

int[,] array = GetArray();
PrintArray(array);
MinSumElementsArr(array);


void MinSumElementsArr(int[,] arr)
{
    int sum = 0;
    int minSum = 0;
    int index = 0;
    for (int i = 0; i < arr.GetLength(1); i++)
    {
        minSum += arr[0, i];
    }

    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            sum += arr[i, j];
        }
        if (sum < minSum)
        {
            minSum = sum;
            index = i;
        }
        sum = 0;

    }
    System.Console.WriteLine($"Cтрока с наименьшей суммой элементов: {index + 1}");
}


void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}


int[,] GetArray()
{
    int rows = inputNumber("Введите размерность массива: ");
    int[,] arr = new int[rows, rows];
    Random rand = new();
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = rand.Next(0, 10);
        }
    }
    return arr;
}


int inputNumber(string textOutput)
{
    int number;

    while (true)
    {
        System.Console.Write(textOutput);
        string? textInput = Console.ReadLine();
        if (int.TryParse(textInput, out number))
        {
            break;
        }
        System.Console.WriteLine("Не удалось распознать число, попробуйте еще раз.");
    }
    return number;
}