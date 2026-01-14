using BlogWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogWebsite.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
        new Category { Id = 1, Name = "Technology", Description = "All about tech and gadgets" },
        new Category { Id = 2, Name = "Health", Description = "Health tips and news" },
        new Category { Id = 3, Name = "Travel", Description = "Travel guides and experiences" },
        new Category { Id = 4, Name = "Lifestyle", Description = "People lifestyle and stuffs." },
        new Category { Id = 5, Name = "Entertainment", Description = "Sports media and all." }

                );
            modelBuilder.Entity<Post>().HasData(
         // Category 1: Tech (6 posts)
         new Post { Id = 1, Title = "Latest Tech Trends 2025", Content = "Stay updated with the latest technology trends for 2025.", Author = "Theon", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 1 },
         new Post { Id = 2, Title = "AI Revolution in 2026", Content = "How artificial intelligence is shaping the future.", Author = "Ada Lovelace", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 1 },
         new Post { Id = 3, Title = "Best Laptops for Developers", Content = "Top picks for coding and development in 2025.", Author = "CodeMaster", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 1 },
         new Post { Id = 4, Title = "Quantum Computing Explained", Content = "A beginner's guide to quantum computing.", Author = "QuantumGuru", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 1 },
         new Post { Id = 5, Title = "5G vs 6G: What's Next?", Content = "The evolution of mobile networks.", Author = "NetWizard", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 1 },
         new Post { Id = 6, Title = "Cybersecurity Tips 2025", Content = "Protect yourself in the digital age.", Author = "SecureOne", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 1, ImageUrl= "/images/Posts/Cybersecurity Tips 2025.jfif" },

         // Category 2: Health (6 posts)
         new Post { Id = 7, Title = "Healthy Eating Tips", Content = "Learn how to eat healthy and maintain your lifestyle.", Author = "Ramsay", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 2 },
         new Post { Id = 8, Title = "Morning Workout Routine", Content = "Start your day with energy and strength.", Author = "FitPro", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 2 },
         new Post { Id = 9, Title = "Mental Health Matters", Content = "Tips for managing stress and anxiety.", Author = "MindfulSoul", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 2 },
         new Post { Id = 10, Title = "Benefits of Yoga", Content = "Improve flexibility and inner peace.", Author = "YogiBear", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 2 },
         new Post { Id = 11, Title = "Sleep Better Tonight", Content = "Science-backed tips for quality sleep.", Author = "Dreamer", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 2 },
         new Post { Id = 12, Title = "Hydration and Health", Content = "Why water is your best friend.", Author = "HydroMan", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 2 },

         // Category 3: Travel (6 posts)
         new Post { Id = 13, Title = "Top Travel Destinations", Content = "Check out the most amazing travel destinations this year.", Author = "Lockhead", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 3 },
         new Post { Id = 14, Title = "Backpacking in Europe", Content = "Budget tips for an epic European adventure.", Author = "EuroNomad", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 3 },
         new Post { Id = 15, Title = "Hidden Gems in Asia", Content = "Off-the-beaten-path locations you must visit.", Author = "AsiaExplorer", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 3 },
         new Post { Id = 16, Title = "Solo Travel Safety Tips", Content = "How to travel alone confidently.", Author = "SoloWanderer", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 3 },
         new Post { Id = 17, Title = "Best Beaches 2025", Content = "Paradise beaches around the world.", Author = "BeachLover", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 3 },
         new Post { Id = 18, Title = "Mountain Trekking Guide", Content = "Prepare for your next hiking adventure.", Author = "PeakClimber", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 3 },

         // Category 4: Lifestyle (6 posts)
         new Post { Id = 19, Title = "Minimalism in 2025", Content = "Live more with less.", Author = "SimpleLife", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 4 },
         new Post { Id = 20, Title = "Productivity Hacks", Content = "Get more done in less time.", Author = "TimeMaster", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 4 },
         new Post { Id = 21, Title = "Home Decor Ideas", Content = "Transform your space on a budget.", Author = "InteriorPro", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 4 },
         new Post { Id = 22, Title = "Fashion Trends 2025", Content = "What to wear this year.", Author = "StyleIcon", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 4 },
         new Post { Id = 23, Title = "Building Good Habits", Content = "Small changes, big results.", Author = "HabitBuilder", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 4 },
         new Post { Id = 24, Title = "Financial Freedom Tips", Content = "Manage money like a pro.", Author = "MoneyWise", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 4 },

         // Category 5: Entertainment (6 posts)
         new Post { Id = 25, Title = "Best Movies of 2025", Content = "Must-watch films this year.", Author = "Cinephile", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 5 },
         new Post { Id = 26, Title = "Top Video Games 2025", Content = "Games you can't miss.", Author = "GamerX", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 5 },
         new Post { Id = 27, Title = "New Music Releases", Content = "Fresh tracks to add to your playlist.", Author = "MusicLover", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 5 },
         new Post { Id = 28, Title = "Book Recommendations", Content = "Page-turners for every mood.", Author = "Bookworm", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 5 },
         new Post { Id = 29, Title = "TV Series to Binge", Content = "Addictive shows worth your time.", Author = "SeriesFan", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 5 },
       new Post { Id = 30, Title = "Comedy Specials 2025", Content = "Laugh out loud with these stand-ups.", Author = "FunnyGuy", PublishedDate = new DateTime(2025, 12, 17, 10, 0, 0), CategoryId = 5 },

       // Category 1: Tech (add 4 more)
new Post { Id = 31, Title = "Cloud Computing Basics", Content = "Intro to cloud services and providers.", Author = "CloudGuy", PublishedDate = new DateTime(2025, 12, 18, 10, 0, 0), CategoryId = 1 },
new Post { Id = 32, Title = "DevOps for Beginners", Content = "CI/CD and automation explained simply.", Author = "DevOpsNinja", PublishedDate = new DateTime(2025, 12, 18, 10, 0, 0), CategoryId = 1 },
new Post { Id = 33, Title = "Blockchain Beyond Crypto", Content = "Real world blockchain use cases.", Author = "BlockSmith", PublishedDate = new DateTime(2025, 12, 18, 10, 0, 0), CategoryId = 1 },
new Post { Id = 34, Title = "Future of Programming", Content = "How coding will change in next decade.", Author = "FutureCoder", PublishedDate = new DateTime(2025, 12, 18, 10, 0, 0), CategoryId = 1 },

// Category 2: Health (add 4 more)
new Post { Id = 35, Title = "Cardio vs Strength Training", Content = "Which workout is better?", Author = "HealthGeek", PublishedDate = new DateTime(2025, 12, 18, 10, 0, 0), CategoryId = 2 },
new Post { Id = 36, Title = "Boost Your Immunity", Content = "Daily habits for strong immunity.", Author = "DrWell", PublishedDate = new DateTime(2025, 12, 18, 10, 0, 0), CategoryId = 2 },
new Post { Id = 37, Title = "Desk Job Health Tips", Content = "Stay healthy with office work.", Author = "OfficeFit", PublishedDate = new DateTime(2025, 12, 18, 10, 0, 0), CategoryId = 2 },
new Post { Id = 38, Title = "Breathing Exercises", Content = "Simple breathing for calm mind.", Author = "ZenCoach", PublishedDate = new DateTime(2025, 12, 18, 10, 0, 0), CategoryId = 2 },

// Category 3: Travel (add 4 more)
new Post { Id = 39, Title = "Budget Travel Tips", Content = "Travel more by spending less.", Author = "BudgetNomad", PublishedDate = new DateTime(2025, 12, 18, 10, 0, 0), CategoryId = 3 },
new Post { Id = 40, Title = "Travel Packing Checklist", Content = "Never forget essentials again.", Author = "PackSmart", PublishedDate = new DateTime(2025, 12, 18, 10, 0, 0), CategoryId = 3 },
new Post { Id = 41, Title = "Best Travel Apps", Content = "Apps every traveler should use.", Author = "AppTraveler", PublishedDate = new DateTime(2025, 12, 18, 10, 0, 0), CategoryId = 3 },
new Post { Id = 42, Title = "Cultural Travel Etiquette", Content = "Respect local cultures while traveling.", Author = "CultureGuide", PublishedDate = new DateTime(2025, 12, 18, 10, 0, 0), CategoryId = 3 },

// Category 4: Lifestyle (add 4 more)
new Post { Id = 43, Title = "Morning Routines of Success", Content = "Start your day right.", Author = "LifeCoach", PublishedDate = new DateTime(2025, 12, 18, 10, 0, 0), CategoryId = 4 },
new Post { Id = 44, Title = "Digital Detox", Content = "Reduce screen time stress.", Author = "CalmMind", PublishedDate = new DateTime(2025, 12, 18, 10, 0, 0), CategoryId = 4 },
new Post { Id = 45, Title = "Work Life Balance", Content = "Balance career and personal life.", Author = "BalancePro", PublishedDate = new DateTime(2025, 12, 18, 10, 0, 0), CategoryId = 4 },
new Post { Id = 46, Title = "Self Discipline Hacks", Content = "Train your mind for consistency.", Author = "MindTrainer", PublishedDate = new DateTime(2025, 12, 18, 10, 0, 0), CategoryId = 4 },

// Category 5: Entertainment (add 4 more)
new Post { Id = 47, Title = "OTT Platforms Compared", Content = "Which streaming service is best?", Author = "StreamCritic", PublishedDate = new DateTime(2025, 12, 18, 10, 0, 0), CategoryId = 5 },
new Post { Id = 48, Title = "Anime to Watch 2025", Content = "Top anime recommendations.", Author = "OtakuSensei", PublishedDate = new DateTime(2025, 12, 18, 10, 0, 0), CategoryId = 5 },
new Post { Id = 49, Title = "Behind the Scenes Movies", Content = "How movies are really made.", Author = "FilmInsider", PublishedDate = new DateTime(2025, 12, 18, 10, 0, 0), CategoryId = 5 },
new Post { Id = 50, Title = "Music Genres Explained", Content = "Understand different music styles.", Author = "SoundWave", PublishedDate = new DateTime(2025, 12, 18, 10, 0, 0), CategoryId = 5 }

     );
            modelBuilder.Entity<Comment>().HasData(
                 new Comment
                 {
                     Id = 1,
                     UserName = "Alice",
                     Content = "Great article! Learned a lot about tech.",
                     CreatedDate = new DateTime(2025, 12, 17, 10, 0, 0),
                     PostId = 1
                 },
        new Comment
        {
            Id = 2,
            UserName = "Bob",
            Content = "Very helpful health tips, thanks!",
            CreatedDate = new DateTime(2025, 12, 17, 10, 0, 0),
            PostId = 2
        },
        new Comment
        {
            Id = 3,
            UserName = "Charlie",
            Content = "I want to visit these places ASAP!",
            CreatedDate = new DateTime(2025, 12, 17, 10, 0, 0),
            PostId = 3
        }
                );
        }
    }

}
