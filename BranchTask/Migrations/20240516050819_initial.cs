using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BranchTask.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomNo = table.Column<int>(type: "int", nullable: false),
                    ArabicName = table.Column<string>(type: "varchar(100)", nullable: true),
                    ArabicDescription = table.Column<string>(type: "varchar(1000)", nullable: true),
                    EnglishName = table.Column<string>(type: "varchar(100)", nullable: true),
                    EnglishDescription = table.Column<string>(type: "varchar(1000)", nullable: true),
                    Note = table.Column<string>(type: "varchar(1000)", nullable: true),
                    Address = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.BranchId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branch");
        }
    }
}
