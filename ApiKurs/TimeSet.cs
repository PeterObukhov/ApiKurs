using System;
using System.Windows.Forms;

namespace ApiKurs
{
    public partial class TimeSet : Form
    {
        public string timeAns;
        public TimeSet()
        {
            InitializeComponent();
        }

        private void ParseTime_Click(object sender, EventArgs e)
        {
            string[] time = TimeInsert.Text.Split(';');
            string seconds = string.Empty;
            string minutes = string.Empty;
            string hours = string.Empty;
            foreach(string s in time)
            {
                string[] strArr = s.Trim().Split(':');
                seconds += $"{strArr[0]},";
                minutes += $"{strArr[1]},";
                hours += $"{strArr[2]},";
            }
            timeAns = $"{seconds.Trim(',')} {minutes.Trim(',')} {hours.Trim(',')}";
            Close();
        }
    }
}
