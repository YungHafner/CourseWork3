using Course_WPF.ViewModels;
using System.Windows.Controls;

namespace Course_WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для TrenersListPage.xaml
    /// </summary>
    public partial class TrenersListPage : Page
    {
        public TrenersListPage()
        {
            InitializeComponent();
            DataContext = new TrenersListPageVM();
        }
    }
}
