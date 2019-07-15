using IPMA.API.NET;
using IPMA.API.NET.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;

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

				Type locsModelType = locs.GetType();

				PropertyInfo[] listOfProperties = locsModelType.GetProperties();

				foreach (PropertyInfo property in listOfProperties)
				{
					Assert.IsNotNull(property.GetValue(locs).ToString());
				}

				foreach (var item in locs.Data)
				{
					Type itemModelType = item.GetType();

					PropertyInfo[] listOfPropertyInfos = itemModelType.GetProperties();

					foreach (PropertyInfo property in listOfPropertyInfos)
					{
						Assert.IsNotNull(property.GetValue(item).ToString());
					}
				}

				Assert.AreEqual("BRAGA", locs.Data.Where(x => x.GlobalIdLocal == 1030300).Select(x => x.Local.ToUpper()).SingleOrDefault());

			}
			catch (System.Exception ex)
			{
				Trace.WriteLine(ex.Message);
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		public void GetWeatherTypesTest()
		{

			try
			{
				IpmaAPI m_ipma = new IpmaAPI();
				var wTypes = m_ipma.GetWeatherTypes();

				Type wTypesModelType = wTypes.GetType();

				PropertyInfo[] listOfProperties = wTypesModelType.GetProperties();

				foreach (PropertyInfo property in listOfProperties)
				{
					Assert.IsNotNull(property.GetValue(wTypes).ToString());
				}


				foreach (var item in wTypes.Data)
				{
					Type itemModelType = item.GetType();

					PropertyInfo[] listOfPropertyInfos = itemModelType.GetProperties();

					foreach (PropertyInfo property in listOfPropertyInfos)
					{
						Assert.IsNotNull(property.GetValue(item).ToString());
					}
				}

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

				Type meteoModelTypes = meteo.GetType();

				PropertyInfo[] listOfProperties = meteoModelTypes.GetProperties();

				foreach (PropertyInfo property in listOfProperties)
				{
					Assert.IsNotNull(property.GetValue(meteo).ToString());
				}

				foreach (var item in meteo.Data)
				{
					Type itemModelType = item.GetType();

					PropertyInfo[] listOfPropertyInfos = itemModelType.GetProperties();

					foreach (PropertyInfo property in listOfPropertyInfos)
					{
						Assert.IsNotNull(property.GetValue(item).ToString());
					}
				}

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
				var windTypes = m_ipma.GetWindSpeedDescription();

				Type windTypesModelType = windTypes.GetType();

				PropertyInfo[] listOfProperties = windTypesModelType.GetProperties();

				foreach (PropertyInfo property in listOfProperties)
				{
					Assert.IsNotNull(property.GetValue(windTypes).ToString());
				}

				foreach (var item in windTypes.Data)
				{
					Type itemModelType = item.GetType();

					PropertyInfo[] listOfPropertyInfos = itemModelType.GetProperties();

					foreach (PropertyInfo property in listOfPropertyInfos)
					{
						Assert.IsNotNull(property.GetValue(item).ToString());
					}
				}

				List<string> wTypesWinds = windTypes.Data.Select(x => x.DescClassWindSpeedDailyEN).ToList();
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

				Assert.ThrowsException<Exception>(() => m_ipma.GetMeteoForecastByDay(3));
			}
			catch (System.Exception ex)
			{
				Trace.WriteLine(ex.Message);
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		public void GetSeismologyDataTest()
		{
			try
			{
				IpmaAPI m_ipma = new IpmaAPI();
				var seismicity = m_ipma.GetSeismologyData(3);

				Type seismicityModelType = seismicity.GetType();

				PropertyInfo[] listOfProperties = seismicityModelType.GetProperties();

				foreach (PropertyInfo property in listOfProperties)
				{
					Assert.IsNotNull(property.GetValue(seismicity).ToString());
				}

				foreach (var item in seismicity.Data)
				{
					Type itemModelType = item.GetType();

					PropertyInfo[] listOfPropertyInfos = itemModelType.GetProperties();

					foreach (PropertyInfo property in listOfPropertyInfos)
					{
						Assert.IsNotNull(property.GetValue(item).ToString());
					}
				}

				Assert.AreNotEqual(seismicity.Data.Count(), 0);
				Assert.IsNotNull(seismicity.IDArea);
				Assert.IsNotNull(seismicity.LastSismicActivityDate);

				seismicity = m_ipma.GetSeismologyData(7);

				Assert.AreNotEqual(seismicity.Data.Count(), 0);
				Assert.IsNotNull(seismicity.IDArea);
				Assert.IsNotNull(seismicity.LastSismicActivityDate);

				Assert.ThrowsException<ExceptionIPMASeismicInvliadID>(() => m_ipma.GetSeismologyData(1));
			}
			catch (System.Exception ex)
			{
				Trace.WriteLine(ex.Message);
				Assert.Fail(ex.Message);
			}
		}
	}
}
