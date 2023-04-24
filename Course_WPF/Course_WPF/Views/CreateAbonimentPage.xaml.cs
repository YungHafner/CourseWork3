using Course_WPF.ViewModels;
using System.Windows.Controls;

namespace Course_WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateAbonimentPage.xaml
    /// </summary>
    public partial class CreateAbonimentPage : Page
    {
        public CreateAbonimentPage()
        {
            InitializeComponent();
            DataContext = new CreateAbonenementPageVM();
        }
    }
}
