using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JardaCAD
{
    internal static class MainWindowControl
    {

        public static Point mouseLocation;

        private static int borderSize = 2;
        public static int BorderSize
        {
            get => borderSize;
        }

        private static int borderWidth = 3;
        public static int BorderWidth
        {
            get => borderSize;
        }

        private static Canvas canvas = new Canvas();
        public static Canvas getCanvas
        {
             get => canvas;
        }


        public static void Mouse_Click_Exit(object sender, MouseEventArgs e)
        {
            Program.mainForm.Close();
        }
        public static void Mouse_Click_Minimize(object sender, MouseEventArgs e)
        {
            Program.mainForm.WindowState = FormWindowState.Minimized;
        }

        public static void Mouse_Click_Maximaze(object sender, MouseEventArgs e)
        {
            if(Program.mainForm.WindowState != FormWindowState.Maximized)
            {
                Program.mainForm.WindowState = FormWindowState.Maximized;
            }
            else
            {
                Program.mainForm.WindowState = FormWindowState.Normal;
                //Program.mainForm.Width = windowWidth;
                //Program.mainForm.Height = windowHeight;
                //Program.mainForm.WindowState = FormWindowState.Maximized;
            }
        }

        public static void AdjustForm()
        {
            switch (Program.mainForm.WindowState)
            {
                case FormWindowState.Maximized:
                    Program.mainForm.Padding = new Padding(7);
                    break;
                case FormWindowState.Normal:
                    if (Program.mainForm.Padding.Top != borderSize)
                    {
                        Program.mainForm.Padding = new Padding(borderSize);
                    }
                    break;

            }
        }

    }
}
