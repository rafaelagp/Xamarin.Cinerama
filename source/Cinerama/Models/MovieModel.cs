using System;
using System.Collections.Generic;

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
	}
}
