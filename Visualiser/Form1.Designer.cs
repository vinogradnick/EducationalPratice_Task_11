namespace Visualiser
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.InputBox = new System.Windows.Forms.TextBox();
            this.KeyTable = new System.Windows.Forms.DataGridView();
            this.OutTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.KeyTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutTable)).BeginInit();
            this.SuspendLayout();
            // 
            // InputBox
            // 
            this.InputBox.Location = new System.Drawing.Point(12, 54);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(434, 20);
            this.InputBox.TabIndex = 0;
            // 
            // KeyTable
            // 
            this.KeyTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KeyTable.Location = new System.Drawing.Point(12, 80);
            this.KeyTable.Name = "KeyTable";
            this.KeyTable.Size = new System.Drawing.Size(359, 358);
            this.KeyTable.TabIndex = 1;
            // 
            // OutTable
            // 
            this.OutTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OutTable.Location = new System.Drawing.Point(429, 80);
            this.OutTable.Name = "OutTable";
            this.OutTable.Size = new System.Drawing.Size(359, 358);
            this.OutTable.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OutTable);
            this.Controls.Add(this.KeyTable);
            this.Controls.Add(this.InputBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.KeyTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.DataGridView KeyTable;
        private System.Windows.Forms.DataGridView OutTable;
    }
}

