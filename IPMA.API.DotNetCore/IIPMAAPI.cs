using System.Threading.Tasks;

namespace IPMA.API.DotNetCore
{
	internal interface IIPMAAPI
	{
		Locations GetLocationsList();

		Task<Locations> GetLocationsListAsync();

		WeatherTypes GetWeatherTypes();

		Task<WeatherTypes> GetWeatherTypesAsync();

		MeteoForecast GetMeteoForecatsGlobalIDLocal(int id);

		Task<MeteoForecast> GetMeteoForecatsGlobalIDLocalAsync(int id);

	}
}
