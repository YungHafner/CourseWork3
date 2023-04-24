using Course_Lib.Models;
using Course_WPF.Tools;
using Microsoft.Win32;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Course_WPF.ViewModels
{
    public class EditClientPageVM : BaseVM
    {
        private byte[] image;
        private Client client;

        public Client Client { get => client; set { client = value; Signal(); } }
        public string Family { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportSeria { get; set; }
        public string PassportNumber { get; set; }
        public DateTime Birthday { get; set; } 
        public byte Vipclient { get; set; } = 0;
        public byte[] Image { get => image; set { image = value; Signal(); } }

        public CustomCommand Edit_Client { get; set; }
        public CustomCommand SelectedPhoto { get; set; }

        public EditClientPageVM(int id)
        {
            Task.Run(async () =>
            {
                var json = await HttpTool.PostAsyncs("Clients", id , "GetClient");
                Client = HttpTool.Deserialize<Client>(json.Item2);
            });

            SelectedPhoto = new CustomCommand(async () =>
            {
                OpenFileDialog ofd = new();
                if (ofd.ShowDialog() == true)
                {
                    var bytes = File.ReadAllBytes(ofd.FileName);
                    Image = bytes;

                }
            });

            Edit_Client = new CustomCommand(async () =>
            {
                var json2 = await HttpTool.PostAsyncs("ImageCliens", Image , "EditPhoto");
                var json = await HttpTool.PostAsyncs("Clients", new Client { Name= Client.Name, 
                    Family = Client.Family, Lastname = Client.Lastname,
                    Birthday = Client.Birthday,
                    Adress = Client.Adress,
                    PhoneNumber = Client.PhoneNumber,
                    PassportSeria = Client.PassportSeria,
                    PassportNumber= Client.PassportNumber,
                    Vipclient= Client.Vipclient,
                }, "UpdateClient");
            });
        }
    }
}
