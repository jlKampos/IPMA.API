using Newtonsoft.Json;
using System.Collections.Generic;

namespace IPMA.API.NET
{
	public class MeteoForecast
	{
		string owner;
		string country;
		List<IPMAMeteorologyStruct> waether;

		public MeteoForecast()
		{
			owner = string.Empty;
			country = string.Empty;
			waether = new List<IPMAMeteorologyStruct>();
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
		public List<IPMAMeteorologyStruct> Data
		{
			get { return waether; }
			internal set { waether = value; }
		}

	}
}
