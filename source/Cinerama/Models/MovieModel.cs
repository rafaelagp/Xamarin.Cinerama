using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinerama.Models
{
	/// <summary>
	/// JSON wrapper class for MovieModels.
	/// </summary>
	public class MovieModelList
	{
		public List<MovieModel> Results { get; set; }
	}

	public class MovieModel
	{
		public string Title { get; set; }
		public string BackdropPath { get; set; }
		public string PosterPath { get; set; }
		public string Overview { get; set; }
		public DateTime ReleaseDate { get; set; }
		public int[] GenreIds { get; set; }
		public string GenreNames { get; set; }

		/// <summary>
		/// Compiles GenreNames from GenreIds and a list of GenreModels.
		/// </summary>
		/// <param name="genres">A list of GenreModels.</param>
		public void GetGenreNames(List<GenreModel> genres)
		{
			GenreNames = string.Empty;

			foreach (var genreId in GenreIds)
			{
				var genre = genres.FirstOrDefault(x => x.Id == genreId);

				if (string.IsNullOrWhiteSpace(GenreNames))
				{
					GenreNames = genre.Name;
					continue;
				}

				GenreNames += $", {genre.Name}";
			}
		}
	}
}
