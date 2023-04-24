using System;
using System.Collections.Generic;

namespace Course_Lib.Models
{
    public partial class ImageClient
    {
        public ImageClient()
        {
            Clients = new HashSet<Client>();
        }

        public int Id { get; set; }
        public byte[]? PhotoClient { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
