using System;
using Microsoft.AspNetCore.Mvc;
using Platform_DomainModelEntity.Models;
using Platform_Infrastruture.Api;

namespace Platform.Controllers
{
	public class ContentController : Controller
	{
		public UserApi userapi = new UserApi();
		public PostWordApi postwordapi = new PostWordApi();
		public PostWordDataApi postworddataapi = new PostWordDataApi();
		public FriendApi friendapi = new FriendApi();
		public SayHelloApi sayhelloapi = new SayHelloApi();
		public PostWordDataCommentApi postworddatacommentapi = new PostWordDataCommentApi();

		public async Task<IActionResult> ReplyPost(string Content, int postId)
		{
			string userValue = HttpContext.Session.GetString("user");

			// PostWordDataId = PostWord id
			PostWordDataComment pwc = new PostWordDataComment()
			{
				PostWordDataId = postId,
				UserId = Convert.ToInt32(userValue),
				Content = Content,
				Date = DateTime.Now,
				Status = true
			};

			await postworddatacommentapi.PostWordDataCommentCreateDat(pwc);

			var data = postwordapi.GetAllPostWord().Result;
			var db = data.Where(x => x.Id == postId).FirstOrDefault();

			// comment count save
			// take count
			var commentData = postworddatacommentapi.GetAllPostWordDataComment().Result;
			var commentCount = commentData.Where(x => x.PostWordDataId == postId).Count();

			// find postword id
			var postword = postwordapi.GetAllPostWord().Result;
			var findPostword = postword.Where(x => x.Id == postId).FirstOrDefault();
			findPostword.Comment = commentCount;

			await postwordapi.EditPostWord(findPostword);

			return RedirectToAction("ContentPage", "Content", new { id = db.Id, type = db.type_main });
		}

		public async Task<IActionResult> PageTurn(int id, string type)
		{
			string userValue = HttpContext.Session.GetString("user");
			if (userValue == "" || userValue == null)
				return RedirectToAction("Login", "Login");

			var data = postwordapi.GetAllPostWord().Result;
			var db = data.Where(x => x.Id == id).FirstOrDefault();
			if (db != null)
			{
				db.View += 1;
				await postwordapi.EditPostWord(db);
			}

			return RedirectToAction("ContentPage", "Content", new { id = id, type = type });
		}

		public async Task<IActionResult> ContentPage(int id, string type)
		{
			string userValue = HttpContext.Session.GetString("user");
			string typename = "";
			string navigationname = "";
			if (type == "hzw")
			{
				typename = "hzw";
				navigationname = "One Piece";
			}
			else if (type == "hyrz")
			{
				typename = "hyrz";
				navigationname = "Naruto";
			}
			else if (type == "casual")
			{
				typename = "casual";
				navigationname = "Casual Chat";
			}
			else if (type == "emotional")
			{
				typename = "emotional";
				navigationname = "Emotional Station";
			}
			else if (type == "findapartner")
			{
				typename = "findapartner";
				navigationname = "Find a Partner";
			}
			else if (type == "penangcuisine")
			{
				typename = "penangcuisine";
				navigationname = "Penang Cuisine";
			}
			else if (type == "kualalumpurcuisine")
			{
				typename = "kualalumpurcuisine";
				navigationname = "Kuala Lumpur Cuisine";
			}
			else if (type == "internationalcuisine")
			{
				typename = "internationalcuisine";
				navigationname = "International Cuisine";
			}
			else if (type == "foodcreation")
			{
				typename = "foodcreation";
				navigationname = "Food Creation/Sharing";
			}
			else if (type == "travel")
			{
				typename = "travel";
				navigationname = "Travel Adventures";
			}
			else if (type == "urban")
			{
				typename = "urban";
				navigationname = "Urban Excursions";
			}
			else if (type == "overseas")
			{
				typename = "overseas";
				navigationname = "Overseas Travel";
			}
			else if (type == "snack")
			{
				typename = "snack";
				navigationname = "Snack Discussion";
			}
			else if (type == "nutritious")
			{
				typename = "nutritious";
				navigationname = "Nutritious Foods";
			}
			else if (type == "healthy")
			{
				typename = "healthy";
				navigationname = "Healthy Practices";
			}
			else if (type == "maintainingfitness")
			{
				typename = "maintainingfitness";
				navigationname = "Maintaining Fitness";
			}
			else if (type == "buildingrelationships")
			{
				typename = "buildingrelationships";
				navigationname = "Building Relationships";
			}
			else if (type == "personalgrowth")
			{
				typename = "personalgrowth";
				navigationname = "Personal Growth";
			}
			else if (type == "happinesstechniques")
			{
				typename = "happinesstechniques";
				navigationname = "Happiness Techniques";
			}
			else if (type == "lifeskillsdiscussion")
			{
				typename = "lifeskillsdiscussion";
				navigationname = "Life Skills Discussion";
			}
			else if (type == "malaysiadiscussion")
			{
				typename = "malaysiadiscussion";
				navigationname = "Malaysia Discussion";
			}
			else if (type == "foreigndiscussions")
			{
				typename = "foreigndiscussions";
				navigationname = "Foreign Discussions";
			}
			else if (type == "newsdiscussions")
			{
				typename = "newsdiscussions";
				navigationname = "News Discussions";
			}
			else if (type == "ideasharing")
			{
				typename = "ideasharing";
				navigationname = "Idea Sharing";
			}
			else if (type == "basketball")
			{
				typename = "basketball";
				navigationname = "Basketball Discussion";
			}
			else if (type == "soccer")
			{
				typename = "soccer";
				navigationname = "Soccer Discussion";
			}
			else if (type == "baseball")
			{
				typename = "baseball";
				navigationname = "Baseball Discussion";
			}
			else if (type == "sports")
			{
				typename = "sports";
				navigationname = "Sports Discussion/Sharing";
			}
			else if (type == "resume")
			{
				typename = "resume";
				navigationname = "Resume Search";
			}
			else if (type == "corporate")
			{
				typename = "corporate";
				navigationname = "Corporate Recruitment";
			}
			else if (type == "internship")
			{
				typename = "internship";
				navigationname = "Internship Resumes";
			}
			else if (type == "englishlearning")
			{
				typename = "englishlearning";
				navigationname = "English Learning";
			}
			else if (type == "chineselearning")
			{
				typename = "chineselearning";
				navigationname = "Chinese Learning";
			}
			else if (type == "programminglearning")
			{
				typename = "programminglearning";
				navigationname = "Programming Learning";
			}
			else if (type == "businesslearning")
			{
				typename = "businesslearning";
				navigationname = "Casual Chat";
			}
			else if (type == "howtolearn")
			{
				typename = "howtolearn";
				navigationname = "How to Learn";
			}
			else if (type == "programmingdiscussion")
			{
				typename = "programmingdiscussion";
				navigationname = "Programming Discussion";
			}
			else if (type == "learningdiscussion")
			{
				typename = "learningdiscussion";
				navigationname = "Learning Discussion";
			}
			else if (type == "penang")
			{
				typename = "penang";
				navigationname = "Penang";
			}
			else if (type == "ipoh")
			{
				typename = "ipoh";
				navigationname = "Ipoh";
			}
			else if (type == "kualalumpur")
			{
				typename = "kualalumpur";
				navigationname = "Kuala Lumpur";
			}
			else if (type == "taiping")
			{
				typename = "taiping";
				navigationname = "Taiping";
			}
			else if (type == "bukitmertajam")
			{
				typename = "bukitmertajam";
				navigationname = "Bukit Mertajam";
			}
			else if (type == "jelutong")
			{
				typename = "jelutong";
				navigationname = "Jelutong";
			}
			else if (type == "bayanlepas")
			{
				typename = "bayanlepas";
				navigationname = "Bayan Lepas";
			}
			else if (type == "kulim")
			{
				typename = "kulim";
				navigationname = "Kulim";
			}
			else if (type == "subangjaya")
			{
				typename = "subangjaya";
				navigationname = "Subang Jaya";
			}
			else if (type == "klang")
			{
				typename = "klang";
				navigationname = "Klang";
			}
			else if (type == "shahalam")
			{
				typename = "shahalam";
				navigationname = "Shah Alam";
			}
			else if (type == "malacca")
			{
				typename = "malacca";
				navigationname = "Malacca";
			}
			else if (type == "muar")
			{
				typename = "muar";
				navigationname = "Muar";
			}
			else if (type == "johor")
			{
				typename = "johor";
				navigationname = "Johor";
			}
			else if (type == "kotabahru")
			{
				typename = "kotabahru";
				navigationname = "Kota Bahru";
			}
			else if (type == "jaychou")
			{
				typename = "jaychou";
				navigationname = "Jay Chou";
			}
			else if (type == "mayday")
			{
				typename = "mayday";
				navigationname = "Mayday";
			}
			else if (type == "huachenyu")
			{
				typename = "huachenyu";
				navigationname = "Hua Chenyu";
			}
			else if (type == "mj116")
			{
				typename = "mj116";
				navigationname = "MJ116";
			}
			else if (type == "oneokrock")
			{
				typename = "oneokrock";
				navigationname = "One Ok Rock";
			}
			else if (type == "english")
			{
				typename = "english";
				navigationname = "English Music";
			}
			else if (type == "chinese")
			{
				typename = "chinese";
				navigationname = "Chinese Music";
			}
			else if (type == "animeop")
			{
				typename = "animeop";
				navigationname = "Anime OP Music";
			}
			else if (type == "internationalmusic")
			{
				typename = "internationalmusic";
				navigationname = "International Music";
			}
			else if (type == "relaxed")
			{
				typename = "relaxed";
				navigationname = "Relaxed Music";
			}
			else if (type == "music")
			{
				typename = "music";
				navigationname = "Music Sharing/Discussion";
			}
			else if (type == "pop")
			{
				typename = "pop";
				navigationname = "Pop Music";
			}
			else if (type == "rock")
			{
				typename = "rock";
				navigationname = "Rock Music";
			}
			else if (type == "rap")
			{
				typename = "rap";
				navigationname = "Rap Music";
			}
			else if (type == "createlyrics")
			{
				typename = "createlyrics";
				navigationname = "Create/Share Lyrics";
			}
			else if (type == "genshin")
			{
				typename = "genshin";
				navigationname = "Genshin Impact";
			}
			else if (type == "honkai")
			{
				typename = "honkai";
				navigationname = "Honkai Impact: Star Rail";
			}
			else if (type == "pubg")
			{
				typename = "pubg";
				navigationname = "PUBG Mobile";
			}
			else if (type == "league")
			{
				typename = "league";
				navigationname = "League of Legends";
			}
			else if (type == "game")
			{
				typename = "game";
				navigationname = "Game Discussions";
			}
			else if (type == "sao")
			{
				typename = "sao";
				navigationname = "Sword Art Online";
			}
			else if (type == "bleach")
			{
				typename = "bleach";
				navigationname = "Bleach";
			}
			else if (type == "gintama")
			{
				typename = "gintama";
				navigationname = "Gintama";
			}
			else if (type == "spies")
			{
				typename = "spies";
				navigationname = "Spies and Family Liquor";
			}
			else if (type == "anime")
			{
				typename = "anime";
				navigationname = "Anime Discussions";
			}
			else if (type == "honor")
			{
				typename = "honor";
				navigationname = "Honor of Kings";
			}
			else if (type == "domestic")
			{
				typename = "casual";
				navigationname = "Domestic Productions Sharing";
			}
			else if (type == "korean")
			{
				typename = "korean";
				navigationname = "Korean Drama Sharing";
			}
			else if (type == "american")
			{
				typename = "american";
				navigationname = "American Drama Sharing";
			}
			else if (type == "variety")
			{
				typename = "variety";
				navigationname = "Variety Show Discussions";
			}
			else if (type == "tv")
			{
				typename = "tv";
				navigationname = "TV Series Discussions";
			}
			else if (type == "movie")
			{
				typename = "movie";
				navigationname = "Movie Discussions";
			}



			ViewBag.typeName = typename;
			ViewBag.navigationName = navigationname;

			DateTime today = DateTime.Today;
			string formattedDate = today.ToString("yyyy-MM-dd");

			bool b = false;
			var data = postwordapi.GetAllPostWord().Result;
			var db = data.Where(x => x.Id == id).FirstOrDefault();

			var public_count_today = data.Where(x => x.type_main == type && x.date_post.ToString("yyyy-MM-dd") == formattedDate).Count();
			var postCount = data.Where(x => x.userid == db.userid).Count();
			ViewBag.postCount = postCount;
			ViewBag.public_count_today = public_count_today;


			if (db != null)
			{
				if (db.imglist != "Null")
					b = true;
			}

			ViewBag.postUserID = db.userid;

			var p_data = postworddataapi.GetAllPostWordData().Result;
			var p_db = p_data.Where(x => x.PostWordId == id).FirstOrDefault();
			ViewBag.content = p_db.Content;
			ViewBag.dbid = id;
			ViewBag.contentTitle = db.title;
			ViewBag.TypePost = db.type_post.Remove(db.type_post.Length - 1);

			var frienddata = friendapi.GetAllFriend().Result;
			var friendCount = frienddata.Where(x =>
			x.userid == db.userid && x.status == "true" ||
			x.friendid == db.userid && x.status == "true"
			).Count();
			ViewBag.friendCount = friendCount;

			if (db.role == "admin")
			{
				ViewBag.avatar = "Avatar.png";
				ViewBag.Name = "Admin";
				ViewBag.address = "Admin";
				ViewBag.Max = 1;
				ViewBag.experience = 1;
				ViewBag.role = "Admin";
			}
			else
			{
				var u_data = userapi.GetAllUser().Result;
				var u_db = u_data.Where(x => x.Id == db.userid).FirstOrDefault();
				ViewBag.avatar = u_db.avatar;
				ViewBag.Name = u_db.username;
				ViewBag.address = u_db.address;
				ViewBag.Max = u_db.maxexperience;
				ViewBag.experience = u_db.experience;
				if (db.userid == Convert.ToInt32(userValue))
				{
					ViewBag.role = "Some";
					ViewBag.friend = false;
					ViewBag.Sayhello = false;
				}
				else
				{
					ViewBag.role = "User";

					//friend
					var frienddb = frienddata.Where(x =>
					(x.userid == Convert.ToInt32(userValue) && x.friendid == db.userid && (x.status == "pending" || x.status == "true")) ||
					(x.userid == db.userid && x.friendid == Convert.ToInt32(userValue) && (x.status == "pending" || x.status == "true"))
					).FirstOrDefault();

					if (frienddb != null)
						ViewBag.friend = false;
					else
						ViewBag.friend = true;


					//sayhello
					var sayhellodata = sayhelloapi.GetAllSayHello().Result;
					var sayhellodb = sayhellodata.Where(x => x.userId == Convert.ToInt32(userValue) && x.otherUserId == db.userid).LastOrDefault();
					ViewBag.Sayhello = true;
					if (sayhellodb != null)
					{
						var date = sayhellodb.date.ToString("yyyy-MM-dd");

						if (formattedDate != date)
							ViewBag.Sayhello = true;
						else
							ViewBag.Sayhello = false;

					}

				}

			}



			ViewBag.id = id;
			ViewBag.img = b;
			ViewBag.imgurl = db.imglist;
			ViewBag.date = db.date_post.ToString("yyyy-MM-dd hh:mm tt", System.Globalization.CultureInfo.InvariantCulture);
			ViewBag.View = db.View;
			ViewBag.Comment = db.Comment;

			return View();
		}
	}
}
