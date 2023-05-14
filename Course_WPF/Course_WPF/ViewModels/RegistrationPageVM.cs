using Course_Lib;
using Course_Lib.Models;
using Course_WPF.Tools;
using Course_WPF.Tools;

namespace Course_WPF.ViewModels
{
    public class RegistrationPageVM : BaseVM
    {
        public CustomCommand BackToSignUp { get; set; }
        public CustomCommand RegistrationManager { get; set; }

        public string _Login { get; set; }
        public string _Password { get; set; }

        public RegistrationPageVM()
        {
            BackToSignUp = new CustomCommand(() =>
            {
                Navigation.Instance.CurrentPage = null;
            });

            RegistrationManager = new CustomCommand(async() => 
            {
                var hashPass = HashedPassword.HashPassword(_Password);
                var json = await HttpTool.PostAsyncs("Managers", new Manager { LoginManager = _Login, PasswordManager = hashPass }, "CreateRegistrationManager");
                Navigation.Instance.CurrentPage = null;
            });

        }
    }
}
