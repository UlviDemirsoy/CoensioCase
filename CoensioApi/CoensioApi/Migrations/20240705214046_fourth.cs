using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CoensioApi.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodingQuestionsTestTakerAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssesmentAssignmentId = table.Column<int>(type: "integer", nullable: false),
                    CodingQuestionId = table.Column<int>(type: "integer", nullable: false),
                    UserSubmission = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodingQuestionsTestTakerAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodingQuestionsTestTakerAnswer_AssesmentAssignments_Assesme~",
                        column: x => x.AssesmentAssignmentId,
                        principalTable: "AssesmentAssignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CodingQuestionsTestTakerAnswer_CodingQuestions_CodingQuesti~",
                        column: x => x.CodingQuestionId,
                        principalTable: "CodingQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FreeTextQuestionTestTakerAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssesmentAssignmentId = table.Column<int>(type: "integer", nullable: false),
                    FreeTextQuestionId = table.Column<int>(type: "integer", nullable: false),
                    UserSubmission = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreeTextQuestionTestTakerAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FreeTextQuestionTestTakerAnswer_AssesmentAssignments_Assesm~",
                        column: x => x.AssesmentAssignmentId,
                        principalTable: "AssesmentAssignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FreeTextQuestionTestTakerAnswer_FreeTextQuestions_FreeTextQ~",
                        column: x => x.FreeTextQuestionId,
                        principalTable: "FreeTextQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultipleChoiceQuestionTestTakerAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssesmentAssignmentId = table.Column<int>(type: "integer", nullable: false),
                    MultipleChoiceQuestionId = table.Column<int>(type: "integer", nullable: false),
                    UserSubmission = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceQuestionTestTakerAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceQuestionTestTakerAnswer_AssesmentAssignments_~",
                        column: x => x.AssesmentAssignmentId,
                        principalTable: "AssesmentAssignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceQuestionTestTakerAnswer_MultipleChoiceQuestio~",
                        column: x => x.MultipleChoiceQuestionId,
                        principalTable: "MultipleChoiceQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CodingQuestionsTestTakerAnswer_AssesmentAssignmentId",
                table: "CodingQuestionsTestTakerAnswer",
                column: "AssesmentAssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CodingQuestionsTestTakerAnswer_CodingQuestionId",
                table: "CodingQuestionsTestTakerAnswer",
                column: "CodingQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_FreeTextQuestionTestTakerAnswer_AssesmentAssignmentId",
                table: "FreeTextQuestionTestTakerAnswer",
                column: "AssesmentAssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FreeTextQuestionTestTakerAnswer_FreeTextQuestionId",
                table: "FreeTextQuestionTestTakerAnswer",
                column: "FreeTextQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceQuestionTestTakerAnswer_AssesmentAssignmentId",
                table: "MultipleChoiceQuestionTestTakerAnswer",
                column: "AssesmentAssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MultipleChoiceQuestionTestTakerAnswer_MultipleChoiceQuestio~",
                table: "MultipleChoiceQuestionTestTakerAnswer",
                column: "MultipleChoiceQuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodingQuestionsTestTakerAnswer");

            migrationBuilder.DropTable(
                name: "FreeTextQuestionTestTakerAnswer");

            migrationBuilder.DropTable(
                name: "MultipleChoiceQuestionTestTakerAnswer");
        }
    }
}
