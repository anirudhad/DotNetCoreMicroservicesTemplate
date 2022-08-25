using DotNetCoreMicroservicesTemplate.Data;
using DotNetCoreMicroservicesTemplate.Entities;
using DotNetCoreMicroservicesTemplate.Repositories.Base;
namespace DotNetCoreMicroservicesTemplate.Repositories
{
    public class SampleQuizRepository : BaseRepository<SampleQuiz>, ISampleQuizRepository
    {
        public SampleQuizRepository(IDatabaseContext context) : base(context)
        {
        }
    }
}
