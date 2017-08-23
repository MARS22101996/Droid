using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using VTSClient.Core.Models;

namespace VTSClient.Droid.ViewHolders
{
	public class CountryItemViewHolder : MvxRecyclerViewHolder
	{
		private TextView _countryNameText;
		private TextView _citiesQtyText;
		private LinearLayout _countryLayout;
		private LinearLayoutManager _layoutManager;

		public CountryItemViewHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)
		{
			InitComponents(itemView);
			BindComponents();
		}

		private void InitComponents(View itemView)
		{
			_countryNameText = itemView.FindViewById<TextView>(Resource.Id.countryNameText);

			_citiesQtyText = itemView.FindViewById<TextView>(Resource.Id.countryPagerText);

			_countryLayout = itemView.FindViewById<LinearLayout>(Resource.Id.countryLayout);

			_layoutManager = new LinearLayoutManager(itemView.Context, LinearLayoutManager.Horizontal, false);

		}

		private void BindComponents()
		{
			var bindingSet = this.CreateBindingSet<CountryItemViewHolder, VacationCoreModel>();

			bindingSet.Bind(_countryNameText)
				.To(x => x.CreateDate);

			bindingSet.Bind(_citiesQtyText).For(d => d.Text).To(f => f.VacationStatus);

			bindingSet.Apply();
		}
	}
}