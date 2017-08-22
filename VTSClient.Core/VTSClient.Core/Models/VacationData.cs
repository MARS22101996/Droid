using System;
using VTSClient.DAL.Enums;

namespace VTSClient.Core.Models
{
	public class VacationData
	{
		public Guid Id { get; set; }
		public FilterEnum VacationStatus { get; set; }
	}
}
