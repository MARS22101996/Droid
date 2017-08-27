using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using VTSClient.Core.Models;
using VTSClient.Core.ViewModels;
using VTSClient.Droid.Settings;

namespace VTSClient.Droid.ViewHolders
{
	public class SegmentItemViewHolder : MvxRecyclerViewHolder
	{
		private Button _segmentText;

		private LinearLayoutManager _layoutManager;
		public SegmentItemViewHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)
		{
			InitComponents(itemView);

			BindComponents();
		}

		private void InitComponents(View itemView)
		{
			_segmentText = itemView.FindViewById<Button>(Resource.Id.segmentName);

			_layoutManager = new LinearLayoutManager(itemView.Context, LinearLayoutManager.Horizontal, false);

		}

		private void BindComponents()
		{
			var bindingSet = this.CreateBindingSet<SegmentItemViewHolder, SectionViewModel>();

			bindingSet.Bind(_segmentText)
			   .For(x=>x.Text)
			   .To(vm => vm.NameStatus);

			bindingSet.Bind(_segmentText)
				.To(vm => vm.GoToVacationsCommand);

			bindingSet.Apply();
		}
	}
}