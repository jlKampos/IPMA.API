
using System.Threading.Tasks;

namespace IPMA.API.NET.Interfaces
{
	internal interface IIpmaAPI
	{
		Locations GetLocationsList();

		Task<Locations> GetLocationsListAsync();

		WeatherTypes GetWeatherTypes();

		Task<WeatherTypes> GetWeatherTypesAsync();

		MeteoForecast GetMeteoForecatsGlobalIDLocal(int id);

		Task<MeteoForecast> GetMeteoForecatsGlobalIDLocalAsync(int id);

		WindSpeedDescription GetWindSpeedDescription();

		Task<WindSpeedDescription> GetWindSpeedDescriptionAsync();

		MeteoForecast GetMeteoForecastByDay(int id);

		Task<MeteoForecast> GetMeteoForecastByDayAsync(int id);

		SeismicityData GetSeismologyData(int id);

		Task<SeismicityData> GetSeismologyDataAsync(int id);
	}
}
