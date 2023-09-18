using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RunGroopWebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCspViolation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CspViolationModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlockedUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disposition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffectiveDirective = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalPolicy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Referrer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScriptSample = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViolatedDirective = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CspViolationModels", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CspViolationModels");
        }
    }
}
