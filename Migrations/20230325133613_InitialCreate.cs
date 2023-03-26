using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    EmployerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: true),
                    Prenom = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.EmployerID);
                });

            migrationBuilder.CreateTable(
                name: "Avantages",
                columns: table => new
                {
                    AvantageID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: true),
                    EmployerID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avantages", x => x.AvantageID);
                    table.ForeignKey(
                        name: "FK_Avantages_Employers_EmployerID",
                        column: x => x.EmployerID,
                        principalTable: "Employers",
                        principalColumn: "EmployerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avantages_EmployerID",
                table: "Avantages",
                column: "EmployerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avantages");

            migrationBuilder.DropTable(
                name: "Employers");
        }
    }
}
