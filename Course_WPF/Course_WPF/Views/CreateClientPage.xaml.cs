using Course_WPF.ViewModels;
using System.Windows.Controls;

namespace Course_WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateClient.xaml
    /// </summary>
    public partial class CreateClientPage : Page
    {
        public CreateClientPage()
        {
            InitializeComponent();
            DataContext = new CreateClientVM();
        }
    }
}
