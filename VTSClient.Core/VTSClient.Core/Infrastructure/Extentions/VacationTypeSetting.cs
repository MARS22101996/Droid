using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTSClient.DAL.Enums;

namespace VTSClient.Core.Infrastructure.Extentions
{
	public static class VacationTypeSetting
	{
		public static VacationType GetType(int position)
		{
			switch (position)
			{
				case 0:
					return VacationType.Undefined;
				case 1:
					return VacationType.Regular;
				case 2:
					return VacationType.Sick;
				case 3:
					return VacationType.Exceptional;
				case 4:
					return VacationType.LeaveWithoutPay;
				default:
					return VacationType.Overtime;
			}
		}
	}
}
