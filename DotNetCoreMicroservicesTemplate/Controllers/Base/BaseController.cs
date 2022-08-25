using DotNetCoreMicroservicesTemplate.Repositories.Base;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Net;

namespace DotNetCoreMicroservicesTemplate.Controllers.Base
{
    public abstract class BaseController<T> : Controller where T : class
    {
        private readonly IBaseRepository<T> _repository;
        private readonly ILogger<T> _logger;

        public BaseController(IBaseRepository<T> repository, ILogger<T> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<T>>> Get()
        {
            var result = await _repository.GetAll();
            return Ok(result);
        }

        [HttpGet("{Id:length(24)}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public virtual async Task<ActionResult<T>> GetProductById(string Id)
        {
            var product = await _repository.Get(Id);

            if (product == null)
            {
                _logger.LogError($"Product with Id: {Id}, not found.");
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("{Search}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public virtual async Task<ActionResult<IEnumerable<T>>> Search(string Search)
        {
            var product = await _repository.Search(Search);

            if (product == null)
            {
                _logger.LogError($"Product(s) with search string: {Search}, not found.");
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public virtual async Task<ActionResult<T>> Create([FromBody] T obj)
        {
            await _repository.Create(obj);
            var id = GetId(obj);
            return CreatedAtAction("GetProductById", new { Id = id }, obj);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] T obj)
        {
            return Ok(await _repository.Update(obj));
        }

        [HttpDelete("{Id:length(24)}")]
        public virtual async Task<IActionResult> DeleteById(string Id)
        {
            return Ok(await _repository.Delete(Id));
        }

        private BsonValue GetId(T entity)
        {
            var bsonDoc = entity.ToBsonDocument();
            return bsonDoc.GetElement("_id").Value;
        }
    }
}
