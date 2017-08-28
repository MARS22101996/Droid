using System;
using System.Globalization;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using VTSClient.BLL.Dto;
using VTSClient.BLL.Interfaces;
using VTSClient.Core.Infrastructure.Extentions;
using VTSClient.Core.Models;
using VTSClient.DAL.Enums;

namespace VTSClient.Core.ViewModels
{
	public class DetailViewModel : MvxViewModel<VacationData>
	{
		private readonly IApiVacationService _vacationService;

		private Guid _id;

		private IMvxCommand _changeStatusCommand;

		private IMvxCommand _swipeEventCommand;

		private IMvxCommand _startDateCommand;

		private IMvxCommand _endDateCommand;

		private IMvxCommand _saveCommand;

		private IMvxCommand _doneCommand;

		private IMvxCommand _cancelCommand;

		private IMvxCommand _changeToClosedCommand;

		private IMvxCommand _changeToApprovedCommand;

		private bool _isStartDate;

		private bool _isDatePickerVacation = true;

		public bool IsDatePickerVacation
		{
			get { return _isDatePickerVacation; }
			set
			{
				_isDatePickerVacation = value;
				RaisePropertyChanged(() => IsDatePickerVacation);
			}
		}

		private DateTime _datePickerVacationDate = DateTime.UtcNow;

		public DateTime DatePickerVacationDate
		{
			get { return _datePickerVacationDate; }
			set
			{
				_datePickerVacationDate = value;
				RaisePropertyChanged(() => DatePickerVacationDate);
			}
		}

		private bool _isDatePickerToolbar = true;

		public bool IsDatePickerToolbar
		{
			get { return _isDatePickerToolbar; }
			set
			{
				_isDatePickerToolbar = value;
				RaisePropertyChanged(() => IsDatePickerToolbar);
			}
		}

		private VacationDto Vacation { get; set; }

		private string _startDay = string.Empty;

		public string StartDay
		{
			get { return _startDay; }
			set
			{
				_startDay = value;
				RaisePropertyChanged(() => StartDay);
			}
		}

		private string _startMonth = string.Empty;

		public string StartMonth
		{
			get { return _startMonth; }
			set
			{
				_startMonth = value;
				RaisePropertyChanged(() => StartMonth);
			}
		}

		private string _startYear = string.Empty;

		public string StartYear
		{
			get { return _startYear; }
			set
			{
				_startYear = value;
				RaisePropertyChanged(() => StartYear);
			}
		}

		private string _endDay = string.Empty;

		public string EndDay
		{
			get { return _endDay; }
			set
			{
				_endDay = value;
				RaisePropertyChanged(() => EndDay);
			}
		}

		private string _endMonth = string.Empty;

		public string EndMonth
		{
			get { return _endMonth; }
			set
			{
				_endMonth = value;
				RaisePropertyChanged(() => EndMonth);
			}
		}

		private string _endYear = string.Empty;

		public string EndYear
		{
			get { return _endYear; }
			set
			{
				_endYear = value;
				RaisePropertyChanged(() => EndYear);
			}
		}

		private VacationStatus _statusButtonSelectedSegment = 0;

		public VacationStatus StatusButtonSelectedSegment
		{
			get { return _statusButtonSelectedSegment; }
			set
			{
				_statusButtonSelectedSegment = value;
				RaisePropertyChanged(() => StatusButtonSelectedSegment);
			}
		}

		private string _typeText = string.Empty;

		public string TypeText
		{
			get { return _typeText; }
			set
			{
				_typeText = value;
				RaisePropertyChanged(() => TypeText);
			}
		}

		private int _page = 0;

		public int Page
		{
			get { return _page; }
			set
			{
				_page = value;
				RaisePropertyChanged(() => Page);
			}
		}

		private string _position = "1";

		public string Position
		{
			get { return _position; }
			set
			{
				_position = value;
				RaisePropertyChanged(() => Position);
			}
		}
		public DetailViewModel(IApiVacationService vacationService)
		{
			_vacationService = vacationService;
		}

		public IMvxCommand ChangeStatusCommand => _changeStatusCommand ??
		                                          (_changeStatusCommand = new MvxCommand(
			                                          ChangeStatus));

		public IMvxCommand ChangeToApprovedCommand => _changeToApprovedCommand ??
										  (_changeToApprovedCommand = new MvxCommand(
											  ChangeStatusToApproved));

		public IMvxCommand ChangeToClosedCommand => _changeToClosedCommand ??
										  (_changeToClosedCommand = new MvxCommand(
											  ChangeStatusToClosed));

		public IMvxCommand DoneCommand => _doneCommand ??
		                                  (_doneCommand = new MvxCommand(
			                                  DoneButtonChoose));

		public IMvxCommand CancelCommand => _cancelCommand ??
								  (_cancelCommand = new MvxCommand(
									  HideDatePicker));

		public IMvxCommand SaveCommand => _saveCommand ??
		                                  (_saveCommand = new MvxCommand(() =>
			                                  {
				                                  Save();
				                                  ShowViewModel<MenuViewModel>();
			                                  }
		                                  ));

	   public IMvxCommand SwipeEventCommand => _swipeEventCommand ??
		                                        (_swipeEventCommand = new MvxCommand(
			                                        SwipeEvent));


		public IMvxCommand StartDateCommand => _startDateCommand ??
		                                      (_startDateCommand = new MvxCommand(
			                                      StartDateEvent));

		public IMvxCommand EndDateCommand => _endDateCommand ??
									  (_endDateCommand = new MvxCommand(
										  EndDateEvent));

		public override async Task Initialize(VacationData parameter)
		{
		}

		private void StartDateEvent()
		{
			var date = Vacation.Start;

			ShowDatePicker(date);

			_isStartDate = true;
		}

		private void EndDateEvent()
		{
			var date = Vacation.End;

			ShowDatePicker(date);

			_isStartDate = false;
		}
		private void ShowDatePicker(DateTime date)
		{
			IsDatePickerVacation = false;

			IsDatePickerToolbar = false;

			DatePickerVacationDate = date;
		}

		private async Task SetVacation(Guid id)
		{
			if (id == default(Guid))
			{
				Vacation = _vacationService.GetExampleVacation();
			}
			else
			{
				Vacation = await _vacationService.GetVacationByIdAsync(id);

				var type = (int)Vacation.VacationType;

				Position = type.ToString();
			}
		}

		private void SetData()
		{
			StartDay = Vacation.Start.Day.ToString();

			StartMonth = Vacation.Start.ToShortMonth();

			StartYear = Vacation.Start.Year.ToString();

			EndDay = Vacation.End.Day.ToString();

			EndMonth = Vacation.End.ToShortMonth();

			EndYear = Vacation.End.Year.ToString();

			StatusButtonSelectedSegment = Vacation.VacationStatus;

			Page = (int) Vacation.VacationType;

			Position = Page.ToString();

			if (_id == Guid.Empty)
            {
				TypeText = Enum.GetName(typeof(VacationType), 0);
            }
            else
            {
				TypeText = Vacation.VacationType.ToString();
            }

			DatePickerVacationDate = Vacation.Start;
		}

		private void SwipeEvent()
		{
			var page = Page;
			Vacation.VacationType = (VacationType) page;
			TypeText = Enum.GetName(typeof(VacationType), page);
		}

		public async Task Init(VacationData parameter)
		{
			_id = parameter.Id;

			await SetVacation(parameter.Id);

			SetData();
		}

		private void Save()
		{
			SetType();

			ResetDates();

			if (_id == Guid.Empty)
			{
				_vacationService.CreateVacationAsync(Vacation);
			}
			else
			{
				_vacationService.UpdateVacationAsync(Vacation);
			}			
		}

		private void ResetDates()
		{
			var monthStart = GetMonthByName(_startMonth);

			Vacation.Start = ConfigureDate(_startYear,_startDay, monthStart);

			var monthEnd = GetMonthByName(_endMonth);

			Vacation.End = ConfigureDate(_endYear, _endDay, monthEnd);
		}

		private void SetType()
		{
			if (Position != "")
			{
				Vacation.VacationType = VacationTypeSetting.GetType(int.Parse(Position));
			}
		}

		private int GetMonthByName(string name)
		{
			return DateTime.ParseExact(name, "MMM", CultureInfo.InvariantCulture).Month;
		}

		private DateTime ConfigureDate(string year, string day, int month)
		{
			return new DateTime(int.Parse(year), month, int.Parse(day));
		}

		private void ChangeStatus()
		{
			Vacation.VacationStatus = StatusButtonSelectedSegment;
		}

		private void ChangeStatusToApproved()
		{
			Vacation.VacationStatus = VacationStatus.Approved;
		}

		private void ChangeStatusToClosed()
		{
			Vacation.VacationStatus = VacationStatus.Closed;
		}

		private void DoneButtonChoose()
		{
			if (_isStartDate)
			{
				DatePickerStartButtonEvent();
				return;
			}
			DatePickerEndButtonEvent();

			HideDatePicker();
		}

		private void HideDatePicker()
		{
			IsDatePickerToolbar= true;

			IsDatePickerVacation = true;
		}

		private void DatePickerEndButtonEvent()
		{
			var date = DatePickerVacationDate;

			EndDay= date.Day.ToString();

			EndMonth=date.ToShortMonth();

			EndYear=date.Year.ToString();

			Vacation.End = date;

			IsDatePickerVacation= false;

			IsDatePickerToolbar = true;
		}

		private void DatePickerStartButtonEvent()
		{
			var date = DatePickerVacationDate;

			StartDay=date.Day.ToString();

			StartMonth=date.ToShortMonth();

			StartYear=date.Year.ToString();

			Vacation.Start = date;

			IsDatePickerVacation = true;

			IsDatePickerToolbar = true;
		}

	}
}
