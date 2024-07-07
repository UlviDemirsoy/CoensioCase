using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CoensioApi.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "CodingQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodeTemplate = table.Column<string>(type: "text", nullable: false),
                    Input = table.Column<string>(type: "text", nullable: false),
                    Output = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodingQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FreeTextQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionText = table.Column<string>(type: "text", nullable: false),
                    TrueAnswerText = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreeTextQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MultipleChoiceQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionText = table.Column<string>(type: "text", nullable: false),
                    Options = table.Column<string>(type: "text", nullable: false),
                    TrueAnswer = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestCodingQuestions",
                columns: table => new
                {
                    CodingQuestionsId = table.Column<int>(type: "integer", nullable: false),
                    TestsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCodingQuestions", x => new { x.CodingQuestionsId, x.TestsId });
                    table.ForeignKey(
                        name: "FK_TestCodingQuestions_CodingQuestions_CodingQuestionsId",
                        column: x => x.CodingQuestionsId,
                        principalTable: "CodingQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestCodingQuestions_Tests_TestsId",
                        column: x => x.TestsId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestFreeTextQuestions",
                columns: table => new
                {
                    FreeTextQuestionsId = table.Column<int>(type: "integer", nullable: false),
                    TestsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestFreeTextQuestions", x => new { x.FreeTextQuestionsId, x.TestsId });
                    table.ForeignKey(
                        name: "FK_TestFreeTextQuestions_FreeTextQuestions_FreeTextQuestionsId",
                        column: x => x.FreeTextQuestionsId,
                        principalTable: "FreeTextQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestFreeTextQuestions_Tests_TestsId",
                        column: x => x.TestsId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestMultipleChoiceQuestions",
                columns: table => new
                {
                    MultipleChoiceQuestionsId = table.Column<int>(type: "integer", nullable: false),
                    TestsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestMultipleChoiceQuestions", x => new { x.MultipleChoiceQuestionsId, x.TestsId });
                    table.ForeignKey(
                        name: "FK_TestMultipleChoiceQuestions_MultipleChoiceQuestions_Multipl~",
                        column: x => x.MultipleChoiceQuestionsId,
                        principalTable: "MultipleChoiceQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestMultipleChoiceQuestions_Tests_TestsId",
                        column: x => x.TestsId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestCodingQuestions_TestsId",
                table: "TestCodingQuestions",
                column: "TestsId");

            migrationBuilder.CreateIndex(
                name: "IX_TestFreeTextQuestions_TestsId",
                table: "TestFreeTextQuestions",
                column: "TestsId");

            migrationBuilder.CreateIndex(
                name: "IX_TestMultipleChoiceQuestions_TestsId",
                table: "TestMultipleChoiceQuestions",
                column: "TestsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "TestCodingQuestions");

            migrationBuilder.DropTable(
                name: "TestFreeTextQuestions");

            migrationBuilder.DropTable(
                name: "TestMultipleChoiceQuestions");

            migrationBuilder.DropTable(
                name: "CodingQuestions");

            migrationBuilder.DropTable(
                name: "FreeTextQuestions");

            migrationBuilder.DropTable(
                name: "MultipleChoiceQuestions");

            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
