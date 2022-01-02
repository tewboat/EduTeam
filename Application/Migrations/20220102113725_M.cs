using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    public partial class M : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberProject_Projects_ProjectGuid",
                table: "MemberProject");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberProject_Users_UserGuid",
                table: "MemberProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberProject",
                table: "MemberProject");

            migrationBuilder.RenameTable(
                name: "MemberProject",
                newName: "MemberProjects");

            migrationBuilder.RenameIndex(
                name: "IX_MemberProject_ProjectGuid",
                table: "MemberProjects",
                newName: "IX_MemberProjects_ProjectGuid");

            migrationBuilder.AddColumn<int>(
                name: "AccessLevel",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberProjects",
                table: "MemberProjects",
                columns: new[] { "UserGuid", "ProjectGuid" });

            migrationBuilder.AddForeignKey(
                name: "FK_MemberProjects_Projects_ProjectGuid",
                table: "MemberProjects",
                column: "ProjectGuid",
                principalTable: "Projects",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberProjects_Users_UserGuid",
                table: "MemberProjects",
                column: "UserGuid",
                principalTable: "Users",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberProjects_Projects_ProjectGuid",
                table: "MemberProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberProjects_Users_UserGuid",
                table: "MemberProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberProjects",
                table: "MemberProjects");

            migrationBuilder.DropColumn(
                name: "AccessLevel",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "MemberProjects",
                newName: "MemberProject");

            migrationBuilder.RenameIndex(
                name: "IX_MemberProjects_ProjectGuid",
                table: "MemberProject",
                newName: "IX_MemberProject_ProjectGuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberProject",
                table: "MemberProject",
                columns: new[] { "UserGuid", "ProjectGuid" });

            migrationBuilder.AddForeignKey(
                name: "FK_MemberProject_Projects_ProjectGuid",
                table: "MemberProject",
                column: "ProjectGuid",
                principalTable: "Projects",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberProject_Users_UserGuid",
                table: "MemberProject",
                column: "UserGuid",
                principalTable: "Users",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
