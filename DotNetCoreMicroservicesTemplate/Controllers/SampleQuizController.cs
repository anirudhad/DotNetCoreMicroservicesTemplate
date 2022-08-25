using DotNetCoreMicroservicesTemplate.Controllers.Base;
using DotNetCoreMicroservicesTemplate.Entities;
using DotNetCoreMicroservicesTemplate.Repositories;
using DotNetCoreMicroservicesTemplate.Repositories.Base;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreMicroservicesTemplate.Controllers
{
    [ApiController]
    [Route("SampleQuizAPI/v1/[controller]")]
    public class SampleQuizController : BaseController<SampleQuiz>
    {
        public SampleQuizController(ISampleQuizRepository repository, ILogger<SampleQuiz> logger) : base(repository, logger)
        {
        }
    }
}
