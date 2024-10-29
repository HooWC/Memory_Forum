using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Platform_DomainModelEntity.Models;
using Platform_Infrastruture.Api;

namespace Platform.Controllers
{
	public class LoginController : Controller
	{
		public UserApi userapi = new UserApi();
		public static User user_data = new User();

		public IActionResult Login()
		{
			string userValue = HttpContext.Session.GetString("user");
			if (userValue != "" || userValue != null)
				HttpContext.Session.SetString("user", "");

			ViewBag.failed = false;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(User res)
		{
			ViewBag.failed = false;
			var data = userapi.GetAllUser().Result;
			var db = data.Where(x => x.username == res.username).FirstOrDefault();
			if (db != null)
			{
				bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(res.password, db.password);
				if (isPasswordCorrect)
				{

					//更改登入status  每天
					DateTime today = DateTime.Now;
					string todayAsString = today.ToString("yyyy-MM-dd");
					var date = db.signInDate.ToString("yyyy-MM-dd");
					if (todayAsString != date)
					{
						db.signInDate = today;
					}

					await userapi.EditUser(db);

					if (db.login_count != 0)
					{
						if ((res.security_question == db.security_question) && (res.security_question_answers == db.security_question_answers))
						{
							ViewBag.failed = false;

							// 这是保存用户的id，登入的时候
							HttpContext.Session.SetString("user", db.Id.ToString());

							return RedirectToAction("HomePage", "Home");
						}
						else
						{
							db.login_count -= 1;
							await userapi.EditUser(db);
							ViewBag.logfailed = $"Login failed, there are {db.login_count} chances left";
							ViewBag.failed = true;
							return View();
						}
					}
					else
					{
						ViewBag.logfailed = $"Can't log in anymore today";
						ViewBag.failed = true;
						return View();
					}
				}
			}

			ViewBag.logfailed = $"Login failed";
			ViewBag.failed = true;
			return View();
		}

		public IActionResult Register()
		{
			string userValue = HttpContext.Session.GetString($"user");

			if (userValue != "" || userValue != null)
				HttpContext.Session.SetString("user", "");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(User res)
		{
			var data = userapi.GetAllUser().Result;
			var userNoId_data = "UID-2";
			if (data.Count != 0)
			{
				var last = data.LastOrDefault();
				var latid = last.userNoId; // UID-12
				int hyphenIndex = latid.ToString().IndexOf('-');

				string part1 = latid.ToString().Substring(0, hyphenIndex + 1);
				int part2 = Convert.ToInt32(latid.ToString().Substring(hyphenIndex + 1)) + 1;
				userNoId_data = part1 + part2;
			}

			var ava = "";
			if (res.gender == "0")
				ava = "maleAvatar.jpg";
			else if (res.gender == "1")
				ava = "femaleAvatar.jpg";
			else
				ava = "Avatar.png";

			string hashedPassword = BCrypt.Net.BCrypt.HashPassword(res.password);

			User user = new User()
			{
				userNoId = userNoId_data,
				avatar = ava,
				username = res.username,
				password = hashedPassword,
				gmail = res.gmail,
				phone = res.phone,
				gender = res.gender,
				level = "1",
				experience = 0,
				maxexperience = 100,
				signIn = false,
				signInDate = DateTime.Now,
				continuous_check_day = 0,
				total_day = 0,
				address = "Newbie",
				status = true,
				security_question = res.security_question,
				security_question_answers = res.security_question_answers,
				login_count = 3
			};

			await userapi.UserCreateDat(user);

			return RedirectToAction("Login", "Login");
		}

		public IActionResult ForgetPassword()
		{
			string userValue = HttpContext.Session.GetString("user");
			if (userValue != "" || userValue != null)
				HttpContext.Session.SetString("user", "");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ForgetPassword(User res, string cpassword)
		{
			var data = userapi.GetAllUser().Result;
			var db = data.Where(x => x.username == res.username && x.gmail == res.gmail).FirstOrDefault();
			var right = res.password == cpassword;

			if (db != null && right)
			{
				string hashedPassword = BCrypt.Net.BCrypt.HashPassword(res.password);
				db.password = hashedPassword;
				await userapi.EditUser(db);

				return RedirectToAction("Login", "Login");
			}
			else
			{
				return RedirectToAction("ForgetPassword", "Login");
			}
		}


		public IActionResult Logout()
		{
			HttpContext.Session.SetString("user", "");
			return RedirectToAction("HomePage", "Home");
		}

		//====================

		public static bool ContainsLetter(string text)
		{
			foreach (char c in text)
			{
				if (char.IsLetter(c))
				{
					return true;
				}
			}
			return false;
		}
	}
}
