// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07


int rows = inputNumber("Введите размерность массива: ");
int colums = rows;
int[,] array = GetArray();
PrintArray(array);
PrintArray(FillArraySpiral(rows, colums));


int[,] FillArraySpiral(int row, int col)
{
    int[,] arr = new int[row, col];
    int startCol = 0;
    int endCol = row - 1;
    int startRow = 0;
    int endRow = col - 1;
    int count = 0;
    while (startCol <= endCol && startRow <= endRow)
    {
        for (int i = startCol; i <= endCol; i++)
        {
            arr[startRow, i] = count;
            count++;
        }
        startRow++;
        for (int k = startRow; k <= endRow; k++)
        {
            arr[k, endCol] = count;
            count++;
        }
        endCol--;
        for (int t = endCol; t >= startCol; t--)
        {
            arr[endRow, t] = count;
            count++;
        }
        endRow--;
        for (int r = endRow; r >= startRow; r--)
        {
            arr[r, startCol] = count;
            count++;
        }
        startCol++;
    }
    return arr;
}



int[,] GetArray()
{
    int[,] arr = new int[rows, colums];
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


void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] < 10)
            {
                Console.Write(array[i, j]);
                Console.Write("  ");
            }
            else Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
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