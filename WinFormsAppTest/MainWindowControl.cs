using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JardaCAD
{
    internal class MainWindowControl
    {

        public static Point mouseLocation;


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



    }
}
