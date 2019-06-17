using IPMA.API.NET.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPMA.API.NET.DataStructures
{
	public class IPMASeismicityStruc : IIPMASeismicityStruct
	{


		string googlemapref;
		string degree;
		DateTime dataUpdate;
		string magType;
		string obsRegion;
		double lon;
		string source;
		double depth;
		string tensorRef;
		string sensed;
		long shakemapid;
		DateTime time;
		double lat;
		string shakemapref;
		string local;
		double magnitud;

		public IPMASeismicityStruc()
		{
			googlemapref = string.Empty;
			degree = string.Empty;
			dataUpdate = DateTime.Now;
			magType = string.Empty;
			obsRegion = string.Empty;
			lon = 0.0;
			source = string.Empty;
			depth = 0.0;
			tensorRef = string.Empty;
			sensed = string.Empty;
			shakemapid = 0;
			time = DateTime.Now;
			lat = 0.0;
			shakemapref = string.Empty;
			local = string.Empty;
			magnitud = 0.0;
		}

		[JsonProperty("googlemapref")]
		public string Googlemapref
		{
			get { return googlemapref; }
			internal set
			{
				if (value == null)
				{
					googlemapref = string.Empty;
				}
				else
				{
					googlemapref = value;
				}
			}
		}

		[JsonProperty("degree")]
		public string Degree
		{
			get { return degree; }
			internal set
			{
				if (value == null)
				{
					degree = string.Empty;
				}
				else
				{
					degree = value;
				}
			}
		}

		[JsonProperty("dataUpdate")]
		public DateTime DataUpdate
		{
			get { return dataUpdate; }
			internal set { dataUpdate = value; }
		}

		[JsonProperty("magType")]
		public string MagType
		{
			get { return magType; }
			internal set
			{
				if (value == null)
				{
					magType = string.Empty;
				}
				else
				{
					magType = value;
				}

			}
		}

		[JsonProperty("obsRegion")]
		public string ObsRegion
		{
			get { return obsRegion; }
			internal set
			{
				if (value == null)
				{
					obsRegion = string.Empty;
				}
				else
				{
					obsRegion = value;
				}
			}
		}

		[JsonProperty("lon")]

		public double Lon
		{
			get { return lon; }
			internal set { lon = value; }
		}

		[JsonProperty("source")]
		public string Source
		{
			get { return source; }
			internal set
			{
				if (value == null)
				{
					source = string.Empty;
				}
				else
				{
					source = value;
				}
			}
		}

		[JsonProperty("depth")]
		public double Depth
		{
			get { return depth; }
			internal set { depth = value; }
		}

		[JsonProperty("tensorRef")]
		public string TensorRef
		{
			get { return tensorRef; }
			internal set
			{
				if (value == null)
				{
					tensorRef = string.Empty;
				}
				else
				{
					tensorRef = value;
				}
			}
		}

		[JsonProperty("sensed")]
		public string Sensed
		{
			get { return sensed; }
			internal set
			{
				if (value == null)
				{
					sensed = string.Empty;
				}
				else
				{
					sensed = value;
				}
			}
		}

		[JsonProperty("shakemapid")]
		public long ShakemapID
		{
			get { return shakemapid; }
			internal set { shakemapid = value; }
		}

		[JsonProperty("time")]
		public DateTime Time
		{
			get { return time; }
			internal set { time = value; }
		}

		[JsonProperty("lat")]
		public double Lat
		{
			get { return lat; }
			internal set { lat = value; }
		}


		[JsonProperty("shakemapref")]
		public string Shakemapref
		{
			get { return shakemapref; }
			internal set
			{
				if (value == null)
				{
					shakemapref = string.Empty;
				}
				else
				{
					shakemapref = value;
				}
			}
		}

		[JsonProperty("local")]
		public string Local
		{
			get { return local; }
			internal set
			{
				if (value == null)
				{
					local = string.Empty;
				}
				else
				{
					local = value;
				}
			}
		}

		[JsonProperty("magnitud")]
		public double Magnitud
		{
			get { return magnitud; }
			internal set { magnitud = value; }
		}
	}
}
