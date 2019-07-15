using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPMA.API.NET.Exceptions
{
	public class ExceptionIPMASeismicInvliadID : Exception
	{
		public ExceptionIPMASeismicInvliadID(string message) : base(string.Format(IPMAResources.IPMASeismicInvliadID, message))
		{
		}
	}

	public class ExceptionIPMADailyForecastWrongNumberDay : Exception
	{
		public ExceptionIPMADailyForecastWrongNumberDay(string message) : base(string.Format(IPMAResources.IPMADailyForecastWrongNumberDay, message))
		{
		}
	}

}

