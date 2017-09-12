using System.Collections.Generic;

namespace Cinerama.Models
{
	/// <summary>
	/// JSON wrapper class for GenreModels.
	/// </summary>
	public class GenreModelList
	{
		public List<GenreModel> Genres { get; set; }
	}

	public class GenreModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
