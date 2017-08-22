using MvvmCross.Core.ViewModels;
using VTSClient.DAL.Enums;

namespace VTSClient.Core.ViewModels
{
	public class MenuViewModel : MvxViewModel
	{
		public MvxObservableCollection<SectionViewModel> Sections { get; set; } =
			new MvxObservableCollection<SectionViewModel>();

		private IMvxCommand _addCommand;

		public MenuViewModel()
		{
			AddSections();
		}

		private void AddSections()
		{
			Sections.Add(new SectionViewModel { NameStatus = FilterEnum.All });

			Sections.Add(new SectionViewModel { NameStatus = FilterEnum.Opened });

			Sections.Add(new SectionViewModel { NameStatus = FilterEnum.Closed });
		}

		public IMvxCommand AddCommand => _addCommand ??
								   (_addCommand = new MvxCommand(
									   () =>
									   {
										   ShowViewModel<DetailViewModel>();
									   }));
	}
}
