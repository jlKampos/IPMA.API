# IPMA.API
### C# .NET Framework & DotnetCore Implementation of https://api.ipma.pt/#legal

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/7a17cf464e76452f908a5bccf66d1feb)](https://app.codacy.com/app/jlKampos/IPMA.API?utm_source=github.com&utm_medium=referral&utm_content=jlKampos/IPMA.API&utm_campaign=Badge_Grade_Settings)
[![.NET Framework Nuget](https://img.shields.io/nuget/v/IPMA.API.NET.svg?color=Green&label=.NET%20Framework%20Nuget&logo=nuget&logoColor=Green&style=popout-square)](https://www.nuget.org/packages/IPMA.API.NET/) [![License: GPL v3](https://img.shields.io/badge/License-GPL%20v3-green.svg?style=popout-square&logo=gnu&logoColor=Black)](https://www.gnu.org/licenses/lgpl-3.0)

##### **18-06-2019** 
Development of Unit Tests

##### **17-06-2019** 
Finished Porting all Weather & Seismicity Data functions to C#,
Added Folders to Projects for better organization

##### .NET Framework Nuget https://www.nuget.org/packages/IPMA.API.NET

**Functionalities Provided in this release**

```csharp
SeismicityData GetSeismologyData(int id);
Task<SeismicityData> GetSeismologyDataAsync(int id);
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
```

##### **16-06-2019** 
splited the project into 2 projects, .NET Framework and Dotnetcore
**Functionalities Provided in this release**

##### In this release all methods are provided in both asynchronous and synchronous

**GetLocationsList** 
Will Retrieve all locations provided by IPMA

**GetWeatherTypes**
Will Retrieve all Weather Types 
eg: Clear sky, Partly cloudy, etc ...

**GetMeteoForecatsGlobalIDLocal**
Will Retrieve a 5 day forecast. for the given GlobalID

**Future Release**
Get MeteoForecast by City Name,
All the Rest of the https://api.ipma.pt/#legal functionalities

**DotnetCore  how to**
```csharp
using IPMA.API.NET;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace IPMATestingNET
{
	static class Program
	{

		static void Main(string[] args)
		{
			try
			{

				int cityID = 0;

				IpmaAPI ipma = new IpmaAPI();

				Locations locs = null;

				Task<Locations> callTask = Task.Run(() => ipma.GetLocationsListAsync());

				callTask.Wait();

				locs = callTask.Result;

				cityID = locs.Data.Where(x => x.Local.ToUpper().Equals("BRAGA")).Select(x => x.GlobalIdLocal).SingleOrDefault();

				Task<WeatherTypes> callTaskI;
				WeatherTypes wTypes = null;

				callTaskI = Task.Run(() => ipma.GetWeatherTypesAsync());

				callTaskI.Wait();

				wTypes = callTaskI.Result;

				Task<MeteoForecast> callTaskII;
				MeteoForecast meteo = null;

				callTaskII = Task.Run(() => ipma.GetMeteoForecatsGlobalIDLocalAsync(cityID));

				callTaskII.Wait();

				meteo = callTaskII.Result;

				Task<WindSpeedDescription> callTaskIII;
				WindSpeedDescription winDesc = null;

				callTaskIII = Task.Run(() => ipma.GetWindSpeedDescriptionAsync());

				callTaskIII.Wait();

				winDesc = callTaskIII.Result;

				Task<MeteoForecast> callTaskIV;
				MeteoForecast mm = null;

				callTaskIV = Task.Run(() => ipma.GetMeteoForecastByDayAsync(2));

				callTaskIV.Wait();

				mm = callTaskIV.Result; // not used on this demo, just how to get daily Meteo forecast 

				var city = locs.Data.Where(x => x.GlobalIdLocal == cityID).Select(x => x.Local).SingleOrDefault();

				Console.WriteLine("\n5 Days meteo Forecast for the city: {0}", city);

				for (int i = 0; i < meteo.Data.Count; i++)
				{
					Console.WriteLine("WeekDay: {0}", meteo.Data[i].ForecastDate.DayOfWeek);
					Console.WriteLine("Max Temp: {0}", meteo.Data[i].TMax);
					Console.WriteLine("Min Temp: {0}", meteo.Data[i].TMin);
					Console.WriteLine("Wind Direction: {0}", meteo.Data[i].PredWindDir);
					Console.WriteLine("Precipitation Probability: {0}", meteo.Data[i].PrecipitaProb);
					string howsDaWeather = wTypes.Data.Where(x => x.IDWeatherType == meteo.Data[i].IDWeatherType).Select(y => y.DescIdWeatherTypeEN).SingleOrDefault();
					Console.WriteLine("Description of Weather: {0}", howsDaWeather);
					string windDescEN = winDesc.Data.Where(x => x.ClassWindSpeed == meteo.Data[i].ClassWindSpeed).Select(x => x.DescClassWindSpeedDailyEN).SingleOrDefault();
					Console.WriteLine("Description of Wind Speed: {0}\n", windDescEN);

				}

				Task<SeismicityData> callSeismicity;
				SeismicityData seismicityData = null;

				callSeismicity = Task.Run(() => ipma.GetSeismologyDataAsync(7));

				callSeismicity.Wait();

				seismicityData = callSeismicity.Result; // not used on this demo, just how to get daily Meteo forecast 

				Console.WriteLine("\n Seismicity");

				foreach (var item in seismicityData.Data)
				{
					Type tModelType = item.GetType();

					PropertyInfo[] arrayPropertyInfos = tModelType.GetProperties();

					foreach (PropertyInfo property in arrayPropertyInfos)
					{
						Console.WriteLine("Name of Property is:" + property.Name);
						Console.WriteLine("Value of Property is:" + property.GetValue(item).ToString());
					}
					break;
				}

			}

			catch (Exception ex)
			{
				if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
				{
					Console.WriteLine(ex.InnerException.Message);
				}
				else
				{
					Console.WriteLine(ex.Message);
				}
			}

			Console.ReadKey();
		}
	}
}
```

### .NET Publish Solution nuget
Install and check this VS Extension https://marketplace.visualstudio.com/items?itemName=CnSharpStudio.NuPack

### DotNet Publish Solution nuget
Build -> Release
Right Click Projet -> Publish -> Configuration : Release; Target Framework netcoreapp*; Target Runtime "Optional" leave Portable

![alt text](https://github.com/jlKampos/IPMA.API/blob/master/Image_002.png)

### Execution under WSL
![alt text](https://github.com/jlKampos/IPMA.API/blob/master/Image_001.png)

### Seismicity Data first element
![alt text](https://github.com/jlKampos/IPMA.API/blob/master/Image_003.png)
