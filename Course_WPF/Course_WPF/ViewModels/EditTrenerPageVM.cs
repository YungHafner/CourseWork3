using Course_Lib.Models;
using Course_WPF.Tools;
using Course_WPF.Views;
using Microsoft.Win32;
using System.IO;
using System.Threading.Tasks;

namespace Course_WPF.ViewModels
{
    public class EditTrenerPageVM : BaseVM
    {
        private byte[] image;

        public byte[] Image { get => image; set => image = value; }

        public CustomCommand Edit_Trener { get; set; }
        public CustomCommand SelectPhoto { get; set; }

        public Trener Trener { get; }

        public EditTrenerPageVM(Trener trener)
        {
            Trener = trener;
            

            SelectPhoto = new CustomCommand(async () =>
            {
                OpenFileDialog ofd = new();
                if (ofd.ShowDialog() == true)
                {
                    var bytes = File.ReadAllBytes(ofd.FileName);
                    Image = bytes;
                }
            });

            Edit_Trener = new CustomCommand(async () =>
            {
                //var json = await HttpTool.PostAsyncs("Treners", new Trener { } , "EditTrener");
                Navigation.Instance.CurrentPage = new TrenersListPage();
            });
        }
    }
}
