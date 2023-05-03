using Course_Lib;
using Course_Lib.Models;
using Course_WPF.Tools;
using Course_WPF.Views;
using System.Windows;

namespace Course_WPF.ViewModels
{
    public class MainWindowVM : BaseVM
    {
        public CustomCommand SignUp { get; set; }
        public CustomCommand RegistrationManager { get; set; }

        public string login { get; set; }
        public string password { get; set; }

        public Navigation Navigation { get; set; }

        bool isLogin = false, isEditManager = false;

        
        bool magic = false;
        public MainWindowVM(MainWindow mainWindow)
        {
            Navigation = Navigation.Instance;

            RegistrationManager = new CustomCommand(() =>
            {
                Navigation.Instance.CurrentPage = new RegistrationPage();
            });
            SignUp = new CustomCommand(async () =>
            {
                if (magic)
                { return; }
                magic = true;
                var json = await HttpTool.PostAsyncs("Managers", new AuthData { Login = login, Password = password }, "SearchOne");
                var manager = HttpTool.Deserialize<Manager>(json.Item2);

                if (manager.Id == 0)
                {
                    MessageBox.Show("Такого пользователя нет");
                }

                else
                {
                    isLogin = true;
                }

                if (isLogin)
                {
                    
                    MainMenu win = new MainMenu();
                    win.Show();
                }
                magic = false;

                mainWindow.Close();
            });
        }
    }
}
