namespace Course_Lib.Models
{
    public partial class GroupTrain
    {
        public int Id { get; set; }
        public string? TrainName { get; set; }
        public string? Description { get; set; }
        public decimal? Cost { get; set; }
        public int? TrenerId { get; set; }

        public virtual Trener? Trener { get; set; }
    }
}
