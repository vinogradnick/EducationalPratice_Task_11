using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EducationPratice_Task_11;

namespace Visualiser
{
    public partial class Form1 : Form
    {
        private Encrypt encryptor;
        public Form1()
        {
            InitializeComponent();
            encryptor = new Encrypt();
            KeyTable.DataSource = encryptor.EncryptKey;
            Fill();
        }

        public void Fill()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    KeyTable[i, j].Value = encryptor.EncryptKey[i, j];
                }
            }
        }
    }
}
