using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using iOSSpecialFeatures.MobileAppService.Graphs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace iOSSpecialFeatures.MobileAppService.Controllers
{
    [Route("api/[controller]")]
    public class GraphController : Controller
    {
        private readonly ISchema schema;
        private readonly IDocumentExecuter documentExecuter;

        public GraphController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            this.schema = schema;
            this.documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var jsonDebug = query.ToString();
            var inputs = query.Variables.ToInputs();

            var executeOpts = new ExecutionOptions
            {
                Schema = schema,
                Query = query.Query,
                Inputs = inputs
            };

            var result = await documentExecuter.ExecuteAsync(executeOpts).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return this.StatusCode(500, result);
            }

            return Ok(result);
        }
    }
}
