using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using VTSClient.Droid.ViewHolders;

namespace VTSClient.Droid.Adapters
{
	public class VacationsAdapter : MvxRecyclerAdapter
	{
		private IMvxAndroidBindingContext _context;
		public VacationsAdapter(IMvxAndroidBindingContext bindingContext)
		: base(bindingContext)
		{
			_context = bindingContext;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext.LayoutInflaterHolder);

			var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.VacationRow, parent, false);

			return new VacationItemViewHolder(view, itemBindingContext);
		}
	}
}