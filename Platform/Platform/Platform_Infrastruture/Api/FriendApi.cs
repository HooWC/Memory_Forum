using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Platform_DomainModelEntity.Models;

namespace Platform_Infrastruture.Api
{
	public class FriendApi
	{
		//const string baseUrl = "http://localhost:5155/api/";
		//const string baseUrl = "https://hoowengchin-001-site1.itempurl.com/api/";
		const string baseUrl = "http://hoochin-001-site1.itempurl.com/api/";
		HttpClient client = new HttpClient();

		public async Task<List<Friend>> GetAllFriend()
		{
			string jsonStr = await client.GetStringAsync(baseUrl + "Friend");
			return JsonConvert.DeserializeObject<List<Friend>>(jsonStr);
		}

		public async Task<Friend> FindFriend(int id)
		{
			var jsonStr = await client.GetStringAsync(baseUrl + "Friend/" + id);
			return JsonConvert.DeserializeObject<Friend>(jsonStr);
		}

		public async Task EditFriend(Friend Friend)
		{
			var jsonStr = new StringContent(JsonConvert.SerializeObject(Friend), Encoding.UTF8, "application/json");
			await client.PutAsync(baseUrl + "Friend/" + Friend.Id, jsonStr);
		}

		public async Task DeleteFriend_Admin(int id)
		{
			await client.DeleteAsync(baseUrl + "Friend/" + id);
		}

		public async Task FriendCreateDat(Friend Friend)
		{
			var jsonStr = new StringContent(JsonConvert.SerializeObject(Friend), Encoding.UTF8, "application/json");
			await client.PostAsync(baseUrl + "Friend", jsonStr);
		}
	}
}
