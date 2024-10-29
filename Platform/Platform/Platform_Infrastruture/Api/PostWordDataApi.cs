using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Platform_DomainModelEntity.Models;

namespace Platform_Infrastruture.Api
{
	public class PostWordDataApi
	{
		//const string baseUrl = "http://localhost:5155/api/";
		//const string baseUrl = "https://hoowengchin-001-site1.itempurl.com/api/";
		const string baseUrl = "http://hoochin-001-site1.itempurl.com/api/";
		HttpClient client = new HttpClient();

		public async Task<List<PostWordData>> GetAllPostWordData()
		{
			string jsonStr = await client.GetStringAsync(baseUrl + "PostWordData");
			return JsonConvert.DeserializeObject<List<PostWordData>>(jsonStr);
		}

		public async Task<PostWordData> FindPostWordData(int id)
		{
			var jsonStr = await client.GetStringAsync(baseUrl + "PostWordData/" + id);
			return JsonConvert.DeserializeObject<PostWordData>(jsonStr);
		}

		public async Task EditPostWordData(PostWordData post)
		{
			var jsonStr = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");
			await client.PutAsync(baseUrl + "PostWordData/" + post.Id, jsonStr);
		}

		public async Task DeletePostWordData_Admin(int id)
		{
			await client.DeleteAsync(baseUrl + "PostWordData/" + id);
		}

		public async Task PostWordDataCreateDat(PostWordData post)
		{
			var jsonStr = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");
			await client.PostAsync(baseUrl + "PostWordData", jsonStr);
		}
	}
}
