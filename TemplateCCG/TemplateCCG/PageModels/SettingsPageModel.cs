using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using FreshMvvm;
using PropertyChanged;
using TemplateCCG.Core;
using TemplateCCG.Helpers;
using Xamarin.Forms;

namespace TemplateCCG.PageModels
{
	[AddINotifyPropertyChangedInterface]
	public class SettingsPageModel : PageModelBase
	{
		private bool isStatusBarTranslu = false;
		public SettingsPageModel()
		{
			LoadAnotherCommand = new Command((arg) =>
			{
				Reload();
			});
			MakeTranslucideBarCommand = new Command((arg) =>
			{
				StatusBarHelper.Instance.MakeTranslucentStatusBar(!isStatusBarTranslu);
				isStatusBarTranslu = !isStatusBarTranslu;
			});
		}

		public ICommand LoadAnotherCommand { get; set; }
		public ICommand MakeTranslucideBarCommand { get; set; }
		private string _randomSource = $"https://cdn.discordapp.com/attachments/290124294145703936/418369570395521024/unknown.png";
		public string ImageSourceText { get; set; }
		

		public void Reload()
		{
			RandomSource = "https://static.esea.net/global/images/teams/154810.1510586034.png";
		}

		public string RandomSource
		{
			get { return _randomSource; }
			set { _randomSource = value; }
		}



		

	}
}
