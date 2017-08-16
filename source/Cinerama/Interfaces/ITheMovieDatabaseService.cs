using System.Collections.Generic;
using System.Threading.Tasks;
using Cinerama.Models;

namespace Cinerama.Interfaces
{
	public interface ITheMovieDatabaseService
	{
		Task<List<MovieModel>> GetUpcomingMoviesAsync(int page, string language = "en-us");
	}
}
