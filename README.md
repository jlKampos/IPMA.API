# IPMA.API
## C# .NET Framework & DotnetCore Implementation of https://api.ipma.pt/#legal
#### __NOTE:__ 
This is just a Preview (Work in Progress)

##### .NET Framework Nuget https://www.nuget.org/packages/IPMA.API.NET

##### .DotNetCore Nuget https://www.nuget.org/packages/IPMA.API.DotNetCore/

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
using IPMA.API.*; // It depends NET Framework proj or DotNet
using System;
using System.Linq;
using System.Threading.Tasks;
namespace IPMATesting
{
	class Program
	{
		static void Main(string[] args)
		{
			IPMAAPI ipma = new IPMAAPI();

			Locations locs = null;

			Task<Locations> callTask = Task.Run(() => ipma.GetLocationsListAsync());

			callTask.Wait();

			locs = callTask.Result;

			Task<WeatherTypes> callTaskI;
			WeatherTypes wTypes = null;


			callTaskI = Task.Run(() => ipma.GetWeatherTypesAsync());

			callTaskI.Wait();

			wTypes = callTaskI.Result;

			Task<MeteoForecast> callTaskII;
			MeteoForecast meteo = null;


			callTaskII = Task.Run(() => ipma.GetMeteoForecatsGlobalIDLocalAsync(1010500));

			callTaskII.Wait();

			meteo = callTaskII.Result;

			var city = locs.Data.Where(x => x.GlobalIdLocal == 1010500).Select(x => x.Local).SingleOrDefault();


			Console.WriteLine("\n5 Days meteo Forecast for the city: {0}", city);

			for (int i = 0; i < meteo.Data.Count; i++)
			{
				Console.WriteLine("WeekDay: {0}", meteo.Data[i].ForecastDate.DayOfWeek);
				Console.WriteLine("Max Temp: {0}", meteo.Data[i].TMax);
				Console.WriteLine("Min Temp: {0}", meteo.Data[i].TMin);
				Console.WriteLine("Wind Direction: {0}", meteo.Data[i].PredWindDir);
				Console.WriteLine("Precipitation Probability: {0}", meteo.Data[i].PrecipitaProb);
				string howsDaWeather = wTypes.Data.Where(x => x.IDWeatherType == meteo.Data[i].IDWeatherType).Select(y => y.DescIdWeatherTypeEN).SingleOrDefault();
				Console.WriteLine("Description of Weather: {0}\n", howsDaWeather);

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
