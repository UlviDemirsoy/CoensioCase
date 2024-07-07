using CoensioApi.Data.Dtos;
using CoensioApi.Data.Models;

namespace CoensioApi.Services.Abstracts
{
    public interface IAssignmentService
    {
        List<AssesmentAssignment> GetCurrentUserAssignments();
        AssesmentAssignment CreateTestAssignment(dtoCreateTestAssignment dto);
        void CreateSubmission(dtoCreateSubmission dto);
    }
}
