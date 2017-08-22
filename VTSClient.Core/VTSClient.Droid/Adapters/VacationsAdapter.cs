using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using VTSClient.Droid.Infrastracture;
using VTSClient.BLL.Dto;

namespace VTSClient.Droid.Adapters
{
    public class VacationsAdapter : BaseAdapter<VacationDto>
    {
        private readonly AppCompatActivity _context;
        private readonly List<VacationDto> _vacations;

        public VacationsAdapter(AppCompatActivity context, List<VacationDto> vacations)
        {
            _context = context;
            _vacations = vacations;
        }

        public override VacationDto this[int position] => _vacations[position];

        public override int Count => _vacations.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = _context.LayoutInflater.Inflate(Resource.Layout.VacationRow, parent, false);
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