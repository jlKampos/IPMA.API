using IPMA.API.NET.DataStructures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace IPMA.API.NET
{
	public class SeismicityData
	{
		int idArea;
		string country;
		DateTime lastSismicActivityDate;
		DateTime updateDate;
		string owner;
		List<IPMASeismicityStruc> seismologyList;

		public SeismicityData()
		{
			idArea = 0;
			country = string.Empty;
			lastSismicActivityDate = new DateTime();
			updateDate = new DateTime(); ;
			owner = string.Empty;
			seismologyList = new List<IPMASeismicityStruc>();
		}

		[JsonProperty("idArea")]
		public int IDArea
		{
			get { return idArea; }
			internal set { idArea = value; }
		}

		[JsonProperty("country")]
		public string Country
		{
			get { return country; }
			internal set { country = value; }
		}

		[JsonProperty("lastSismicActivityDate")]
		public DateTime LastSismicActivityDate
		{
			get { return lastSismicActivityDate; }
			internal set { lastSismicActivityDate = value; }
		}

		[JsonProperty("updateDate")]
		public DateTime UpdateDate
		{
			get { return updateDate; }
			internal set { updateDate = value; }
		}

		[JsonProperty("owner")]
		public string Owner
		{
			get { return owner; }
			internal set { owner = value; }
		}

		[JsonProperty("data")]
		public List<IPMASeismicityStruc> Data
		{
			get { return seismologyList; }
			internal set { seismologyList = value; }
		}
	}
}
