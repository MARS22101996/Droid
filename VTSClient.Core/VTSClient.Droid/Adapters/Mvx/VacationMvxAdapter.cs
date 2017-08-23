using System.Collections.Generic;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using VTSClient.BLL.Dto;
using VTSClient.Droid.Infrastracture;

namespace VTSClient.Droid.Adapters.Mvx
{
	public class VacationMvxAdapter : MvxAdapter<VacationDto>
	{
		//private readonly AppCompatActivity _context;
		private readonly List<VacationDto> _vacations;

		private Context _context;

		private IMvxAndroidBindingContext _bindingContext;

		public VacationMvxAdapter(Context context, IMvxAndroidBindingContext bindingContext)
			: base(context, bindingContext)
		{
			_context = context;
			_bindingContext = bindingContext;
		}

		//public override VacationDto this[int position] => _vacations[position];

		public override int Count => _vacations.Count;

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = _bindingContext.LayoutInflaterHolder.LayoutInflater.Inflate(Resource.Layout.VacationRow, parent, false);
			var picture = view.FindViewById<AppCompatImageView>(Resource.Id.pictureImageView);
			var duration = view.FindViewById<AppCompatTextView>(Resource.Id.durationTextView);
			var type = view.FindViewById<AppCompatTextView>(Resource.Id.typeTextView);
			var status = view.FindViewById<AppCompatTextView>(Resource.Id.statusTextView);
			picture.SetImageResource(VacationTypeSetting.GetPicture(_vacations[position].VacationType));
			status.Text = _vacations[position].VacationStatus.ToString();

			duration.Text =
				string.Format(
					$"{_vacations[position].Start.ToShortDateString()} - {_vacations[position].End.ToShortDateString()}");
			type.Text = _vacations[position].VacationType.ToString();

			return view;
		}
	}
}