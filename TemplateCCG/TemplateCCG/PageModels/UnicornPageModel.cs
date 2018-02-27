using System;
using System.Collections.Generic;
using System.Text;
using FreshMvvm;
using TemplateCCG.Core;

namespace TemplateCCG.PageModels
{
	public class UnicornPageModel : PageModelBase
	{
		public string ImagePath { get; private set; }

		public override void Init(object initData)
		{
			base.Init(initData);

			var imagePath = initData as string;

			if (string.IsNullOrWhiteSpace(imagePath))
			{
				CoreMethods.DisplayAlert("Error!", "Not an image path!", "OK");
				return;
			}

			ImagePath = imagePath;
			
		}
	}
}
