using Course_Lib.Models;
using Course_WPF.Tools;
using Course_WPF.Views;

namespace Course_WPF.ViewModels
{
    public class CreateAbonenementPageVM
    {
        public CustomCommand Create_Abonement { get; set; }

        public string Name_Aboniment { get; set; }
        public string Description { get; set; }
        public int Time_train_minutes { get; set; }
        public string Train_type { get; set; }
        public decimal Cost { get; set; }
        public byte Check_PersonalTrain { get; set; }

        public CreateAbonenementPageVM()
        {
            Create_Abonement = new CustomCommand(async () =>
            {
                var json = await HttpTool.PostAsyncs("Aboniments", new Aboniment() 
                { 
                    NameAboniment = Name_Aboniment, 
                    Description = Description, 
                    TrainTimeMinutes = Time_train_minutes, 
                    TypeTrain = Train_type,
                    Cost = Cost }, "CreateAbonement");
                //var abonement =  HttpTool.Deserialize<Aboniment>(json.Item2);

                Navigation.Instance.CurrentPage = new AbonimentsListPage();
            });
        }
    }
}
