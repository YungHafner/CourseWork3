using Course_Lib.Models;
using Course_WPF.ViewModels;
using System.Windows.Controls;

namespace Course_WPF.Views
{
    public partial class EditClientPage : Page
    {
        public EditClientPage(Client client)
        {
            InitializeComponent();
            DataContext = new EditClientPageVM(client);
        }

        
    }
}
