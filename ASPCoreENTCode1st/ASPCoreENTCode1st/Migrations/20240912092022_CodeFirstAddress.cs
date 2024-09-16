using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPCoreENTCode1st.Migrations
{
    /// <inheritdoc />
    public partial class CodeFirstAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmpAddress",
                table: "Employees",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpAddress",
                table: "Employees");
        }
    }
}
