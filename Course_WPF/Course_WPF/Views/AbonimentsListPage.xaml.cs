using Course_WPF.ViewModels;
using System.Windows.Controls;

namespace Course_WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для AbonimentsListPage.xaml
    /// </summary>
    public partial class AbonimentsListPage : Page
    {
        public AbonimentsListPage()
        {
            InitializeComponent();
            DataContext = new AbonimentsListPageVM();
        }
    }
}
