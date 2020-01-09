namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;

    public class FootballBettingContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }
   public FootballBettingContext(DbContextOptions options) : base(options)
        {
       
        }

        public FootballBettingContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // CompositePrimaryKey for PlayerStatistics table
            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(ps => new { ps.GameId, ps.PlayerId });


            // >>>>>>>>>>>>>>>>>>>>>>>> RELATIONS: <<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // User -> Bets
            modelBuilder.Entity<User>()
            .HasMany(u => u.Bets)
            .WithOne(b => b.User);

            // Game -> Bets
            modelBuilder.Entity<Game>()
                .HasMany(g => g.Bets)
                .WithOne(b => b.Game);

            // Game -> PlayerStatistics
            modelBuilder.Entity<PlayerStatistic>()
                .HasOne(ps => ps.Game)
                .WithMany(g => g.PlayerStatistics)
                .HasForeignKey(ps => ps.GameId);

            // Player -> PlayerStatistics
            modelBuilder.Entity<PlayerStatistic>()
                .HasOne(ps => ps.Player)
                .WithMany(p => p.PlayerStatistics)
                .HasForeignKey(ps => ps.PlayerId);

            // Position -> Players
            modelBuilder.Entity<Position>()
                .HasMany(p => p.Players)
                .WithOne(pl => pl.Position);

            // Team -> Players
            modelBuilder.Entity<Team>()
                .HasMany(t => t.Players)
                .WithOne(p => p.Team);

            // Team -> Games (AwayTeam)
            modelBuilder.Entity<Team>()
                .HasMany(t => t.AwayGames)
                .WithOne(g => g.AwayTeam);

            // Team -> Games (HomeTeam)
            modelBuilder.Entity<Team>()
                .HasMany(t => t.HomeGames)
                .WithOne(g => g.HomeTeam);

            // Color -> Teams (PrimaryKit)
            modelBuilder.Entity<Color>()
                .HasMany(c => c.PrimaryKitTeams)
                .WithOne(t => t.PrimaryKitColor);

            // Color -> Teams (SecondaryKit)
            modelBuilder.Entity<Color>()
                .HasMany(c => c.SecondaryKitTeams)
                .WithOne(t => t.SecondaryKitColor);

            // Town -> Teams
            modelBuilder.Entity<Town>()
                .HasMany(t => t.Teams)
                .WithOne(tm => tm.Town);

            // Country -> Towns
            modelBuilder.Entity<Country>()
                .HasMany(c => c.Towns)
                .WithOne(t => t.Country);
        }
    }
}
