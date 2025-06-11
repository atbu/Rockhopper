using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rockhopper;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public string Repository { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        Repository = "C:\\";
        this.DataContext = this;
    }

    void Button1_Click(object sender, RoutedEventArgs e)
    {
        string outputText = "";
        if (Directory.Exists($"{Repository}\\.git"))
        {
            outputText = ".git folder exists at this location.";
        }
        else
        {
            outputText = ".git folder does not exist at this location.";
        }
        MessageBox.Show(outputText);
    }
}