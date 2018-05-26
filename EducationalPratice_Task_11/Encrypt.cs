using System;
using System.CodeDom;
using System.Diagnostics;

namespace EducationPratice_Task_11
{
    class Encrypt
    {
        private string InputString { get; set; }
        private const int MatrixLength = 5;//Размерность кодируемой матрицы
        private int[,] matrix = new int[MatrixLength,MatrixLength];


        public Encrypt(string text)
        {
            InputString = text;
        }
    }

}