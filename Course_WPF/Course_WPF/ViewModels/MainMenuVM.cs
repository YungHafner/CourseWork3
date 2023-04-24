using Course_WPF.Tools;
using Course_WPF.Views;

namespace Course_WPF.ViewModels
{
    public class MainMenuVM: BaseVM
    {
        public CustomCommand CreateTrener { get; set; }
        public CustomCommand TrenersList { get; set; }
        public CustomCommand CreateAboniment { get; set; }
        public CustomCommand AbonimentsList { get; set; }
        public CustomCommand CreateClient { get; set; }
        public CustomCommand ClientsList { get; set; }
        public CustomCommand Main_Menu { get; set; }

        public Navigation Navigation { get; set; }
        

        public MainMenuVM()
        {
            Navigation = Navigation.Instance;

            Main_Menu = new CustomCommand(() =>
            {
                Navigation.Instance.CurrentPage = null;
            });

            CreateTrener = new CustomCommand(() =>
            {
                Navigation.Instance.CurrentPage = new CreateTrenerPage();
            });

            TrenersList = new CustomCommand(() =>
            {
                Navigation.Instance.CurrentPage = new TrenersListPage();
            });

            CreateAboniment = new CustomCommand(() =>
            {
                Navigation.Instance.CurrentPage = new CreateAbonimentPage();
            });

            AbonimentsList = new CustomCommand(() =>
            {
                Navigation.Instance.CurrentPage = new AbonimentsListPage();
            });

            CreateClient = new CustomCommand(() =>
            {
                Navigation.Instance.CurrentPage = new CreateClientPage();
            });

            ClientsList = new CustomCommand(() =>
            {
                Navigation.Instance.CurrentPage = new ClientsListPage();
            });
        }
    }
}
