using System;

namespace IPMA.API.NET.Interfaces
{
	interface IIPMASeismicityStruct
	{
		string Googlemapref { get; }
		string Degree { get; }
		DateTime DataUpdate { get; }
		string MagType { get; }
		string ObsRegion { get; }
		double Lon { get; }
		string Source { get; }
		double Depth { get; }
		string TensorRef { get; }
		string Sensed { get; }
		long ShakemapID { get; }
		DateTime Time { get; }
		double Lat { get; }
		string Shakemapref { get; }
		string Local { get; }
		double Magnitud { get; }
	}
}
