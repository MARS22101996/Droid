namespace VTSClient.Droid.Adapters
{
    public class TypesAdapter : Android.Support.V4.App.FragmentPagerAdapter
    {
        readonly Android.Support.V4.App.Fragment[] _fragments;

        public TypesAdapter(Android.Support.V4.App.FragmentManager fm, Android.Support.V4.App.Fragment[] fragments)
			: base(fm)
        {
            _fragments = fragments;
		}

        public override int Count => _fragments.Length;

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {       
            return _fragments[position];
        }
    }
}