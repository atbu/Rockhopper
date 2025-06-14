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
    
    public MainWindow(IRepositoryService repositoryService)
    {
        _repositoryService = repositoryService;
        
        InitializeComponent();
        this.DataContext = this;
    }
}