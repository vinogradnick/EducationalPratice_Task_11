using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EducationPratice_Task_11
{
   public class Encrypt
    {
        /// <summary>
        /// Входная строка
        /// </summary>
        private string InputString { get; set; }
        private List<string[,]> EncryptionTable { get; set; }
        private int MatrixLength;
        private List<int> key;
        private Random rd = new Random();
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="text">входной текст</param>
        public Encrypt(string text)
        {
            InputString = text;//Входная строка
            key= new List<int>(InputString.Length/4);
            EncryptionTable=new List<string[,]>();
            MatrixLength = 10;
        }

        private void KeyGen()
        {
            for (int i = 0; i < 25; i++)
            {
               int number = rd.Next(1, 100);
                while (key.Contains(number))
                    number = rd.Next(1,100);
                key.Add(number);
            }
        }
        public void Encryption()
        {
            int[,]table = new int[MatrixLength,MatrixLength];
            table.Fill();
            PrintMatrix(table);
            KeyGen();
            table.KeyTableFill(key);
            PrintMatrix(table);


        }
       
     
   


        /// <summary>
        /// Поворот матрицы на 90 градусов
        /// </summary>
        /// <param name="matrix">входая матрица для поворота</param>
        /// <returns>матрица повернутая на 90 градусов</returns>
        static int[,] RotateMatrix(int[,] matrix)
        {
            int[,] rotated_matrix = new int[matrix.GetLength(1), matrix.GetLength(0)];//Перевернутая матрица

            for (int i = 0; i < matrix.GetLength(1); i++)
            for (int j = 0; j < matrix.GetLength(0); j++)
                rotated_matrix[i, j] = matrix[matrix.GetLength(0) - j - 1, i];
            return rotated_matrix;
        }

     
    
        /// <summary>
        /// Печать матрицы
        /// </summary>
        /// <param name="matrix">входная матрица</param>
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($" {matrix[i, j],2} ");
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write($" {matrix[i, j],2} ");
                }
                Console.WriteLine();
            }
        }

    }

    public static class EncryptTableExtension
    {
        public static int[,] Fill(this int[,] array)
        {


            int number = 1;
            for (int i = 0; i <array.GetLength(1); i++)
            {
                for (int j = 0; j <array.GetLength(0) ; j++)
                {
                    array[i, j] = number++;
                }   
            }

            return array;
        }

        public static int[,] KeyTableFill(this int[,]array, List<int> key)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            for (int j = 0; j < array.GetLength(0); j++)
                if (key.Contains(array[i, j]))
                    array[i, j] = 0;

            return array;
        }

        public static string[,] ConcatTables(this string[,] first, int[,] second)
        {
            for (int i = 0; i < first.GetLength(1); i++)
            {
                for (int j = 0; j < first.GetLength(0); j++)
                {
                    int number = -1;

                    bool status = int.TryParse(first[i,j], out number);
                    if (status && number == second[i, j])
                        first[i, j] = "0";
                }
            }

            return first;
        }
       
    }

}