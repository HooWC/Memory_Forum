using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform_DomainModelEntity.Models
{
	public class PostWordDataComment
	{
		public int Id { get; set; }
		public int PostWordDataId { get; set; }
		public int UserId { get; set; }
		public string Content { get; set; }
		public DateTime Date { get; set; }
		public bool Status { get; set; }
	}
}
