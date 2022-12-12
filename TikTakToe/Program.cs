using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe
{
    class Program
    {
        const byte SIZE = 3; // размер поля
        
        static void showfield(byte[,] mas)
        {
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    Console.Write(mas[i, j]);
                }
                Console.WriteLine();
            }
        }

        static bool IsGameOver(byte[,] mas, byte player)
        {
            for (int j = 0; j < SIZE; j++) // проверка по вертикали и горизнтали
            {
                int k_str = 0;
                int k_stlb = 0;
                for (int i = 0; i < SIZE; i++)
                {
                    if (mas[j, i] == player)
                    {
                        k_str++;
                    }
                    if(mas[i, j] == player)
                    {
                        k_stlb++;
                    }
                if (k_str == SIZE)
                {

                        Console.WriteLine(player);
                        return true;
                }
                if(k_stlb == SIZE)
                {
                    return true;
                }
                }
            }

            // проверка по диагонали
            int k_maindiag = 0;
            int k_pobochdiag = 0;
            for (int i = 0; i < SIZE; i++)
            {
                if (mas[i, i] == player)
                {
                    k_maindiag++;
                }
                if(mas[i, SIZE - i -1] == player)
                {
                    k_pobochdiag++;
                }
            }
            if(k_maindiag == 3)
            {
                return true;
            }
            if(k_pobochdiag == 3)
            {
                return true;
            }

            return false;
        }

        static bool IsRightInput(out byte i, out byte j)
        {
            Console.WriteLine("Введите координты x и y вашего хода, в одной строке через пробел");
            string[] temp = Console.ReadLine().Split();
            byte x = Convert.ToByte(temp[0]);
            byte y = Convert.ToByte(temp[1]);
            if(x > 0 && x < 4 && y > 0 && y < 4)
            {
                i = (byte)(3 - y);
                j = (byte)(x - 1);
                return true;
            }
            else
            {
                i = byte.MaxValue;
                j = byte.MaxValue;
                return false;
            }
        }

        static int Game() // 1 или 2 победа игрока, 0 - ничья
        {
            byte[,] field = new byte[SIZE, SIZE];
            byte i, j;
            int steps = 0;
            byte player = 2; // ход крестиков
            showfield(field);
            while (!IsGameOver(field, player))
            {
                if(steps == SIZE * SIZE)
                {
                    return 0;
                }
                if (IsRightInput(out i, out j))
                {
                    if (field[i, j] == 0)
                    {
                        player = (byte)(player % 2 + 1); // переход к следующему игроку
                        field[i, j] = player;
                        steps++;
                        showfield(field);

                    }
                    else
                    {
                        Console.WriteLine("Поле занято");
                    }
                }
                else
                {
                    Console.WriteLine("Плохие координаты");
                }
            }
            return player;
        }
        
        static void Main(string[] args)
        {
            int result = Game();
            if(result == 0)
            {
                Console.WriteLine("Ничья");
            }
            else
            {
                Console.WriteLine("Победил - " + result);
            }
            
        }
    }
}
