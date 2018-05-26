using System;
using System.CodeDom;
using System.Diagnostics;

namespace EducationPratice_Task_11
{
    class Encrypt
    {
        private string InputString { get; set; }

        private const int MatrixLength = 5;//Размерность кодируемой матрицы
        private int[,] matrix;
        private int[] keys;
        private static Random rd= new Random();

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="text">входной текст</param>
        public Encrypt(string text)
        {
            InputString = text;//Входная строка
            matrix = new int[MatrixLength, MatrixLength];//Матрица для шифрования
        }
        
        /// <summary>
        /// Генерация массива ключей для поиска
        /// </summary>
        /// <returns></returns>
        static int[] keyGenerate()
        {
            int[] keys = new int[MatrixLength];
            for (int i = 0; i < keys.Length; i++)
                keys[i] = rd.Next(25);

            return keys;
        }
        /// <summary>
        /// Заполнение матрицы ключами
        /// </summary>
        /// <param name="array">матрица для шифрования</param>
        /// <param name="key">массив ключей для шифрования данного массива</param>
        /// <returns></returns>
        static int[] keyFill(int[,] array,int[]key)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            for (int j = 0; j < array.GetLength(0); j++)
                if (key[j] == array[i, j])
                    array[i, j] = 0;

        }
        /// <summary>
        /// Поворот матрицы на 90 градусов
        /// </summary>
        /// <param name="matrix">входая матрица для поворота</param>
        /// <returns>матрица повернутая на 90 градусов</returns>
        static char[,] RotateMatrix(char[,] matrix)
        {
            char[,] rotated_matrix = new char[matrix.GetLength(1), matrix.GetLength(0)];//Перевернутая матрица

            for (int i = 0; i < matrix.GetLength(1); i++)
            for (int j = 0; j < matrix.GetLength(0); j++)
                rotated_matrix[i, j] = matrix[matrix.GetLength(0) - j - 1, i];
            return rotated_matrix;
        }
    }

}