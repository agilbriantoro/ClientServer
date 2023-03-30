using Client.Models;

namespace Client.Repositories.Data
{
	public class UniversityRepository : GeneralRepository<University, int>
	{
		/*private readonly string request;
		private readonly HttpClient _httpClient;*/

		public UniversityRepository(string request = "Universities/") : base(request)
		{
			/*this.request = request;
			_httpClient = new HttpClient
			{
				BaseAddress = new Uri("https://localhost:7235/api")
			};*/
		}
	}
}
