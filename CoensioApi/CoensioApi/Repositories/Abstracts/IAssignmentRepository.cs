using CoensioApi.Data.Models;
using System.Linq.Expressions;

namespace CoensioApi.Repositories.Abstracts
{
    public interface IAssignmentRepository
    {
        AssesmentAssignment Add(AssesmentAssignment assignment);
        List<AssesmentAssignment> Where(Expression<Func<AssesmentAssignment, bool>> lamda);
        AssesmentAssignment GetById(int id);
        public void Update(AssesmentAssignment entity);

    }
}
