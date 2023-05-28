using System;

class NQueensProblem
{
    static int N = 8; // Брой на цариците и размер на шахматната дъска
    static int[,] board = new int[N, N];

    static void Main()
    {
        SolveNQueens();
    }

    static void SolveNQueens()
    {
        if (PlaceQueens(0))
        {
            PrintBoard();
        }
        else
        {
            Console.WriteLine("Няма възможно решение за задачата.");
        }
    }

    static bool PlaceQueens(int col)
    {
        if (col >= N)
        {
            return true; // Всички царици са разположени успешно
        }

        for (int row = 0; row < N; row++)
        {
            if (IsSafe(row, col))
            {
                board[row, col] = 1; // Поставяме царица на текущата позиция

                if (PlaceQueens(col + 1))
                {
                    return true; // Разполагаме следващата царица успешно
                }

                board[row, col] = 0; // Отменяме разполагането на царицата (връщане назад)
            }
        }

        return false; // Няма възможно разполагане на царица в текущата колона
    }

    static bool IsSafe(int row, int col)
    {
        // Проверка на реда и колоната
        for (int i = 0; i < col; i++)
        {
            if (board[row, i] == 1)
            {
                return false;
            }
        }

        // Проверка на горния диагонал
        for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
        {
            if (board[i, j] == 1)
            {
                return false;
            }
        }

        // Проверка на долния диагонал
        for (int i = row, j = col; i < N && j >= 0; i++, j--)
        {
            if (board[i, j] == 1)
            {
                return false;
            }
        }

        return true; // Местоположението е безопасно за разполагане на царица
    }

    static void PrintBoard()
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}


