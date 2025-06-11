using System.Windows;
using Rockhopper.Git;

namespace Rockhopper;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public string CurrentRepository { get; set; }
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void RepositoryOpenClicked(object sender, RoutedEventArgs e)
    {
        Microsoft.Win32.OpenFolderDialog dialog = new()
        {
            Multiselect = false,
            Title = "Open Repository"
        };

        bool? result = dialog.ShowDialog();

        string? fullPathToFolder = "";
        if (result == true)
        {
            fullPathToFolder = dialog.FolderName;
        }

        if (fullPathToFolder != "")
        {
            if (RepositoryHelper.DoesGitRepositoryExist(fullPathToFolder))
            {
                MessageBox.Show("Git repository exists at this location.");
            }
            else
            {
                MessageBox.Show("No Git repository exists at this location.");
            }
        }
        else
        {
            MessageBox.Show("No folder selected. Cancelling.");
        }
        
    }
}