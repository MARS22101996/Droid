using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using VTSClient.Core.Models;
using VTSClient.Droid.Infrastracture;
using VTSClient.Droid.Settings;

namespace VTSClient.Droid.ViewHolders
{
	public class VacationItemViewHolder : MvxRecyclerViewHolder
	{
		private TextView _durationText;

		private TextView _typeText;

		private TextView _statusText;

		private ImageView _picture;

		private Button _toDetails;

		private LinearLayoutManager _layoutManager;

		public VacationItemViewHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)
		{
			InitComponents(itemView);

			BindComponents();
		}

		private void InitComponents(View itemView)
		{
			_picture = itemView.FindViewById<ImageView>(Resource.Id.vacationImg);

			_durationText = itemView.FindViewById<TextView>(Resource.Id.vacationDate);

			_typeText = itemView.FindViewById<TextView>(Resource.Id.vacationType);

			_statusText= itemView.FindViewById<TextView>(Resource.Id.vacationStatus);

			_toDetails = itemView.FindViewById<Button>(Resource.Id.ToDetails);

			_layoutManager = new LinearLayoutManager(itemView.Context, LinearLayoutManager.Horizontal, false);

		}

		private void BindComponents()
		{
			var bindingSet = this.CreateBindingSet<VacationItemViewHolder, VacationCoreModel>();

			bindingSet.Bind(_durationText)
				.For(d => d.Text)
				.To(x => x.Period);

			bindingSet.Bind(_typeText)
				.For(d => d.Text)
				.To(f => f.VacationType);

			bindingSet.Bind(_statusText)
				.For(d => d.Text)
				.To(f => f.VacationStatus);


			bindingSet.Bind(_toDetails)
				.To(f => f.DetailCommand);

			bindingSet.Apply();

			var typePicture = _typeText.Text;

			_picture.SetImageResource(VacationTypeSetting.GetPicture(typePicture));
		}
	}
}