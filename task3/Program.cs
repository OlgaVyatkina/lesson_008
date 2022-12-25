// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18


int rows = inputNumber("Введите размерность массива М = ");
int colums = inputNumber("Введите размерность массива N = ");

int[,] arrayOne = GetArray(rows, colums);
int[,] arraySecond = GetArray(rows, colums);


PrintArray("Первая матрица: ", arrayOne);
PrintArray("Вторая матрица: ", arraySecond);
PrintArray("Произведение матриц: ", ArrSortToLower(arrayOne, arraySecond));


int[,] GetArray(int rows, int colums)
{
    int[,] arr = new int[rows, colums];
    Random rand = new();
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = rand.Next(1, 5);
        }
    }
    return arr;
}


int[,] ArrSortToLower(int[,] arrOne, int[,] arrSecond)
{
    int[,] array3 = new int[rows, colums];
    for (int i = 0; i < arrOne.GetLength(1); i++)
    {
        for (int j = 0; j < arrOne.GetLength(1); j++)
        {
            for (int k = 0; k < arrSecond.GetLength(1); k++)
            {
                array3[i, j] += arrOne[i, k] * arrSecond[k, j];
            }
        }

    }
    return array3;
}


void PrintArray(string textOutput, int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            System.Console.Write(arr[i, j] + " ");
        }
        System.Console.WriteLine();
    }
    System.Console.WriteLine();
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