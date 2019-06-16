using Newtonsoft.Json;
using System.Collections.Generic;

namespace IPMA.API.DotNetCore
{
	public class WeatherTypes
	{
		string owner;
		string country;
		List<IPMASignificantWeatherIdentifier> listWeatherTypes;

		public WeatherTypes()
		{
			owner = string.Empty;
			country = string.Empty;
			listWeatherTypes = new List<IPMASignificantWeatherIdentifier>();
		}

		[JsonProperty("owner")]
		public string Owner
		{
			get { return owner; }
			internal set { owner = value; }
		}

		[JsonProperty("country")]
		public string Country
		{
			get { return country; }
			internal set { country = value; }
		}

		[JsonProperty("data")]
		public List<IPMASignificantWeatherIdentifier> Data
		{
			get { return listWeatherTypes; }
			internal set { listWeatherTypes = value; }
		}

	}
}
