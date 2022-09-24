using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TypeAuthTest.Migrations
{
    public partial class CreateClaimDependencyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClaimDependency",
                columns: table => new
                {
                    BaseClaimId = table.Column<int>(type: "int", nullable: false),
                    DependedOnClaimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimDependency", x => new { x.BaseClaimId, x.DependedOnClaimId });
                    table.ForeignKey(
                        name: "FK_ClaimDependency_Claims_BaseClaimId",
                        column: x => x.BaseClaimId,
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimDependency_Claims_DependedOnClaimId",
                        column: x => x.DependedOnClaimId,
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClaimDependency_DependedOnClaimId",
                table: "ClaimDependency",
                column: "DependedOnClaimId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaimDependency");
        }
    }
}
