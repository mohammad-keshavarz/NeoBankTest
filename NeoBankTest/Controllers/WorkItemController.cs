using Domain.Service;
using Domain.Service.Azure;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NeoBankTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkItemController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IUserService _userService;
        private readonly IRequestService<dynamic, dynamic> _RequestService;
        private readonly IAzureService<dynamic, dynamic> _AzureService;
        public WorkItemController(ILogger<AuthenticationController> logger, IUserService userService, IRequestService<dynamic, dynamic> requestService, IAzureService<dynamic,dynamic> azureService)
        {
            _logger = logger;
            _userService = userService;
            _RequestService = requestService;
            _AzureService = azureService;
        }
        // GET: api/<WorkItemController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<WorkItemController>/5
        [HttpGet("{id}")]
        public  async Task<dynamic> Get(int id)
        {
            var workItemList = new List<int>(id) { id};
            var workItem =  _AzureService.GetWorkItem(workItemList);
            return workItem;
        }

        // POST api/<WorkItemController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WorkItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WorkItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
