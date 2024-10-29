using Microsoft.AspNetCore.Mvc;
using Platform_Infrastruture.Api;

namespace Platform.Controllers
{
	public class SearchController : Controller
	{
		public PostWordApi postwordapi = new PostWordApi();
		public UserApi userapi = new UserApi();
		public SayHelloApi sayhelloapi = new SayHelloApi();
		public FriendApi friendapi = new FriendApi();
		public PostWordDataApi postworddateapi = new PostWordDataApi();
		public PostWordDataCommentApi postworddatacommentapi = new PostWordDataCommentApi();

		public IActionResult Search(string value)
		{
			string userValue = HttpContext.Session.GetString("user");
			if (userValue == "" || userValue == null)
				return RedirectToAction("Login", "Login");

			ViewBag.value = value;
			return View();
		}
	}
}
