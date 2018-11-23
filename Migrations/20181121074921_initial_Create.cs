using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebCrf.Migrations
{
    public partial class initial_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_roles",
                columns: table => new
                {
                    IdRole = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NamaRole = table.Column<string>(nullable: true),
                    Deskripsi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_roles", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "tb_users",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NamaUser = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Sandi = table.Column<string>(nullable: true),
                    JenisKelamin = table.Column<string>(nullable: true),
                    Alamat = table.Column<string>(nullable: true),
                    Gambar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "tb_user_roles",
                columns: table => new
                {
                    IdUserRole = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    tb_roleIdRole = table.Column<int>(nullable: true),
                    Tb_UserIdUser = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_user_roles", x => x.IdUserRole);
                    table.ForeignKey(
                        name: "FK_tb_user_roles_tb_users_Tb_UserIdUser",
                        column: x => x.Tb_UserIdUser,
                        principalTable: "tb_users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_user_roles_tb_roles_tb_roleIdRole",
                        column: x => x.tb_roleIdRole,
                        principalTable: "tb_roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_roles_Tb_UserIdUser",
                table: "tb_user_roles",
                column: "Tb_UserIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_roles_tb_roleIdRole",
                table: "tb_user_roles",
                column: "tb_roleIdRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_user_roles");

            migrationBuilder.DropTable(
                name: "tb_users");

            migrationBuilder.DropTable(
                name: "tb_roles");
        }
    }
}
