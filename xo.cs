using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_7_8
{
    class Cross
    {
        static int size_win = 2;
        static int size_x = 3;
        static int size_y = 3;

        static char[,] field = new char[size_x, size_y];

        static char player_dot = 'X';
        static char al_dot = 'O';
        static char empty_dot = '.';

        static Random random = new Random();

        private static void Field()
        {
            for (int i = 0; i < size_x; i++)
            {
                for (int j = 0; j < size_y; j++)
                {
                    field[i, j] = empty_dot;
                }
            }
        }

        private static void PrintField()
        {
            Console.Clear();
            Console.WriteLine("******");
            for (int i = 0; i < size_x; i++)
            {
                Console.Write("|");
                for (int j = 0; j < size_y; j++)
                {
                    Console.Write(field[i, j] + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("******");
        }
        static void Main(string[] args)
        {
            Field();
            PrintField();
            do
            {
                player();
                Console.WriteLine("Ваш ход на поле");
                PrintField();
                if (CheckWin(player_dot))
                {
                    Console.WriteLine("Вы выиграли");
                    break;
                }
                else if (IsFieldFull()) break;
                AiMove();
                Console.WriteLine("Ход Компа на поле");
                PrintField();
                if (CheckWin(al_dot))
                {
                    Console.WriteLine("Выиграли Комп");
                    break;
                }
                else if (IsFieldFull()) break;
            } while (true);
            Console.WriteLine("!Конец игры!");
        }

        private static void SetSum(int y, int x, char sum)
        {
            field[y, x] = sum;
        }

        private static bool IsCellValid(int x, int y)
        {
            if (x < 0 || y < 0 || x > size_x - 1 || y > size_y - 1)
            {
                return false;
            }
            return field[x, y] == empty_dot;
        }

        private static bool IsFieldFull()
        {
            for (int i = 0; i < size_x; i++)
            {
                for (int j = 0; j < size_y; j++)
                {
                    if (field[i, j] == empty_dot)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        //Ход человева
        private static void player()
        {
            int x, y;

            do
            {
                Console.WriteLine("Введите координаты вашего хода в диапозоне от 1 до " + size_x);
                Console.WriteLine("Координат по строке ");
                x = Int32.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Координат по столбцу ");
                y = Int32.Parse(Console.ReadLine()) - 1;
            }
            while (!IsCellValid(x, y));
            SetSum(y, x, player_dot);
        }

        //Ход компьютера
        private static void AiMove()
        {
            int x, y;
            //блокировка ходов человека
            for (int v = 0; v < size_y; v++)
            {
                for (int h = 0; h < size_x; h++)
                {
                    //анализ наличие поля для проверки
                    if (h + size_win <= size_x)
                    {                           //по горизонтале
                        if (CheckLineHorisont(v, h, player_dot) == size_win - 1)
                        {
                            if (MoveAiLineHorisont(v, h, al_dot)) return;
                        }

                        if (v - size_win > -2)
                        {                            //вверх по диагонале
                            if (CheckDiaUp(v, h, player_dot) == size_win - 1)
                            {
                                if (MoveAiDiaUp(v, h, al_dot)) return;
                            }
                        }
                        if (v + size_win <= size_y)
                        {                       //вниз по диагонале
                            if (CheckDiaDown(v, h, player_dot) == size_win - 1)
                            {
                                if (MoveAiDiaDown(v, h, al_dot)) return;
                            }
                        }
                    }
                    if (v + size_win <= size_y)
                    {                       //по вертикале
                        if (CheckLineVertical(v, h, player_dot) == size_win - 1)
                        {
                            if (MoveAiLineVertical(v, h, al_dot)) return;
                        }
                    }
                }
            }
            //игра на победу
            for (int v = 0; v < size_y; v++)
            {
                for (int h = 0; h < size_x; h++)
                {
                    //анализ наличие поля для проверки
                    if (h + size_win <= size_x)
                    {                           //по горизонтале
                        if (CheckLineHorisont(v, h, al_dot) == size_win - 1)
                        {
                            if (MoveAiLineHorisont(v, h, al_dot)) return;
                        }

                        if (v - size_win > -2)
                        {                            //вверх по диагонале
                            if (CheckDiaUp(v, h, al_dot) == size_win - 1)
                            {
                                if (MoveAiDiaUp(v, h, al_dot)) return;
                            }
                        }
                        if (v + size_win <= size_y)
                        {                       //вниз по диагонале
                            if (CheckDiaDown(v, h, al_dot) == size_win - 1)
                            {
                                if (MoveAiDiaDown(v, h, al_dot)) return;
                            }
                        }

                    }
                    if (v + size_win <= size_y)
                    {                       //по вертикале
                        if (CheckLineVertical(v, h, al_dot) == size_win - 1)
                        {
                            if (MoveAiLineVertical(v, h, al_dot)) return;
                        }
                    }
                }
            }

        }

        //ход компьютера по горизонтале
        private static bool MoveAiLineHorisont(int v, int h, char dot)
        {
            for (int j = h; j < size_win; j++)
            {
                if ((field[v, j] == empty_dot))
                {
                    field[v, j] = dot;
                    return true;
                }
            }
            return false;
        }
        //ход компьютера по вертикале
        private static bool MoveAiLineVertical(int v, int h, char dot)
        {
            for (int i = v; i < size_win; i++)
            {
                if ((field[i, h] == empty_dot))
                {
                    field[i, h] = dot;
                    return true;
                }
            }
            return false;
        }
        //проверка заполнения всей линии по диагонале вверх

        private static bool MoveAiDiaUp(int v, int h, char dot)
        {
            for (int i = 0, j = 0; j < size_win; i--, j++)
            {
                if ((field[v + i, h + j] == empty_dot))
                {
                    field[v + i, h + j] = dot;
                    return true;
                }
            }
            return false;
        }
        //проверка заполнения всей линии по диагонале вниз

        private static bool MoveAiDiaDown(int v, int h, char dot)
        {

            for (int i = 0; i < size_win; i++)
            {
                if ((field[i + v, i + h] == empty_dot))
                {
                    field[i + v, i + h] = dot;
                    return true;
                }
            }
            return false;
        }

        //проверка заполнения всей линии по диагонале вверх

        private static int CheckDiaUp(int v, int h, char dot)
        {
            int count = 0;
            for (int i = 0, j = 0; j < size_win; i--, j++)
            {
                if ((field[v + i, h + j] == dot)) count++;
            }
            return count;
        }
        //проверка заполнения всей линии по диагонале вниз

        private static int CheckDiaDown(int v, int h, char dot)
        {
            int count = 0;
            for (int i = 0; i < size_win; i++)
            {
                if ((field[i + v, i + h] == dot)) count++;
            }
            return count;
        }

        private static int CheckLineHorisont(int v, int h, char dot)
        {
            int count = 0;
            for (int j = h; j < size_win + h; j++)
            {
                if ((field[v, j] == dot)) count++;
            }
            return count;
        }
        //проверка заполнения всей линии по вертикале
        private static int CheckLineVertical(int v, int h, char dot)
        {
            int count = 0;
            for (int i = v; i < size_win + v; i++)
            {
                if ((field[i, h] == dot)) count++;
            }
            return count;
        }

        //проверка победы
        private static bool CheckWin(char dot)
        {
            for (int v = 0; v < size_y; v++)
            {
                for (int h = 0; h < size_x; h++)
                {
                    //анализ наличие поля для проверки
                    if (h + size_win <= size_x)
                    {                           
                        if (CheckLineHorisont(v, h, dot) >= size_win)
                            return true;

                        if (v - size_win > -2)
                        {                            
                            if (CheckDiaUp(v, h, dot) >= size_win)
                                return true;
                        }
                        if (v + size_win <= size_y)
                        {                       
                            if (CheckDiaDown(v, h, dot) >= size_win)
                                return true;
                        }
                    }
                    if (v + size_win <= size_y)
                    {                       
                        if (CheckLineVertical(v, h, dot) >= size_win)
                            return true;
                    }
                }
            }
            return false;
        }
        
    }
}
