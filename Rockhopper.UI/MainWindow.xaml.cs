using System.Windows;
using Rockhopper.Git.Models;
using Rockhopper.Git.Services;

namespace Rockhopper.UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IRepositoryService _repositoryService;

    public Repository Repository { get; set; }
    public string RepositoryName { get; set; }
    public string HEAD
    {
        get { return (string)GetValue(HEADProperty); }
        set { SetValue(HEADProperty, value); }
    }

    public static readonly DependencyProperty HEADProperty =
        DependencyProperty.Register(nameof(HEAD), typeof(string), typeof(MainWindow), new PropertyMetadata(null));
    
    public MainWindow(IRepositoryService repositoryService)
    {
        _repositoryService = repositoryService;
        
        InitializeComponent();
        this.DataContext = this;
    }

    private void TopMenuRepositoryOpenClicked(object sender, RoutedEventArgs e)
    {
        Microsoft.Win32.OpenFolderDialog dialog = new();

        dialog.Multiselect = false;
        dialog.Title = "Open Repository";

        bool? result = dialog.ShowDialog();

        if (result == true)
        {
            string fullPathToFolder = dialog.FolderName;
            string folderNameOnly = dialog.SafeFolderName;

            Repository = new Repository(fullPathToFolder);
            Repository.RootFolderName = folderNameOnly;
            Repository.HEAD = _repositoryService.GetHEAD(Repository);

            HEAD = Repository.HEAD;
        }
    }
}