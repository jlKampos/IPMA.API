using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace IPMA.API.DotNetCore
{
	public class IPMAAPI : IIPMAAPI
	{

		string m_locationsURL;
		string m_weatherTypesURL;
		string m_weatherForecastGlocalID;

		public IPMAAPI()
		{
			m_locationsURL = "http://api.ipma.pt/open-data/distrits-islands.json";
			m_weatherTypesURL = "http://api.ipma.pt/open-data/weather-type-classe.json";
			m_weatherForecastGlocalID = "http://api.ipma.pt/open-data/forecast/meteorology/cities/daily/{0}.json";
		}

		internal string GetData(string url)
		{
			try
			{
				using (WebClient webClient = new WebClient())
				{
					webClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.140 Safari/537.36 Edge/17.17134");

					var results = webClient.DownloadString(String.Format(m_locationsURL));

					return results;
				}

			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		internal async Task<string> GetDataAsync(string url)
		{
			try
			{
				using (WebClient webClient = new WebClient())
				{
					webClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.140 Safari/537.36 Edge/17.17134");
					return await webClient.DownloadStringTaskAsync(url);
				}

			}
			catch (Exception ex)
			{

				throw ex;
			}
		}


		public Locations GetLocationsList()
		{
			try
			{
				Locations locationList = new Locations();
				locationList = JsonConvert.DeserializeObject<Locations>(GetData(m_locationsURL));
				return locationList;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public async Task<Locations> GetLocationsListAsync()
		{
			try
			{
				Locations locationList = new Locations();
				locationList = JsonConvert.DeserializeObject<Locations>(await GetDataAsync(m_locationsURL));
				return locationList;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public WeatherTypes GetWeatherTypes()
		{
			try
			{
				WeatherTypes wTypes = new WeatherTypes();
				wTypes = JsonConvert.DeserializeObject<WeatherTypes>(GetData(m_weatherTypesURL));
				return wTypes;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public async Task<WeatherTypes> GetWeatherTypesAsync()
		{
			try
			{
				WeatherTypes wTypes = new WeatherTypes();
				wTypes = JsonConvert.DeserializeObject<WeatherTypes>(await GetDataAsync(m_weatherTypesURL));
				return wTypes;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public MeteoForecast GetMeteoForecatsGlobalIDLocal(int id)
		{
			try
			{
				MeteoForecast weather = new MeteoForecast();
				weather = JsonConvert.DeserializeObject<MeteoForecast>(GetData(string.Format(m_weatherForecastGlocalID, id)));
				return weather;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public async Task<MeteoForecast> GetMeteoForecatsGlobalIDLocalAsync(int id)
		{
			try
			{

				MeteoForecast weather = new MeteoForecast();
				weather = JsonConvert.DeserializeObject<MeteoForecast>(await GetDataAsync(string.Format(m_weatherForecastGlocalID, id)));
				return weather;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
	}
}
