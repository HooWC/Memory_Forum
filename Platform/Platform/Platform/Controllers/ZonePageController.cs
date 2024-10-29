using Microsoft.AspNetCore.Mvc;
using Platform_Infrastruture.Api;

namespace Platform.Controllers
{
	public class ZonePageController : Controller
	{
		public UserApi userapi = new UserApi();
		public PostWordApi postwordapi = new PostWordApi();

		public IActionResult Zone(string type, string postType)
		{
			DateTime today = DateTime.Today;
			string formattedDate = today.ToString("yyyy-MM-dd");

			var data = postwordapi.GetAllPostWord().Result;
			var user_data = userapi.GetAllUser().Result;

			var public_count_today = data.Where(x => x.type_main == type && x.date_post.ToString("yyyy-MM-dd") == formattedDate).Count();
			ViewBag.public_count_today = public_count_today;

			var Admin = data.Where(x => x.type_main == "all").ToList().Count;
			var db = data.Where(x => x.type_main == type).ToList();
			var num = Admin + db.Count;

			var uniqueUserIds = db.Select(x => x.userid)
								 .Distinct()
								 .Take(5)
								 .ToList();

			var matchedUsers = user_data.Where(x => uniqueUserIds.Contains(x.Id)).ToList();
			ViewBag.topic_user = matchedUsers;

			if (postType != null)
				ViewBag.postType = postType;
			else
				ViewBag.postType = "All";

			if (type == "hzw")
			{
				ViewBag.navigationName = "One Piece";
				ViewBag.postNum = $"One Piece【Zone】Posts: {num}";
				ViewBag.typePageName = "hzw";
				ViewBag.AjaxName = "GetOne_Piece_Data";
				ViewBag.PostLink = "Normal?link=hzw";
				ViewBag.Zonepinture = "hzwzone.png";
				return View();
			}
			else if (type == "hyrz")
			{
				ViewBag.navigationName = "Naruto";
				ViewBag.postNum = $"Naruto【Zone】Posts: {num}";
				ViewBag.typePageName = "hyrz";
				ViewBag.AjaxName = "GetNaruto_Data";
				ViewBag.PostLink = "Normal?link=hyrz";
				ViewBag.Zonepinture = "hyrzzone.png";
				return View();
			}
			else if (type == "casual")
			{
				ViewBag.navigationName = "Casual Chat";
				ViewBag.postNum = $"Casual Chat【Zone】Posts: {num}";
				ViewBag.typePageName = "casual";
				ViewBag.AjaxName = "GetCasual_Data";
				ViewBag.PostLink = "Normal?link=casual";
				ViewBag.Zonepinture = "b1.png";
				return View();
			}
			else if (type == "emotional")
			{
				ViewBag.navigationName = $"Emotional Station";
				ViewBag.postNum = $"Emotional Station【Zone】Posts: {num}";
				ViewBag.typePageName = "emotional";
				ViewBag.AjaxName = "GetEmotional_Data";
				ViewBag.PostLink = "Normal?link=emotional";
				ViewBag.Zonepinture = "b2.png";
				return View();
			}
			else if (type == "findapartner")
			{
				ViewBag.navigationName = $"Find a Partner";
				ViewBag.postNum = $"Find a Partner【Zone】Posts: {num}";
				ViewBag.typePageName = "findapartner";
				ViewBag.AjaxName = "GetFindapartner_Data";
				ViewBag.PostLink = "Normal?link=findapartner";
				ViewBag.Zonepinture = "b3.png";
				return View();
			}
			else if (type == "penangcuisine")
			{
				ViewBag.navigationName = $"Penang Cuisine";
				ViewBag.postNum = $"Penang Cuisine【Zone】Posts: {num}";
				ViewBag.typePageName = "penangcuisine";
				ViewBag.AjaxName = "GetPenangcuisine_Data";
				ViewBag.PostLink = "Normal?link=penangcuisine";
				ViewBag.Zonepinture = "b4.png";
				return View();
			}
			else if (type == "kualalumpurcuisine")
			{
				ViewBag.navigationName = $"Kuala Lumpur Cuisine";
				ViewBag.postNum = $"Kuala Lumpur Cuisine【Zone】Posts: {num}";
				ViewBag.typePageName = "kualalumpurcuisine";
				ViewBag.AjaxName = "GetKualalumpurcuisine_Data";
				ViewBag.PostLink = "Normal?link=kualalumpurcuisine";
				ViewBag.Zonepinture = "b5.png";
				return View();
			}
			else if (type == "internationalcuisine")
			{
				ViewBag.navigationName = $"International Cuisine";
				ViewBag.postNum = $"International Cuisine【Zone】Posts: {num}";
				ViewBag.typePageName = "internationalcuisine";
				ViewBag.AjaxName = "GetInternationalcuisine_Data";
				ViewBag.PostLink = "Normal?link=internationalcuisine";
				ViewBag.Zonepinture = "b6.png";
				return View();
			}
			else if (type == "foodcreation")
			{
				ViewBag.navigationName = $"Food Creation/Sharing";
				ViewBag.postNum = $"Food Creation/Sharing【Zone】Posts: {num}";
				ViewBag.typePageName = "foodcreation";
				ViewBag.AjaxName = "GetFoodcreation_Data";
				ViewBag.PostLink = "Normal?link=foodcreation";
				ViewBag.Zonepinture = "b7.png";
				return View();
			}
			else if (type == "travel")
			{
				ViewBag.navigationName = $"Travel Adventures";
				ViewBag.postNum = $"Travel Adventures【Zone】Posts: {num}";
				ViewBag.typePageName = "travel";
				ViewBag.AjaxName = "GetTravel_Data";
				ViewBag.PostLink = "Normal?link=travel";
				ViewBag.Zonepinture = "b8.png";
				return View();
			}
			else if (type == "urban")
			{
				ViewBag.navigationName = $"Urban Excursions";
				ViewBag.postNum = $"Urban Excursions【Zone】Posts: {num}";
				ViewBag.typePageName = "urban";
				ViewBag.AjaxName = "GetUrban_Data";
				ViewBag.PostLink = "Normal?link=urban";
				ViewBag.Zonepinture = "b9.png";
				return View();
			}
			else if (type == "overseas")
			{
				ViewBag.navigationName = $"Overseas Travel";
				ViewBag.postNum = $"Overseas Travel【Zone】Posts: {num}";
				ViewBag.typePageName = "overseas";
				ViewBag.AjaxName = "GetOverseas_Data";
				ViewBag.PostLink = "Normal?link=overseas";
				ViewBag.Zonepinture = "b10.png";
				return View();
			}
			else if (type == "snack")
			{
				ViewBag.navigationName = $"Snack Discussion";
				ViewBag.postNum = $"Snack Discussion【Zone】Posts: {num}";
				ViewBag.typePageName = "snack";
				ViewBag.AjaxName = "GetSnack_Data";
				ViewBag.PostLink = "Normal?link=snack";
				ViewBag.Zonepinture = "b11.png";
				return View();
			}
			else if (type == "nutritious")
			{
				ViewBag.navigationName = $"Nutritious Foods";
				ViewBag.postNum = $"Nutritious Foods【Zone】Posts: {num}";
				ViewBag.typePageName = "nutritious";
				ViewBag.AjaxName = "GetNutritious_Data";
				ViewBag.PostLink = "Normal?link=nutritious";
				ViewBag.Zonepinture = "b14.png";
				return View();
			}
			else if (type == "healthy")
			{
				ViewBag.navigationName = $"Healthy Practices";
				ViewBag.postNum = $"Healthy Practices【Zone】Posts: {num}";
				ViewBag.typePageName = "healthy";
				ViewBag.AjaxName = "GetHealthy_Data";
				ViewBag.PostLink = "Normal?link=healthy";
				ViewBag.Zonepinture = "b15.png";
				return View();
			}
			else if (type == "maintainingfitness")
			{
				ViewBag.navigationName = $"Maintaining Fitness";
				ViewBag.postNum = $"Maintaining Fitness【Zone】Posts: {num}";
				ViewBag.typePageName = "maintainingfitness";
				ViewBag.AjaxName = "GetMaintainingfitness_Data";
				ViewBag.PostLink = "Normal?link=maintainingfitness";
				ViewBag.Zonepinture = "b16.png";
				return View();
			}
			else if (type == "buildingrelationships")
			{
				ViewBag.navigationName = $"Building Relationships";
				ViewBag.postNum = $"Building Relationships【Zone】Posts: {num}";
				ViewBag.typePageName = "buildingrelationships";
				ViewBag.AjaxName = "GetBuildingrelationships_Data";
				ViewBag.PostLink = "Normal?link=buildingrelationships";
				ViewBag.Zonepinture = "b17.png";
				return View();
			}
			else if (type == "personalgrowth")
			{
				ViewBag.navigationName = $"Personal Growth";
				ViewBag.postNum = $"Personal Growth【Zone】Posts: {num}";
				ViewBag.typePageName = "personalgrowth";
				ViewBag.AjaxName = "GetPersonalgrowth_Data";
				ViewBag.PostLink = "Normal?link=personalgrowth";
				ViewBag.Zonepinture = "b18.png";
				return View();
			}
			else if (type == "happinesstechniques")
			{
				ViewBag.navigationName = $"Happiness Techniques";
				ViewBag.postNum = $"Happiness Techniques【Zone】Posts: {num}";
				ViewBag.typePageName = "happinesstechniques";
				ViewBag.AjaxName = "GetHappinesstechniques_Data";
				ViewBag.PostLink = "Normal?link=happinesstechniques";
				ViewBag.Zonepinture = "b19.png";
				return View();
			}
			else if (type == "lifeskillsdiscussion")
			{
				ViewBag.navigationName = $"Life Skills Discussion";
				ViewBag.postNum = $"Life Skills Discussion【Zone】Posts: {num}";
				ViewBag.typePageName = "lifeskillsdiscussion";
				ViewBag.AjaxName = "GetLifeskillsdiscussion_Data";
				ViewBag.PostLink = "Normal?link=lifeskillsdiscussion";
				ViewBag.Zonepinture = "b20.png";
				return View();
			}
			else if (type == "malaysiadiscussion")
			{
				ViewBag.navigationName = $"Malaysia Discussion";
				ViewBag.postNum = $"Malaysia Discussion【Zone】Posts: {num}";
				ViewBag.typePageName = "malaysiadiscussion";
				ViewBag.AjaxName = "GetMalaysiadiscussion_Data";
				ViewBag.PostLink = "Normal?link=malaysiadiscussion";
				ViewBag.Zonepinture = "b21.png";
				return View();
			}
			else if (type == "foreigndiscussions")
			{
				ViewBag.navigationName = $"Foreign Discussions";
				ViewBag.postNum = $"Foreign Discussions【Zone】Posts: {num}";
				ViewBag.typePageName = "foreigndiscussions";
				ViewBag.AjaxName = "GetForeigndiscussions_Data";
				ViewBag.PostLink = "Normal?link=foreigndiscussions";
				ViewBag.Zonepinture = "b22.png";
				return View();
			}
			else if (type == "newsdiscussions")
			{
				ViewBag.navigationName = $"News Discussions";
				ViewBag.postNum = $"News Discussions【Zone】Posts: {num}";
				ViewBag.typePageName = "newsdiscussions";
				ViewBag.AjaxName = "GetNewsdiscussions_Data";
				ViewBag.PostLink = "Normal?link=newsdiscussions";
				ViewBag.Zonepinture = "b23.png";
				return View();
			}
			else if (type == "ideasharing")
			{
				ViewBag.navigationName = $"Idea Sharing";
				ViewBag.postNum = $"Idea Sharing【Zone】Posts: {num}";
				ViewBag.typePageName = "ideasharing";
				ViewBag.AjaxName = "GetIdeasharing_Data";
				ViewBag.PostLink = "Normal?link=ideasharing";
				ViewBag.Zonepinture = "b24.png";
				return View();
			}
			else if (type == "basketball")
			{
				ViewBag.navigationName = $"Basketball Discussion";
				ViewBag.postNum = $"Basketball Discussion【Zone】Posts: {num}";
				ViewBag.typePageName = "basketball";
				ViewBag.AjaxName = "GetBasketball_Data";
				ViewBag.PostLink = "Normal?link=basketball";
				ViewBag.Zonepinture = "b25.png";
				return View();
			}
			else if (type == "soccer")
			{
				ViewBag.navigationName = $"Soccer Discussion";
				ViewBag.postNum = $"Soccer Discussion【Zone】Posts: {num}";
				ViewBag.typePageName = "soccer";
				ViewBag.AjaxName = "GetSoccer_Data";
				ViewBag.PostLink = "Normal?link=soccer";
				ViewBag.Zonepinture = "b26.png";
				return View();
			}
			else if (type == "baseball")
			{
				ViewBag.navigationName = $"Baseball Discussion";
				ViewBag.postNum = $"Baseball Discussion【Zone】Posts: {num}";
				ViewBag.typePageName = "baseball";
				ViewBag.AjaxName = "GetBaseball_Data";
				ViewBag.PostLink = "Normal?link=baseball";
				ViewBag.Zonepinture = "b27.png";
				return View();
			}
			else if (type == "sports")
			{
				ViewBag.navigationName = $"Sports Discussion/Sharing";
				ViewBag.postNum = $"Sports Discussion/Sharing【Zone】Posts: {num}";
				ViewBag.typePageName = "sports";
				ViewBag.AjaxName = "GetSports_Data";
				ViewBag.PostLink = "Normal?link=sports";
				ViewBag.Zonepinture = "b28.png";
				return View();
			}
			else if (type == "resume")
			{
				ViewBag.navigationName = $"Resume Search";
				ViewBag.postNum = $"Resume Search【Zone】Posts: {num}";
				ViewBag.typePageName = "resume";
				ViewBag.AjaxName = "GetResume_Data";
				ViewBag.PostLink = "Normal?link=resume";
				ViewBag.Zonepinture = "b29.png";
				return View();
			}
			else if (type == "corporate")
			{
				ViewBag.navigationName = $"Corporate Recruitment";
				ViewBag.postNum = $"Corporate Recruitment【Zone】Posts: {num}";
				ViewBag.typePageName = "corporate";
				ViewBag.AjaxName = "GetCorporate_Data";
				ViewBag.PostLink = "Normal?link=corporate";
				ViewBag.Zonepinture = "b30.png";
				return View();
			}
			else if (type == "internship")
			{
				ViewBag.navigationName = $"Internship Resumes";
				ViewBag.postNum = $"Internship Resumes【Zone】Posts: {num}";
				ViewBag.typePageName = "internship";
				ViewBag.AjaxName = "GetInternship_Data";
				ViewBag.PostLink = "Normal?link=internship";
				ViewBag.Zonepinture = "b31.png";
				return View();
			}
			else if (type == "englishlearning")
			{
				ViewBag.navigationName = $"English Learning";
				ViewBag.postNum = $"English Learning【Zone】Posts: {num}";
				ViewBag.typePageName = "englishlearning";
				ViewBag.AjaxName = "GetEnglishlearning_Data";
				ViewBag.PostLink = "Normal?link=englishlearning";
				ViewBag.Zonepinture = "b32.png";
				return View();
			}
			else if (type == "chineselearning")
			{
				ViewBag.navigationName = $"Chinese Learning";
				ViewBag.postNum = $"Chinese Learning【Zone】Posts: {num}";
				ViewBag.typePageName = "chineselearning";
				ViewBag.AjaxName = "GetChineselearning_Data";
				ViewBag.PostLink = "Normal?link=chineselearning";
				ViewBag.Zonepinture = "b33.png";
				return View();
			}
			else if (type == "programminglearning")
			{
				ViewBag.navigationName = $"Programming Learning";
				ViewBag.postNum = $"Programming Learning【Zone】Posts: {num}";
				ViewBag.typePageName = "programminglearning";
				ViewBag.AjaxName = "GetProgramminglearning_Data";
				ViewBag.PostLink = "Normal?link=programminglearning";
				ViewBag.Zonepinture = "b34.png";
				return View();
			}
			else if (type == "businesslearning")
			{
				ViewBag.navigationName = $"Business Learning";
				ViewBag.postNum = $"Business Learning【Zone】Posts: {num}";
				ViewBag.typePageName = "businesslearning";
				ViewBag.AjaxName = "GetBusinesslearning_Data";
				ViewBag.PostLink = "Normal?link=businesslearning";
				ViewBag.Zonepinture = "b35.png";
				return View();
			}
			else if (type == "howtolearn")
			{
				ViewBag.navigationName = $"How to Learn";
				ViewBag.postNum = $"How to Learn【Zone】Posts: {num}";
				ViewBag.typePageName = "howtolearn";
				ViewBag.AjaxName = "GetHowtolearn_Data";
				ViewBag.PostLink = "Normal?link=howtolearn";
				ViewBag.Zonepinture = "b36.png";
				return View();
			}
			else if (type == "programmingdiscussion")
			{
				ViewBag.navigationName = $"Programming Discussion";
				ViewBag.postNum = $"Programming Discussion【Zone】Posts: {num}";
				ViewBag.typePageName = "programmingdiscussion";
				ViewBag.AjaxName = "GetProgrammingdiscussion_Data";
				ViewBag.PostLink = "Normal?link=programmingdiscussion";
				ViewBag.Zonepinture = "b37.png";
				return View();
			}
			else if (type == "learningdiscussion")
			{
				ViewBag.navigationName = $"Learning Discussion";
				ViewBag.postNum = $"Learning Discussion【Zone】Posts: {num}";
				ViewBag.typePageName = "learningdiscussion";
				ViewBag.AjaxName = "GetLearningdiscussion_Data";
				ViewBag.PostLink = "Normal?link=learningdiscussion";
				ViewBag.Zonepinture = "b38.png";
				return View();
			}
			else if (type == "penang")
			{
				ViewBag.navigationName = $"Penang";
				ViewBag.postNum = $"Penang【Zone】Posts: {num}";
				ViewBag.typePageName = "penang";
				ViewBag.AjaxName = "GetPenang_Data";
				ViewBag.PostLink = "Normal?link=penang";
				ViewBag.Zonepinture = "b39.png";
				return View();
			}
			else if (type == "ipoh")
			{
				ViewBag.navigationName = $"Ipoh";
				ViewBag.postNum = $"Ipoh【Zone】Posts: {num}";
				ViewBag.typePageName = "ipoh";
				ViewBag.AjaxName = "GetIpoh_Data";
				ViewBag.PostLink = "Normal?link=ipoh";
				ViewBag.Zonepinture = "b40.png";
				return View();
			}
			else if (type == "kualalumpur")
			{
				ViewBag.navigationName = $"Kuala Lumpur";
				ViewBag.postNum = $"Kuala Lumpur【Zone】Posts: {num}";
				ViewBag.typePageName = "kualalumpur";
				ViewBag.AjaxName = "GetKualalumpur_Data";
				ViewBag.PostLink = "Normal?link=kualalumpur";
				ViewBag.Zonepinture = "b41.png";
				return View();
			}
			else if (type == "taiping")
			{
				ViewBag.navigationName = $"Taiping";
				ViewBag.postNum = $"Taiping【Zone】Posts: {num}";
				ViewBag.typePageName = "taiping";
				ViewBag.AjaxName = "GetTaiping_Data";
				ViewBag.PostLink = "Normal?link=taiping";
				ViewBag.Zonepinture = "b42.png";
				return View();
			}
			else if (type == "bukitmertajam")
			{
				ViewBag.navigationName = $"Bukit Mertajam";
				ViewBag.postNum = $"Bukit Mertajam【Zone】Posts: {num}";
				ViewBag.typePageName = "bukitmertajam";
				ViewBag.AjaxName = "GetBukitmertajam_Data";
				ViewBag.PostLink = "Normal?link=bukitmertajam";
				ViewBag.Zonepinture = "b43.png";
				return View();
			}
			else if (type == "jelutong")
			{
				ViewBag.navigationName = $"Jelutong";
				ViewBag.postNum = $"Jelutong【Zone】Posts: {num}";
				ViewBag.typePageName = "jelutong";
				ViewBag.AjaxName = "GetJelutong_Data";
				ViewBag.PostLink = "Normal?link=jelutong";
				ViewBag.Zonepinture = "b44.png";
				return View();
			}
			else if (type == "bayanlepas")
			{
				ViewBag.navigationName = $"Bayan Lepas";
				ViewBag.postNum = $"Bayan Lepas【Zone】Posts: {num}";
				ViewBag.typePageName = "bayanlepas";
				ViewBag.AjaxName = "GetBayanlepas_Data";
				ViewBag.PostLink = "Normal?link=bayanlepas";
				ViewBag.Zonepinture = "b45.png";
				return View();
			}
			else if (type == "kulim")
			{
				ViewBag.navigationName = $"Kulim";
				ViewBag.postNum = $"Kulim【Zone】Posts: {num}";
				ViewBag.typePageName = "kulim";
				ViewBag.AjaxName = "GetKulim_Data";
				ViewBag.PostLink = "Normal?link=kulim";
				ViewBag.Zonepinture = "b46.png";
				return View();
			}
			else if (type == "subangjaya")
			{
				ViewBag.navigationName = $"Subang Jaya";
				ViewBag.postNum = $"Subang Jaya【Zone】Posts: {num}";
				ViewBag.typePageName = "subangjaya";
				ViewBag.AjaxName = "GetSubangjaya_Data";
				ViewBag.PostLink = "Normal?link=subangjaya";
				ViewBag.Zonepinture = "b47.png";
				return View();
			}
			else if (type == "klang")
			{
				ViewBag.navigationName = $"Klang";
				ViewBag.postNum = $"Klang【Zone】Posts: {num}";
				ViewBag.typePageName = "klang";
				ViewBag.AjaxName = "GetKlang_Data";
				ViewBag.PostLink = "Normal?link=klang";
				ViewBag.Zonepinture = "b48.png";
				return View();
			}
			else if (type == "shahalam")
			{
				ViewBag.navigationName = $"Shah Alam";
				ViewBag.postNum = $"Shah Alam【Zone】Posts: {num}";
				ViewBag.typePageName = "shahalam";
				ViewBag.AjaxName = "GetShahalam_Data";
				ViewBag.PostLink = "Normal?link=shahalam";
				ViewBag.Zonepinture = "b49.png";
				return View();
			}
			else if (type == "malacca")
			{
				ViewBag.navigationName = $"Malacca";
				ViewBag.postNum = $"Malacca【Zone】Posts: {num}";
				ViewBag.typePageName = "malacca";
				ViewBag.AjaxName = "GetMalacca_Data";
				ViewBag.PostLink = "Normal?link=malacca";
				ViewBag.Zonepinture = "b50.png";
				return View();
			}
			else if (type == "muar")
			{
				ViewBag.navigationName = $"Muar";
				ViewBag.postNum = $"Muar【Zone】Posts: {num}";
				ViewBag.typePageName = "muar";
				ViewBag.AjaxName = "GetMuar_Data";
				ViewBag.PostLink = "Normal?link=muar";
				ViewBag.Zonepinture = "b51.png";
				return View();
			}
			else if (type == "johor")
			{
				ViewBag.navigationName = $"Johor";
				ViewBag.postNum = $"Johor【Zone】Posts: {num}";
				ViewBag.typePageName = "johor";
				ViewBag.AjaxName = "GetJohor_Data";
				ViewBag.PostLink = "Normal?link=johor";
				ViewBag.Zonepinture = "b52.png";
				return View();
			}
			else if (type == "kotabahru")
			{
				ViewBag.navigationName = $"Kota Bahru";
				ViewBag.postNum = $"Kota Bahru【Zone】Posts: {num}";
				ViewBag.typePageName = "kotabahru";
				ViewBag.AjaxName = "GetKotabahru_Data";
				ViewBag.PostLink = "Normal?link=kotabahru";
				ViewBag.Zonepinture = "b53.png";
				return View();
			}
			else if (type == "jaychou")
			{
				ViewBag.navigationName = $"Jay Chou";
				ViewBag.postNum = $"Jay Chou【Zone】Posts: {num}";
				ViewBag.typePageName = "jaychou";
				ViewBag.AjaxName = "GetJaychou_Data";
				ViewBag.PostLink = "Normal?link=jaychou";
				ViewBag.Zonepinture = "b54.png";
				return View();
			}
			else if (type == "mayday")
			{
				ViewBag.navigationName = $"Mayday";
				ViewBag.postNum = $"Mayday【Zone】Posts: {num}";
				ViewBag.typePageName = "mayday";
				ViewBag.AjaxName = "GetMayday_Data";
				ViewBag.PostLink = "Normal?link=mayday";
				ViewBag.Zonepinture = "b55.png";
				return View();
			}
			else if (type == "huachenyu")
			{
				ViewBag.navigationName = $"Hua Chenyu";
				ViewBag.postNum = $"Hua Chenyu【Zone】Posts: {num}";
				ViewBag.typePageName = "huachenyu";
				ViewBag.AjaxName = "GetHuachenyu_Data";
				ViewBag.PostLink = "Normal?link=huachenyu";
				ViewBag.Zonepinture = "b56.png";
				return View();
			}
			else if (type == "mj116")
			{
				ViewBag.navigationName = $"MJ116";
				ViewBag.postNum = $"MJ116【Zone】Posts: {num}";
				ViewBag.typePageName = "mj116";
				ViewBag.AjaxName = "GetMJ116_Data";
				ViewBag.PostLink = "Normal?link=mj116";
				ViewBag.Zonepinture = "b57.png";
				return View();
			}
			else if (type == "oneokrock")
			{
				ViewBag.navigationName = $"One Ok Rock";
				ViewBag.postNum = $"One Ok Rock【Zone】Posts: {num}";
				ViewBag.typePageName = "oneokrock";
				ViewBag.AjaxName = "GetOneokrock_Data";
				ViewBag.PostLink = "Normal?link=oneokrock";
				ViewBag.Zonepinture = "b58.png";
				return View();
			}
			else if (type == "english")
			{
				ViewBag.navigationName = $"English Music";
				ViewBag.postNum = $"English Music【Zone】Posts: {num}";
				ViewBag.typePageName = "english";
				ViewBag.AjaxName = "GetEnglish_Data";
				ViewBag.PostLink = "Normal?link=english";
				ViewBag.Zonepinture = "b59.png";
				return View();
			}
			else if (type == "chinese")
			{
				ViewBag.navigationName = $"Chinese Music";
				ViewBag.postNum = $"Chinese Music【Zone】Posts: {num}";
				ViewBag.typePageName = "chinese";
				ViewBag.AjaxName = "GetChinese_Data";
				ViewBag.PostLink = "Normal?link=chinese";
				ViewBag.Zonepinture = "b60.png";
				return View();
			}
			else if (type == "animeop")
			{
				ViewBag.navigationName = $"Anime OP Music";
				ViewBag.postNum = $"Anime OP Music【Zone】Posts: {num}";
				ViewBag.typePageName = "animeop";
				ViewBag.AjaxName = "GetAnimeop_Data";
				ViewBag.PostLink = "Normal?link=animeop";
				ViewBag.Zonepinture = "b61.png";
				return View();
			}
			else if (type == "internationalmusic")
			{
				ViewBag.navigationName = $"International Music";
				ViewBag.postNum = $"International Music【Zone】Posts: {num}";
				ViewBag.typePageName = "internationalmusic";
				ViewBag.AjaxName = "GetInternationalmusic_Data";
				ViewBag.PostLink = "Normal?link=internationalmusic";
				ViewBag.Zonepinture = "b62.png";
				return View();
			}
			else if (type == "relaxed")
			{
				ViewBag.navigationName = $"Relaxed Music";
				ViewBag.postNum = $"Relaxed Music【Zone】Posts: {num}";
				ViewBag.typePageName = "relaxed";
				ViewBag.AjaxName = "GetRelaxed_Data";
				ViewBag.PostLink = "Normal?link=relaxed";
				ViewBag.Zonepinture = "b63.png";
				return View();
			}
			else if (type == "music")
			{
				ViewBag.navigationName = $"Music Sharing/Discussion";
				ViewBag.postNum = $"Music Sharing/Discussion【Zone】Posts: {num}";
				ViewBag.typePageName = "music";
				ViewBag.AjaxName = "GetMusic_Data";
				ViewBag.PostLink = "Normal?link=music";
				ViewBag.Zonepinture = "b64.png";
				return View();
			}
			else if (type == "pop")
			{
				ViewBag.navigationName = $"Pop Music";
				ViewBag.postNum = $"Pop Music【Zone】Posts: {num}";
				ViewBag.typePageName = "pop";
				ViewBag.AjaxName = "GetPop_Data";
				ViewBag.PostLink = "Normal?link=pop";
				ViewBag.Zonepinture = "b65.png";
				return View();
			}
			else if (type == "rock")
			{
				ViewBag.navigationName = $"Rock Music";
				ViewBag.postNum = $"Rock Music【Zone】Posts: {num}";
				ViewBag.typePageName = "rock";
				ViewBag.AjaxName = "GetRock_Data";
				ViewBag.PostLink = "Normal?link=rock";
				ViewBag.Zonepinture = "b66.png";
				return View();
			}
			else if (type == "rap")
			{
				ViewBag.navigationName = $"Rap Music";
				ViewBag.postNum = $"Rap Music【Zone】Posts: {num}";
				ViewBag.typePageName = "rap";
				ViewBag.AjaxName = "GeRap_Data";
				ViewBag.PostLink = "Normal?link=rap";
				ViewBag.Zonepinture = "b67.png";
				return View();
			}
			else if (type == "createlyrics")
			{
				ViewBag.navigationName = $"Create/Share Lyrics";
				ViewBag.postNum = $"Create/Share Lyrics【Zone】Posts: {num}";
				ViewBag.typePageName = "createlyrics";
				ViewBag.AjaxName = "GetCreatelyrics_Data";
				ViewBag.PostLink = "Normal?link=createlyrics";
				ViewBag.Zonepinture = "b68.png";
				return View();
			}
			else if (type == "genshin")
			{
				ViewBag.navigationName = $"Genshin Impact";
				ViewBag.postNum = $"Genshin Impact【Zone】Posts: {num}";
				ViewBag.typePageName = "genshin";
				ViewBag.AjaxName = "GetGenshin_Data";
				ViewBag.PostLink = "Normal?link=genshin";
				ViewBag.Zonepinture = "b69.png";
				return View();
			}
			else if (type == "honkai")
			{
				ViewBag.navigationName = $"Honkai Impact: Star Rail";
				ViewBag.postNum = $"Honkai Impact: Star Rail【Zone】Posts: {num}";
				ViewBag.typePageName = "honkai";
				ViewBag.AjaxName = "GetHonkai_Data";
				ViewBag.PostLink = "Normal?link=honkai";
				ViewBag.Zonepinture = "Stars70.png";
				return View();
			}
			else if (type == "pubg")
			{
				ViewBag.navigationName = $"PUBG Mobile";
				ViewBag.postNum = $"PUBG Mobile【Zone】Posts: {num}";
				ViewBag.typePageName = "pubg";
				ViewBag.AjaxName = "GetPubg_Data";
				ViewBag.PostLink = "Normal?link=pubg";
				ViewBag.Zonepinture = "b71.png";
				return View();
			}
			else if (type == "league")
			{
				ViewBag.navigationName = $"League of Legends";
				ViewBag.postNum = $"League of Legends【Zone】Posts: {num}";
				ViewBag.typePageName = "league";
				ViewBag.AjaxName = "GetLeague_Data";
				ViewBag.PostLink = "Normal?link=league";
				ViewBag.Zonepinture = "b72.png";
				return View();
			}
			else if (type == "game")
			{
				ViewBag.navigationName = $"Game Discussions";
				ViewBag.postNum = $"Game Discussions【Zone】Posts: {num}";
				ViewBag.typePageName = "game";
				ViewBag.AjaxName = "GetGame_Data";
				ViewBag.PostLink = "Normal?link=game";
				ViewBag.Zonepinture = "b73.png";
				return View();
			}
			else if (type == "sao")
			{
				ViewBag.navigationName = $"Sword Art Online";
				ViewBag.postNum = $"Sword Art Online【Zone】Posts: {num}";
				ViewBag.typePageName = "sao";
				ViewBag.AjaxName = "GetSao_Data";
				ViewBag.PostLink = "Normal?link=sao";
				ViewBag.Zonepinture = "b74.png";
				return View();
			}
			else if (type == "bleach")
			{
				ViewBag.navigationName = $"Bleach";
				ViewBag.postNum = $"Bleach【Zone】Posts: {num}";
				ViewBag.typePageName = "bleach";
				ViewBag.AjaxName = "GetBleach_Data";
				ViewBag.PostLink = "Normal?link=bleach";
				ViewBag.Zonepinture = "b75.png";
				return View();
			}
			else if (type == "gintama")
			{
				ViewBag.navigationName = $"Gintama";
				ViewBag.postNum = $"Gintama【Zone】Posts: {num}";
				ViewBag.typePageName = "gintama";
				ViewBag.AjaxName = "GetGintama_Data";
				ViewBag.PostLink = "Normal?link=gintama";
				ViewBag.Zonepinture = "b76.png";
				return View();
			}
			else if (type == "spies")
			{
				ViewBag.navigationName = $"Spies and Family Liquor";
				ViewBag.postNum = $"Spies and Family Liquor【Zone】Posts: {num}";
				ViewBag.typePageName = "spies";
				ViewBag.AjaxName = "GetSpies_Data";
				ViewBag.PostLink = "Normal?link=spies";
				ViewBag.Zonepinture = "b77.png";
				return View();
			}
			else if (type == "anime")
			{
				ViewBag.navigationName = $"Anime Discussions";
				ViewBag.postNum = $"Anime Discussions【Zone】Posts: {num}";
				ViewBag.typePageName = "anime";
				ViewBag.AjaxName = "GetAnime_Data";
				ViewBag.PostLink = "Normal?link=anime";
				ViewBag.Zonepinture = "b78.png";
				return View();
			}
			else if (type == "honor")
			{
				ViewBag.navigationName = $"Honor of Kings";
				ViewBag.postNum = $"Honor of Kings【Zone】Posts: {num}";
				ViewBag.typePageName = "honor";
				ViewBag.AjaxName = "GetHonor_Data";
				ViewBag.PostLink = "Normal?link=honor";
				ViewBag.Zonepinture = "b79.png";
				return View();
			}
			else if (type == "domestic")
			{
				ViewBag.navigationName = $"Domestic Productions Sharing";
				ViewBag.postNum = $"Domestic Productions Sharing【Zone】Posts: {num}";
				ViewBag.typePageName = "domestic";
				ViewBag.AjaxName = "GetDomestic_Data";
				ViewBag.PostLink = "Normal?link=domestic";
				ViewBag.Zonepinture = "b79.png";
				return View();
			}
			else if (type == "korean")
			{
				ViewBag.navigationName = $"Korean Drama Sharing";
				ViewBag.postNum = $"Korean Drama Sharing【Zone】Posts: {num}";
				ViewBag.typePageName = "korean";
				ViewBag.AjaxName = "GetKorean_Data";
				ViewBag.PostLink = "Normal?link=korean";
				ViewBag.Zonepinture = "b79.png";
				return View();
			}
			else if (type == "american")
			{
				ViewBag.navigationName = $"American Drama Sharing";
				ViewBag.postNum = $"American Drama Sharing【Zone】Posts: {num}";
				ViewBag.typePageName = "american";
				ViewBag.AjaxName = "GetAmerican_Data";
				ViewBag.PostLink = "Normal?link=american";
				ViewBag.Zonepinture = "b79.png";
				return View();
			}
			else if (type == "variety")
			{
				ViewBag.navigationName = $"Variety Show Discussions";
				ViewBag.postNum = $"Variety Show Discussions【Zone】Posts: {num}";
				ViewBag.typePageName = "variety";
				ViewBag.AjaxName = "GetVariety_Data";
				ViewBag.PostLink = "Normal?link=variety";
				ViewBag.Zonepinture = "b79.png";
				return View();
			}
			else if (type == "tv")
			{
				ViewBag.navigationName = $"TV Series Discussions";
				ViewBag.postNum = $"TV Series Discussions【Zone】Posts: {num}";
				ViewBag.typePageName = "tv";
				ViewBag.AjaxName = "GetTv_Data";
				ViewBag.PostLink = "Normal?link=tv";
				ViewBag.Zonepinture = "b79.png";
				return View();
			}
			else if (type == "movie")
			{
				ViewBag.navigationName = $"Movie Discussions";
				ViewBag.postNum = $"Movie Discussions【Zone】Posts: {num}";
				ViewBag.typePageName = "movie";
				ViewBag.AjaxName = "GetMovie_Data";
				ViewBag.PostLink = "Normal?link=movie";
				ViewBag.Zonepinture = "b79.png";
				return View();
			}

			return View();
		}
	}
}
