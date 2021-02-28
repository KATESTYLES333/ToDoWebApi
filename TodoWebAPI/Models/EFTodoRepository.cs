using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoWebAPI.Models
{
	public class EFTodoRepository : ITodoRepository
	{
		public EFTodoDBContext Context;
		public EFTodoRepository(EFTodoDBContext context)
		{
			Context = context;
		}
		public void Create(TodoItem item)
		{
			Context.TodoItems.Add(item);
			Context.SaveChanges();
		}

		public TodoItem Delete(int Id)
		{
			TodoItem item = Get(Id);
			if (item != null)
			{
				Context.TodoItems.Remove(item);
				Context.SaveChanges();
			}
			return item;
		}

		public IEnumerable<TodoItem> Get()
		{
			return Context.TodoItems;
		}

		public TodoItem Get(int id)
		{
			return Context.TodoItems.Find(id);
		}

		public void Update(TodoItem updatedItem)
		{
			TodoItem currentIt = Get(updatedItem.Id);
			currentIt.IsComplete = updatedItem.IsComplete;
			currentIt.TaskDescription = updatedItem.TaskDescription;

			Context.TodoItems.Update(currentIt);
			Context.SaveChanges();
		}

	}
}
