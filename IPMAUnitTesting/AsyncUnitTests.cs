using IPMA.API.NET;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IPMAUnitTesting
{
	[TestClass]
	public class AsyncUnitTests
	{
		[TestMethod]
		public async Task GetLocationsTestAsync()
		{

			try
			{
				IpmaAPI m_ipma = new IpmaAPI();

				var locs = await m_ipma.GetLocationsListAsync();

				Assert.AreEqual("BRAGA", locs.Data.Where(x => x.GlobalIdLocal == 1030300).Select(x => x.Local.ToUpper()).SingleOrDefault());

			}
			catch (System.Exception ex)
			{
				Trace.WriteLine(ex.Message);
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		public async Task GetWeatherTypesTestAsync()
		{

			try
			{
				IpmaAPI m_ipma = new IpmaAPI();
				var wTypes = await m_ipma.GetWeatherTypesAsync();
				Assert.AreEqual("---", wTypes.Data.Where(x => x.IDWeatherType == -99).Select(x => x.DescIdWeatherTypePT).SingleOrDefault());
				Assert.AreEqual("Céu nublado", wTypes.Data.Where(x => x.IDWeatherType == 27).Select(x => x.DescIdWeatherTypePT).SingleOrDefault());
				Assert.AreEqual(0, wTypes.Data.Where(x => x.DescIdWeatherTypeEN.Equals("Céu nublado")).Select(x => x.IDWeatherType).SingleOrDefault());

			}
			catch (System.Exception ex)
			{
				Trace.WriteLine(ex.Message);
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		public async Task GetMeteoForecatsGlobalIDLocalTestAsync()
		{
			try
			{
				IpmaAPI m_ipma = new IpmaAPI();
				var locs = await m_ipma.GetLocationsListAsync();
				int cityID = locs.Data.Where(x => x.Local.Equals("Braga")).Select(x => x.GlobalIdLocal).SingleOrDefault();
				var meteo = await m_ipma.GetMeteoForecatsGlobalIDLocalAsync(cityID);
				Assert.AreEqual(cityID, meteo.GlobalIdLocal);
				var city = locs.Data.Where(x => x.GlobalIdLocal == cityID).SingleOrDefault();
				var latitude = meteo.Data.Where(x => x.Longitude == locs.Data.Where(y => y.GlobalIdLocal == cityID).Select(y => y.Longitude).SingleOrDefault()).Select(z => z.Latitude).FirstOrDefault();
				Assert.AreEqual(city.Latitude, latitude);
			}
			catch (System.Exception ex)
			{
				Trace.WriteLine(ex.Message);
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		public async Task GetMeteoForecatsGlobalIDLocalThrowsExceptionAsync()
		{
			try
			{
				IpmaAPI m_ipma = new IpmaAPI();
				await Assert.ThrowsExceptionAsync<WebException>(() => m_ipma.GetMeteoForecatsGlobalIDLocalAsync(-1));
			}
			catch (System.Exception ex)
			{
				Trace.WriteLine(ex.Message);
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		public async Task GetWindSpeedDescriptionTestAsync()
		{
			try
			{
				IpmaAPI m_ipma = new IpmaAPI();
				var wTypes = await m_ipma.GetWindSpeedDescriptionAsync();
				List<string> wTypesWinds = wTypes.Data.Select(x => x.DescClassWindSpeedDailyEN).ToList();
				List<string> windDescTypes = new List<string> { "Weak", "Moderate", "Strong", "Very strong", "--" };
				CollectionAssert.AreEquivalent(wTypesWinds, windDescTypes);

			}
			catch (System.Exception ex)
			{
				Trace.WriteLine(ex.Message);
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		public async Task GetMeteoForecastByDayTestAsync()
		{
			try
			{
				IpmaAPI m_ipma = new IpmaAPI();
				var locs = await m_ipma.GetLocationsListAsync();
				var city = locs.Data.Single(x => x.Local.Equals("Braga"));
				var meteo = await m_ipma.GetMeteoForecastByDayAsync(0);

				Assert.IsNotNull(meteo.Data);
				Assert.IsNotNull(meteo.ForecastDate);

				meteo = new MeteoForecast();
				meteo = await m_ipma.GetMeteoForecastByDayAsync(1);

				Assert.IsNotNull(meteo.Data);
				Assert.IsNotNull(meteo.ForecastDate);

				meteo = new MeteoForecast();
				meteo = await m_ipma.GetMeteoForecastByDayAsync(2);

				Assert.IsNotNull(meteo.Data);
				Assert.IsNotNull(meteo.ForecastDate);

				await Assert.ThrowsExceptionAsync<Exception>(() => m_ipma.GetMeteoForecastByDayAsync(3));
			}
			catch (System.Exception ex)
			{
				Trace.WriteLine(ex.Message);
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		public async Task GetSeismologyDataTestAsync()
		{
			try
			{
				IpmaAPI m_ipma = new IpmaAPI();
				var seismicity = await m_ipma.GetSeismologyDataAsync(3);

				Assert.AreNotEqual(seismicity.Data.Count(), 0);
				Assert.IsNotNull(seismicity.IDArea);
				Assert.IsNotNull(seismicity.LastSismicActivityDate);

				seismicity = new SeismicityData();
				seismicity = await m_ipma.GetSeismologyDataAsync(7);

				Assert.AreNotEqual(seismicity.Data.Count(), 0);
				Assert.IsNotNull(seismicity.IDArea);
				Assert.IsNotNull(seismicity.LastSismicActivityDate);

				await Assert.ThrowsExceptionAsync<Exception>(() => m_ipma.GetSeismologyDataAsync(1));
			}
			catch (System.Exception ex)
			{
				Trace.WriteLine(ex.Message);
				Assert.Fail(ex.Message);
			}
		}
	}
}

