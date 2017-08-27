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
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using VTSClient.Droid.ViewHolders;

namespace VTSClient.Droid.Adapters
{
	public class SegmentAdapter : MvxRecyclerAdapter
	{
		private IMvxAndroidBindingContext _context;
		public SegmentAdapter(IMvxAndroidBindingContext bindingContext)
		: base(bindingContext)
		{
			_context = bindingContext;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext.LayoutInflaterHolder);

			var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Segment, parent, false);

			return new SegmentItemViewHolder(view, itemBindingContext);
		}
	}
}