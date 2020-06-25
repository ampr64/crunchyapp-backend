using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
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
                    ImageURL = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
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
                    ImageURL = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
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
