using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogWebsite.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FeatureImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "All about tech and gadgets", "Technology" },
                    { 2, "Health tips and news", "Health" },
                    { 3, "Travel guides and experiences", "Travel" },
                    { 4, "People lifestyle and stuffs.", "Lifestyle" },
                    { 5, "Sports media and all.", "Entertainment" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "CategoryId", "Content", "FeatureImagePath", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, "Theon", 1, "Stay updated with the latest technology trends for 2025.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Latest Tech Trends 2025" },
                    { 2, "Ada Lovelace", 1, "How artificial intelligence is shaping the future.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "AI Revolution in 2026" },
                    { 3, "CodeMaster", 1, "Top picks for coding and development in 2025.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Best Laptops for Developers" },
                    { 4, "QuantumGuru", 1, "A beginner's guide to quantum computing.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Quantum Computing Explained" },
                    { 5, "NetWizard", 1, "The evolution of mobile networks.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "5G vs 6G: What's Next?" },
                    { 6, "SecureOne", 1, "Protect yourself in the digital age.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Cybersecurity Tips 2025" },
                    { 7, "Ramsay", 2, "Learn how to eat healthy and maintain your lifestyle.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Healthy Eating Tips" },
                    { 8, "FitPro", 2, "Start your day with energy and strength.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Morning Workout Routine" },
                    { 9, "MindfulSoul", 2, "Tips for managing stress and anxiety.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Mental Health Matters" },
                    { 10, "YogiBear", 2, "Improve flexibility and inner peace.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Benefits of Yoga" },
                    { 11, "Dreamer", 2, "Science-backed tips for quality sleep.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Sleep Better Tonight" },
                    { 12, "HydroMan", 2, "Why water is your best friend.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Hydration and Health" },
                    { 13, "Lockhead", 3, "Check out the most amazing travel destinations this year.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Top Travel Destinations" },
                    { 14, "EuroNomad", 3, "Budget tips for an epic European adventure.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Backpacking in Europe" },
                    { 15, "AsiaExplorer", 3, "Off-the-beaten-path locations you must visit.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Hidden Gems in Asia" },
                    { 16, "SoloWanderer", 3, "How to travel alone confidently.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Solo Travel Safety Tips" },
                    { 17, "BeachLover", 3, "Paradise beaches around the world.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Best Beaches 2025" },
                    { 18, "PeakClimber", 3, "Prepare for your next hiking adventure.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Mountain Trekking Guide" },
                    { 19, "SimpleLife", 4, "Live more with less.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Minimalism in 2025" },
                    { 20, "TimeMaster", 4, "Get more done in less time.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Productivity Hacks" },
                    { 21, "InteriorPro", 4, "Transform your space on a budget.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Home Decor Ideas" },
                    { 22, "StyleIcon", 4, "What to wear this year.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Fashion Trends 2025" },
                    { 23, "HabitBuilder", 4, "Small changes, big results.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Building Good Habits" },
                    { 24, "MoneyWise", 4, "Manage money like a pro.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Financial Freedom Tips" },
                    { 25, "Cinephile", 5, "Must-watch films this year.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Best Movies of 2025" },
                    { 26, "GamerX", 5, "Games you can't miss.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Top Video Games 2025" },
                    { 27, "MusicLover", 5, "Fresh tracks to add to your playlist.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "New Music Releases" },
                    { 28, "Bookworm", 5, "Page-turners for every mood.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Book Recommendations" },
                    { 29, "SeriesFan", 5, "Addictive shows worth your time.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "TV Series to Binge" },
                    { 30, "FunnyGuy", 5, "Laugh out loud with these stand-ups.", null, new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Comedy Specials 2025" },
                    { 31, "CloudGuy", 1, "Intro to cloud services and providers.", null, new DateTime(2025, 12, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "Cloud Computing Basics" },
                    { 32, "DevOpsNinja", 1, "CI/CD and automation explained simply.", null, new DateTime(2025, 12, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "DevOps for Beginners" },
                    { 33, "BlockSmith", 1, "Real world blockchain use cases.", null, new DateTime(2025, 12, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "Blockchain Beyond Crypto" },
                    { 34, "FutureCoder", 1, "How coding will change in next decade.", null, new DateTime(2025, 12, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "Future of Programming" },
                    { 35, "HealthGeek", 2, "Which workout is better?", null, new DateTime(2025, 12, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "Cardio vs Strength Training" },
                    { 36, "DrWell", 2, "Daily habits for strong immunity.", null, new DateTime(2025, 12, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "Boost Your Immunity" },
                    { 37, "OfficeFit", 2, "Stay healthy with office work.", null, new DateTime(2025, 12, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "Desk Job Health Tips" },
                    { 38, "ZenCoach", 2, "Simple breathing for calm mind.", null, new DateTime(2025, 12, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "Breathing Exercises" },
                    { 39, "BudgetNomad", 3, "Travel more by spending less.", null, new DateTime(2025, 12, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "Budget Travel Tips" },
                    { 40, "PackSmart", 3, "Never forget essentials again.", null, new DateTime(2025, 12, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "Travel Packing Checklist" },
                    { 41, "AppTraveler", 3, "Apps every traveler should use.", null, new DateTime(2025, 12, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "Best Travel Apps" },
                    { 42, "CultureGuide", 3, "Respect local cultures while traveling.", null, new DateTime(2025, 12, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "Cultural Travel Etiquette" },
                    { 43, "LifeCoach", 4, "Start your day right.", null, new DateTime(2025, 12, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "Morning Routines of Success" },
                    { 44, "CalmMind", 4, "Reduce screen time stress.", null, new DateTime(2025, 12, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "Digital Detox" },
                    { 45, "BalancePro", 4, "Balance career and personal life.", null, new DateTime(2025, 12, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "Work Life Balance" },
                    { 46, "MindTrainer", 4, "Train your mind for consistency.", null, new DateTime(2025, 12, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "Self Discipline Hacks" },
                    { 47, "StreamCritic", 5, "Which streaming service is best?", null, new DateTime(2025, 12, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "OTT Platforms Compared" },
                    { 48, "OtakuSensei", 5, "Top anime recommendations.", null, new DateTime(2025, 12, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "Anime to Watch 2025" },
                    { 49, "FilmInsider", 5, "How movies are really made.", null, new DateTime(2025, 12, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "Behind the Scenes Movies" },
                    { 50, "SoundWave", 5, "Understand different music styles.", null, new DateTime(2025, 12, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), "Music Genres Explained" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedDate", "PostId", "UserName" },
                values: new object[,]
                {
                    { 1, "Great article! Learned a lot about tech.", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, "Alice" },
                    { 2, "Very helpful health tips, thanks!", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, "Bob" },
                    { 3, "I want to visit these places ASAP!", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, "Charlie" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
