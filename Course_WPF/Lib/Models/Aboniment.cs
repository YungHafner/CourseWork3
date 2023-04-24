using System;
using System.Collections.Generic;

namespace Course_Lib.Models
{
    /// <summary>
    /// personaltriain 1 то тренировка первональная иначе она груповая
    /// </summary>
    public partial class Aboniment
    {
        public Aboniment()
        {
            Treners = new HashSet<Trener>();
        }

        public int Id { get; set; }
        public string? NameAboniment { get; set; }
        public string? Description { get; set; }
        public int? TrainTimeMinutes { get; set; }
        public string? TypeTrain { get; set; }
        public decimal? Cost { get; set; }
        public int? ClientId { get; set; }
        public byte? PersonalTrain { get; set; }

        public virtual Client? Client { get; set; }
        public virtual ICollection<Trener> Treners { get; set; }
    }
}
