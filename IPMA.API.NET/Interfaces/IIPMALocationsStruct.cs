namespace IPMA.API.NET.Interfaces
{
	internal interface IIPMALocationsStruct
	{
		double Longitude { get; }

		int IDRegiao { get; }

		string IDAreaAviso { get; }

		int IdConcelho { get; }

		int GlobalIdLocal { get; }

		double Latitude { get; }

		int IDDistrito { get; }

		string Local { get; }

	}
}
