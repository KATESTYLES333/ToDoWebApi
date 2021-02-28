using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoWebAPI.Models
{
	public class EFTodoDBContext : DbContext
	{
		public EFTodoDBContext(DbContextOptions<EFTodoDBContext> options) : base(options)
		{ }
		public DbSet<TodoItem> TodoItems { get; set; }	
	}
}
