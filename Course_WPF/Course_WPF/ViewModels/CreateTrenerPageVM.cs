using Course_Lib.Models;
using Course_WPF.Tools;
using Course_WPF.Views;
using Microsoft.Win32;
using System.IO;
using System.Windows.Controls;

namespace Course_WPF.ViewModels
{
    public class CreateTrenerPageVM : BaseVM
    {
        private CustomCommand selectPhoto;

        private byte[] image;

        public string Trener_name { get; set; }
        public string Trener_type { get; set; }
        public string Trener_description { get; set; }
        public int Trener_salary { get; set; }
        public string Trener_login { get; set; }
        public string Trener_password { get; set; }
        public byte[] Image { get => image; set { image = value; Signal(); } }  

        public CustomCommand Registration_Trener { get; set; }
        public CustomCommand SelectPhoto { get => selectPhoto; set => selectPhoto = value; }

        public CreateTrenerPageVM()
        {
            SelectPhoto = new CustomCommand(() =>
            {
                OpenFileDialog ofd = new();
                if (ofd.ShowDialog() == true)
                {
                    var bytes = File.ReadAllBytes(ofd.FileName);
                    Image = bytes;

                }
            });


            Registration_Trener = new CustomCommand(async () =>
            {
                    var json2 = await HttpTool.PostAsyncs("ImageTreners", new ImageTrener { PhotoTrener = Image }, "EditPhotoForTrener");
                    var img_Trener = HttpTool.Deserialize<ImageTrener>(json2.Item2);

                var json = await HttpTool.PostAsyncs("Treners", new Trener { TrenerName = Trener_name, 
                        TrenerType = Trener_type, TrenerDescription = Trener_description, 
                    TrenerSalary = Trener_salary, TrenerLogin = Trener_login, TrenerPassword = Trener_password,
                    ImageTrenerId = img_Trener.Id }, "Create_Trener");
                

                Navigation.Instance.CurrentPage = new TrenersListPage();
            });
        }
    }
}
