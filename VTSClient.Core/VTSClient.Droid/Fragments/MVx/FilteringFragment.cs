//using System;
//using System.Collections.Generic;
//using Android.OS;
//using Android.Runtime;
//using Android.Support.V7.Widget;
//using Android.Views;
//using Android.Widget;
//using Autofac;
//using MvvmCross.Droid.Support.V4;
//using MvvmCross.Droid.Views;
//using VTSClient.BLL.Dto;
//using VTSClient.BLL.Interfaces;
//using VTSClient.DAL.Enums;
//using VTSClient.Droid.Autofac;
//using MvvmCross.Droid.Shared.Attributes;
//using VTSClient.Core.ViewModels;
//using VTSClient.Droid.Adapters.Mvx;

//namespace VTSClient.Droid.Fragments.MVx
//{
//	public class FilteringFragment : MvxFragment
//	{
//		private View _view;
//		private ListViewCompat _vacationList;
//		private Button _button;

//		private IApiVacationService _vacationService;
//		private IEnumerable<VacationDto> _vacations;

//		private readonly MvxActivity _context;
//		private readonly FilterEnum _type;

//		[Register(".ctor", "()V", "")]
//		public FilteringFragment() : base()
//        {
//		}


//		public FilteringFragment(MvxActivity context, FilterEnum type)
//		{
//			_context = context;
//			_type = type;
//		}

//		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
//		{
//			base.OnCreateView(inflater, container, savedInstanceState);

//			AutofacSetting.Initialize();

//			_vacationService = AutofacSetting.Container.Resolve<IApiVacationService>();

//			_view = inflater.Inflate(Resource.Layout.Main, container, false);

//			GetVacations();

//			return _view;
//		}

//		public override void OnDestroyView()
//		{
//			UnbindEvents();
//			base.OnDestroyView();
//		}

//		private async void GetVacations()
//		{
//			_vacationList = _view.FindViewById<ListViewCompat>(Resource.Id.vacationsList);
//			_vacations = await _vacationService.FilterVacations(_type);

//			//var vacationAdapter = new VacationMvxAdapter(_context);
//			//_vacationList.Adapter = vacationAdapter;
//			//_button = new Button(_vacationList.Context)
//			//{
//			//	Text = "Add"
//			//};

//			//_vacationList.AddFooterView(_button);
//			//BindEvents();
//		}


//		private void OnAddClick(object sender, EventArgs e)
//		{
//			//StartActivity(new Intent(_context, typeof(DetailsScreenActivity)));
//		}

//		private void OnClick(object sender, AdapterView.ItemClickEventArgs e)
//		{
//			//var intent = new Intent(_context, typeof(DetailsScreenActivity));
//			//intent.PutExtra("VacationId", _vacations.ToList()[e.Position].Id.ToString());
//			//StartActivity(intent);
//		}

//		private void BindEvents()
//		{
//			_button.Click += OnAddClick;
//			_vacationList.ItemClick += OnClick;
//		}

//		private void UnbindEvents()
//		{
//			_button.Click -= OnAddClick;
//			_vacationList.ItemClick -= OnClick;
//		}
//	}
//}