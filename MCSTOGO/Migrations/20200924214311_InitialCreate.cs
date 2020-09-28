using Microsoft.EntityFrameworkCore.Migrations;

namespace MCSTOGO.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 12, nullable: false),
                    NomPost = table.Column<string>(nullable: true),
                    Prix = table.Column<string>(nullable: true),
                    Lieu = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TypeContrat = table.Column<string>(nullable: true),
                    EtatVente = table.Column<string>(nullable: true),
                    DateAjout = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 12, nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Etat = table.Column<string>(type: "varchar(10)", nullable: true),
                    DateAjout = table.Column<string>(type: "varchar(20)", nullable: true),
                    PostId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PostId",
                table: "Photos",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
