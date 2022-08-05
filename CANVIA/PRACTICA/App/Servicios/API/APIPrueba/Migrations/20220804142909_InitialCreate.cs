using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIPrueba.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    PaymentDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardOwnerName = table.Column<string>(type: "nVarchar(100)", nullable: false),
                    CardNumber = table.Column<string>(type: "nVarchar(16)", nullable: false),
                    ExpirationDate = table.Column<string>(type: "nVarchar(5)", nullable: false),
                    SecurityCode = table.Column<string>(type: "nVarchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.PaymentDetailId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentDetails");
        }
    }
}
