
// Задачу закончила, вроде бы. Но есть вопрос. Можно ли как то ее оптимизировать? Сократить запись и т.д. Заранее спасибо ))   


int[,] array = GetArray();
PrintArray(array);
PrintArray(Spiralka(array));


int[,] Spiralka(int[,] array) 
{
    int startCol = 0;
    int endCol = array.GetLength(0) - 1;
    int startRow = 0;
    int endRow = array.GetLength(1) - 1;
    int count = 1;
    int i = 0;
    while (i <= array.GetLength(0))
    {
        ArrSpiralRight(ref count, startRow + i, endRow - i, startCol + i, endCol - i);
        ArraySpiralLeft(ref count, startRow + i, endRow - i, startCol + i, endCol - i);
        i++;
    }
    return array;


    void ArrSpiralRight(ref int count, int startRow, int endRow, int startCol, int endCol) // (локальная функция) движение право
    {

        if (startCol < endCol)
        {
            array[startRow, startCol] = count;
            count++;
            ArrSpiralRight(ref count, startRow, endRow, startCol + 1, endCol);

        }
        else
        if (startRow < endRow)
        {
            array[startRow, endCol] = count;
            count++;
            ArrSpiralRight(ref count, startRow + 1, endRow, startCol, endCol);
        }
    }

    void ArraySpiralLeft(ref int count, int startRow, int endRow, int startCol, int endCol) // (локальная функция) движение влево
    {

        if (endCol > startCol)
        {
            array[endRow, endCol] = count;
            count++;
            ArraySpiralLeft(ref count, startRow, endRow, startCol, endCol - 1);

        }
        else
        if (endRow > startRow)
        {
            array[endRow, startCol] = count;
            count++;
            ArraySpiralLeft(ref count, startRow, endRow - 1, startCol, endCol);
        }

    }
}

int[,] GetArray()
{
    int row = inputNumber("Введите размерность массива: ");
    int col = row;
    int[,] arr = new int[row, col];
    Random rand = new();
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = rand.Next(0, 1);
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



// int[,] Reverse(int[,] array)  //поворот массива на 90 градусов
// {
//     int[,] new_arr = new int[array.GetLength(0), array.GetLength(1)];
//     for (int i = 0; i < array.GetLength(0); i++)
//     {
//         for (int j = 0; j < array.GetLength(1); j++)
//         {
//             new_arr[i, j] = array[j, (array.GetLength(1) - 1 - i)];
//         }
//     }
//     return new_arr;
// }