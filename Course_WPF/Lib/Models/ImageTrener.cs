

namespace Course_Lib.Models
{
    public partial class ImageTrener
    {
        public ImageTrener()
        {
            Treners = new HashSet<Trener>();
        }

        public int Id { get; set; }
        public byte[]? PhotoTrener { get; set; }

        public virtual ICollection<Trener> Treners { get; set; }
    }
}
