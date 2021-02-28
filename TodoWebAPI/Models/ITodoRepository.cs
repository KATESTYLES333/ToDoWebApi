using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoWebAPI.Models;

namespace TodoWebAPI
{
	public interface ITodoRepository
	{
		IEnumerable<TodoItem> Get();
		TodoItem Get(int id);
		void Create(TodoItem item);
		void Update(TodoItem item);
		TodoItem Delete(int Id);
	}
}
