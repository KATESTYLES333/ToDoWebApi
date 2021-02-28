using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoWebAPI.Models;

namespace TodoWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TodoController : Controller
	{
		ITodoRepository TodoRepository;

		public TodoController(ITodoRepository todoRepository)
		{
			TodoRepository = todoRepository;
		}

		[HttpGet(Name = "GetAllItems")]
		public IEnumerable<TodoItem> Get() { return TodoRepository.Get(); }

		[HttpGet("{id}", Name = "GetTodoItem")]
		public IActionResult Get(int Id)
		{
			TodoItem item = TodoRepository.Get(Id);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

		[HttpPost]
		public IActionResult Create([FromBody] TodoItem todoItem)
		{
			if (todoItem == null)
			{
				return BadRequest();
			}
			TodoRepository.Create(todoItem);
			return CreatedAtRoute("GetTodoItem", new { id = todoItem.Id }, todoItem);
		}

		[HttpPut("id")]
		public IActionResult Update(int Id, [FromBody] TodoItem updateItem)
		{
			if (updateItem == null || updateItem.Id != Id)
			{
				return BadRequest();
			}

			var todoItem = TodoRepository.Get(Id);
			if (todoItem == null)
			{
				return NotFound();
			}

			TodoRepository.Update(updateItem);
			return RedirectToRoute("GetAllItems");
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int Id)
		{
			var delItem = TodoRepository.Delete(Id);
			if (delItem == null)
			{
				return BadRequest();

			}
			return new ObjectResult(delItem);

		}
	}
}
