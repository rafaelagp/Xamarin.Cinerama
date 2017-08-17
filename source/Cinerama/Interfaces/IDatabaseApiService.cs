using System.Collections.Generic;
using System.Threading.Tasks;
using Cinerama.Models;

namespace Cinerama.Interfaces
{
	public interface IDatabaseApiService
	{
		Task<List<GenreModel>> GetMovieGenresAsync(string language = "en-us");
		Task<List<MovieModel>> GetUpcomingMoviesAsync(int page = 1, string language = "en-us");
	}
}
