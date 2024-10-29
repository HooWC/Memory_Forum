using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform_DomainModelEntity.Models
{
	public class PostWord
	{
		public int Id { get; set; }
		public int userid { get; set; }
		public string title { get; set; }
		public string imglist { get; set; }
		public bool status { get; set; }
		public string type_main { get; set; }
		public string type_post { get; set; }
		public DateTime date_post { get; set; }
		public int money { get; set; }
		public string role { get; set; }
		public int View { get; set; }
		public int Comment { get; set; }
		public string Color { get; set; }
	}
}
