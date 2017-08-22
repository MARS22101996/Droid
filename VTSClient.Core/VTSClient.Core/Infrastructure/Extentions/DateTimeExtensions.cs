using System;
using System.Globalization;

namespace VTSClient.Core.Infrastructure.Extentions
{
    public static class DateTimeExtensions
	{
		public static string ToShortMonth(this DateTime dateTime)
		{
			return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(dateTime.Month);
		}
	}

}
