using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace UTSAfida.Migrations
{
    public partial class tb_jadwal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Jadwal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    pelatihan = table.Column<string>(type: "text", nullable: true),
                    TglMulai = table.Column<DateTime>(type: "datetime", nullable: false),
                    TglSelesai = table.Column<DateTime>(type: "datetime", nullable: false),
                    pertemuan = table.Column<string>(type: "text", nullable: true),
                    Tutor = table.Column<string>(type: "text", nullable: true),
                    Keterangan = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Jadwal", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Jadwal");
        }
    }
}
