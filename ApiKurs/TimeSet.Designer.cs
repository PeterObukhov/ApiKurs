namespace ApiKurs
{
    partial class TimeSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TimeInsert = new System.Windows.Forms.TextBox();
            this.ParseTime = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TimeInsert
            // 
            this.TimeInsert.Location = new System.Drawing.Point(12, 39);
            this.TimeInsert.Name = "TimeInsert";
            this.TimeInsert.Size = new System.Drawing.Size(452, 23);
            this.TimeInsert.TabIndex = 0;
            // 
            // ParseTime
            // 
            this.ParseTime.Location = new System.Drawing.Point(12, 80);
            this.ParseTime.Name = "ParseTime";
            this.ParseTime.Size = new System.Drawing.Size(92, 23);
            this.ParseTime.TabIndex = 1;
            this.ParseTime.Text = "Подтвердить";
            this.ParseTime.UseVisualStyleBackColor = true;
            this.ParseTime.Click += new System.EventHandler(this.ParseTime_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(413, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите время в формате \"секунды:минуты:часы; секунды:минуты:часы\"";
            // 
            // TimeSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 142);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ParseTime);
            this.Controls.Add(this.TimeInsert);
            this.Name = "TimeSet";
            this.Text = "TimeSet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TimeInsert;
        private System.Windows.Forms.Button ParseTime;
        private System.Windows.Forms.Label label1;
    }
}