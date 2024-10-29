using System;
using Microsoft.AspNetCore.Mvc;
using Platform_DomainModelEntity.Models;
using Platform_Infrastruture.Api;

namespace Platform.Controllers
{
	public class OtherProfileController : Controller
	{
		public UserApi userapi = new UserApi();
		public FriendApi friendapi = new FriendApi();
		public SayHelloApi sayhelloapi = new SayHelloApi();

		public IActionResult Index(int id)
		{
			HttpContext.Session.SetString("otheruser", id.ToString());
			return View();
		}

		public IActionResult Friend(int id)
		{
			HttpContext.Session.SetString("otheruser", id.ToString());
			return View();
		}

		public IActionResult Post(int id)
		{
			HttpContext.Session.SetString("otheruser", id.ToString());
			return View();
		}

		public async Task<IActionResult> MakeFriend(int id, int dbid, string type)
		{
			string userValue = HttpContext.Session.GetString("user");
			if (userValue == "" || userValue == null)
				return RedirectToAction("Login", "Login");

			Friend fri = new Friend()
			{
				userid = Convert.ToInt32(userValue),
				friendid = id,
				status = "pending"
			};

			await friendapi.FriendCreateDat(fri);

			return RedirectToAction("ContentPage", "Content", new { id = dbid, type = type });
		}

		public async Task<IActionResult> Hello(int id, int dbid, string type)
		{
			string userValue = HttpContext.Session.GetString("user");
			if (userValue == "" || userValue == null)
				return RedirectToAction("Login", "Login");



			SayHello say = new SayHello()
			{
				userId = Convert.ToInt32(userValue),
				otherUserId = id,
				date = DateTime.Now
			};

			await sayhelloapi.SayHelloCreateData(say);

			return RedirectToAction("ContentPage", "Content", new { id = dbid, type = type });
		}

	}
}
