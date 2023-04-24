using Course_Lib.Models;
using Course_WPF.Tools;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Course_WPF.ViewModels
{

    public class AbonimentsListPageVM:BaseVM
    {
        private List<Aboniment> aboniments;

        public List<Aboniment> Aboniments { get => aboniments; set { aboniments = value; Signal(); } }
        public Aboniment SelectedAboniment { get; set; }

        public string NameAboniment { get; set; }
        public string Description { get; set; }
        public string TrainTimeMinutes { get; set; }
        public string Cost { get; set; }

        public CustomCommand DeleteAbonement { get; set; }


        public AbonimentsListPageVM()
        {
            DeleteAbonement = new CustomCommand(async() =>
            {
                if (SelectedAboniment != null)
                {
                    var json = await HttpTool.PostAsyncs("Aboniments", SelectedAboniment.Id, "DeleteAbonement");
                    Update();
                }
            });
            Task.Run(async () =>
            {
                Update();
            });
        }

        public async void Update()
        {
            var json = await HttpTool.PostAsyncs("Aboniments", null, "GetAllAboniments");
            Aboniments = HttpTool.Deserialize<List<Aboniment>>(json.Item2);
        }
    }
}
