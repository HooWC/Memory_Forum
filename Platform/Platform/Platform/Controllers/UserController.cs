using Microsoft.AspNetCore.Mvc;
using Platform_DomainModelEntity.Models;
using Platform_Infrastruture.Api;

namespace Platform.Controllers
{
	public class UserController : Controller
	{
		public UserApi userapi = new UserApi();
		public PostWordApi postwordapi = new PostWordApi();
		public SayHelloApi sayhelloapi = new SayHelloApi();
		public FriendApi friendapi = new FriendApi();

		public IActionResult Index()
		{
			string userValue = HttpContext.Session.GetString("user");
			if (userValue == "" || userValue == null)
				return RedirectToAction("Login", "Login");

			var post = postwordapi.GetAllPostWord().Result;
			var say = sayhelloapi.GetAllSayHello().Result;
			var friend = friendapi.GetAllFriend().Result;

			ViewBag.postCount = post.Where(x => x.userid == Convert.ToInt32(userValue)).Count();
			ViewBag.sayCount = say.Where(x => x.otherUserId == Convert.ToInt32(userValue)).Count();
			ViewBag.friendCount = friend.Where(x =>
				x.userid == Convert.ToInt32(userValue) && x.status == "true" ||
				x.friendid == Convert.ToInt32(userValue) && x.status == "true"
			).Count();

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UserEdit(IFormFile file, int id)
		{
			var data = userapi.GetAllUser().Result;
			var user = data.Where(x => x.Id == id).FirstOrDefault();

			if (file != null)
			{
				string filePath = $@"wwwroot/Img/Avatar/{user.Id + user.username + file.FileName}";
				using (var stream = System.IO.File.Create(filePath))
				{
					await file.CopyToAsync(stream);
				};

				user.avatar = user.Id + user.username + file.FileName;
				await userapi.EditUser(user);
			}

			return RedirectToAction("Index", "User");
		}

		public IActionResult BestFriend()
		{
			string userValue = HttpContext.Session.GetString("user");
			if (userValue == "" || userValue == null)
				return RedirectToAction("Login", "Login");
			return View();
		}

		public IActionResult SayHello()
		{
			string userValue = HttpContext.Session.GetString("user");
			if (userValue == "" || userValue == null)
				return RedirectToAction("Login", "Login");
			return View();
		}

		public IActionResult UserPost()
		{

			string userValue = HttpContext.Session.GetString("user");
			if (userValue == "" || userValue == null)
				return RedirectToAction("Login", "Login");
			return View();
		}
	}
}
