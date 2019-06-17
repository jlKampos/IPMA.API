using IPMA.API.NET.Interfaces;
using Newtonsoft.Json;

namespace IPMA.API.NET.DataStructures
{
	public class IPMASignificantWeatherIdentifier : IIPMASignificantWeatherIdentifier
	{

		string descIdWeatherTypeEN;
		string descIdWeatherTypePT;
		int idWeatherType;

		public IPMASignificantWeatherIdentifier()
		{
			descIdWeatherTypeEN = string.Empty;
			descIdWeatherTypePT = string.Empty; ;
			idWeatherType = 0;
		}

		[JsonProperty("descIdWeatherTypeEN")]
		public string DescIdWeatherTypeEN
		{
			get { return descIdWeatherTypeEN; }
			internal set { descIdWeatherTypeEN = value; }
		}

		[JsonProperty("descIdWeatherTypePT")]
		public string DescIdWeatherTypePT
		{
			get { return descIdWeatherTypePT; }
			internal set { descIdWeatherTypePT = value; }
		}

		[JsonProperty("idWeatherType")]
		public int IDWeatherType
		{
			get { return idWeatherType; }
			internal set { idWeatherType = value; }
		}
	}
}
