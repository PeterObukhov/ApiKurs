using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ApiKurs
{
    internal class TrayApp : ApplicationContext
    {
        private NotifyIcon trayIcon;
        private Image image;
        private Api api = new Api();
        public TrayApp()
        {
            trayIcon = new NotifyIcon()
            {
                Icon = new Icon("Resources/AppIcon.ico"),
                ContextMenuStrip = new ContextMenuStrip(),
                Visible = true,
                Text = "KursAPI"
            };
            trayIcon.ContextMenuStrip.Items.Add("Exit", image, Exit);
            trayIcon.ContextMenuStrip.Items.Add("Start now", image, StartNow);
            trayIcon.ContextMenuStrip.Items.Add("Start automatically", image, StartAutomatically);
            trayIcon.ContextMenuStrip.Items.Add("Stop", image, Stop);
            trayIcon.ContextMenuStrip.Items.Add("Set time", image, Time);
            trayIcon.ContextMenuStrip.Items.Add("Set coordinates", image, InputData);
            trayIcon.ContextMenuStrip.Items.Add("Get output", image, OutputData);
        }
        private void Exit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }
        private void StartNow(object sender, EventArgs e)
        {
            api.RunNow();
        }
        private void StartAutomatically(object sender, EventArgs e)
        {
            api.RunAutomatic();
            trayIcon.Text += " running";
        }
        private void Stop(object sender, EventArgs e)
        {
            api.StopRunning();
            trayIcon.Text = "KursAPI";
        }
        private void Time(object sender, EventArgs e)
        {
            api.StopRunning();
            api.SetTime();
            trayIcon.Text = "KursAPI";
        }
        private void InputData(object sender, EventArgs e)
        {
            InputForm inputForm = new InputForm();
            inputForm.ShowDialog();
        }
        private void OutputData(object sender, EventArgs e)
        {
            var p = new Process();
            p.StartInfo = new ProcessStartInfo("output.txt")
            {
                UseShellExecute = true
            };
            p.Start();
        }
    }
}
