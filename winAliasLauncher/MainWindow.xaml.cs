using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using WpfApplication1.models;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // load up the json file of options
        fileParser fp = new fileParser();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string msg = entryBox.Text;
            string cmd = fp.getCmd(msg);

            try
            {
                // need to add full process start up (so we can add admin start)
                ProcessStartInfo p = new ProcessStartInfo(cmd);
                p.Verb = "runas";
                p.UseShellExecute = true;
                Process.Start(p);
            }
            catch (Exception err)
            {
                MessageBox.Show("Unable to start matching program for: " + msg + " (" + err.Message + ")");
            }
        }
    }
}