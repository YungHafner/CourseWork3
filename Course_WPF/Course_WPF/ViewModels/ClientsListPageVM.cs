using Course_Lib.Models;
using Course_WPF.Tools;
using Course_WPF.Views;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_WPF.ViewModels
{
    public class ClientsListPageVM : BaseVM
    {
        private List<Client> clients;

        public string Family { get; set; }
        public DateTime Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public byte Vipclient { get; set; }
        public List<Client> Clients { get => clients; set { clients = value; Signal(); } }
        public Client SelectedClient { get; set; }
        ImageClient img_Client;
        private string vipClientText;

        public string VipClientText { get => vipClientText; set { vipClientText = value; Signal(); } }

        public CustomCommand EditClient { get; set; }
        public CustomCommand DeleteClient { get; set; }

        public ClientsListPageVM()
        {

            EditClient = new CustomCommand(async () =>
            {
                if (SelectedClient != null && SelectedClient.ImageClientId != 0)
                {
                    var json = await HttpTool.PostAsyncs("ImageClients", SelectedClient.ImageClientId, "Get_Client");
                    Navigation.Instance.CurrentPage = new EditClientPage(SelectedClient);

                    if (json.Item1 == HttpStatusCode.OK)
                    {
                        img_Client = HttpTool.Deserialize<ImageClient>(json.Item2);
                    }
                    else

                        MessageBox.Show("Не найдена фотография клиента");
                }
            });
            DeleteClient = new CustomCommand(async () =>
            {
                if (SelectedClient != null)
                {
                    var jsonRemoveClient = await HttpTool.PostAsyncs("Clients", SelectedClient.Id, "DeleteClient");
                    Update();
                }
            });
            Task.Run(() =>
            {
                Update();
            });

        }
        public async void Update()
        {
            var json = await HttpTool.PostAsyncs("Clients", null, "GetAll");
            Clients = HttpTool.Deserialize<List<Client>>(json.Item2);
            
        }
    }
}
