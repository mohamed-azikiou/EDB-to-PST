using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EDB_to_PST_Csharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModel View = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void run_cmd(string cmd, string args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python";
            start.Arguments = string.Format("{0} {1}", cmd, args);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    ViewModel.instance.Label += result;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.instance.Label = "";
            run_cmd("\""+System.IO.Path.GetFullPath(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "script.py"))+ "\"", "");
        }
    }

    public class ViewModel : INotifyPropertyChanged
    {
        public static ViewModel instance;
        public ViewModel() { instance = this; }
        String _label = "";

        public string Label { get => _label; set { _label = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Label")); } }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

