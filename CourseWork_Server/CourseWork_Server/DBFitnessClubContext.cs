using Course_Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseWork_Server
{
    public partial class DBFitnessClubContext : DbContext
    {
        public DBFitnessClubContext()
        {
        }

        public DBFitnessClubContext(DbContextOptions<DBFitnessClubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aboniment> Aboniments { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<GroupTrain> GroupTrains { get; set; } = null!;
        public virtual DbSet<ImageClient> ImageClients { get; set; } = null!;
        public virtual DbSet<ImageTrener> ImageTreners { get; set; } = null!;
        public virtual DbSet<Manager> Managers { get; set; } = null!;
        public virtual DbSet<Trener> Treners { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=LAPTOP-5KPUDC1J\\YO;database=DBFitnessClub;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aboniment>(entity =>
            {
                entity.HasComment("personaltriain 1 то тренировка первональная иначе она груповая");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Cost)
                    .HasColumnType("money")
                    .HasColumnName("cost");

                entity.Property(e => e.Description)
                    .HasMaxLength(10)
                    .HasColumnName("description")
                    .IsFixedLength();

                entity.Property(e => e.NameAboniment)
                    .HasMaxLength(10)
                    .HasColumnName("name_aboniment")
                    .IsFixedLength();

                entity.Property(e => e.PersonalTrain).HasColumnName("personal_train");

                entity.Property(e => e.TrainTimeMinutes).HasColumnName("train_time_minutes");

                entity.Property(e => e.TypeTrain)
                    .HasMaxLength(10)
                    .HasColumnName("type_train")
                    .IsFixedLength();

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Aboniments)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Aboniments_Clients");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Adress)
                    .HasMaxLength(10)
                    .HasColumnName("adress")
                    .IsFixedLength();

                entity.Property(e => e.Birthday)
                    .HasColumnType("datetime")
                    .HasColumnName("birthday");

                entity.Property(e => e.Family)
                    .HasMaxLength(10)
                    .HasColumnName("family")
                    .IsFixedLength();

                entity.Property(e => e.ImageClientId).HasColumnName("image_clientId");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(10)
                    .HasColumnName("lastname")
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .HasColumnName("name")
                    .IsFixedLength();

                entity.Property(e => e.PassportNumber).HasColumnName("passport_number");

                entity.Property(e => e.PassportSeria).HasColumnName("passport_seria");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .HasColumnName("phone_number")
                    .IsFixedLength();

                entity.Property(e => e.Vipclient).HasColumnName("VIPclient");

                entity.HasOne(d => d.ImageClient)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.ImageClientId)
                    .HasConstraintName("FK_Clients_image_Client");
            });

            modelBuilder.Entity<GroupTrain>(entity =>
            {
                entity.ToTable("GroupTrain");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost)
                    .HasColumnType("money")
                    .HasColumnName("cost");

                entity.Property(e => e.Description)
                    .HasMaxLength(10)
                    .HasColumnName("description")
                    .IsFixedLength();

                entity.Property(e => e.TrainName)
                    .HasMaxLength(10)
                    .HasColumnName("train_name")
                    .IsFixedLength();

                entity.Property(e => e.TrenerId).HasColumnName("trener_id");

                entity.HasOne(d => d.Trener)
                    .WithMany(p => p.GroupTrains)
                    .HasForeignKey(d => d.TrenerId)
                    .HasConstraintName("FK_GroupTrain_Treners");
            });

            modelBuilder.Entity<ImageClient>(entity =>
            {
                entity.ToTable("image_Client");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PhotoClient)
                    .HasColumnType("image")
                    .HasColumnName("photo_client");
            });

            modelBuilder.Entity<ImageTrener>(entity =>
            {
                entity.ToTable("image_Trener");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PhotoTrener)
                    .HasColumnType("image")
                    .HasColumnName("photo_Trener");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LoginManager)
                    .HasMaxLength(10)
                    .HasColumnName("login_manager")
                    .IsFixedLength();

                entity.Property(e => e.PasswordManager)
                    .HasMaxLength(10)
                    .HasColumnName("password_manager")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Trener>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.ImageTrenerId).HasColumnName("image_trenerId");

                entity.Property(e => e.TraningId).HasColumnName("traning_id");

                entity.Property(e => e.TrenerDescription)
                    .HasMaxLength(10)
                    .HasColumnName("trener_description")
                    .IsFixedLength();

                entity.Property(e => e.TrenerLogin)
                    .HasMaxLength(10)
                    .HasColumnName("trener_login")
                    .IsFixedLength();

                entity.Property(e => e.TrenerName)
                    .HasMaxLength(10)
                    .HasColumnName("trener_name")
                    .IsFixedLength();

                entity.Property(e => e.TrenerPassword)
                    .HasMaxLength(10)
                    .HasColumnName("trener_password")
                    .IsFixedLength();

                entity.Property(e => e.TrenerProfit).HasColumnName("trener_profit");

                entity.Property(e => e.TrenerSalary).HasColumnName("trener_salary");

                entity.Property(e => e.TrenerType)
                    .HasMaxLength(10)
                    .HasColumnName("trener_type")
                    .IsFixedLength();

                entity.HasOne(d => d.Traning)
                    .WithMany(p => p.Treners)
                    .HasForeignKey(d => d.TraningId)
                    .HasConstraintName("FK_Treners_Aboniments");

                entity.HasOne(d => d.TraningNavigation)
                    .WithMany(p => p.Treners)
                    .HasForeignKey(d => d.TraningId)
                    .HasConstraintName("FK_Treners_image_Trener");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
