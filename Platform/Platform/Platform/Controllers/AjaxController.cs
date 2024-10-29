using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Platform_DomainModelEntity.Models;
using Platform_Infrastruture.Api;

namespace Platform.Controllers
{
	public class AjaxController : Controller
	{
		public PostWordApi postwordapi = new PostWordApi();
		public UserApi userapi = new UserApi();
		public SayHelloApi sayhelloapi = new SayHelloApi();
		public FriendApi friendapi = new FriendApi();
		public PostWordDataApi postworddateapi = new PostWordDataApi();
		public PostWordDataCommentApi postworddatacommentapi = new PostWordDataCommentApi();

		public IActionResult GetAllTypeData(string Type, string PostType)
		{
			var post_list = postwordapi.GetAllPostWord().Result;
			var user_list = userapi.GetAllUser().Result;

			List<PostWord> Admin_list = new List<PostWord>();
			List<PostWord> User_list = new List<PostWord>();
			List<PostWord> list = new List<PostWord>();
			foreach (var post in post_list)
			{
				if (post.type_main == "all" && PostType == "All")
					Admin_list.Add(post);
				else if (post.type_main == "all" && post.type_post.Contains(PostType))
					Admin_list.Add(post);
			}

			foreach (var post in post_list)
			{
				if (post.type_main == Type && post.status != false && PostType == "All")
					User_list.Add(post);
				else if (post.type_main == Type && post.status != false && post.type_post.Contains(PostType))
					User_list.Add(post);
			}

			foreach (var post in post_list)
			{
				if (post.type_main == "all" && PostType == "All" || post.type_main == Type && post.status != false && PostType == "All")
					list.Add(post);
				else if (post.type_main == "all" && post.type_post.Contains(PostType) || post.type_main == Type && post.status != false && post.type_post.Contains(PostType))
					list.Add(post);
			}

			if (user_list.Count > 0)
			{
				var Admin = DataTake(User_list, Admin_list, user_list);

				return Json(Admin);
			}

			return Json(list);
		}

		public class PostData
		{
			public string Title { get; set; }
			public string Username { get; set; }
			public string Date_post { get; set; }
			public string Role { get; set; }
			public bool Img { get; set; }
			public string Imgurl { get; set; }
			public int UserId { get; set; }
			public int PostId { get; set; }
			public int View { get; set; }
			public int Comment { get; set; }
			public string PostType { get; set; }
			public string Color { get; set; }
			public string typedata { get; set; }
		}

		public static List<PostData> DataTake(List<PostWord> User_list, List<PostWord> Admin_list, List<User> user_list)
		{
			var Admin = (from c in Admin_list
						 select new PostData
						 {
							 Title = c.title,
							 Username = "",
							 Date_post = DateTime.Parse(c.date_post.ToString()).ToString("yyyy-M-d hh:mm tt", new System.Globalization.CultureInfo("en-US")),
							 Role = c.role,
							 Img = c.imglist == "Null" ? false : true,
							 Imgurl = c.imglist,
							 UserId = 0,
							 PostId = c.Id,
							 View = c.View,
							 Comment = c.Comment,
							 PostType = c.type_post.Remove(c.type_post.Length - 1),
							 Color = c.Color,
							 typedata = "none",
						 }).ToList();

			var Admin_Data = (from c in User_list
							  where c.userid == 1
							  select new PostData
							  {
								  Title = c.title,
								  Username = "",
								  Date_post = DateTime.Parse(c.date_post.ToString()).ToString("yyyy-M-d hh:mm tt", new System.Globalization.CultureInfo("en-US")),
								  Role = c.role,
								  Img = c.imglist == "Null" ? false : true,
								  Imgurl = c.imglist,
								  UserId = 0,
								  PostId = c.Id,
								  View = c.View,
								  Comment = c.Comment,
								  PostType = c.type_post.Remove(c.type_post.Length - 1),
								  Color = c.Color,
								  typedata = "none",
							  }).ToList();

			Admin.AddRange(Admin_Data);

			var db = (from c in User_list
					  join us in user_list on c.userid equals us.Id
					  select new PostData
					  {
						  Title = c.title,
						  Username = us.username,
						  Date_post = DateTime.Parse(c.date_post.ToString()).ToString("yyyy-M-d hh:mm tt", new System.Globalization.CultureInfo("en-US")),
						  Role = c.role,
						  Img = c.imglist == "Null" ? false : true,
						  Imgurl = c.imglist,
						  UserId = us.Id,
						  PostId = c.Id,
						  View = c.View,
						  Comment = c.Comment,
						  PostType = c.type_post.Remove(c.type_post.Length - 1),
						  Color = c.Color,
						  typedata = "none",
					  }).OrderByDescending(x => x.PostId).ToList();

			Admin.AddRange(db);

			return Admin;
		}

		public IActionResult Checking_username_Register(string username)
		{
			var data = userapi.GetAllUser().Result;
			var db = data.Where(x => x.username == username).FirstOrDefault();

			if (username == null || username == "")
				return Json(false);
			else if (username.Length < 5)
				return Json("more");
			else if (db != null)
				return Json("Repeat");

			return Json(true);
		}

		public IActionResult Checking_Password_Register(string password)
		{
			if (password == null || password == "")
			{
				return Json(false);
			}
			else if (password.Length < 8)
			{
				return Json("Repeat");
			}

			return Json(true);
		}

		public IActionResult Checking_Email_Registerl(string email)
		{
			if (email == null || email == "")
				return Json(false);
			else if (!email.Contains("@gmail.com"))
				return Json(false);

			var data = userapi.GetAllUser().Result;
			if (data.Count != 0)
			{
				var db = data.Where(x => x.gmail == email).FirstOrDefault();
				if (db != null)
					return Json("Repeat");
			}

			return Json(true);
		}

		public static string codeNu = "";
		public IActionResult Post_Email_Code(string email)
		{

			Random random = new Random();
			string num = "";
			for (int i = 0; i < 4; i++)
			{
				int randomNumber = random.Next(0, 10);
				num += randomNumber;
			}
			codeNu = num;

			try
			{
				string form = "wengchin1234567@gamil.com";
				MailMessage m = new MailMessage(form, email);
				string date = DateTime.Now.ToString();

				m.Subject = "Memory Forum";
				m.Body = $"<h1>Verification code: {num}</h1>";
				m.BodyEncoding = Encoding.UTF8;
				m.IsBodyHtml = true;

				System.Net.Mail.SmtpClient c = new SmtpClient("smtp.gmail.com", 587);
				NetworkCredential n = new NetworkCredential("wengchin1234567@gmail.com", "fdlvlbnoomdhdasu");

				c.EnableSsl = true;
				c.UseDefaultCredentials = false;
				c.Credentials = n;

				c.Send(m);

			}
			catch (Exception ex)
			{
				return Json(false);
			}

			return Json(true);
		}

		public IActionResult Checking_Code_Registerl(string vercode)
		{
			if (codeNu != vercode || vercode == null)
				return Json(false);

			return Json(true);
		}

		public IActionResult Get_SignIn_Data()
		{
			DateTime currentTime = DateTime.Now;
			var dateString = currentTime.ToString("yyyy-MM-dd");

			var data = userapi.GetAllUser().Result;
			var db = data.Where(x => x.signIn == true && x.signInDate.ToString("yyyy-MM-dd") == dateString).ToList();



			var json = new List<User>();
			if (db.Count > 0)
			{
				Random random = new Random();
				for (int i = db.Count - 1; i > 0; i--)
				{
					int j = random.Next(0, i + 1);
					var temp = db[i];
					db[i] = db[j];
					db[j] = temp;
				}

				json = db.Take(10).ToList();
			}
			else
			{
				json = null;
			}


			return Json(json);
		}

		public IActionResult GetSayHello_Data()
		{
			string userValue = HttpContext.Session.GetString("user");
			var userdata = userapi.GetAllUser().Result;
			//var db = data.Where(x => x.Id == Convert.ToInt32(userValue)).FirstOrDefault();
			var data = sayhelloapi.GetAllSayHello().Result;
			var db = data.Where(x => x.otherUserId == Convert.ToInt32(userValue)).ToList();

			var json = (from c in db
						join user in userdata on c.userId equals user.Id
						select new
						{
							avatar = user.avatar,
							name = user.username,
							say = user.gender == "0" ? "He said hello to you" : "She say hello to you",
							date = c.date.ToString("yyyy-MM-dd HH:mm:ss")
						});


			return Json(json);
		}

		public IActionResult GetFriend_Data()
		{
			string userValue = HttpContext.Session.GetString("user");
			var userdata = userapi.GetAllUser().Result;


			var data = friendapi.GetAllFriend().Result;

			var frienddb = data.Where(x =>
					(x.userid == Convert.ToInt32(userValue) && x.status == "true") ||
					(x.friendid == Convert.ToInt32(userValue) && x.status == "true")
					).ToList();

			Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
			foreach (var i in frienddb)
			{
				if (i.userid == Convert.ToInt32(userValue))
					keyValuePairs.Add(i.Id, i.friendid);
				else
					keyValuePairs.Add(i.Id, i.userid);
			}

			var json = (from c in keyValuePairs
						join user in userdata on c.Value equals user.Id
						select new
						{
							id = c.Key,
							avatar = user.avatar,
							name = user.username,
							gender = user.gender == "0" ? "Male" : "Female",
							address = user.address,
							lv = "LV." + user.level
						});

			return Json(json);
		}

		public IActionResult GetFriendRequired_Data()
		{
			string userValue = HttpContext.Session.GetString("user");
			var userdata = userapi.GetAllUser().Result;


			var data = friendapi.GetAllFriend().Result;

			var frienddb = data.Where(x =>
					x.friendid == Convert.ToInt32(userValue) && x.status == "pending"
					).ToList();

			Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
			foreach (var i in frienddb)
			{
				if (i.userid == Convert.ToInt32(userValue))
					keyValuePairs.Add(i.Id, i.friendid);
				else
					keyValuePairs.Add(i.Id, i.userid);
			}

			var json = (from c in keyValuePairs
						join user in userdata on c.Value equals user.Id
						select new
						{
							id = c.Key,
							avatar = user.avatar,
							name = user.username,
							gender = user.gender == "0" ? "Male" : "Female",
							address = user.address,
							lv = "LV." + user.level
						});

			return Json(json);
		}

		public IActionResult GetPortList_Data()
		{
			string userValue = HttpContext.Session.GetString("user");


			var data = postwordapi.GetAllPostWord().Result;
			var db = data.Where(x => x.userid == Convert.ToInt32(userValue) && x.status != false).ToList();
			var user_list = userapi.GetAllUser().Result;

			var json = (from c in db
						join us in user_list on c.userid equals us.Id
						select new
						{
							Title = c.title,
							Username = us.username,
							Date_post = DateTime.Parse(c.date_post.ToString()).ToString("yyyy-M-d hh:mm tt", new System.Globalization.CultureInfo("en-US")),
							Role = c.role,
							Img = c.imglist == "Null" ? false : true,
							Imgurl = c.imglist,
							UserId = us.Id,
							PostId = c.Id,
							View = c.View,
							Comment = c.Comment,
							PostType = c.type_post.Remove(c.type_post.Length - 1),
							Color = c.Color,
							TypeMain = c.type_main
						}).OrderByDescending(x => x.PostId).ToList();

			return Json(json);
		}

		public async Task<IActionResult> AcceptFriend(int id)
		{
			var fdata = friendapi.GetAllFriend().Result;
			var db = fdata.Where(x => x.Id == id).FirstOrDefault();

			db.status = "true";
			await friendapi.EditFriend(db);

			string userValue = HttpContext.Session.GetString("user");
			var userdata = userapi.GetAllUser().Result;


			var data = friendapi.GetAllFriend().Result;

			var frienddb = data.Where(x =>
					x.friendid == Convert.ToInt32(userValue) && x.status == "pending"
					).ToList();

			Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
			foreach (var i in frienddb)
			{
				if (i.userid == Convert.ToInt32(userValue))
					keyValuePairs.Add(i.Id, i.friendid);
				else
					keyValuePairs.Add(i.Id, i.userid);
			}

			var json = (from c in keyValuePairs
						join user in userdata on c.Value equals user.Id
						select new
						{
							id = c.Key,
							avatar = user.avatar,
							name = user.username,
							gender = user.gender == "0" ? "Male" : "Female",
							address = user.address,
							lv = "LV." + user.level
						});

			return Json(json);
		}

		public async Task<IActionResult> RejectFriend(int id)
		{

			await friendapi.DeleteFriend_Admin(id);

			string userValue = HttpContext.Session.GetString("user");
			var userdata = userapi.GetAllUser().Result;


			var data = friendapi.GetAllFriend().Result;

			var frienddb = data.Where(x =>
					x.friendid == Convert.ToInt32(userValue) && x.status == "pending"
					).ToList();

			Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
			foreach (var i in frienddb)
			{
				if (i.userid == Convert.ToInt32(userValue))
					keyValuePairs.Add(i.Id, i.friendid);
				else
					keyValuePairs.Add(i.Id, i.userid);
			}

			var json = (from c in keyValuePairs
						join user in userdata on c.Value equals user.Id
						select new
						{
							id = c.Key,
							avatar = user.avatar,
							name = user.username,
							gender = user.gender == "0" ? "Male" : "Female",
							address = user.address,
							lv = "LV." + user.level
						});

			return Json(json);
		}

		public IActionResult GetOtherFriend_Data(int id)
		{

			string userValue = HttpContext.Session.GetString("user");

			var userdata = userapi.GetAllUser().Result;


			var data = friendapi.GetAllFriend().Result;

			var frienddb = data.Where(x =>
					(x.userid == id && x.status == "true") ||
					(x.friendid == id && x.status == "true")
					).ToList();

			Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
			foreach (var i in frienddb)
			{
				if (i.userid == id)
					keyValuePairs.Add(i.Id, i.friendid);
				else
					keyValuePairs.Add(i.Id, i.userid);
			}

			var json = (from c in keyValuePairs
						join user in userdata on c.Value equals user.Id
						select new
						{
							id = c.Key,
							userid = user.Id,
							avatar = user.avatar,
							name = user.username,
							gender = user.gender == "0" ? "Male" : "Female",
							address = user.address,
							lv = "LV." + user.level,
							show = c.Value == Convert.ToInt32(userValue) ? false : true
						});

			return Json(json);
		}

		public IActionResult GetOtherPortList_Data(int id)
		{

			var data = postwordapi.GetAllPostWord().Result;
			var db = data.Where(x => x.userid == id).ToList();
			var user_list = userapi.GetAllUser().Result;

			var json = (from c in db
						join us in user_list on c.userid equals us.Id
						select new
						{
							Title = c.title,
							Username = us.username,
							Date_post = DateTime.Parse(c.date_post.ToString()).ToString("yyyy-M-d hh:mm tt", new System.Globalization.CultureInfo("en-US")),
							Role = c.role,
							Img = c.imglist == "Null" ? false : true,
							Imgurl = c.imglist,
							UserId = us.Id,
							PostId = c.Id,
							View = c.View,
							Comment = c.Comment,
							PostType = c.type_post.Remove(c.type_post.Length - 1),
							Color = c.Color,
							TypeMain = c.type_main
						}).OrderByDescending(x => x.PostId).ToList();

			return Json(json);
		}

		public IActionResult GetComment_Data(int id)
		{
			string userValue = HttpContext.Session.GetString("user");
			var data = postworddatacommentapi.GetAllPostWordDataComment().Result;
			var db = data.Where(x => x.PostWordDataId == id).ToList();
			var user_list = userapi.GetAllUser().Result;
			var postword_list = postwordapi.GetAllPostWord().Result;
			var friend_list = friendapi.GetAllFriend().Result;
			var sayhellodata = sayhelloapi.GetAllSayHello().Result;

			var json = (from c in db
						join us in user_list on c.UserId equals us.Id
						select new
						{
							commentid = c.Id,
							comment = c.Content,
							date = c.Date.ToString("yyyy-MM-dd hh:mm tt", System.Globalization.CultureInfo.InvariantCulture),
							avatar = us.avatar,
							name = us.username,
							userid = us.Id,
							postcount = postword_list.Where(x => x.userid == us.Id).Count(),
							friendcount = friend_list.Where(x => x.userid == us.Id && x.status == "true").Count() + friend_list.Where(x => x.friendid == us.Id && x.status == "true").Count(),
							experience = us.experience,
							max = us.maxexperience,
							address = us.address,
							sayhello = sayhellodata.Where(x => x.userId == Convert.ToInt32(userValue) && x.otherUserId == us.Id).LastOrDefault()?.date.ToString("yyyy-MM-dd") != DateTime.Now.ToString("yyyy-MM-dd"),
							friend = friend_list.Any(x =>
									(x.userid == Convert.ToInt32(userValue) && x.friendid == us.Id && (x.status == "pending" || x.status == "true")) ||
									(x.userid == us.Id && x.friendid == Convert.ToInt32(userValue) && (x.status == "pending" || x.status == "true"))),
							sameuser = Convert.ToInt32(userValue) == us.Id ? true : false,
						}).OrderByDescending(x => x.commentid).ToList();

			//var singleData = json.FirstOrDefault();
			//var repeatedJson = Enumerable.Repeat(singleData, 12).ToList();

			return Json(json);
		}

		public IActionResult GetLatestData()
		{
			var postdata = postwordapi.GetAllPostWord().Result;
			var data = postdata.Where(x => x.type_main != "all" && x.status != false).OrderByDescending(x => x.Id).Take(10).ToList();

			var db = (from c in data
					  select new
					  {
						  postId = c.Id,
						  title = c.title,
						  type = c.type_main,
						  date = c.date_post.ToString("MM/dd")
					  }).ToList();

			return Json(db);
		}

		public IActionResult GetZoneLatestData()
		{
			var postdata = postwordapi.GetAllPostWord().Result;
			var data = postdata.Where(x => x.type_main != "all" && x.status != false).OrderByDescending(x => x.Id).Take(7).ToList();

			var db = (from c in data
					  select new
					  {
						  postId = c.Id,
						  title = c.title,
						  type = c.type_main,
						  date = c.date_post.ToString("MM/dd")
					  }).ToList();

			return Json(db);
		}

		public IActionResult GetSearchData(string value)
		{
			var user_list = userapi.GetAllUser().Result;
			var data = postwordapi.GetAllPostWord().Result;
			var db = data.Where(x => x.title.ToLower().Contains(value.ToLower()) && x.type_main != "all" && x.status != false).ToList();
			var json = SearchDataTake(db, user_list);

			if (json.Count > 0)
				return Json(json);
			else
				return Json(false);
		}

		public static List<PostData> SearchDataTake(List<PostWord> data, List<User> user_list)
		{

			var db = (from c in data
					  join us in user_list on c.userid equals us.Id
					  select new PostData
					  {
						  Title = c.title,
						  Username = us.username,
						  Date_post = DateTime.Parse(c.date_post.ToString()).ToString("yyyy-M-d hh:mm tt", new System.Globalization.CultureInfo("en-US")),
						  Role = c.role,
						  Img = c.imglist == "Null" ? false : true,
						  Imgurl = c.imglist,
						  UserId = us.Id,
						  PostId = c.Id,
						  View = c.View,
						  Comment = c.Comment,
						  PostType = c.type_post.Remove(c.type_post.Length - 1),
						  Color = c.Color,
						  typedata = c.type_main,
					  }).OrderByDescending(x => x.PostId).ToList();

			return db;
		}




	}
}
