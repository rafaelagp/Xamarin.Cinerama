using System.Globalization;
using Newtonsoft.Json.Serialization;

namespace Cinerama.Utils.Json
{
	/// <summary>
	/// Custom property name resolver for Newtonsoft.Json, converts PascalCase into SnakeCase. 
	/// Ex.: PosterPath -> poster_path. 
	/// </summary>
	public class CustomPropertyNamesContractResolver : DefaultContractResolver
	{
		static readonly CultureInfo Culture = CultureInfo.InvariantCulture;

		protected override string ResolvePropertyName(string propertyName)
		{
			return ChangeCase(propertyName);
		}

		string ChangeCase(string propertyName)
		{
			var newPropertyName = string.Empty;

			for (var i = 0; i < propertyName.Length; i++)
			{
				if (char.IsUpper(propertyName[i]))
				{
					newPropertyName += char.ToLower(propertyName[i]);
				}
				else
				{
					newPropertyName += propertyName[i];
				}

				if (i+1 < propertyName.Length
				    && char.IsUpper(propertyName[i+1]))
				{
					newPropertyName += "_";
				}
			}

			return newPropertyName;
		}
	}

}
