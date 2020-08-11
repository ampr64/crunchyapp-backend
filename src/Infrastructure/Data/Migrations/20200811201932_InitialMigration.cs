using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Anime",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    Episodes = table.Column<int>(nullable: false),
                    IsComplete = table.Column<bool>(nullable: false),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anime_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manga",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Author = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    Chapters = table.Column<int>(nullable: false),
                    IsComplete = table.Column<bool>(nullable: false),
                    ImageUrl = table.Column<string>(unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manga_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Young male hero focused on action, adventure and fighting.", "Shounen" },
                    { 2, "Isekai is a 'accidental travel' genre of light novels, manga, anime and video games that revolve around a normal person from Earth being transported to, reborn or otherwise trapped in a parallel universe, fantasy world or virtual world.", "Isekai" },
                    { 3, "Anime and manga in this category reflect the traditions of the Western genre. Westerns usually take place in the American Old West, but the genre has expanded to frontiers beyond, like space and future Japan.", "Western" },
                    { 4, "Aimed at demographic of young men between the ages of 15-24. Seinen anime and manga tend to be of a more violent and/or psychological nature than shonen series—though, of course, there are seinen comedies as well. They can also have content of a pornographic nature (though this is not the focus of the work).", "Seinen" },
                    { 5, "“Shojo” (少女), which is often translated as “young girl,” is the female counterpart to shonen, and anime and manga of this type are aimed at girls between the ages of ten and eighteen. These tend to focus on romance and interpersonal relationships—though this does not mean they are necessarily without action or adventure.", "Shojo" },
                    { 6, "Anime and manga of the “josei” (女性) variety are aimed at adult women. Josei series are often slice-of-life or romantic tales featuring adult women, though, in recent years, shonen-like action-adventures have become popular as well. In general, these works tend to contain more realistic interpersonal relationships (as opposed to shojo’s often idealized ones) and can cover darker subjects like rape and infidelity.", "Josei" }
                });

            migrationBuilder.InsertData(
                table: "Anime",
                columns: new[] { "Id", "CategoryId", "Description", "Episodes", "ImageUrl", "IsComplete", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Izuku has dreamt of being a hero all his life—a lofty goal for anyone, but especially challenging for a kid with no superpowers. That’s right, in a world where eighty percent of the population has some kind of super-powered “quirk,” Izuku was unlucky enough to be born completely normal. But that’s not enough to stop him from enrolling in one of the world’s most prestigious hero academies.", 88, "https://i2.wp.com/lacomikeria.com/wp-content/uploads/2020/04/c5c213f074e0325713cce87b281fc78e8b978b95r1-722-1024v2_uhq.jpg?resize=600%2C400&ssl=1", false, "My Hero Academia" },
                    { 3, 4, "Kicked out of his orphanage and on the verge of starving to death, Nakajima Atsushi meets some strange men. One of them, Dazai Osamu, is a suicidal man attempting to drown himself in broad daylight. The other, bespectacled Kunikida Doppo, nervously stands by flipping through a notepad. Both are members of the  \"Armed Detective Agency \" said to solve incidents that even the military and police won't touch. Atsushi ends up accompanying them on a mission to eliminate a man-eating tiger that's been terrorizing the population...", 37, "https://obs.line-scdn.net/0hMBCFH-r4Em1-PzqfLettOkRpEQJNUwFuGglDcy5RTFkHB1E_FlBfWFI-GVtSDFUzEApZAls8CVwAWlUyRl9f/w644", true, "Bungou Stray Dogs" },
                    { 2, 5, "Impassive girl meets trouble maker in a brand new love story! After Mizutani Shizuku, a girl whose sole interest is studying, is asked to deliver some handouts to Yoshida Haru, a boy who hasn't come to school after spilling blood on the first day, she finds herself the target of his affection. This is a story about a boy and a girl who struggle with love and friendship. Opening yourself up to other people forces you to be honest with yourself.", 13, "https://i.pinimg.com/originals/a0/92/54/a09254f34a19bcbd85d99caffb6a3ee4.png", true, "My Little Monster" }
                });

            migrationBuilder.InsertData(
                table: "Manga",
                columns: new[] { "Id", "Author", "CategoryId", "Chapters", "Description", "ImageUrl", "IsComplete", "Title" },
                values: new object[,]
                {
                    { 1, "Hajime Isayama", 1, 129, "A century ago, the grotesque giants known as Titans appeared and consumed all but a few thousand humans. The survivors took refuge behind giant walls. Today, the threat of the Titans is a distant memory, and a boy named Eren yearns to explore the world beyond Wall Maria. But what began as a childish dream will become an all-too-real nightmare when the Titans return and humanity is once again on the brink of extinction", "https://i1.wp.com/lacomikeria.com/wp-content/uploads/2020/06/Attack-on-Titan-manga.jpg?resize=600%2C400&ssl=1", false, "Attack on Titan" },
                    { 3, "Inio Asano", 4, 147, "A coming-of-age drama story, it follows the life of a child named Onodera Punpun, from his elementary school years to his early 20s, as he copes with his dysfunctional family, love life, friends, life goals and hyperactive mind, while occasionally focusing on the lives and struggles of his schoolmates and family. Punpun and the members of his family are normal humans, but are depicted to the reader in the forms of birds. The manga explores themes such as depression, love, social isolation, sex, death, and family.", "https://media.metrolatam.com/2020/01/22/template90-703d63d7f00a258de6aea0cc70cd8d85-600x400.jpg", true, "Goodnight, Punpun" },
                    { 2, "Aya Nakahara", 5, 66, "Love is unusual for Koizumi Risa and Ootani Atsushi, who are both striving to find their ideal partner in high school—172 cm tall Koizumi is much taller than the average girl, and Ootani is much shorter than the average guy at 156 cm. To add to their plights, their crushes fall in love with each other, leaving Koizumi and Ootani comically flustered and heartbroken. To make matters worse, they're even labeled as a comedy duo by their homeroom teacher due to their personalities and the stark difference in their heights, and their classmates even think of their arguments as sketches.", "https://uploads.spiritfanfiction.com/fanfics/historias/202001/because-there-is-you-18417494-260120201649.png", false, "Lovely Complex" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anime_CategoryId",
                table: "Anime",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Manga_CategoryId",
                table: "Manga",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anime");

            migrationBuilder.DropTable(
                name: "Manga");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}