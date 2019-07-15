using IPMA.API.NET.Exceptions;
using IPMA.API.NET.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace IPMA.API.NET
{
	public class IpmaAPI : IIpmaAPI
	{

		readonly string m_locationsURL;
		readonly string m_weatherTypesURL;
		readonly string m_weatherForecastGlocalID;
		readonly string m_windspeed;
		readonly string m_weatherForecastByDay;
		readonly string m_seismic;
		readonly static string m_userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:68.0) Gecko/20100101 Firefox/68.0";

		public IpmaAPI()
		{
			m_locationsURL = "http://api.ipma.pt/open-data/distrits-islands.json";
			m_weatherTypesURL = "http://api.ipma.pt/open-data/weather-type-classe.json";
			m_weatherForecastGlocalID = "http://api.ipma.pt/open-data/forecast/meteorology/cities/daily/{0}.json";
			m_windspeed = "http://api.ipma.pt/open-data/wind-speed-daily-classe.json";
			m_weatherForecastByDay = " http://api.ipma.pt/open-data/forecast/meteorology/cities/daily/hp-daily-forecast-day{0}.json";
			m_seismic = "http://api.ipma.pt/open-data/observation/seismic/{0}.json";
		}

		/// <summary>
		/// Method that invoques async the requested URL
		/// </summary>
		/// <param name="url">url of service</param>
		/// <returns>string to be parsed into json</returns>
		internal static string GetData(string url)
		{
			try
			{
				using (WebClient webClient = new WebClient())
				{
					webClient.Headers.Add("user-agent", m_userAgent);

					var results = webClient.DownloadString(url);

					return results;
				}

			}
			catch (WebException ex)
			{
				throw new WebException(string.Format(IPMAResources.IPMA404Exception, ex.Message, url));
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Method that invoques async the requested URL
		/// </summary>
		/// <param name="url">url of service</param>
		/// <returns>string to be parsed into json</returns>
		internal static async Task<string> GetDataAsync(string url)
		{
			try
			{
				using (WebClient webClient = new WebClient())
				{
					webClient.Headers.Add("user-agent", m_userAgent);
					return await webClient.DownloadStringTaskAsync(url);
				}

			}
			catch (WebException ex)
			{
				throw new WebException(string.Format(IPMAResources.IPMA404Exception, ex.Message, url));
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// List of identifiers for the capitals district and islands
		/// </summary>
		/// <returns>Locations</returns>
		public Locations GetLocationsList()
		{
			try
			{
				Locations locationList = new Locations();
				locationList = JsonConvert.DeserializeObject<Locations>(GetData(m_locationsURL));
				return locationList;
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// List of significant Weather identifiers
		/// </summary>
		/// <returns>Locations</returns>
		public async Task<Locations> GetLocationsListAsync()
		{
			try
			{
				Locations locationList = new Locations();
				locationList = JsonConvert.DeserializeObject<Locations>(await GetDataAsync(m_locationsURL).ConfigureAwait(false));
				return locationList;
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// List of significant Weather identifiers
		/// </summary>
		/// <returns>Locations</returns>
		public WeatherTypes GetWeatherTypes()
		{
			try
			{
				WeatherTypes wTypes = new WeatherTypes();
				wTypes = JsonConvert.DeserializeObject<WeatherTypes>(GetData(m_weatherTypesURL));
				return wTypes;
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// List of significant Weather identifiers
		/// </summary>
		/// <returns>Locations</returns>
		public async Task<WeatherTypes> GetWeatherTypesAsync()
		{
			try
			{
				WeatherTypes wTypes = new WeatherTypes();
				wTypes = JsonConvert.DeserializeObject<WeatherTypes>(await GetDataAsync(m_weatherTypesURL).ConfigureAwait(false));
				return wTypes;
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Daily Weather Forecast up to 5 days added by Local.
		/// Note: Only daily data is available.
		/// </summary>
		/// <param name="id">Place ID</param>
		/// <returns>% days MeteoForecast for the given place ID</returns>
		public MeteoForecast GetMeteoForecatsGlobalIDLocal(int id)
		{
			try
			{
				MeteoForecast weather = new MeteoForecast();
				weather = JsonConvert.DeserializeObject<MeteoForecast>(GetData(string.Format(m_weatherForecastGlocalID, id)));
				return weather;
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Daily Weather Forecast up to 5 days added by Local.
		/// Note: Only daily data is available.
		/// </summary>
		/// <param name="id">Place ID</param>
		/// <returns>% days MeteoForecast for the given place ID</returns>
		public async Task<MeteoForecast> GetMeteoForecatsGlobalIDLocalAsync(int id)
		{
			try
			{
				MeteoForecast weather = new MeteoForecast();
				weather = JsonConvert.DeserializeObject<MeteoForecast>(await GetDataAsync(string.Format(m_weatherForecastGlocalID, id)).ConfigureAwait(false));
				return weather;
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// List of wind strength classes
		/// </summary>
		/// <returns>WindSpeedDescription</returns>
		public WindSpeedDescription GetWindSpeedDescription()
		{
			try
			{
				WindSpeedDescription winSpeedDesc = new WindSpeedDescription();
				winSpeedDesc = JsonConvert.DeserializeObject<WindSpeedDescription>(GetData(m_windspeed));
				return winSpeedDesc;
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// List of wind strength classes
		/// </summary>
		/// <returns>WindSpeedDescription</returns>
		public async Task<WindSpeedDescription> GetWindSpeedDescriptionAsync()
		{
			try
			{
				WindSpeedDescription wTypes = new WindSpeedDescription();
				wTypes = JsonConvert.DeserializeObject<WindSpeedDescription>(await GetDataAsync(m_windspeed).ConfigureAwait(false));
				return wTypes;
			}
			catch (Exception)
			{

				throw;
			}
		}

		/// <summary>
		/// Note: Only daily data is available. {idDay} ranges from 0 to 2, where:
		/// 0 - is day equivalent to today
		/// 1 - tomorrow
		/// 2 - the day after tomorrow
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Meteo Forecast</returns>
		public MeteoForecast GetMeteoForecastByDay(int id)
		{
			try
			{
				if (id < 0 || id > 2)
				{
					throw new ExceptionIPMADailyForecastWrongNumberDay(id.ToString());
				}

				MeteoForecast weather = new MeteoForecast();
				weather = JsonConvert.DeserializeObject<MeteoForecast>(GetData(string.Format(m_weatherForecastByDay, id)));

				return weather;
			}
			catch (ExceptionIPMADailyForecastWrongNumberDay)
			{
				throw;
			}
			catch (Exception)
			{

				throw;
			}
		}

		/// <summary>
		/// Note: Only daily data is available. {idDay} ranges from 0 to 2, where:
		/// 0 - is day equivalent to today
		/// 1 - tomorrow
		/// 2 - the day after tomorrow
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Meteo Forecast</returns>
		public async Task<MeteoForecast> GetMeteoForecastByDayAsync(int id)
		{
			try
			{
				if (id < 0 || id > 2)
				{
					throw new ExceptionIPMADailyForecastWrongNumberDay(id.ToString());
				}

				MeteoForecast weather = new MeteoForecast();
				weather = JsonConvert.DeserializeObject<MeteoForecast>(await GetDataAsync(string.Format(m_weatherForecastByDay, id)).ConfigureAwait(false));
				return weather;
			}
			catch (ExceptionIPMADailyForecastWrongNumberDay)
			{
				throw;
			}
			catch (Exception)
			{

				throw;
			}
		}

		/// <summary>
		/// Information on seismicity, Arq. Azores, Mainland and Madeira. Integrates 30 days of information. 
		/// 3 - Arq. Azores
		/// 7 - Mainland and Madeira
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public SeismicityData GetSeismologyData(int id)
		{
			try
			{
				if (id != 3 && id != 7)
				{
					throw new ExceptionIPMASeismicInvliadID(id.ToString());
				}
				SeismicityData seismicData = new SeismicityData();
				seismicData = JsonConvert.DeserializeObject<SeismicityData>(GetData(string.Format(m_seismic, id)));
				return seismicData;
			}
			catch (ExceptionIPMASeismicInvliadID)
			{
				throw;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<SeismicityData> GetSeismologyDataAsync(int id)
		{
			try
			{
				if (id != 3 && id != 7)
				{
					throw new ExceptionIPMASeismicInvliadID(id.ToString());
				}

				SeismicityData seismicData = new SeismicityData();
				seismicData = JsonConvert.DeserializeObject<SeismicityData>(await GetDataAsync(string.Format(m_seismic, id)).ConfigureAwait(false));
				return seismicData;
			}
			catch (ExceptionIPMASeismicInvliadID)
			{
				throw;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
