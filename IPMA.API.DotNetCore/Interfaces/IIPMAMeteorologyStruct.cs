using System;

namespace IPMA.API.DotNetCore.Interfaces
{
	internal interface IIPMAMeteorologyStruct
	{
		double PrecipitaProb { get; }
		double TMin { get; }
		double TMax { get; }
		string PredWindDir { get; }
		int IDWeatherType { get; }
		int ClassWindSpeed { get; }
		double Longitude { get; }
		DateTime ForecastDate { get; }
		double Latitude { get; }
	}
}
