using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Platform.Models;
using Platform_Infrastruture.Api;

namespace Platform.Controllers
{
	public class HomeController : Controller
	{
		public UserApi userapi = new UserApi();
		public PostWordApi postwordapi = new PostWordApi();
		public PostWordDataApi postworddateapi = new PostWordDataApi();

		public async Task<IActionResult> HomePage()
		{
			var data = postwordapi.GetAllPostWord().Result;
			var emotion = data.Where(x => x.type_main == "emotional" && x.status != false).ToList();
			var music = data.Where(x => x.type_main == "music" && x.status != false).ToList();
			var anime = data.Where(x => x.type_main == "hzw" && x.status != false).ToList();

			int[] randomIndices1 = GenerateRandomIndices(emotion.Count, 6);
			int[] randomIndices2 = GenerateRandomIndices(music.Count, 6);
			int[] randomIndices3 = GenerateRandomIndices(anime.Count, 6);

			ViewBag.emotionView = randomIndices1.Select(index => emotion[index]).ToList();
			ViewBag.musicView = randomIndices2.Select(index => music[index]).ToList();
			ViewBag.animeView = randomIndices3.Select(index => anime[index]).ToList();

			//==

			var userdata = userapi.GetAllUser().Result;
			var postworddata = postworddateapi.GetAllPostWordData().Result;
			var postdata = postwordapi.GetAllPostWord().Result;
			var poststatus = postdata.Where(x => x.status == true).ToList();
			var imgpostdata = poststatus.Where(x => x.imglist != "Null" && x.type_main != "all").ToList();
			int[] randomIndices = GenerateRandomIndices(imgpostdata.Count, 4);
			var randomFourData = randomIndices.Select(index => imgpostdata[index]).ToList();

			var db = (from c in randomFourData
					  join pd in poststatus on c.Id equals pd.Id
					  join user in userdata on c.userid equals user.Id
					  select new
					  {
						  Id = c.Id,
						  title = c.title,
						  ImgList = pd.imglist?.Split('|').Take(1).FirstOrDefault(),
						  type = c.type_main,
						  username = user.username
					  }).ToList();

			ViewBag.randomlist = db;

			//==

			foreach (var i in userdata)
			{
				DateTime today = DateTime.Now;
				string todayAsString = today.ToString("yyyy-MM-dd");
				var date = i.signInDate.ToString("yyyy-MM-dd");

				if (todayAsString != date)
				{
					i.login_count = 3;
					i.signIn = false;
				}

				await userapi.EditUser(i);
			}

			//==

			ViewBag.usercount = userdata.Count;
			ViewBag.postcount = postdata.Count;
			ViewBag.today = DateTime.Now.ToString("MMM dd", new System.Globalization.CultureInfo("en-US")); /*new System.Globalization.CultureInfo("en-US")*/
			ViewBag.userlock = userdata.Where(x => x.status == false).Count();

			ViewBag.test = LoginController.user_data;

			return View();
		}

		public static int[] GenerateRandomIndices(int count, int num)
		{
			Random random = new Random();
			return Enumerable.Range(0, count).OrderBy(_ => random.Next()).Take(num).ToArray();
		}

		public async Task<IActionResult> Daily_SignIn()
		{

			string userValue = HttpContext.Session.GetString("user");
			bool b = false;
			ViewBag.b = b;
			ViewBag.countSignin = 0;

			var data = userapi.GetAllUser().Result;
			DateTime today = DateTime.Today;
			string formattedDate = today.ToString("yyyy-MM-dd");

			var Fuser = data.Where(x => x.signInDate.ToString("yyyy-MM-dd") != formattedDate).ToList();
			Fuser.ForEach(x => x.signIn = false);

			foreach (var i in Fuser)
				await userapi.EditUser(i);

			if (userValue != "" && userValue != null)
			{
				var db = data.Where(x => x.Id == Convert.ToInt32(userValue)).FirstOrDefault();


				if (db != null)
				{
					if (db.signIn == false)
						b = false;
					else
						b = true;
				}

				ViewBag.b = b;
				ViewBag.countSignin = data.Where(x => x.signIn == true).ToList().Count;
				return View();
			}

			ViewBag.countSignin = data.Where(x => x.signIn == true).ToList().Count;

			return View();
		}

		public async Task<IActionResult> Daily_SignIn_Update()
		{
			string userValue = HttpContext.Session.GetString("user");
			if (userValue == "" || userValue == null)
				return RedirectToAction("Login", "Login");

			var data = userapi.GetAllUser().Result;
			var db = data.Where(x => x.Id == Convert.ToInt32(userValue)).FirstOrDefault();

			var maxexprience = db.maxexperience;
			var exprience = db.experience;
			var level = db.level;
			//======

			var new_exprience = exprience + 20;
			if (new_exprience >= maxexprience) //200 / 200
			{
				if (Convert.ToInt32(level) != 70)
				{
					level = (Convert.ToInt32(level) + 1).ToString();
					var new_maxexprience = maxexprience + 150;
					var more_exprience = new_exprience - maxexprience;
					//======  new data
					db.level = level;
					db.maxexperience = new_maxexprience;
					db.experience = more_exprience;

					//称号
					if (Convert.ToInt32(level) == 3)
						db.address = "Active Contributor";
					else if (Convert.ToInt32(level) == 7)
						db.address = "Skilled Player";
					else if (Convert.ToInt32(level) == 15)
						db.address = "Expert";
					else if (Convert.ToInt32(level) == 20)
						db.address = "Senior User";
					else if (Convert.ToInt32(level) == 22)
						db.address = "Gold Member";
					else if (Convert.ToInt32(level) == 28)
						db.address = "Forum Enthusiast";
					else if (Convert.ToInt32(level) == 34)
						db.address = "Star of Honor";
					else if (Convert.ToInt32(level) == 40)
						db.address = "Dark Knight";
					else if (Convert.ToInt32(level) == 45)
						db.address = "Abyss Swordsman";
					else if (Convert.ToInt32(level) == 50)
						db.address = "Lone Swordsman";
					else if (Convert.ToInt32(level) == 55)
						db.address = "Fate Runner";
					else if (Convert.ToInt32(level) == 60)
						db.address = "Aurora Swordsman";
					else if (Convert.ToInt32(level) == 65)
						db.address = "Eternal Conqueror";
					else if (Convert.ToInt32(level) == 70)
						db.address = "Moderator";
				}
				else if (Convert.ToInt32(level) == 70)
				{
					db.level = level;
					db.maxexperience = maxexprience;
					db.experience = maxexprience;
				}
			}
			else
			{
				db.experience = new_exprience;
			}


			DateTime today = DateTime.Now;
			DateTime yesterday = today.AddDays(-1);

			DateTime dbSignInDate = db.signInDate;

			string yesterdayAsString = yesterday.ToString("yyyy-MM-dd");
			string dbSignInDateAsString = dbSignInDate.ToString("yyyy-MM-dd");

			if (yesterdayAsString == dbSignInDateAsString)
			{
				db.continuous_check_day += 1;
			}
			else
			{
				db.continuous_check_day = 1;
			}

			db.total_day += 1;
			db.signIn = true;
			db.signInDate = today;

			await userapi.EditUser(db);

			return RedirectToAction("Daily_SignIn", "Home");
		}

		public IActionResult Rules()
		{
			return View();
		}

		public IActionResult Customer_Services()
		{
			return View();
		}

		public IActionResult Common_Problems()
		{
			return View();
		}

	}
}