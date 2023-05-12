using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebTopicChat.DataAccessLayer.Context
{
    public partial class TopicChatContext : DbContext
    {
        public TopicChatContext()
        {
        }

        public TopicChatContext(DbContextOptions<TopicChatContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<ClientTopic> ClientTopics { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Topic> Topics { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=CL-5CD8478Z0K\\SQLEXPRESS;database=TopicChat;user=sa;password=Adpass01@");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Clients_pk2")
                    .IsClustered(false);

                entity.HasIndex(e => e.Id, "Clients_Id_index");

                entity.HasIndex(e => e.UserName, "Clients_pk")
                    .IsUnique();

                entity.Property(e => e.DisplayName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClientTopic>(entity =>
            {
                entity.HasKey(e => new { e.TopicId, e.ClientId })
                    .HasName("ClientTopic_pk");

                entity.ToTable("ClientTopic");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientTopics)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ClientTopic_Clients_Id_fk");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.ClientTopics)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ClientTopic_Topics_Id_fk");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Messages_pk")
                    .IsClustered(false);

                entity.HasIndex(e => e.Id, "Messages_Id_index");

                entity.Property(e => e.Content).HasMaxLength(255);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Messages_Clients_Id_fk");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Messages_Topics_Id_fk");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Topics_pk")
                    .IsClustered(false);

                entity.HasIndex(e => e.Id, "Topics_Id_index");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Topics_Clients_Id_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
