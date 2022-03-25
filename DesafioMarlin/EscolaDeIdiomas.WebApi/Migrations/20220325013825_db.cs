using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDeIdiomas.WebApi.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    idAluno = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nomeCompleto = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.idAluno);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    idTurma = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    numeroTurma = table.Column<int>(type: "INTEGER", nullable: false),
                    anoLetivo = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false),
                    descricaoTurma = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.idTurma);
                });

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    idMatricula = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idAluno = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    idTurma = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.idMatricula);
                    table.ForeignKey(
                        name: "FK_Matriculas_Alunos_idAluno",
                        column: x => x.idAluno,
                        principalTable: "Alunos",
                        principalColumn: "idAluno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matriculas_Turmas_idTurma",
                        column: x => x.idTurma,
                        principalTable: "Turmas",
                        principalColumn: "idTurma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_cpf",
                table: "Alunos",
                column: "cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_email",
                table: "Alunos",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_idAluno",
                table: "Matriculas",
                column: "idAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_idTurma",
                table: "Matriculas",
                column: "idTurma");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_numeroTurma",
                table: "Turmas",
                column: "numeroTurma",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Turmas");
        }
    }
}
