using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoWebAPI.Models
{
	public class TodoItem
	{
		public int Id { get; set; }
		public string TaskDescription { get; set; }
		public bool IsComplete { get; set; }
	}
}
