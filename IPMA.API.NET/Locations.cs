using IPMA.API.NET.DataStructures;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace IPMA.API.NET
{
	public class Locations
	{

		string owner;
		string country;
		List<IPMALocationsStruct> listLocations;

		public Locations()
		{
			owner = string.Empty;
			country = string.Empty;
			listLocations = new List<IPMALocationsStruct>();
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
		public List<IPMALocationsStruct> Data
		{
			get { return listLocations; }
			internal set { listLocations = value; }
		}

	}
}
