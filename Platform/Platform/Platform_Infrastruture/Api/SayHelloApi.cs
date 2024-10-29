using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Platform_DomainModelEntity.Models;

namespace Platform_Infrastruture.Api
{
	public class SayHelloApi
	{
		//const string baseUrl = "http://localhost:5155/api/";
		//const string baseUrl = "https://hoowengchin-001-site1.itempurl.com/api/";
		const string baseUrl = "http://hoochin-001-site1.itempurl.com/api/";
		HttpClient client = new HttpClient();

		public async Task<List<SayHello>> GetAllSayHello()
		{
			string jsonStr = await client.GetStringAsync(baseUrl + "SayHello");
			return JsonConvert.DeserializeObject<List<SayHello>>(jsonStr);
		}

		public async Task<SayHello> FindSayHello(int id)
		{
			var jsonStr = await client.GetStringAsync(baseUrl + "SayHello/" + id);
			return JsonConvert.DeserializeObject<SayHello>(jsonStr);
		}

		public async Task EditSayHello(SayHello SayHello)
		{
			var jsonStr = new StringContent(JsonConvert.SerializeObject(SayHello), Encoding.UTF8, "application/json");
			await client.PutAsync(baseUrl + "SayHello/" + SayHello.Id, jsonStr);
		}

		public async Task DeleteSayHello_Admin(int id)
		{
			await client.DeleteAsync(baseUrl + "SayHello/" + id);
		}

		public async Task SayHelloCreateData(SayHello SayHello)
		{
			var jsonStr = new StringContent(JsonConvert.SerializeObject(SayHello), Encoding.UTF8, "application/json");
			await client.PostAsync(baseUrl + "SayHello", jsonStr);
		}
	}
}
