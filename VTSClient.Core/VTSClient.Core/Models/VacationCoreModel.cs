using System;
using MvvmCross.Core.ViewModels;
using VTSClient.Core.ViewModels;
using VTSClient.DAL.Enums;

namespace VTSClient.Core.Models
{
	public class VacationCoreModel : MvxViewModel
	{
		public Guid Id { get; set; }

		public DateTime Start { get; set; }

		public DateTime End { get; set; }

		public DateTime CreateDate { get; set; }

		public string CreatedBy { get; set; }

		public VacationStatus VacationStatus { get; set; }

		private VacationType _vacationType = DAL.Enums.VacationType.Regular;

		public VacationType VacationType
		{
			get { return _vacationType; }
			set
			{
				_vacationType = value;
				RaisePropertyChanged(() => VacationType);
			}
		}

		public virtual string Period => $"{Start.Date:d} - {End.Date:d}";

		private IMvxCommand _detailCommand;

		public IMvxCommand DetailCommand => _detailCommand ??
		                                    (_detailCommand = new MvxCommand(
			                                    () =>
			                                    {
				                                    ShowViewModel<DetailViewModel>(new VacationData
				                                    {
					                                    Id = Id
				                                    });
			                                    }));
	}
}
