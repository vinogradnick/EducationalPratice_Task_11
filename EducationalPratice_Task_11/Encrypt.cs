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
        private int StringNumerator = 0;//Перечислитель строки
        private Random rd = new Random();
        /// <summary>
        /// Выходная таблица строк
        /// </summary>
        public string[,] OutputTable { get; set; }
        /// <summary>
        /// Таблица для шифрования
        /// </summary>
        public  int[,] EncryptKey = new int[10, 10]
        {
            { 1, 1, 0, 1, 1, 1, 1, 0, 1, 1},
            { 1, 1, 1, 0, 1, 1, 1, 1, 1, 1},
            { 1, 1, 1, 0, 1, 1, 1, 0, 0, 1},
            { 1, 1, 0, 1, 1, 1, 1, 1, 1, 0},
            { 0, 1, 1, 0, 1, 1, 0, 1, 1, 0},
            { 1, 0, 0, 1, 0, 1, 1, 0, 0, 1},
            { 1, 1, 1, 0, 1, 1, 1, 1, 1, 0},
            { 1, 1, 1, 1, 1, 1, 1, 1, 0, 1},
            { 0, 1, 1, 0, 1, 1, 1, 1, 0, 0},
            { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1}
        };

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="text">входной текст</param>
        public Encrypt()
        {

        }
        public Encrypt(string text)
        {
            InputString = text;//Входная строка
        }
        /// <summary>
        /// Расшифрование таблицы 
        /// </summary>
        /// <param name="textStrings">Таблица строк</param>
        /// <param name="keyEncryptKey"> Ключ таблица для расшифрования</param>
        public Encrypt(string[,] textStrings, int[,] keyEncryptKey)
        {
            if (textStrings != null)
            {
                OutputTable = textStrings;

            }
            else
            {
                Console.WriteLine("Выходная таблица пуста");
            }

            if (CheckTable(keyEncryptKey))
            {
                EncryptKey = keyEncryptKey;
            }
            else
                Console.WriteLine("Ключ-таблица неправильная");
        }
        /// <summary>
                /// Проверка таблицы ключей на правильность
                /// </summary>
        public bool CheckTable(int[,] key)
        {
            int [,] temp = new int[10,10];
            for (int g = 0; g < key.GetLength(1); g++)
            {
                for (int i = 0; i < key.GetLength(1); i++)
                {
                    for (int j = 0; j < key.GetLength(1); j++)
                    {
                        if (key[i, j] == 0)
                        {
                            temp[i, j] = key[i, j];
                        }
                    }
                }
                key.RotateMatrix();
;            }
            /* Проверка таблицы на ненужные элементы */
            for (int i = 0; i < key.GetLength(1); i++)
            {
                for (int j = 0; j < key.GetLength(1); j++)
                {
                    if (temp[i, j] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        /// <summary>
        /// Расшифрование текста
        /// </summary>
        /// <param name="textStrings"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public string Decrypt()
        {
            string result = "";
            for (int counterIndex = 0; counterIndex < 4; counterIndex++)//Просчет количества поворотов таблицы
            {

                for (int i = 0; i < OutputTable.GetLength(1); i++)
                {
                    for (int j = 0; j < OutputTable.GetLength(0); j++)
                    {
                        if (EncryptKey[i, j] == 0 && OutputTable[i, j] != "0")//Проверка на соответствие матрицы и чисео
                        {
                            
                            result=result+ OutputTable[i, j];
                            Console.WriteLine(result);
                            OutputTable[i, j] = "0";
                        }
                    }
                }
               EncryptKey=EncryptKey.RotateMatrix();//Поворот матрицы
            }
            return result;
        }
        /// <summary>
        /// Заполнение матрицы символами
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public string[,] FillCharMatrix(string[,] array)
        {
            int count = 0;
            for (int i = 0; i < array.GetLength(1); i++)
            for (int j = 0; j < array.GetLength(0); j++)
            {
                int number = -1;
                bool status = int.TryParse(array[i, j], out number);
                if (status && number == 0)
                {
                    array[i, j] = InputString[StringNumerator].ToString();
                    StringNumerator++;
                    Console.WriteLine(StringNumerator+" "+ array[i,j]);
                    count++;
                }
            }
            Console.WriteLine();
            Console.WriteLine(count);
            return array;
        }
        /// <summary>
        /// Шифровка текста по заданой матрице ключей
        /// </summary>
        public void Encryption()
        {
            string[,] round1 = FillCharMatrix(EncryptKey.toStringTable());
            Console.WriteLine("2");
            string[,] round2 = FillCharMatrix(EncryptKey.RotateMatrix().toStringTable());
            Console.WriteLine("3");

            string[,] round3 = FillCharMatrix(EncryptKey.RotateMatrix().RotateMatrix().toStringTable());
            Console.WriteLine("4");

            string[,] round4 = FillCharMatrix(EncryptKey.RotateMatrix().RotateMatrix().RotateMatrix().toStringTable());

            
            PrintMatrix(round1);
            PrintMatrix(round2);
            PrintMatrix(round3);
            PrintMatrix(round4);
            Console.WriteLine("Соеденение массивов");

            round1.ConcatTable(round2).ConcatTable(round3).ConcatTable(round4);
            OutputTable = round1;
            PrintMatrix(OutputTable);


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