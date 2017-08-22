using System;
using System.Globalization;
using MvvmCross.Platform.Converters;
using VTSClient.DAL.Enums;

namespace VTSClient.iOS.ValueConverters
{
	public class StatusToNumbervalueConverter : MvxValueConverter<VacationStatus, int>
	{
		protected override int Convert(
			VacationStatus value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			var result = value == VacationStatus.Approved ? 0 : 1;

			return result;
		}
	}
}