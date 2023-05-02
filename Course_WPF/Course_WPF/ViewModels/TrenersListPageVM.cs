using Course_Lib.Models;
using Course_WPF.Tools;
using Course_WPF.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace Course_WPF.ViewModels
{
    public class TrenersListPageVM : BaseVM
    {
        private List<Trener> treners;
        private byte[] photoTrener;

        public CustomCommand Delete_Trener { get; set; }
        public CustomCommand Edit_Trener { get; set; }

        public List<Trener> Treners
        {
            get => treners; set { treners = value; Signal(); }
        }

        public byte[] PhotoTrener { get => photoTrener; set { photoTrener = value; Signal(); } }
        public string TrenerName { get; set; }
        public string TrenerType { get; set; }
        public string TrenerDescription { get; set; }
        public string TrenerSalary { get; set; }
        public Trener SelectedTrener { get; set; }

        public TrenersListPageVM()
        {
            Edit_Trener = new CustomCommand(async () =>
            {
                if(SelectedTrener != null)
                {
                   var json = await HttpTool.PostAsyncs("ImageTreners", null , $"GetTrenersImage/{SelectedTrener.ImageTrenerId}");
                   var img_trener = HttpTool.Deserialize<ImageTrener>(json.Item2);

                    Navigation.Instance.CurrentPage = new EditTrenerPage(SelectedTrener, img_trener);
                }
            });


            Delete_Trener = new CustomCommand(async () =>
            {
                if (SelectedTrener != null)
                {
                    var json = await HttpTool.PostAsyncs("Treners", SelectedTrener.Id, "Delete_Trener");


                    try
                    {
                        if (json.Item1 == System.Net.HttpStatusCode.OK)
                        {
                            UpdateList();
                        }
                    }
                    catch(Exception e) 
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            });

            Task.Run(async () =>
            {
                UpdateList();
            });
        }


        public async void UpdateList()
        {
            var json = await HttpTool.PostAsyncs("Treners", null, "GetAllTrenersWithImages");
            Treners = HttpTool.Deserialize<List<Trener>>(json.Item2);
        }

    }
}
