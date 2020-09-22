using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET.Homework03.DataLayer.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Genre = table.Column<int>(nullable: false),
                    HasMacedonianSubtitle = table.Column<bool>(nullable: false),
                    ReleaseDate = table.Column<int>(nullable: false),
                    Rating = table.Column<float>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<long>(nullable: false),
                    TypeOfUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Duration", "Genre", "HasMacedonianSubtitle", "Link", "Price", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 144, 1, true, "https://www.imdb.com/title/tt0381061/?ref_=nv_sr_srsg_3", 300.0, 8f, 2006, "Casino Royale" },
                    { 2, 130, 0, false, "https://www.imdb.com/title/tt0482571/?ref_=fn_al_tt_1", 250.0, 8.5f, 2006, "The Prestige" },
                    { 3, 169, 2, true, "https://www.imdb.com/title/tt0816692/?ref_=fn_al_tt_1", 350.0, 8.6f, 2006, "Interstellar" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone", "TypeOfUser" },
                values: new object[,]
                {
                    { 1, "risteski.dimitar@gmail.com", "Dimitar", "Risteski", 78123456L, 1 },
                    { 2, "bob@yahoo.com", "Bob", "Bobsky", 80012312345L, 0 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "MovieId", "UserId" },
                values: new object[] { 1, 3, 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "MovieId", "UserId" },
                values: new object[] { 2, 3, 2 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "MovieId", "UserId" },
                values: new object[] { 3, 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MovieId",
                table: "Orders",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
