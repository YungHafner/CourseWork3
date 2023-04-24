using Course_WPF.ViewModels;
using System.Windows.Controls;

namespace Course_WPF.Views
{

    public partial class CreateTrenerPage : Page
    {
        public CreateTrenerPage()
        {

            InitializeComponent();
            DataContext = new CreateTrenerPageVM();

        }
    }
}
