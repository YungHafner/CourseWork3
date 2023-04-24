using Course_WPF.ViewModels;
using System.Windows.Controls;

namespace Course_WPF.Views
{
    public partial class EditClientPage : Page
    {
        public EditClientPage(int id)
        {
            InitializeComponent();
            DataContext = new EditClientPageVM(id);
        }
    }
}
