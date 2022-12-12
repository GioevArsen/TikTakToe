using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe
{
    class Program
    {
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

        static bool IsGameOver(byte[,] mas)
        {
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

        static void Main(string[] args)
        {
            byte[,] field = new byte[3, 3];
            byte i, j;
            byte player = 1; // ход крестиков
            showfield(field);
            while (!IsGameOver(field))
            {
                if(IsRightInput(out i, out j))
                {
                    field[i, j] = player;
                    showfield(field);
                    player = (byte)(player % 2 + 1); // переход к следующему игроку
                }
                else
                {
                    Console.WriteLine("Плохие координаты");
                }
            }
        }
    }
}
