using System;

namespace Cinerama.Models
{
	public class MovieModel
	{
		public string Name { get; set; }
		public string PosterFilename { get; set; } 
		public string Genre { get; set; }
		public string Overview { get; set; }
		public DateTime ReleaseDate { get; set; }
	}
}
