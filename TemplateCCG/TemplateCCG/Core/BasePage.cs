using System;
using System.Collections.Generic;
using System.Text;

using TemplateCCG.Helpers;
using TemplateCCG.Pages;
using Xamarin.Forms;

namespace TemplateCCG.Core
{
	public class BasePage : ContentPage
	{
		public BasePage()
		{
			ToolbarItems.Add(new ToolbarItem("", "Home.png", () => {
				Application.Current.MainPage = new NavigationPage(new HomePage());
			}));
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			
		}
	}
}
