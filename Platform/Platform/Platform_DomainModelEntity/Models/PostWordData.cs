using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform_DomainModelEntity.Models
{
	public class PostWordData
	{
		public int Id { get; set; }
		public int PostWordId { get; set; }
		public string ImgList { get; set; }
		public string Content { get; set; }
	}
}
