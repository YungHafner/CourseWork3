using Course_WPF.ViewModels;
using System.Windows;

namespace Course_WPF.Views
{
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
            DataContext = new MainMenuVM();        
        }
    }
}
