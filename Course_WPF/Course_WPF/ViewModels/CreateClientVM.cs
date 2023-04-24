using Course_Lib.Models;
using Course_WPF.Tools;
using Course_WPF.Views;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Course_WPF.ViewModels
{
    public class CreateClientVM: BaseVM
    {
        private byte[] image;

        public CustomCommand Registration_Client { get; set; }
        public CustomCommand Selected_Photo { get; set; }

        public string Family { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Seria { get; set; }
        public string Number { get; set; }
        public DateTime Birthday { get; set; } = DateTime.Now;
        public byte VipClient { get; set; } = 0;    
        public byte[] Image { get => image; set { image = value; Signal(); } }

        public CreateClientVM()
        {
            Selected_Photo = new CustomCommand(async () =>
            {
                OpenFileDialog ofd = new();
                if (ofd.ShowDialog() == true)
                {
                    var bytes = File.ReadAllBytes(ofd.FileName);
                    Image = bytes;

                }
            });

            Registration_Client = new CustomCommand(async () =>
            {
                var json1 = await HttpTool.PostAsyncs("ImageClients", new ImageClient { PhotoClient = Image }, "CreateImage_Client");
                var imgClient = HttpTool.Deserialize<ImageClient>(json1.Item2);

                var json = await HttpTool.PostAsyncs("Clients", new Client
                {
                    Family = Family,
                    Name = Name,
                    Lastname = LastName,
                    Adress = Adress,
                    PhoneNumber = PhoneNumber,
                    PassportSeria = Int32.Parse(Seria),
                    PassportNumber = Int32.Parse(Number),
                    Birthday = Birthday,
                    Vipclient = VipClient,
                    ImageClientId = imgClient.Id
                }, "Create_Client");

                Navigation.Instance.CurrentPage = new ClientsListPage();
            });
        }

    }
}
