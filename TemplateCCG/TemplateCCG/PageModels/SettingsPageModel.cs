using System;
using System.Collections.Generic;
using System.Text;
using FreshMvvm;
using TemplateCCG.Core;
using Xamarin.Forms;

namespace TemplateCCG.PageModels
{
	public class SettingsPageModel : PageModelBase
	{
		public string UnicornText
		{
			get
			{
				return "unicorn!";
			}
		}

		public Command ShowUnicornCommand
		{
			get
			{
				return new Command(() => {
					CoreMethods.PushPageModel<UnicornPageModel>("https://drawinglics.com/view/1697018/efficient-image-resizing-with-imagemagick-smashing-magazine-two-images-of-an-old-woman-the-second-full-of-image-rendering-artifacts.jpg", true);
				});
			}
		}
	}
}
