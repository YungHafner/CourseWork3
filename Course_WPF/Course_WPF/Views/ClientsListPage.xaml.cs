using Course_WPF.ViewModels;
using System.Windows.Controls;

namespace Course_WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для ClientsListPage.xaml
    /// </summary>
    public partial class ClientsListPage : Page
    {
        public ClientsListPage()
        {
            InitializeComponent();
            DataContext = new ClientsListPageVM();
        }
    }
}
