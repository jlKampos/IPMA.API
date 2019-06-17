namespace IPMA.API.DotNetCore.Interfaces
{
	internal interface IIPMASignificantWeatherIdentifier
	{
		string DescIdWeatherTypeEN { get; }
		string DescIdWeatherTypePT { get; }
		int IDWeatherType { get; }
	}
}
