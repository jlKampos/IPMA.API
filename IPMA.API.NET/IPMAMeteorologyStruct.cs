using Newtonsoft.Json;
using System;

namespace IPMA.API.NET
{
	public class IPMAMeteorologyStruct : IIPMAMeteorologyStruct
	{
		double precipitaProb;
		double tMin;
		double tMax;
		string predWindDir;
		int idWeatherType;
		int classWindSpeed;
		double longitude;
		DateTime forecastDate;
		double latitude;

		public IPMAMeteorologyStruct()
		{
			precipitaProb = 0.0;
			tMin = 0.0;
			tMax = 0.0;
			predWindDir = string.Empty;
			idWeatherType = 0;
			classWindSpeed = 0;
			longitude = 0.0;
			forecastDate = DateTime.Parse("1900-01-01");
			latitude = 0.0;
		}

		[JsonProperty("precipitaProb")]
		public double PrecipitaProb
		{
			get { return precipitaProb; }
			internal set { precipitaProb = value; }
		}

		[JsonProperty("tMin")]
		public double TMin
		{
			get { return tMin; }
			internal set { tMin = value; }
		}

		[JsonProperty("tMax")]
		public double TMax
		{
			get { return tMax; }
			internal set { tMax = value; }
		}


		[JsonProperty("predWindDir")]
		public string PredWindDir
		{
			get { return predWindDir; }
			internal set { predWindDir = value; }
		}

		[JsonProperty("idWeatherType")]
		public int IDWeatherType
		{
			get { return idWeatherType; }
			internal set { idWeatherType = value; }
		}

		[JsonProperty("classWindSpeed")]
		public int ClassWindSpeed
		{
			get { return classWindSpeed; }
			internal set { classWindSpeed = value; }
		}

		[JsonProperty("longitude")]
		public double Longitude
		{
			get { return longitude; }
			internal set { longitude = value; }
		}

		[JsonProperty("forecastDate")]
		public DateTime ForecastDate
		{
			get { return forecastDate; }
			internal set { forecastDate = value; }
		}

		[JsonProperty("latitude")]
		public double Latitude
		{
			get { return latitude; }
			internal set { latitude = value; }
		}
	}
}
