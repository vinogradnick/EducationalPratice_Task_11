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
        private static int InputNumerator=0;
        private const int MatrixLength = 5;//Размерность кодируемой матрицы
        private List<string[,]> EncryptionTable { get; set; }
        private List<int> keysList= new List<int>();
        private static Random rd= new Random();
        private static int keycount = 0;
        /// <summary>
        /// Перечислитель списка ключей
        /// </summary>
        private static int KeyNumerator = 0;

        private static int n;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="text">входной текст</param>
        public Encrypt(string text)
        {
            InputString = text;//Входная строка
            EncryptionTable=new List<string[,]>();
        }
        /// <summary>
        /// Генерация массива ключей для поиска
        /// </summary>
        /// <returns></returns>
        public List<int> keyGenerate()
        {
            n = keycount == 3 ? 7 : 6;
            for (int i = 0; i < n; i++)
            {
                int number = rd.Next(1, 26);

                while (keysList.Contains(number))
                    number = rd.Next(1, 26);
                keysList.Add(number);
            }

            keycount++;
            return keysList;
        }
        /// <summary>
        /// Заполнение матрицы числами
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int[,] FillMatrixNumbers(int[,] matrix)
        {
            int number = 1;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrix[i, j] = number++;
                }
            }
            return matrix;
        }

        public void GeneratePrintKeys()
        {
            foreach (int item in this.keyGenerate())
                Console.WriteLine(item);
        }

        public int[,] PartMatrix()
        {
            GeneratePrintKeys();
            int[,] part = new int[MatrixLength, MatrixLength];
            int[] key = new int[n];

            Array.Copy(keysList.ToArray(),KeyNumerator,key,0,n);
            Console.WriteLine("Ключи");
        
            foreach (int item in key)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            KeyNumerator += n;
            
            KeyFill(FillMatrixNumbers(part),key.ToList());
            PrintMatrix(part);
            return part;
        }

        string[,] MatrixFillChars(int[,] matrix)
        {
            string[,] temp = new string[matrix.GetLength(1),matrix.GetLength(0)];
            

            for (int i = temp.GetLength(1) - 1; i >= 0; i--)
            {
                for (int j = 0; j < temp.GetLength(0); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        temp[i, j] = InputString[InputNumerator].ToString();
                        InputNumerator++;
                        Console.WriteLine(temp[i,j] +" "+InputNumerator);
                    }
                    else
                        temp[i, j] = matrix[i, j].ToString();
                }
            }
            return temp;
        }

        string[,] MatrixFillChars(string[,] matrix)
        {
            string[,] temp = new string[matrix.GetLength(1), matrix.GetLength(0)];
                for (int i = temp.GetLength(1) - 1; i >= 0; i--)
                {
                    for (int j = 0; j < temp.GetLength(0); j++)
                    {
                        if (Intparse(matrix[i, j]) == 0)
                        {
                            temp[i, j] = InputString[InputNumerator].ToString();
                            Console.WriteLine(temp[i, j]+" "+InputNumerator);
                            InputNumerator++;
                        }
                        else
                            temp[i, j] = matrix[i, j];
                    }
                }
            return temp;
        }

        string[,] ConcatMatrix(string[,] first, int[,] second)
        {
            for (int i = 0; i < first.GetLength(1); i++)
            {
                for (int j = 0; j < first.GetLength(0); j++)
                {
                    int res = 0;
                    if (second[i, j] == 0)
                        first[i, j] = "0";
                }
            }

            return first;
        }

        bool parse(string obj)
        {
            if (obj is null) return false;
            Console.WriteLine(obj);
            int res = 0;
            return int.TryParse(obj.ToString(),out res);
        }
        int Intparse(string obj)
        {
            
            Console.WriteLine(obj);
            int res = 0;
            int.TryParse(obj.ToString(), out res);
            return res;
        }
        public void Encryption()
        {
            /*
             * Матрица обычная, заполняем нулями по ключам
             *
             */
           

            int[,] basic = BuildEncryptMatrix(PartMatrix(), PartMatrix(), PartMatrix(), PartMatrix());
            Console.WriteLine("Шараш-матрица-монтаж");
            int[,] matrix90 = RotateMatrix(basic);
            int[,] matrix180 = RotateMatrix(matrix90);
            int[,] matrix270 = RotateMatrix(matrix180);
            Console.WriteLine("basic");
            PrintMatrix(basic);
            Console.WriteLine("matrix 90");
            PrintMatrix(matrix90);
            Console.WriteLine("matrix 180");
            PrintMatrix(matrix180);
            Console.WriteLine("matrix 270");
            PrintMatrix(matrix270);
          

        }
        
        /// <summary>
        /// Заполнение матрицы ключами
        /// </summary>
        /// <param name="array">матрица для шифрования</param>
        /// <param name="key">массив ключей для шифрования данного массива</param>
        /// <returns></returns>
        static int[,] KeyFill(int[,] array,List<int>key)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            for (int j = 0; j < array.GetLength(0); j++)
                if (key.Contains(array[i, j]))
                    array[i, j] = 0;
            return array;
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

        string[,] WordFill(int[,] matrix)
        {
            string[,] array=  new string[matrix.GetLength(1),matrix.GetLength(0)];
            int number = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] == 0)
                        array[i, j] = InputString[number++].ToString();
                    else
                        array[i, j] = matrix[i, j].ToString();
                }
            }
            Console.WriteLine();
            for (int i = 0; i < array.GetLength(1); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    Console.Write($" {array[i,j],3} ");
                }
                Console.WriteLine();
            }

            return array;
        }
        /// <summary>
        /// Создание шифрованой таблицы 10х10
        /// </summary>
        /// <param name="basic">начальное положение</param>
        /// <param name="right">матрица справа</param>
        /// <param name="rightdown">матрица справа снизу</param>
        /// <param name="down"> матрица снизу</param>
        /// <returns></returns>
        static int[,] BuildEncryptMatrix(int[,] basic, int[,] right, int[,] rightdown, int[,] down)
        {
            int[,] temp = new int[basic.GetLength(1)*2,basic.GetLength(0)*2];
            try
            {
                Console.WriteLine("basic");
                for (int i = 0; i < basic.GetLength(1); i++)
                    for (int j = 0; j < basic.GetLength(0); j++)
                        temp[i, j] = basic[i, j];
                PrintMatrix(temp);
                Console.WriteLine("Заполнение 2 матрицы справа");
                //Заполнение 2 матрицы справа

                for (int i = 0; i < basic.GetLength(1); i++)
                for (int j = basic.GetLength(0); j < basic.GetLength(0) + right.GetLength(0); j++)
                    temp[i, j] = right[i, j - basic.GetLength(0)];
                PrintMatrix(temp);

               
                Console.WriteLine("Заполнение 3 матрицы снизу");
                //Заполнение 3 матрицы снизу

                for (int i = basic.GetLength(1); i < basic.GetLength(1) * 2; i++)
                {
                    for (int j = 0; j < down.GetLength(0); j++)
                        temp[i, j] = down[i - basic.GetLength(1), j];
                }
                PrintMatrix(temp);
                Console.WriteLine("Заполнение 4 матрицы справа снизу");
                //Заполнение 4 матрицы справа снизу
                for (int i = basic.GetLength(1); i < basic.GetLength(1) + rightdown.GetLength(1); i++)
                    for (int j = basic.GetLength(0); j < basic.GetLength(0) + rightdown.GetLength(0); j++)
                        temp[i, j] = rightdown[i - basic.GetLength(1), j - basic.GetLength(0)];
                PrintMatrix(temp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }

            return temp;
        }
        /// <summary>
        /// Заполнение матрицы
        /// </summary>
        /// <param name="a">входной массив</param>
        /// <param name="size">Размер матрицы</param>
            static void FillMatrix(int[,] matrix,string word)
        {
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                matrix[i, j] = word[counter++];
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

}