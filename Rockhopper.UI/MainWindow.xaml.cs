using System.Windows;
using Rockhopper.Git.Helpers;
using Rockhopper.Git.Models;

namespace Rockhopper;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public Repository CurrentRepository { get; set; }
    public string? HEAD { get; set; }
    public Branch[] Branches { get; set; }
    
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
                CurrentRepository = new Repository(fullPathToFolder);
                this.RepositoryBlock.Text = $"Path to current repository: {CurrentRepository.Path}";
                this.HEADBlock.Text = $"HEAD: {RepositoryHelper.GetHEAD(CurrentRepository)}";

                Branches = BranchHelper.GetBranches(CurrentRepository);

                string branchText = "";
                foreach(Branch branch in Branches)
                {
                    branchText += $"{branch.Name},";
                }

                this.BranchesBlock.Text = $"Branches: {branchText}";
            }
            else
            {
                MessageBox.Show("No Git repository exists at this location.");
            }
        }
    }
}