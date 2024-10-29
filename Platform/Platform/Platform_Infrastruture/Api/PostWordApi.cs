using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Platform_DomainModelEntity.Models;

namespace Platform_Infrastruture.Api
{
	public class PostWordApi
	{
		//const string baseUrl = "http://localhost:5155/api/";
		//const string baseUrl = "https://hoowengchin-001-site1.itempurl.com/api/";
		const string baseUrl = "http://hoochin-001-site1.itempurl.com/api/";
		HttpClient client = new HttpClient();

		public async Task<List<PostWord>> GetAllPostWord()
		{
			string jsonStr = await client.GetStringAsync(baseUrl + "PostWord");
			return JsonConvert.DeserializeObject<List<PostWord>>(jsonStr);
		}

		public async Task<PostWord> FindPostWord(int id)
		{
			var jsonStr = await client.GetStringAsync(baseUrl + "PostWord/" + id);
			return JsonConvert.DeserializeObject<PostWord>(jsonStr);
		}

		public async Task EditPostWord(PostWord post)
		{
			var jsonStr = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");
			await client.PutAsync(baseUrl + "PostWord/" + post.Id, jsonStr);
		}

		public async Task DeletePostWord_Admin(int id)
		{
			await client.DeleteAsync(baseUrl + "PostWord/" + id);
		}

		public async Task PostWordCreateDat(PostWord post)
		{
			var jsonStr = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");
			await client.PostAsync(baseUrl + "PostWord", jsonStr);
		}
	}
}
