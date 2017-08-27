using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace VTSClient.Droid.Infrastracture
{
    public class DatePickerFragment : AppCompatDialogFragment,
        DatePickerDialog.IOnDateSetListener
    {
        public static readonly string TAG = "X:" + typeof(DatePickerFragment).Name.ToUpper();

        Action<DateTime> _dateSelectedHandler = delegate { };

        public static DatePickerFragment NewInstance(Action<DateTime> onDateSelected)
        {
            var frag = new DatePickerFragment
            {
                _dateSelectedHandler = onDateSelected
            };

            return frag;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var currently = DateTime.Now;
	        var dialog = new DatePickerDialog(Activity,
		        this,
		        currently.Year,
		        currently.Month,
		        currently.Day)
	        {
		        DatePicker =
		        {
			        CalendarViewShown = true,
			        SpinnersShown = false
		        }
	        };

	        return dialog;
        }

        public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            var selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
            _dateSelectedHandler(selectedDate);
        }
    }
}