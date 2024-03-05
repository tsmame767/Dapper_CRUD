using learndapper.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using learndapper.Model;
using learndapper.Repo;

namespace learndapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IDapperService service;
        public TodoController(IDapperService _service) 
        {
            this.service = _service;
        }
        // GET: TodoController
        [HttpGet("GetAll")]

        public async Task<IActionResult> GetAll()
        {
            var list = await this.service.GetAll();
            if (list != null)
            {
                return Ok(list);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetbyId/{Id}")]

        public async Task<IActionResult> GetbyId(int Id)
        {
            var _list = await this.service.Getbyid(Id);
            if (_list != null)
            {
                return Ok(_list);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Employee emp)
        {
            var _list = await this.service.Create(emp);
            if (_list != null)
            {
                return Ok(_list);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
