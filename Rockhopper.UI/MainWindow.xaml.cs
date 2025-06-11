using System.Windows;
using Rockhopper.Git;

namespace Rockhopper;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public string? CurrentRepository { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = this;
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
                CurrentRepository = fullPathToFolder;
                this.RepositoryBlock.Text = CurrentRepository;
            }
            else
            {
                MessageBox.Show("No Git repository exists at this location.");
            }
        }
        
    }
}