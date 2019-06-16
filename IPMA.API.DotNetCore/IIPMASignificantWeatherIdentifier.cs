namespace IPMA.API.DotNetCore
{
	internal interface IIPMASignificantWeatherIdentifier
	{
		string DescIdWeatherTypeEN { get; }
		string DescIdWeatherTypePT { get; }
		int IDWeatherType { get; }
	}
}
