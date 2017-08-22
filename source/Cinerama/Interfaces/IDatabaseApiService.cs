using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cinerama.Models;

namespace Cinerama.Interfaces
{
	public interface IDatabaseApiService
	{
		Task<List<GenreModel>> GetMovieGenresAsync(CancellationToken token, string language = "en-us");
		Task<List<MovieModel>> GetUpcomingMoviesAsync(CancellationToken token, int page = 1, string language = "en-us");
	}
}
