using Course_Lib.Models;
using Course_WPF.ViewModels;
using System.Windows.Controls;

namespace Course_WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для EditTrenerPage.xaml
    /// </summary>
    public partial class EditTrenerPage : Page
    {
        public EditTrenerPage(Trener trener)
        {
            InitializeComponent();
            DataContext = new EditTrenerPageVM(trener);
        }
    }
}
