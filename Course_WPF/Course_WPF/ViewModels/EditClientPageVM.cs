using Course_Lib.Models;
using Course_WPF.Tools;
using Course_WPF.Views;
using Microsoft.Win32;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows;

namespace Course_WPF.ViewModels
{
    public class EditClientPageVM : BaseVM
    {

        internal ImageClient _ReturnImageClient;
        private Client client;
        private ImageClient imageClient;
        private byte[] photoClient;

        public ImageClient ImageClient { get => imageClient; set { imageClient = value; Signal(); } }
        public Client Client { get => client; set { client = value; Signal(); } }

        public CustomCommand Edit_Client { get; set; }
        public CustomCommand SelectedPhoto { get; set; }

        public byte[] PhotoClient { get => photoClient; set { photoClient = value; Signal(); } }

        public EditClientPageVM(Client client, ImageClient imageClient)
        {
            Task.Run(async () =>
            {
                Client = client;
                PhotoClient = imageClient.PhotoClient;
            });

            SelectedPhoto = new CustomCommand(async () =>
            {
                OpenFileDialog ofd = new();
                if (ofd.ShowDialog() == true)
                {
                    var bytes = File.ReadAllBytes(ofd.FileName);
                    PhotoClient = bytes;

                }
            });

            Edit_Client = new CustomCommand(async () =>
            {
                if (client.ImageClientId != 0 && PhotoClient != null)
                {
                    var json2 = await HttpTool.PostAsyncs("ImageClients", new ImageClient 
                    { 
                        Id = client.ImageClientId,
                        PhotoClient = PhotoClient
                    }, "EditPhoto");
                    _ReturnImageClient = HttpTool.Deserialize<ImageClient>(json2.Item2);
                    
                }
                else if(client.ImageClientId != 0 && PhotoClient == null) 
                {
                    
                }
                var json = await HttpTool.PostAsyncs("Clients", new Client
                {
                    Id = client.Id,
                    Name = Client.Name,
                    Family = Client.Family,
                    Lastname = Client.Lastname,
                    Birthday = Client.Birthday,
                    Adress = Client.Adress,
                    PhoneNumber = Client.PhoneNumber,
                    PassportSeria = Client.PassportSeria,
                    PassportNumber = Client.PassportNumber,
                    Vipclient = Client.Vipclient,
                    ImageClientId = _ReturnImageClient.Id,
                }, "UpdateClient"); ;

                Navigation.Instance.CurrentPage = new ClientsListPage();
            });
        }
    }
}
