using Microsoft.EntityFrameworkCore;
using ChessWebApi.Models;

namespace ChessWebApi.Data
{
    public class ChessDbContext : DbContext
    {
        public ChessDbContext(DbContextOptions<ChessDbContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<PlayerSponsor> PlayerSponsors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("chess");

            // Configure table names
            modelBuilder.Entity<Player>().ToTable("players");
            modelBuilder.Entity<Match>().ToTable("matches");
            modelBuilder.Entity<Sponsor>().ToTable("sponsors");
            modelBuilder.Entity<PlayerSponsor>().ToTable("player_sponsors");

            // Configure primary keys
            modelBuilder.Entity<Player>()
                .HasKey(p => p.player_id);////

            modelBuilder.Entity<Match>()
                .HasKey(m => m.match_id);

            modelBuilder.Entity<Sponsor>()
                .HasKey(s => s.sponsor_id);

            modelBuilder.Entity<PlayerSponsor>()
                .HasKey(ps => new { ps.player_id, ps.sponsor_id });

            // Configure relationships
            modelBuilder.Entity<Player>()
                .HasMany(p => p.MatchesAsPlayer1)
                .WithOne(m => m.player1)
                .HasForeignKey(m => m.player1_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Player>()
                .HasMany(p => p.MatchesAsPlayer2)
                .WithOne(m => m.player2)
                .HasForeignKey(m => m.player2_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Winner)
                .WithMany()
                .HasForeignKey(m => m.winner_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlayerSponsor>()
                .HasOne(ps => ps.Player)
                .WithMany(p => p.PlayerSponsors)
                .HasForeignKey(ps => ps.player_id);

            modelBuilder.Entity<PlayerSponsor>()
                .HasOne(ps => ps.Sponsor)
                .WithMany(s => s.PlayerSponsors)
                .HasForeignKey(ps => ps.sponsor_id);
        }
    }
}
