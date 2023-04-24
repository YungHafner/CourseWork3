using Course_WPF.ViewModels;
using System.Windows;

namespace Course_WPF
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowVM(mainWindow);

            //Task.Run(async () => {

            //    int id = 1;
            //    var json = await HttpTool.PostAsync("Managers", id, "Remove");
            //    if (json.Item1 == System.Net.HttpStatusCode.NoContent)
            //    {
            //        var result = HttpTool.Deserialize<List<User>>(json.Item2);
            //    }
            //    else if (json.Item1 == System.Net.HttpStatusCode.NotFound)
            //    {

            //    }

            //});

        }
    }
}
