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
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FeatureImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                columns: new[] { "Id", "Author", "CategoryId", "Content", "FeatureImagePath", "ImageUrl", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, "Theon", 1, "As we head into late 2025 and look toward 2026, technology continues its rapid evolution, driven primarily by advancements in artificial intelligence, sustainable computing, and connectivity. Agentic AI—systems that autonomously plan, reason, and execute multi-step tasks—has moved from hype to enterprise reality, with Deloitte and Gartner highlighting how organizations are embedding these agents into workflows for everything from customer service to supply chain optimization. Multimodal AI, processing text, images, video, and audio seamlessly, powers more intuitive tools like real-time translation and creative assistants. Edge computing reduces latency for IoT and autonomous systems, while private 5G/6G networks enable secure industrial applications. Sustainability is huge: AI's energy demands push adoption of nuclear-powered data centers and efficient algorithms. Quantum computing edges closer with error-corrected qubits from IBM and Google, promising breakthroughs in drug discovery and optimization. Cybersecurity evolves with AI-driven threat detection amid rising deepfake risks. For developers and businesses, the key is building 'change fitness'—rapid adaptation through hybrid clouds, upskilling, and ethical AI governance. 2025-2026 marks the shift where tech becomes a true strategic partner, not just a tool.", null, "/images/posts/default.jpg", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Latest Tech Trends 2025" },
                    { 2, "Ada Lovelace", 1, "2026 promises the deepest phase of the AI revolution yet. Agentic AI will dominate, acting as autonomous digital colleagues that handle entire workflows—from research and planning to execution and iteration—with minimal oversight. OpenAI, Anthropic, and global players push reasoning models that excel at complex, multi-step problems. Multimodal integration becomes standard, enabling AI to understand and generate across formats like video synthesis or interactive simulations. Trends include AI accelerating scientific discovery (materials science, biology), AI-native security to counter AI threats, and massive infrastructure builds for energy-efficient datacenters. Challenges loom: talent shortages, ethical bias mitigation, potential economic disruption from automation, and regulatory pushback on high-risk systems. Enterprises must invest in governance frameworks and workforce reskilling. By mid-2026, AI won't just augment jobs—it will redefine collaboration, creativity, and problem-solving at scale, creating abundance in knowledge work while demanding new human-AI partnership models.", null, "/images/posts/default.jpg", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "AI Revolution in 2026" },
                    { 3, "CodeMaster", 1, "In 2025-2026, developers need machines that handle demanding IDEs, containers, AI/ML workloads, and long compile times without throttling. Top recommendations start with the ASUS ROG Zephyrus G16 or Strix series for their powerful AMD/Intel combos paired with NVIDIA RTX 40-series GPUs—perfect for game dev, CUDA tasks, or heavy rendering. Lenovo ThinkPad X1 Carbon Gen 13 or P-series remain unbeatable for Linux compatibility, exceptional keyboards, durable builds, and 32GB+ RAM configs essential for modern tools like IntelliJ, VS Code with extensions, and Docker. For macOS fans, the latest MacBook Pro M4 Max offers insane battery life and unified memory for seamless Xcode/SwiftUI work. Budget-conscious? Dell XPS 16 or Lenovo Legion deliver solid performance under $1500. Look for at least 32GB RAM, fast NVMe SSDs (2TB+), high-refresh OLED/QHD+ displays, and effective cooling. Prioritize upgradeability where possible and good webcams/mics for remote work. Your laptop should feel like an extension of your brain—fast, reliable, and comfortable for marathon coding sessions.", null, "/images/posts/default.jpg", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Best Laptops for Developers" },
                    { 4, "QuantumGuru", 1, "Quantum computing leverages quantum mechanics—superposition (qubits in multiple states at once), entanglement (instant correlations), and interference—to tackle problems exponentially harder for classical computers. Unlike binary bits, qubits enable parallel exploration of vast solution spaces. Key applications: simulating molecular interactions for drug/material design, optimizing logistics/finance portfolios, and breaking certain encryptions via Shor's algorithm (though post-quantum crypto is advancing). Current hardware from IBM (Condor, Heron), Google, and IonQ achieves hundreds of qubits with improving fidelity, but noise/decoherence demands sophisticated error correction. Logical qubits (error-protected groups) are the milestone—2025-2026 sees first useful demonstrations. For beginners: imagine searching a maze by exploring all paths simultaneously. Challenges include cryogenic requirements, scalability, and hybrid quantum-classical algorithms. It's not replacing your laptop; it's accelerating specific high-value problems in science and industry.", null, "/images/posts/default.jpg", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Quantum Computing Explained" },
                    { 7, "Ramsay", 2, "Healthy eating in 2025-2026 focuses on personalization, whole foods, and sustainability. Prioritize vegetables/fruits (half your plate), lean proteins (plant/animal), healthy fats (avocados, nuts, olive oil), and complex carbs (quinoa, sweet potatoes). Trends: functional nutrition with adaptogens, gut-supporting fermented foods, and protein-enriched everyday items (even coffee/snacks). Minimize ultra-processed foods, added sugars, and excessive sodium. Meal prep saves time—batch cook grains/proteins, chop veggies ahead. Hydration: 3-4L water daily, infused for flavor. Mindful eating: chew slowly, no screens, listen to hunger cues. Apps track macros/micros for tailored plans. Balance indulgence—80/20 rule works. Consult RDs for conditions like diabetes or allergies. Consistent small changes compound into lifelong vitality.", null, "/images/posts/default.jpg", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Healthy Eating Tips" },
                    { 8, "FitPro", 2, "A solid morning workout sets energy and mindset for the day. Start with 5-10 min dynamic warm-up (arm circles, leg swings, jumping jacks). Core routine: 20-30 min mix of cardio (jog/brisk walk), strength (bodyweight squats, push-ups, planks, lunges), and mobility (yoga flows). HIIT for efficiency—e.g., 30s burpees, 30s rest, repeat 8x. Add weights if available. Trends: personalized AI-coached sessions via wearables. Finish with stretching/breathing for recovery. Hydrate + protein-rich breakfast post-workout. Consistency beats intensity—aim 5 days/week. Benefits: boosted metabolism, better mood via endorphins, improved focus. Adapt to your level—beginners start shorter. Morning movement builds discipline and resilience.", null, "/images/posts/default.jpg", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Morning Workout Routine" },
                    { 9, "MindfulSoul", 2, "Mental health is as vital as physical in 2025-2026. Stress/anxiety management: daily mindfulness/meditation (apps like Headspace), journaling gratitude, limiting news/social media. Build support—talk to friends, therapy (online accessible). Sleep hygiene: 7-9h, consistent schedule, no screens pre-bed. Exercise and nature exposure reduce cortisol. Trends: teen/young adult focus, burnout recovery programs. Digital detox periods restore attention. Self-compassion over perfectionism. Recognize signs: persistent sadness, withdrawal—seek professional help early. Work boundaries prevent overload. Small daily wins (walks, hobbies) build resilience. Mental health thrives on proactive care, not crisis response.", null, "/images/posts/default.jpg", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Mental Health Matters" },
                    { 10, "YogiBear", 2, "Yoga offers holistic benefits: physical (flexibility, strength, balance via poses like downward dog, warrior), mental (stress reduction through breath/pranayama), emotional (mindfulness fosters calm). Regular practice improves posture, joint health, circulation. Styles vary—Hatha for beginners, Vinyasa flow, Yin for deep stretches. 20-60 min sessions 3-5x/week yield results. Trends: augmented classes with wearables tracking form. Combines well with meditation. Benefits extend to better sleep, lower blood pressure, enhanced mood via GABA increase. Accessible anywhere—no fancy gear needed. Start slow, listen to body, use props. Yoga builds body awareness and inner peace for modern life.", null, "/images/posts/default.jpg", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Benefits of Yoga" },
                    { 11, "Dreamer", 2, "Quality sleep (7-9h) is foundational. Science-backed tips: consistent schedule—even weekends. Dark, cool (60-67°F), quiet room—blackout curtains, earplugs, white noise. No caffeine after 2pm, limit alcohol. Wind-down: no screens 1h pre-bed (blue light blocks melatonin), read or journal instead. Evening routine: light dinner, herbal tea, stretching. Track with wearables for patterns. Address issues: if insomnia, CBT-I over pills. Naps <30 min early afternoon. Benefits: sharper cognition, stronger immunity, better mood/weight control. Prioritize sleep—it's recovery time for brain/body.", null, "/images/posts/default.jpg", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Sleep Better Tonight" },
                    { 13, "Lockhead", 3, "2025-2026 travel favors meaningful, less-crowded spots. Antarctica cruises boom for pristine nature. Asia's secondary cities (e.g., lesser-known Japan towns) grow fast. Europe: shoulder-season shoulder-season for moderate weather/climate adaptation. Wellness retreats in Costa Rica, Morocco. Nostalgic U.S. Route 66 centennial trips. Food-focused: coffee/culinary tours in emerging spots. Sustainable choices: eco-lodges, rail over flights. Personalization via AI planning. Destinations align with passions—hiking, culture, relaxation—for deeper connections.", null, "/images/posts/default.jpg", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Top Travel Destinations" },
                    { 14, "EuroNomad", 3, "Budget backpacking in Europe thrives with Eurail passes, hostels, street food. Plan shoulder seasons for savings/crowds. Must-visits: Eastern Europe (Poland, Czechia) cheaper than West. Apps: Rome2Rio, Hostelworld. Tips: pack light (carry-on only), use city cards, walk/cycle. Eat local markets. Safety: secure valuables, share itinerary. Cultural immersion over tourist traps. Sustainable: trains over planes. Europe offers history, variety, affordability for epic adventures on a budget.", null, "/images/posts/default.jpg", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Backpacking in Europe" },
                    { 15, "AsiaExplorer", 3, "Off-beaten-path Asia: Bhutan for happiness focus, lesser-visited Thailand islands, Vietnam's highlands, Japan's countryside. Indonesia's lesser-known islands for diving. Tips: local transport, homestays for authenticity. Respect customs. Sustainable tourism key—avoid overtourism. Budget-friendly, rich culture/nature. Emerging spots offer tranquility, unique experiences away from crowds.", null, "/images/posts/default.jpg", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Hidden Gems in Asia" },
                    { 16, "SoloWanderer", 3, "Solo travel builds confidence. Safety: research destinations, share plans, use trusted apps (Maps.me offline). Accommodation: well-reviewed, central. Night: avoid isolated areas, trust instincts. Money: multiple cards, minimal cash. Connect: join group tours/meetups. Health: insurance, meds, vaccinations. Embrace freedom but stay aware—solo doesn't mean reckless. Empowering and rewarding.", null, "/images/posts/default.jpg", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Solo Travel Safety Tips" },
                    { 18, "PeakClimber", 3, "Mountain trekking preparation: fitness build-up (hikes, cardio), gear (good boots, layers, poles), acclimatization for altitude. Popular: Nepal Annapurna, Patagonia Torres del Paine. Safety: guides for remote, weather checks. Benefits: stunning views, mental clarity, achievement. Pack light, leave no trace. Adventure with respect for nature.", null, "/images/posts/default.jpg", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Mountain Trekking Guide" },
                    { 19, "SimpleLife", 4, "Minimalism evolves to intentional living—quality over quantity, digital declutter (fewer apps/notifications), sustainable choices. 2025-2026 trends: digital minimalism for focus, one-in-one-out rules, capsule wardrobes. Benefits: reduced stress, financial freedom, environmental impact. Start small: declutter spaces, curate possessions. Intentionality creates calm amid chaos.", null, "/images/posts/default.jpg", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Minimalism in 2025" },
                    { 20, "TimeMaster", 4, "Productivity 2025-2026: slow productivity (fewer tasks, deep focus), time-blocking, Pomodoro with breaks. Tools: distraction blockers, AI assistants for routine. Eliminate multitasking. Prioritize: Eisenhower matrix. Habits: morning routines, no-meeting days. Sustainable output beats burnout. Track progress, adjust. Get more done meaningfully.", null, "/images/posts/default.jpg", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Productivity Hacks" },
                    { 21, "InteriorPro", 4, "Budget home decor: multifunctional furniture, neutral palettes + accents, plants for life. Trends: sustainable materials, minimalist with personality. DIY shelves, thrifted finds. Lighting layers for ambiance. Declutter first—less stuff, better flow. Create cozy, functional spaces reflecting you.", null, "/images/posts/default.jpg", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Home Decor Ideas" },
                    { 25, "Cinephile", 5, "2025 must-watch: innovative blockbusters, indie gems, AI-influenced storytelling. Trends: immersive experiences, limited series crossovers. Diverse narratives, visual spectacle. From sci-fi epics to emotional dramas—cinema evolves with tech and culture.", null, "/images/posts/default.jpg", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Best Movies of 2025" },
                    { 26, "GamerX", 5, "2025 games: AI-generated worlds, cloud gaming boom, immersive narratives. Trends: mobile-first, social features. Indie standouts, AAA spectacles. Genres blend—RPGs with survival. Gaming as social/activity hub.", null, "/images/posts/default.jpg", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Top Video Games 2025" },
                    { 27, "MusicLover", 5, "Fresh 2025 tracks: genre fusions, AI-assisted production, viral sensations. Playlists personalize discovery. Artists experiment—live-streamed creations. Add diverse sounds to your rotation for inspiration.", null, "/images/posts/default.jpg", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "New Music Releases" },
                    { 28, "Bookworm", 5, "Page-turners 2025: thrillers, sci-fi exploring AI, self-growth. Diverse voices, immersive worlds. Mix fiction/non-fiction for balance. Reading builds empathy, knowledge. Curate based on mood.", null, "/images/posts/default.jpg", new DateTime(2025, 12, 17, 10, 0, 0, 0, DateTimeKind.Unspecified), "Book Recommendations" }
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
