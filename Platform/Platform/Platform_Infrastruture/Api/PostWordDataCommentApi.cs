using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Platform_DomainModelEntity.Models;

namespace Platform_Infrastruture.Api
{
	public class PostWordDataCommentApi
	{
		//const string baseUrl = "http://localhost:5155/api/";
		//const string baseUrl = "https://hoowengchin-001-site1.itempurl.com/api/";
		const string baseUrl = "http://hoochin-001-site1.itempurl.com/api/";
		HttpClient client = new HttpClient();

		public async Task<List<PostWordDataComment>> GetAllPostWordDataComment()
		{
			string jsonStr = await client.GetStringAsync(baseUrl + "PostWordDataComment");
			return JsonConvert.DeserializeObject<List<PostWordDataComment>>(jsonStr);
		}

		public async Task<PostWordDataComment> FindPostWordDataComment(int id)
		{
			var jsonStr = await client.GetStringAsync(baseUrl + "PostWordDataComment/" + id);
			return JsonConvert.DeserializeObject<PostWordDataComment>(jsonStr);
		}

		public async Task EditPostWordDataComment(PostWordDataComment post)
		{
			var jsonStr = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");
			await client.PutAsync(baseUrl + "PostWordDataComment/" + post.Id, jsonStr);
		}

		public async Task DeletePostWordDataComment_Admin(int id)
		{
			await client.DeleteAsync(baseUrl + "PostWordDataComment/" + id);
		}

		public async Task PostWordDataCommentCreateDat(PostWordDataComment post)
		{
			var jsonStr = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");
			await client.PostAsync(baseUrl + "PostWordDataComment", jsonStr);
		}
	}
}
