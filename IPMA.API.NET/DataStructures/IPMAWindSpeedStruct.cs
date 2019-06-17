using IPMA.API.NET.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPMA.API.NET.DataStructures
{
	public class IPMAWindSpeedStruct : IIPMAWindSpeedStruct
	{
		string descClassWindSpeedDailyEN;
		string descClassWindSpeedDailyPT;
		int classWindSpeed;

		public IPMAWindSpeedStruct()
		{
			descClassWindSpeedDailyEN = string.Empty;
			descClassWindSpeedDailyPT = string.Empty;
			classWindSpeed = 0;
		}

		[JsonProperty("descClassWindSpeedDailyEN")]
		public string DescClassWindSpeedDailyEN
		{
			get { return descClassWindSpeedDailyEN; }
			internal set { descClassWindSpeedDailyEN = value; }
		}

		[JsonProperty("descClassWindSpeedDailyPT")]
		public string DescClassWindSpeedDailyPT
		{
			get { return descClassWindSpeedDailyPT; }
			internal set { descClassWindSpeedDailyPT = value; }
		}


		[JsonProperty("classWindSpeed")]
		public int ClassWindSpeed
		{
			get { return classWindSpeed; }
			internal set { classWindSpeed = value; }
		}
	}
}
