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
        private int StringNumerator = 0;
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

            foreach (int item in key)
            {
                Console.Write($"{item}-");
            }
        }

        public string[,] FillCharMatrix(string[,] array)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            for (int j = 0; j < array.GetLength(0); j++)
            {
                int number = -1;
                bool status = int.TryParse(array[i, j], out number);
                if (status && number == 0)
                {
                    array[i, j] = InputString[StringNumerator].ToString();
                    StringNumerator++;
                }
            }
            Console.WriteLine(StringNumerator);

            return array;
        }
        public void Encryption()
        {
            int[,]keyTable = new int[MatrixLength,MatrixLength];

            keyTable.Fill();//Заполнение таблицы

            PrintMatrix(keyTable);//Печать матрицы

            KeyGen();//Генерация ключа

            keyTable.KeyTableFill(key);//Заполнение таблицы ключами
            Console.WriteLine();
            string[,] round1 = FillCharMatrix(keyTable.toStringTable());
            string[,] round2 = FillCharMatrix(keyTable.RotateMatrix().toStringTable());
            string[,] round3 = FillCharMatrix(keyTable.RotateMatrix().RotateMatrix().toStringTable());
            string[,] round4 = FillCharMatrix(keyTable.RotateMatrix().RotateMatrix().RotateMatrix().toStringTable());

            
            PrintMatrix(round1);
            PrintMatrix(round2);
            PrintMatrix(round3);
            PrintMatrix(round4);
            Console.WriteLine("Соеденение массивов");

            round1.ConcatTable(round2).ConcatTable(round3).ConcatTable(round4);
            
            PrintMatrix(round1);


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
            Console.WriteLine();
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

       
       

        public static string[,] ConcatTable(this string[,] first, string[,] second)
        {
            for (int i = 0; i < first.GetLength(1); i++)
            for (int j = 0; j < first.GetLength(0); j++)
                if(first[i, j].Check()==true && Check(second[i, j])==false)
                    first[i, j] = second[i, j];

            return first;
        }

        public static bool Check(this string text)
        {
            int number = -1;
            return int.TryParse(text, out number);
        }
        public static string[,] CopyTable(this string[,] array, int[,] matrix)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            for (int j = 0; j < array.GetLength(0); j++)
                array[i, j] = matrix[i, j].ToString();

            return array;
        }

        /// <summary>
        /// Поворот матрицы на 90 градусов
        /// </summary>
        /// <param name="matrix">входая матрица для поворота</param>
        /// <returns>матрица повернутая на 90 градусов</returns>
        public static int[,] RotateMatrix(this int[,] matrix)
        {
            int[,] rotated_matrix = new int[matrix.GetLength(1), matrix.GetLength(0)];//Перевернутая матрица

            for (int i = 0; i < matrix.GetLength(1); i++)
            for (int j = 0; j < matrix.GetLength(0); j++)
                rotated_matrix[i, j] = matrix[matrix.GetLength(0) - j - 1, i];
            return rotated_matrix;
        }
        public static string[,] RotateMatrix(this string[,] matrix)
        {
            string[,] rotated_matrix = new string[matrix.GetLength(1), matrix.GetLength(0)];//Перевернутая матрица

            for (int i = 0; i < matrix.GetLength(1); i++)
                for (int j = 0; j < matrix.GetLength(0); j++)
                    rotated_matrix[i, j] = matrix[matrix.GetLength(0) - j - 1, i];
            return rotated_matrix;
        }

        public static string[,] toStringTable(this int[,] table)
        {
            string[,] temp= new string[table.GetLength(1),table.GetLength(0)];
            for (int i = 0; i < temp.GetLength(1); i++)
            {
                for (int j = 0; j < temp.GetLength(0); j++)
                    temp[i, j] = table[i, j].ToString();
            }

            return temp;
        }

    }

}