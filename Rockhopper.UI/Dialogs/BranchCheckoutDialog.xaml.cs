using System.Windows;

namespace Rockhopper.UI.Dialogs;

public partial class BranchCheckoutDialog : Window
{
    public BranchCheckoutDialog()
    {
        InitializeComponent();
    }

    public string BranchToCheckout
    {
        get => BranchTextBox.Text;
        set => BranchTextBox.Text = value;
    }

    private void OKButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }
}