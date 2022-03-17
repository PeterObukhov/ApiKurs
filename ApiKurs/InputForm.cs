using System;
using System.IO;
using System.Windows.Forms;

namespace ApiKurs
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = File.AppendText("coordinates.txt"))
            {
                string coords = $"{descriptionBox.Text}: {startCoordBox.Text} {endCoordBox.Text}";
                sw.WriteLine("\r\n" + coords);
            }
            foreach(Control cont in Controls)
            {
                if(cont.GetType().Name == "TextBox") cont.Text = string.Empty;
            }
        }
    }
}
