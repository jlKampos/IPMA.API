using IPMA.API.DotNetCore.Interfaces;
using Newtonsoft.Json;

namespace IPMA.API.DotNetCore.DataStructures
{
	public class IPMALocationsStruct : IIPMALocationsStruct
	{
		int idRegiao;
		string idAreaAviso;
		int idConcelho;
		int globalIdLocal;
		double latitude;
		int idDistrito;
		string local;
		double longitude;

		public IPMALocationsStruct()
		{
			idRegiao = 0;
			idAreaAviso = string.Empty;
			idConcelho = 0;
			globalIdLocal = 0;
			latitude = 0.0;
			idDistrito = 0;
			local = string.Empty;
			longitude = 0.0;
		}

		[JsonProperty("idRegiao")]
		public int IDRegiao
		{
			get { return idRegiao; }
			internal set { idRegiao = value; }
		}

		[JsonProperty("idAreaAviso")]
		public string IDAreaAviso
		{
			get { return idAreaAviso; }
			internal set { idAreaAviso = value; }

		}


		[JsonProperty("idConcelho")]
		public int IdConcelho
		{
			get { return idConcelho; }
			internal set { idConcelho = value; }

		}

		[JsonProperty("globalIdLocal")]
		public int GlobalIdLocal
		{
			get { return globalIdLocal; }
			internal set { globalIdLocal = value; }

		}

		[JsonProperty("latitude")]
		public double Latitude
		{
			get { return latitude; }
			internal set { latitude = value; }
		}


		[JsonProperty("idDistrito")]
		public int IDDistrito
		{
			get { return idDistrito; }
			internal set { idDistrito = value; }
		}

		[JsonProperty("local")]
		public string Local
		{
			get { return local; }
			internal set { local = value; }

		}

		[JsonProperty("longitude")]
		public double Longitude
		{
			get { return longitude; }
			internal set { longitude = value; }
		}

	}
}
