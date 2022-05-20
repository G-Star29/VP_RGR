using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Visual_Rugby.Models
{
    public partial class rugbyContext : DbContext
    {
        public rugbyContext()
        {
        }

        public rugbyContext(DbContextOptions<rugbyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Match> Matches { get; set; } = null!;
        public virtual DbSet<Result> Results { get; set; } = null!;
        public virtual DbSet<Staduim> Staduims { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<Tournament> Tournaments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=D:\\Trash\\VP_RGR\\Visual_Rugby\\Visual_Rugby\\Assets\\rugby.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("match");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.ResultId).HasColumnName("result_id");

                entity.Property(e => e.StaduimId).HasColumnName("staduim_id");

                entity.Property(e => e.Team0).HasColumnName("team0");

                entity.Property(e => e.Team1).HasColumnName("team1");

                entity.Property(e => e.TournamentId).HasColumnName("tournament_id");

                entity.HasOne(d => d.Result)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.ResultId);

                entity.HasOne(d => d.Staduim)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.StaduimId);

                entity.HasOne(d => d.Team0Navigation)
                    .WithMany(p => p.MatchTeam0Navigations)
                    .HasForeignKey(d => d.Team0);

                entity.HasOne(d => d.Team1Navigation)
                    .WithMany(p => p.MatchTeam1Navigations)
                    .HasForeignKey(d => d.Team1);

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.TournamentId);
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.ToTable("result");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Score0).HasColumnName("score0");

                entity.Property(e => e.Score1).HasColumnName("score1");
            });

            modelBuilder.Entity<Staduim>(entity =>
            {
                entity.ToTable("staduim");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Staduims)
                    .HasForeignKey(d => d.CountryId);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("team");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Games).HasColumnName("games");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.NumberOfPlayers).HasColumnName("number_of_players");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.CountryId);
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.ToTable("tournament");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.NumberOfGames).HasColumnName("number_of_games");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
