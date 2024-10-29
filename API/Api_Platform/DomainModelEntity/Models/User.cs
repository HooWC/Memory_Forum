using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModelEntity.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		public string? userNoId { get; set; }
		public string? avatar { get; set; }
		public string? username { get; set; }
		public string? password { get; set; }
		public string? gmail { get; set; }
		public string? phone { get; set; }
		public string? gender { get; set; }
		public string? level { get; set; }
		public int experience { get; set; }
		public int maxexperience { get; set; }
		public bool signIn { get; set; }
		public DateTime signInDate { get; set; }
		public int continuous_check_day { get; set; }
		public int total_day { get; set; }
		public string? address { get; set; }
		public bool status { get; set; }
		public int security_question { get; set; }
		public string? security_question_answers { get; set; }
		public int login_count { get; set; }
	}
}
