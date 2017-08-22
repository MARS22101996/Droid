using System;
using MvvmCross.Core.ViewModels;
using VTSClient.DAL.Enums;


namespace VTSClient.BLL.Dto
{
	public class VacationDto : MvxViewModel
	{
		public Guid Id { get; set; }

		public DateTime Start { get; set; }

		public DateTime End { get; set; }

		public DateTime CreateDate { get; set; }

		public string CreatedBy { get; set; }

		public VacationStatus VacationStatus { get; set; }

		public VacationType VacationType { get; set; }

		public virtual string Period => $"{Start.Date:d} - {End.Date:d}";
	}
}
