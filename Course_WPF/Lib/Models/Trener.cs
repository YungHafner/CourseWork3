namespace Course_Lib.Models
{
    public partial class Trener
    {
        public Trener()
        {
            GroupTrains = new HashSet<GroupTrain>();
            
        }

        public int Id { get; set; }
        public string? TrenerName { get; set; }
        public string? TrenerType { get; set; }
        public string? TrenerDescription { get; set; }
        public int? TrenerProfit { get; set; }
        public int? TrenerSalary { get; set; }
        public int? TraningId { get; set; }
        public int? ImageTrenerId { get; set; }
        public string? TrenerPassword { get; set; }
        public string? TrenerLogin { get; set; }

        public virtual Aboniment? Traning { get; set; }
        public virtual ImageTrener? TraningNavigation { get; set; }
        public virtual ICollection<GroupTrain> GroupTrains {     get; set; }
    }
}
