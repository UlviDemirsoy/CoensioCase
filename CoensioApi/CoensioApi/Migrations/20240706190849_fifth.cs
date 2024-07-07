using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoensioApi.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CodingQuestionsTestTakerAnswer_AssesmentAssignments_Assesme~",
                table: "CodingQuestionsTestTakerAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_CodingQuestionsTestTakerAnswer_CodingQuestions_CodingQuesti~",
                table: "CodingQuestionsTestTakerAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_FreeTextQuestionTestTakerAnswer_AssesmentAssignments_Assesm~",
                table: "FreeTextQuestionTestTakerAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_FreeTextQuestionTestTakerAnswer_FreeTextQuestions_FreeTextQ~",
                table: "FreeTextQuestionTestTakerAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_MultipleChoiceQuestionTestTakerAnswer_AssesmentAssignments_~",
                table: "MultipleChoiceQuestionTestTakerAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_MultipleChoiceQuestionTestTakerAnswer_MultipleChoiceQuestio~",
                table: "MultipleChoiceQuestionTestTakerAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MultipleChoiceQuestionTestTakerAnswer",
                table: "MultipleChoiceQuestionTestTakerAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FreeTextQuestionTestTakerAnswer",
                table: "FreeTextQuestionTestTakerAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CodingQuestionsTestTakerAnswer",
                table: "CodingQuestionsTestTakerAnswer");

            migrationBuilder.RenameTable(
                name: "MultipleChoiceQuestionTestTakerAnswer",
                newName: "MultipleChoiceQuestionTestTakerAnswers");

            migrationBuilder.RenameTable(
                name: "FreeTextQuestionTestTakerAnswer",
                newName: "FreeTextQuestionTestTakerAnswers");

            migrationBuilder.RenameTable(
                name: "CodingQuestionsTestTakerAnswer",
                newName: "CodingQuestionsTestTakerAnswers");

            migrationBuilder.RenameIndex(
                name: "IX_MultipleChoiceQuestionTestTakerAnswer_MultipleChoiceQuestio~",
                table: "MultipleChoiceQuestionTestTakerAnswers",
                newName: "IX_MultipleChoiceQuestionTestTakerAnswers_MultipleChoiceQuesti~");

            migrationBuilder.RenameIndex(
                name: "IX_MultipleChoiceQuestionTestTakerAnswer_AssesmentAssignmentId",
                table: "MultipleChoiceQuestionTestTakerAnswers",
                newName: "IX_MultipleChoiceQuestionTestTakerAnswers_AssesmentAssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_FreeTextQuestionTestTakerAnswer_FreeTextQuestionId",
                table: "FreeTextQuestionTestTakerAnswers",
                newName: "IX_FreeTextQuestionTestTakerAnswers_FreeTextQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_FreeTextQuestionTestTakerAnswer_AssesmentAssignmentId",
                table: "FreeTextQuestionTestTakerAnswers",
                newName: "IX_FreeTextQuestionTestTakerAnswers_AssesmentAssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_CodingQuestionsTestTakerAnswer_CodingQuestionId",
                table: "CodingQuestionsTestTakerAnswers",
                newName: "IX_CodingQuestionsTestTakerAnswers_CodingQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_CodingQuestionsTestTakerAnswer_AssesmentAssignmentId",
                table: "CodingQuestionsTestTakerAnswers",
                newName: "IX_CodingQuestionsTestTakerAnswers_AssesmentAssignmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MultipleChoiceQuestionTestTakerAnswers",
                table: "MultipleChoiceQuestionTestTakerAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FreeTextQuestionTestTakerAnswers",
                table: "FreeTextQuestionTestTakerAnswers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CodingQuestionsTestTakerAnswers",
                table: "CodingQuestionsTestTakerAnswers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CodingQuestionsTestTakerAnswers_AssesmentAssignments_Assesm~",
                table: "CodingQuestionsTestTakerAnswers",
                column: "AssesmentAssignmentId",
                principalTable: "AssesmentAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CodingQuestionsTestTakerAnswers_CodingQuestions_CodingQuest~",
                table: "CodingQuestionsTestTakerAnswers",
                column: "CodingQuestionId",
                principalTable: "CodingQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FreeTextQuestionTestTakerAnswers_AssesmentAssignments_Asses~",
                table: "FreeTextQuestionTestTakerAnswers",
                column: "AssesmentAssignmentId",
                principalTable: "AssesmentAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FreeTextQuestionTestTakerAnswers_FreeTextQuestions_FreeText~",
                table: "FreeTextQuestionTestTakerAnswers",
                column: "FreeTextQuestionId",
                principalTable: "FreeTextQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MultipleChoiceQuestionTestTakerAnswers_AssesmentAssignments~",
                table: "MultipleChoiceQuestionTestTakerAnswers",
                column: "AssesmentAssignmentId",
                principalTable: "AssesmentAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MultipleChoiceQuestionTestTakerAnswers_MultipleChoiceQuesti~",
                table: "MultipleChoiceQuestionTestTakerAnswers",
                column: "MultipleChoiceQuestionId",
                principalTable: "MultipleChoiceQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CodingQuestionsTestTakerAnswers_AssesmentAssignments_Assesm~",
                table: "CodingQuestionsTestTakerAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_CodingQuestionsTestTakerAnswers_CodingQuestions_CodingQuest~",
                table: "CodingQuestionsTestTakerAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_FreeTextQuestionTestTakerAnswers_AssesmentAssignments_Asses~",
                table: "FreeTextQuestionTestTakerAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_FreeTextQuestionTestTakerAnswers_FreeTextQuestions_FreeText~",
                table: "FreeTextQuestionTestTakerAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_MultipleChoiceQuestionTestTakerAnswers_AssesmentAssignments~",
                table: "MultipleChoiceQuestionTestTakerAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_MultipleChoiceQuestionTestTakerAnswers_MultipleChoiceQuesti~",
                table: "MultipleChoiceQuestionTestTakerAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MultipleChoiceQuestionTestTakerAnswers",
                table: "MultipleChoiceQuestionTestTakerAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FreeTextQuestionTestTakerAnswers",
                table: "FreeTextQuestionTestTakerAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CodingQuestionsTestTakerAnswers",
                table: "CodingQuestionsTestTakerAnswers");

            migrationBuilder.RenameTable(
                name: "MultipleChoiceQuestionTestTakerAnswers",
                newName: "MultipleChoiceQuestionTestTakerAnswer");

            migrationBuilder.RenameTable(
                name: "FreeTextQuestionTestTakerAnswers",
                newName: "FreeTextQuestionTestTakerAnswer");

            migrationBuilder.RenameTable(
                name: "CodingQuestionsTestTakerAnswers",
                newName: "CodingQuestionsTestTakerAnswer");

            migrationBuilder.RenameIndex(
                name: "IX_MultipleChoiceQuestionTestTakerAnswers_MultipleChoiceQuesti~",
                table: "MultipleChoiceQuestionTestTakerAnswer",
                newName: "IX_MultipleChoiceQuestionTestTakerAnswer_MultipleChoiceQuestio~");

            migrationBuilder.RenameIndex(
                name: "IX_MultipleChoiceQuestionTestTakerAnswers_AssesmentAssignmentId",
                table: "MultipleChoiceQuestionTestTakerAnswer",
                newName: "IX_MultipleChoiceQuestionTestTakerAnswer_AssesmentAssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_FreeTextQuestionTestTakerAnswers_FreeTextQuestionId",
                table: "FreeTextQuestionTestTakerAnswer",
                newName: "IX_FreeTextQuestionTestTakerAnswer_FreeTextQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_FreeTextQuestionTestTakerAnswers_AssesmentAssignmentId",
                table: "FreeTextQuestionTestTakerAnswer",
                newName: "IX_FreeTextQuestionTestTakerAnswer_AssesmentAssignmentId");

            migrationBuilder.RenameIndex(
                name: "IX_CodingQuestionsTestTakerAnswers_CodingQuestionId",
                table: "CodingQuestionsTestTakerAnswer",
                newName: "IX_CodingQuestionsTestTakerAnswer_CodingQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_CodingQuestionsTestTakerAnswers_AssesmentAssignmentId",
                table: "CodingQuestionsTestTakerAnswer",
                newName: "IX_CodingQuestionsTestTakerAnswer_AssesmentAssignmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MultipleChoiceQuestionTestTakerAnswer",
                table: "MultipleChoiceQuestionTestTakerAnswer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FreeTextQuestionTestTakerAnswer",
                table: "FreeTextQuestionTestTakerAnswer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CodingQuestionsTestTakerAnswer",
                table: "CodingQuestionsTestTakerAnswer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CodingQuestionsTestTakerAnswer_AssesmentAssignments_Assesme~",
                table: "CodingQuestionsTestTakerAnswer",
                column: "AssesmentAssignmentId",
                principalTable: "AssesmentAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CodingQuestionsTestTakerAnswer_CodingQuestions_CodingQuesti~",
                table: "CodingQuestionsTestTakerAnswer",
                column: "CodingQuestionId",
                principalTable: "CodingQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FreeTextQuestionTestTakerAnswer_AssesmentAssignments_Assesm~",
                table: "FreeTextQuestionTestTakerAnswer",
                column: "AssesmentAssignmentId",
                principalTable: "AssesmentAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FreeTextQuestionTestTakerAnswer_FreeTextQuestions_FreeTextQ~",
                table: "FreeTextQuestionTestTakerAnswer",
                column: "FreeTextQuestionId",
                principalTable: "FreeTextQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MultipleChoiceQuestionTestTakerAnswer_AssesmentAssignments_~",
                table: "MultipleChoiceQuestionTestTakerAnswer",
                column: "AssesmentAssignmentId",
                principalTable: "AssesmentAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MultipleChoiceQuestionTestTakerAnswer_MultipleChoiceQuestio~",
                table: "MultipleChoiceQuestionTestTakerAnswer",
                column: "MultipleChoiceQuestionId",
                principalTable: "MultipleChoiceQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
