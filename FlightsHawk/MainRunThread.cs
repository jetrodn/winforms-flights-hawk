using System;
using System.Windows.Forms;

namespace FlightsHawk
{
    internal static class MainRunThread
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new FlightsForm());
        }
    }
}