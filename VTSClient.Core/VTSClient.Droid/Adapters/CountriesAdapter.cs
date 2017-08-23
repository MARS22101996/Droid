using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using VTSClient.Droid.ViewHolders;

namespace VTSClient.Droid.Adapters
{
	public class CountriesAdapter : MvxRecyclerAdapter
	{
		private IMvxAndroidBindingContext _context;
		public CountriesAdapter(IMvxAndroidBindingContext bindingContext)
		: base(bindingContext)
		{
			_context = bindingContext;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext.LayoutInflaterHolder);
			var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.countries, parent, false);
			return new CountryItemViewHolder(view, itemBindingContext);
		}
	}
}