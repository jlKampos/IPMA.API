﻿using IPMA.API.NET.DataStructures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace IPMA.API.NET
{
	public class MeteoForecast
	{
		string owner;
		string country;
		int globalIdLocal;
		DateTime forecastDate;
		DateTime dataUpdate;
		List<IPMAMeteorologyStruct> waether;

		public MeteoForecast()
		{
			owner = string.Empty;
			country = string.Empty;
			globalIdLocal = 0;
			dataUpdate = new DateTime();
			forecastDate = new DateTime();
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

		[JsonProperty("globalIdLocal")]
		public int GlobalIdLocal
		{
			get { return globalIdLocal; }
			internal set { globalIdLocal = value; }
		}

		[JsonProperty("dataUpdate")]
		public DateTime DataUpdate
		{
			get { return dataUpdate; }
			internal set { dataUpdate = value; }
		}

		[JsonProperty("forecastDate")]
		public DateTime ForecastDate
		{
			get { return forecastDate; }
			internal set { forecastDate = value; }
		}

		[JsonProperty("data")]
		public List<IPMAMeteorologyStruct> Data
		{
			get { return waether; }
			internal set { waether = value; }
		}
	}
}
