using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoManagementAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTodo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Todos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Todos",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
