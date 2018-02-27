using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using TemplateCCG.Helpers;
using TemplateCCG.PageModels;
using Xamarin.Forms;

namespace TemplateCCG.Navigation
{
	public class CustomNavigation : Xamarin.Forms.MasterDetailPage, IFreshNavigationService
	{
		FreshTabbedNavigationContainer _tabbedNavigationPage;
		Page _HomePage, _rankingPage,_settingsPage;

		public CustomNavigation()
		{
			NavigationServiceName = "CustomNav";
			SetupTabbedPage();
			CreateMenuPage("Menu");
			RegisterNavigation();
		}

		void SetupTabbedPage()
		{
			_tabbedNavigationPage = new FreshTabbedNavigationContainer();

			_HomePage = _tabbedNavigationPage.AddTab<HomePageModel>("Home", null);
			_rankingPage = _tabbedNavigationPage.AddTab<RankingPageModel>("Ranking!", null);
			_settingsPage = _tabbedNavigationPage.AddTab<SettingsPageModel>("Settings", null);
			this.Detail = _tabbedNavigationPage;
		}

		protected void RegisterNavigation()
		{
			FreshIOC.Container.Register<IFreshNavigationService>(this, NavigationServiceName);
		}

		protected void CreateMenuPage(string menuPageTitle)
		{
			var _menuPage = new ContentPage();
			_menuPage.Title = menuPageTitle;
			var listView = new ListView();

			listView.ItemsSource = new string[] { "Home", "Ranking", "Settings" };

			listView.ItemSelected += async (sender, args) =>
			{

				switch ((string)args.SelectedItem)
				{
					case "Home":
						_tabbedNavigationPage.CurrentPage = _HomePage;
						break;
					case "Ranking":
						_tabbedNavigationPage.CurrentPage = _rankingPage;
						break;
					case "Settings":
						_tabbedNavigationPage.CurrentPage = _settingsPage;
						break;
					default:
						break;
				}

				IsPresented = false;
			};

			_menuPage.Content = listView;

			Master = new NavigationPage(_menuPage) { Title = "Menu" };
		}

		public virtual async Task PushPage(Xamarin.Forms.Page page, FreshBasePageModel model, bool modal = false, bool animated = true)
		{
			if (modal)
				await Navigation.PushModalAsync(new NavigationPage(page), animated);
			else
				await ((NavigationPage)_tabbedNavigationPage.CurrentPage).PushAsync(page, animated);
		}

		public virtual async Task PopPage(bool modal = false, bool animate = true)
		{
			if (modal)
				await Navigation.PopModalAsync();
			else
				await ((NavigationPage)_tabbedNavigationPage.CurrentPage).PopAsync();
		}

		public virtual async Task PopToRoot(bool animate = true)
		{
			await ((NavigationPage)_tabbedNavigationPage.CurrentPage).PopToRootAsync(animate);
		}

		public string NavigationServiceName { get; private set; }

		public void NotifyChildrenPageWasPopped()
		{
			if (Master is NavigationPage)
				((NavigationPage)Master).NotifyAllChildrenPopped();
			foreach (var page in _tabbedNavigationPage.Children)
			{
				if (page is NavigationPage)
					((NavigationPage)page).NotifyAllChildrenPopped();
			}
		}

		public Task<FreshBasePageModel> SwitchSelectedRootPageModel<T>() where T : FreshBasePageModel
		{
			if (_HomePage.GetModel().GetType().FullName == typeof(T).FullName)
			{
				_tabbedNavigationPage.CurrentPage = _HomePage;
				return Task.FromResult(_HomePage.GetModel());
			}

			if (_rankingPage.GetModel().GetType().FullName == typeof(T).FullName)
			{
				_tabbedNavigationPage.CurrentPage = _rankingPage;
				return Task.FromResult(_rankingPage.GetModel());
			}

			throw new Exception("Cannot do this");
		}
	}
}
