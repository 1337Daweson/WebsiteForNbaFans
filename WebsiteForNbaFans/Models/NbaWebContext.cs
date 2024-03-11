using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebsiteForNbaFans.Models;

public partial class NbaWebContext : DbContext
{
    public NbaWebContext()
    {
    }

    public NbaWebContext(DbContextOptions<NbaWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Conference> Conferences { get; set; }

    public virtual DbSet<ConferenceStanding> ConferenceStandings { get; set; }

    public virtual DbSet<GameResult> GameResults { get; set; }

    public virtual DbSet<PlayerGameStat> PlayerGameStats { get; set; }

    public virtual DbSet<PlayerStat> PlayerStats { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamSchedule> TeamSchedules { get; set; }

    public virtual DbSet<TeamSeasonStat> TeamSeasonStats { get; set; }

    public virtual DbSet<User> Users { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=PRECIOUSONE\\SQLEXPRESS;Database=NbaWeb;Trusted_Connection=True;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.ArticleId).HasName("PK__Articles__9C6270C83FB8CD85");

            entity.Property(e => e.ArticleId).HasColumnName("ArticleID");
            entity.Property(e => e.Author)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.PublishedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comments__C3B4DFAA56A6007D");

            entity.Property(e => e.PublishedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Article).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ArticleId)
                .HasConstraintName("FK__Comments__Articl__3D5E1FD2");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Comments__UserID__3C69FB99");
        });

        modelBuilder.Entity<Conference>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Conferen__4A95EA93167905CE");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<ConferenceStanding>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.WinPercentage).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.IdNavigation).WithMany()
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK__Conferenc__Confe__5070F446");

            entity.HasOne(d => d.Team).WithMany()
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK__Conferenc__TeamI__5165187F");
        });

        modelBuilder.Entity<GameResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GameResu__2AB897DDC9536B4C");

            entity.Property(e => e.GameDate).HasColumnType("datetime");

            entity.HasOne(d => d.AwayTeam).WithMany(p => p.GameResultAwayTeams)
                .HasForeignKey(d => d.AwayTeamId)
                .HasConstraintName("FK__GameResul__AwayT__4CA06362");

            entity.HasOne(d => d.HomeTeam).WithMany(p => p.GameResultHomeTeams)
                .HasForeignKey(d => d.HomeTeamId)
                .HasConstraintName("FK__GameResul__HomeT__4BAC3F29");
        });

        modelBuilder.Entity<PlayerGameStat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlayerGa__0F8077F5EA0FC8F6");

            entity.HasOne(d => d.Game).WithMany(p => p.PlayerGameStats)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("FK__PlayerGam__GameI__5535A963");

            entity.HasOne(d => d.Player).WithMany(p => p.PlayerGameStats)
                .HasForeignKey(d => d.PlayerId)
                .HasConstraintName("FK__PlayerGam__Playe__5441852A");
        });

        modelBuilder.Entity<PlayerStat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PlayerSt__3A162D1E50DFB00E");

            entity.Property(e => e.PlayerName).HasMaxLength(100);

            entity.HasMany(d => d.Teams).WithMany(p => p.Players)
                .UsingEntity<Dictionary<string, object>>(
                    "PlayerTeam",
                    r => r.HasOne<Team>().WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PlayerTea__TeamI__48CFD27E"),
                    l => l.HasOne<PlayerStat>().WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PlayerTea__Playe__47DBAE45"),
                    j =>
                    {
                        j.HasKey("PlayerId", "TeamId").HasName("PK__PlayerTe__CB6DDAD3BE869E8B");
                        j.ToTable("PlayerTeams");
                    });
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teams__123AE7B9EB138E6A");

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Conference).WithMany(p => p.Teams)
                .HasForeignKey(d => d.ConferenceId)
                .HasConstraintName("FK__Teams__Conferenc__440B1D61");
        });

        modelBuilder.Entity<TeamSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TeamSche__9C8A5B6940339E8A");

            entity.ToTable("TeamSchedule");

            entity.Property(e => e.GameDate).HasColumnType("datetime");

            entity.HasOne(d => d.OpponentTeam).WithMany(p => p.TeamScheduleOpponentTeams)
                .HasForeignKey(d => d.OpponentTeamId)
                .HasConstraintName("FK__TeamSched__Oppon__59063A47");

            entity.HasOne(d => d.Team).WithMany(p => p.TeamScheduleTeams)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK__TeamSched__TeamI__5812160E");
        });

        modelBuilder.Entity<TeamSeasonStat>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.WinPercentage).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.IdNavigation).WithMany()
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK__TeamSeaso__TeamI__4E88ABD4");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__1788CCAC5254EF5D");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(256);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
