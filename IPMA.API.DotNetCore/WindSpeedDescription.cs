using Newtonsoft.Json;
using System.Collections.Generic;

namespace IPMA.API.DotNetCore
{
	public class WindSpeedDescription
	{

		string owner;
		string country;
		List<IPMAWindSpeedStruct> windSpeddData;

		public WindSpeedDescription()
		{
			owner = string.Empty;
			country = string.Empty;
			windSpeddData = new List<IPMAWindSpeedStruct>();
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
		public List<IPMAWindSpeedStruct> Data
		{
			get { return windSpeddData; }
			internal set { windSpeddData = value; }
		}

	}
}
