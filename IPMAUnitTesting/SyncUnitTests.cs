using IPMA.API.NET;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace IPMAUnitTesting
{
	[TestClass]
	public class SyncUnitTests
	{
		[TestMethod]
		public void GetLocationsTest()
		{

			try
			{
				IpmaAPI m_ipma = new IpmaAPI();

				var locs = m_ipma.GetLocationsList();

				Assert.AreEqual("BRAGA", locs.Data.Where(x => x.GlobalIdLocal == 1030300).Select(x => x.Local.ToUpper()).SingleOrDefault());

			}
			catch (System.Exception ex)
			{
				Trace.WriteLine(ex.Message);
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		public void GetWeatherTypesTests()
		{

			try
			{
				IpmaAPI m_ipma = new IpmaAPI();
				var wTypes = m_ipma.GetWeatherTypes();
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
		public void GetMeteoForecatsGlobalIDLocal()
		{
			try
			{
				IpmaAPI m_ipma = new IpmaAPI();
				var locs = m_ipma.GetLocationsList();
				int cityID = locs.Data.Where(x => x.Local.Equals("Braga")).Select(x => x.GlobalIdLocal).SingleOrDefault();
				var meteo = m_ipma.GetMeteoForecatsGlobalIDLocal(cityID);
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
		public void GetMeteoForecatsGlobalIDLocalThrowsException()
		{
			try
			{
				IpmaAPI m_ipma = new IpmaAPI();
				Assert.ThrowsException<WebException>(() => m_ipma.GetMeteoForecatsGlobalIDLocal(-1));
			}
			catch (System.Exception ex)
			{
				Trace.WriteLine(ex.Message);
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		public void GetWindSpeedDescriptionTest()
		{
			try
			{
				IpmaAPI m_ipma = new IpmaAPI();
				var wTypes = m_ipma.GetWindSpeedDescription();
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
		public void GetMeteoForecastByDayTest()
		{
			try
			{
				IpmaAPI m_ipma = new IpmaAPI();
				var locs = m_ipma.GetLocationsList();
				var city = locs.Data.Single(x => x.Local.Equals("Braga"));
				var meteo = m_ipma.GetMeteoForecastByDay(0);

				Assert.IsNotNull(meteo.Data);
				Assert.IsNotNull(meteo.ForecastDate);

				meteo = m_ipma.GetMeteoForecastByDay(1);

				Assert.IsNotNull(meteo.Data);
				Assert.IsNotNull(meteo.ForecastDate);

				meteo = m_ipma.GetMeteoForecastByDay(2);

				Assert.IsNotNull(meteo.Data);
				Assert.IsNotNull(meteo.ForecastDate);

			}
			catch (System.Exception ex)
			{
				Trace.WriteLine(ex.Message);
				Assert.Fail(ex.Message);
			}
		}
	}
}
