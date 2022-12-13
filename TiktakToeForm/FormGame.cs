using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiktakToeForm
{
    public partial class FormGame : Form
    {
        const int SIZE = 3;
        byte[,] field = new byte[SIZE, SIZE];
        string[] GameEnd = { "ничья", "крестики", "нолики" };
        int steps = 0;
        byte player = 2; // ход крестиков или ноликов

        void showfield(byte[,] mas)
        {
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if(mas[i,j] == 1)
                    {
                        dataGridViewField.Rows[i].Cells[j].Value = "X";
                    }
                    else
                    {
                        if(mas[i,j] == 2)
                        {
                            dataGridViewField.Rows[i].Cells[j].Value = "O";
                        }
                    }
                }
            }
        }

        public FormGame()
        {
            InitializeComponent();
            for (int i = 0; i < SIZE; i++)
            {
                dataGridViewField.Rows.Add();
            }
            //field[1, 1] = 1;
            //field[2, 2] = 2;
            
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
                    if (mas[i, j] == player)
                    {
                        k_stlb++;
                    }
                    if (k_str == SIZE)
                    {

                        Console.WriteLine(player);
                        return true;
                    }
                    if (k_stlb == SIZE)
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
                if (mas[i, SIZE - i - 1] == player)
                {
                    k_pobochdiag++;
                }
            }
            if (k_maindiag == 3)
            {
                return true;
            }
            if (k_pobochdiag == 3)
            {
                return true;
            }

            return false;
        }


        private void dataGridViewField_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.RowIndex + " " + e.ColumnIndex);
            if (field[e.RowIndex, e.ColumnIndex] == 0)
            {
                player = (byte)(player % 2 + 1); // переход к следующему игроку
                field[e.RowIndex, e.ColumnIndex] = player;
                steps++;
                showfield(field);
                if(IsGameOver(field, player))
                {
                    MessageBox.Show("Победили - " + GameEnd[player]);
                }
                else
                {
                    if(steps == 9)
                    {
                        MessageBox.Show("Ничья");
                    }
                }

            }
            else
            {
                MessageBox.Show("Место занято");
            }

        }
    }
}
