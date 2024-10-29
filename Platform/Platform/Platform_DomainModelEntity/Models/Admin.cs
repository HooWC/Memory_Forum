using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform_DomainModelEntity.Models
{
	public class Admin
	{
		public int Id { get; set; }
		public string avatar { get; set; }
		public string username { get; set; }
		public string password { get; set; }
		public bool status { get; set; }
	}
}
