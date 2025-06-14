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

        HEAD = "Test";
    }
}