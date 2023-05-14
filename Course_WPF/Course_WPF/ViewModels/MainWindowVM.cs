using Course_Lib;
using Course_Lib.Models;
using Course_WPF.Tools;
using Course_WPF.Views;
using System.Windows;
using System.Security.Cryptography;
using System.Text;
using System;
using System.CodeDom;

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

                var hashPass = HashedPassword.HashPassword(password);

                if (hashPass == null )
                {
                    MessageBox.Show("Не введен пароль");
                    magic = false;
                    return;
                }

                if (login != null)
                {
                    var json = await HttpTool.PostAsyncs("Managers", new AuthData { Login = login, Password = hashPass }, "SearchOne");
                    var json1 = await HttpTool.PostAsyncs("Treners", new AuthData { Login = login, Password = password }, "AutorezationTrener");
                


                    if (json.Item1 == System.Net.HttpStatusCode.OK)
                    {
                        MessageBox.Show($"Привет менеджер");
                    }

                    if (json.Item1 != System.Net.HttpStatusCode.OK)
                    {
                        if (json1.Item1 == System.Net.HttpStatusCode.OK)
                        {
                            isLogin = true;
                            MessageBox.Show($"Привет тренер");

                        }
                        else
                        {
                        MessageBox.Show("Такого пользователя нет");
                        magic = false;
                        return;
                        }

                    }
                    else
                    {
                        isLogin = true;
                    }

                }

                if (isLogin)
                {
                    
                    MainMenu win = new MainMenu();
                    win.Show();
                }
                

                mainWindow.Close();
            });
        }

      
    }
}
