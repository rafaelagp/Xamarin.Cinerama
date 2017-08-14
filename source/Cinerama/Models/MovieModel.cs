using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Cinerama.Models
{
	public class MovieModelList
	{
		public List<MovieModel> Results { get; set; }
	}

	public class MovieModel
	{
		public string Title { get; set; }

		[JsonProperty("poster_path")]
		public string PosterFilename { get; set; } 

		public string Overview { get; set; }

		[JsonProperty("release_date")]
		public DateTime ReleaseDate { get; set; }

		[JsonProperty("genre_ids")]
		public int[] GenreIds { get; set; }
	}
}
