using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZBase.Classes;
using ZBase.Utilities;

namespace ZBase.Forms
{
    public partial class Overlay : Form
    {
        Graphics g; // youre gonna use this to draw stuff if youre using the built in graphics library 
        public Overlay()
        {
            InitializeComponent();
        }

        private void Overlay_Load(object sender, EventArgs e)
        {
            BackColor = Color.Black;
            TransparencyKey = Color.Black;
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;

            // for some reason, while loops dont work for drawing stuff, so we use a timer
            RefreshTimer.Enabled = true;
            RefreshTimer.Interval = 1; // 1 ms

            // make sure the overlay is the same size of the csgo window
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                CheckSize();
            }).Start();
        }

        public void CheckSize()
        {
            while (true)
            {
                Memory.SetWindowLong(Handle, -20, Memory.GetWindowLong(Handle, -20) | 0x80000 | 0x20); // makes it so you can click through it
                Size = Main.ScreenSize;
                Top = Main.ScreenRect.top;
                Left = Main.ScreenRect.left;

                Thread.Sleep(100); // how often it checks to make it the same size as the csgo window, change it to what you'd like
            }
        }

        private void Overlay_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            // Heres where you draw overlay things, again for the windows graphics
            g.DrawString("My New CS:GO Cheat!", new Font("Arial", 16), new SolidBrush(Color.Maroon), 10, 10);
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
