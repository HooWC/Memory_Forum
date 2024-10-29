using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Platform_DomainModelEntity.Models;
using Platform_Infrastruture.Api;

namespace Platform.Controllers
{
	public class PostContentController : Controller
	{
		public UserApi userapi = new UserApi();
		public PostWordApi postwordapi = new PostWordApi();
		public PostWordDataApi postworddataapi = new PostWordDataApi();

		public IActionResult Normal(string link)
		{
			string userValue = HttpContext.Session.GetString("user");
			if (userValue == "" || userValue == null)
				return RedirectToAction("Login", "Login");

			if (link == "hzw")
			{
				ViewBag.PageName = "hzw";
				ViewBag.Name = "One Piece";
			}
			else if (link == "hyrz")
			{
				ViewBag.PageName = "hyrz";
				ViewBag.Name = "Naruto";
			}
			else if (link == "casual")
			{
				ViewBag.PageName = "casual";
				ViewBag.Name = "Casual Chat";
			}
			else if (link == "emotional")
			{
				ViewBag.PageName = "emotional";
				ViewBag.Name = "Emotional Station";
			}
			else if (link == "findapartner")
			{
				ViewBag.PageName = "findapartner";
				ViewBag.Name = "Find a Partner";
			}
			else if (link == "penangcuisine")
			{
				ViewBag.PageName = "penangcuisine";
				ViewBag.Name = "Penang Cuisine";
			}
			else if (link == "kualalumpurcuisine")
			{
				ViewBag.PageName = "kualalumpurcuisine";
				ViewBag.Name = "Kuala Lumpur Cuisine";
			}
			else if (link == "internationalcuisine")
			{
				ViewBag.PageName = "internationalcuisine";
				ViewBag.Name = "International Cuisine";
			}
			else if (link == "foodcreation")
			{
				ViewBag.PageName = "foodcreation";
				ViewBag.Name = "Food Creation/Sharing";
			}
			else if (link == "travel")
			{
				ViewBag.PageName = "travel";
				ViewBag.Name = "Travel Adventures";
			}
			else if (link == "urban")
			{
				ViewBag.PageName = "urban";
				ViewBag.Name = "Urban Excursions";
			}
			else if (link == "overseas")
			{
				ViewBag.PageName = "overseas";
				ViewBag.Name = "Overseas Travel";
			}
			else if (link == "snack")
			{
				ViewBag.PageName = "snack";
				ViewBag.Name = "Snack Discussion";
			}
			else if (link == "nutritious")
			{
				ViewBag.PageName = "nutritious";
				ViewBag.Name = "Nutritious Foods";
			}
			else if (link == "healthy")
			{
				ViewBag.PageName = "healthy";
				ViewBag.Name = "Healthy Practices";
			}
			else if (link == "maintainingfitness")
			{
				ViewBag.PageName = "maintainingfitness";
				ViewBag.Name = "Maintaining Fitness";
			}
			else if (link == "buildingrelationships")
			{
				ViewBag.PageName = "buildingrelationships";
				ViewBag.Name = "Building Relationships";
			}
			else if (link == "personalgrowth")
			{
				ViewBag.PageName = "personalgrowth";
				ViewBag.Name = "Personal Growth";
			}
			else if (link == "happinesstechniques")
			{
				ViewBag.PageName = "happinesstechniques";
				ViewBag.Name = "Happiness Techniques";
			}
			else if (link == "lifeskillsdiscussion")
			{
				ViewBag.PageName = "lifeskillsdiscussion";
				ViewBag.Name = "Life Skills Discussion";
			}
			else if (link == "malaysiadiscussion")
			{
				ViewBag.PageName = "malaysiadiscussion";
				ViewBag.Name = "Malaysia Discussion";
			}
			else if (link == "foreigndiscussions")
			{
				ViewBag.PageName = "foreigndiscussions";
				ViewBag.Name = "Foreign Discussions";
			}
			else if (link == "newsdiscussions")
			{
				ViewBag.PageName = "newsdiscussions";
				ViewBag.Name = "News Discussions";
			}
			else if (link == "ideasharing")
			{
				ViewBag.PageName = "ideasharing";
				ViewBag.Name = "Idea Sharing";
			}
			else if (link == "basketball")
			{
				ViewBag.PageName = "basketball";
				ViewBag.Name = "Basketball Discussion";

			}
			else if (link == "soccer")
			{
				ViewBag.PageName = "soccer";
				ViewBag.Name = "Soccer Discussion";

			}
			else if (link == "baseball")
			{
				ViewBag.PageName = "baseball";
				ViewBag.Name = "Baseball Discussion";
			}
			else if (link == "sports")
			{
				ViewBag.PageName = "sports";
				ViewBag.Name = "Sports Discussion/Sharing";
			}
			else if (link == "resume")
			{
				ViewBag.PageName = "resume";
				ViewBag.Name = "Resume Search";
			}
			else if (link == "corporate")
			{
				ViewBag.PageName = "corporate";
				ViewBag.Name = "Corporate Recruitment";
			}
			else if (link == "internship")
			{
				ViewBag.PageName = "internship";
				ViewBag.Name = "Internship Resumes";
			}
			else if (link == "englishlearning")
			{
				ViewBag.PageName = "englishlearning";
				ViewBag.Name = "English Learning";
			}
			else if (link == "chineselearning")
			{
				ViewBag.PageName = "chineselearning";
				ViewBag.Name = "Chinese Learning";
			}
			else if (link == "programminglearning")
			{
				ViewBag.PageName = "programminglearning";
				ViewBag.Name = "Programming Learning";
			}
			else if (link == "businesslearning")
			{
				ViewBag.PageName = "businesslearning";
				ViewBag.Name = "Business Learning";
			}
			else if (link == "howtolearn")
			{
				ViewBag.PageName = "howtolearn";
				ViewBag.Name = "How to Learn";
			}
			else if (link == "programmingdiscussion")
			{
				ViewBag.PageName = "programmingdiscussion";
				ViewBag.Name = "Programming Discussion";
			}
			else if (link == "learningdiscussion")
			{
				ViewBag.PageName = "learningdiscussion";
				ViewBag.Name = "Learning Discussion";
			}
			else if (link == "penang")
			{
				ViewBag.PageName = "penang";
				ViewBag.Name = "Penang";
			}
			else if (link == "ipoh")
			{
				ViewBag.PageName = "ipoh";
				ViewBag.Name = "Ipoh";
			}
			else if (link == "kualalumpur")
			{
				ViewBag.PageName = "kualalumpur";
				ViewBag.Name = "Kuala Lumpur";
			}
			else if (link == "taiping")
			{
				ViewBag.PageName = "taiping";
				ViewBag.Name = "Taiping";
			}
			else if (link == "bukitmertajam")
			{
				ViewBag.PageName = "bukitmertajam";
				ViewBag.Name = "Bukit Mertajam";
			}
			else if (link == "jelutong")
			{
				ViewBag.PageName = "jelutong";
				ViewBag.Name = "Jelutong";
			}
			else if (link == "bayanlepas")
			{
				ViewBag.PageName = "bayanlepas";
				ViewBag.Name = "Bayan Lepas";
			}
			else if (link == "kulim")
			{
				ViewBag.PageName = "kulim";
				ViewBag.Name = "Kulim";
			}
			else if (link == "subangjaya")
			{
				ViewBag.PageName = "subangjaya";
				ViewBag.Name = "Subang Jaya";
			}
			else if (link == "klang")
			{
				ViewBag.PageName = "klang";
				ViewBag.Name = "Klang";
			}
			else if (link == "shahalam")
			{
				ViewBag.PageName = "shahalam";
				ViewBag.Name = "Shah Alam";
			}
			else if (link == "malacca")
			{
				ViewBag.PageName = "malacca";
				ViewBag.Name = "Malacca";
			}
			else if (link == "muar")
			{
				ViewBag.PageName = "muar";
				ViewBag.Name = "Muar";
			}
			else if (link == "johor")
			{
				ViewBag.PageName = "johor";
				ViewBag.Name = "Johor";
			}
			else if (link == "kotabahru")
			{
				ViewBag.PageName = "kotabahru";
				ViewBag.Name = "Kota Bahru";
			}
			else if (link == "jaychou")
			{
				ViewBag.PageName = "jaychou";
				ViewBag.Name = "Jay Chou";
			}
			else if (link == "mayday")
			{
				ViewBag.PageName = "mayday";
				ViewBag.Name = "Mayday";
			}
			else if (link == "huachenyu")
			{
				ViewBag.PageName = "huachenyu";
				ViewBag.Name = "Hua Chenyu";
			}
			else if (link == "mj116")
			{
				ViewBag.PageName = "mj116";
				ViewBag.Name = "MJ116";
			}
			else if (link == "oneokrock")
			{
				ViewBag.PageName = "oneokrock";
				ViewBag.Name = "One Ok Rock";
			}
			else if (link == "english")
			{
				ViewBag.PageName = "english";
				ViewBag.Name = "English Music";
			}
			else if (link == "chinese")
			{
				ViewBag.PageName = "chinese";
				ViewBag.Name = "Chinese Music";
			}
			else if (link == "animeop")
			{
				ViewBag.PageName = "animeop";
				ViewBag.Name = "Anime OP Music";
			}
			else if (link == "internationalmusic")
			{
				ViewBag.PageName = "internationalmusic";
				ViewBag.Name = "International Music";
			}
			else if (link == "relaxed")
			{
				ViewBag.PageName = "relaxed";
				ViewBag.Name = "Relaxed Music";
			}
			else if (link == "music")
			{
				ViewBag.PageName = "music";
				ViewBag.Name = "Music Sharing/Discussion";
			}
			else if (link == "pop")
			{
				ViewBag.PageName = "pop";
				ViewBag.Name = "Pop Music";
			}
			else if (link == "rock")
			{
				ViewBag.PageName = "rock";
				ViewBag.Name = "Rock Music";
			}
			else if (link == "rap")
			{
				ViewBag.PageName = "rap";
				ViewBag.Name = "Rap Music";
			}
			else if (link == "createlyrics")
			{
				ViewBag.PageName = "createlyrics";
				ViewBag.Name = "Create/Share Lyrics";
			}
			else if (link == "genshin")
			{
				ViewBag.PageName = "genshin";
				ViewBag.Name = "Genshin Impact";
			}
			else if (link == "honkai")
			{
				ViewBag.PageName = "honkai";
				ViewBag.Name = "Honkai Impact: Star Rail";
			}
			else if (link == "pubg")
			{
				ViewBag.PageName = "pubg";
				ViewBag.Name = "PUBG Mobile";
			}
			else if (link == "league")
			{
				ViewBag.PageName = "league";
				ViewBag.Name = "League of Legends";
			}
			else if (link == "game")
			{
				ViewBag.PageName = "game";
				ViewBag.Name = "Game Discussions";
			}
			else if (link == "sao")
			{
				ViewBag.PageName = "sao";
				ViewBag.Name = "Sword Art Online";
			}
			else if (link == "bleach")
			{
				ViewBag.PageName = "bleach";
				ViewBag.Name = "Bleach";
			}
			else if (link == "gintama")
			{
				ViewBag.PageName = "gintama";
				ViewBag.Name = "Gintama";
			}
			else if (link == "spies")
			{
				ViewBag.PageName = "spies";
				ViewBag.Name = "Spies and Family Liquor";
			}
			else if (link == "anime")
			{
				ViewBag.PageName = "anime";
				ViewBag.Name = "Anime Discussions";
			}
			else if (link == "honor")
			{
				ViewBag.PageName = "honor";
				ViewBag.Name = "Honor of Kings";
			}
			else if (link == "domestic")
			{
				ViewBag.PageName = "domestic";
				ViewBag.Name = "Domestic Productions Sharing";
			}
			else if (link == "korean")
			{
				ViewBag.PageName = "korean";
				ViewBag.Name = "Korean Drama Sharing";
			}
			else if (link == "american")
			{
				ViewBag.PageName = "american";
				ViewBag.Name = "American Drama Sharing";
			}
			else if (link == "variety")
			{
				ViewBag.PageName = "variety";
				ViewBag.Name = "Variety Show Discussions";
			}
			else if (link == "tv")
			{
				ViewBag.PageName = "tv";
				ViewBag.Name = "TV Series Discussions";
			}
			else if (link == "movie")
			{
				ViewBag.PageName = "movie";
				ViewBag.Name = "Movie Discussions";
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Normal(List<IFormFile> file, string title, string content, string type, string page)
		{
			var date = DateTime.Now;
			string formattedText = content.Replace("\r\n", "<br/>");

			string userValue = HttpContext.Session.GetString("user");
			var data = userapi.GetAllUser().Result;
			var db = data.Where(x => x.Id == Convert.ToInt32(userValue)).FirstOrDefault();

			string imglist = "Null";
			if (file.Count != 0)
			{
				imglist = "";
				for (int i = 0; i < file.Count; i++)
				{
					string filePath = $@"wwwroot/Img/Post/{db.userNoId + file[i].FileName}";
					imglist += db.userNoId + file[i].FileName + "|";
					using (var stream = System.IO.File.Create(filePath))
					{
						await file[i].CopyToAsync(stream);
					};
				}

				imglist = imglist.Substring(0, imglist.LastIndexOf("|"));
			}

			PostWord postWord = new PostWord()
			{
				userid = db.Id,
				title = title,
				imglist = imglist,
				status = true,
				type_main = page,
				type_post = type,
				date_post = date,
				money = 0,
				role = "user",
				View = 0,
				Comment = 0,
				Color = "black",
			};

			await postwordapi.PostWordCreateDat(postWord);
			var allPostWord_Data = postwordapi.GetAllPostWord().Result;
			var onePostWord_DB = allPostWord_Data.LastOrDefault();

			PostWordData pd = new PostWordData()
			{
				PostWordId = onePostWord_DB.Id,
				ImgList = imglist,
				Content = formattedText
			};

			await postworddataapi.PostWordDataCreateDat(pd);

			if (page == "hzw")
				return RedirectToAction("Zone", "ZonePage", new { type = "hzw" });
			else if (page == "hyrz")
				return RedirectToAction("Zone", "ZonePage", new { type = "hyrz" });

			return RedirectToAction("HomePage", "Home");

		}

		public IActionResult Return(string link)
		{
			string userValue = HttpContext.Session.GetString("user");
			if (userValue == "" || userValue == null)
				return RedirectToAction("Login", "Login");

			if (link == "hzw")
				return RedirectToAction("Zone", "ZonePage", new { type = "hzw" });
			else if (link == "hyrz")
				return RedirectToAction("Zone", "ZonePage", new { type = "hyrz" });

			return RedirectToAction("HomePage", "Home");
		}

		public IActionResult EditPost(int id, string type)
		{
			var data = postwordapi.GetAllPostWord().Result;
			var dp = postworddataapi.GetAllPostWordData().Result;
			var postword = data.Where(x => x.Id == id).FirstOrDefault();
			var postword_dp = dp.Where(x => x.PostWordId == id).FirstOrDefault();

			ViewBag.id = id;
			ViewBag.type = type;
			ViewBag.postwordTItle = postword.title;
			ViewBag.content = postword_dp.Content;

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> EditPost(int id, string type, string title, string content)
		{
			var date = DateTime.Now;
			string formattedText = content.Replace("\r\n", "<br/>");

			var data = postwordapi.GetAllPostWord().Result;
			var dp = postworddataapi.GetAllPostWordData().Result;
			var postword = data.Where(x => x.Id == id).FirstOrDefault();
			var postword_dp = dp.Where(x => x.PostWordId == id).FirstOrDefault();

			postword.title = title;
			await postwordapi.EditPostWord(postword);
			postword_dp.Content = formattedText;
			await postworddataapi.EditPostWordData(postword_dp);

			return RedirectToAction("ContentPage", "Content", new { id = id, type = type });
		}

		public async Task<IActionResult> DeletePost(int id)
		{
			var data = postwordapi.GetAllPostWord().Result;
			var postword = data.Where(x => x.Id == id).FirstOrDefault();
			postword.status = false;

			await postwordapi.EditPostWord(postword);

			return RedirectToAction("HomePage", "Home");
		}


	}
}
