using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using FFImageLoading.Forms.Droid;
using TemplateCCG.Helpers;
using Xamarin.Forms;

namespace TemplateCCG.Droid
{
    [Activity(Label = "TemplateCCG", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
	        CachedImageRenderer.Init(true);
	        InitMessageCenterSubscriptions();

			global::Xamarin.Forms.Forms.Init(this, bundle);
	       // FormsPlugin.Iconize.Droid.IconControls.Init(Resource.Id.toolbar, Resource.Id.tabMode);
			LoadApplication(new App());
        }

	    private void InitMessageCenterSubscriptions()
	    {
		    MessagingCenter.Instance.Subscribe<StatusBarHelper, bool>(this, StatusBarHelper.TranslucentStatusChangeMessage, OnTranslucentStatusRequest);
	    }

	    private void OnTranslucentStatusRequest(StatusBarHelper helper, bool makeTranslucent)
	    {
		    MakeStatusBarTranslucent(makeTranslucent);
	    }

	    private void MakeStatusBarTranslucent(bool makeTranslucent)
	    {
		    if (makeTranslucent)
		    {
			    SetStatusBarColor(Android.Graphics.Color.Transparent);

			    if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
			    {
				    Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(SystemUiFlags.LayoutFullscreen | SystemUiFlags.LayoutStable);
			    }
		    }
		    else
		    {
			    using (var value = new TypedValue())
			    {
				    if (Theme.ResolveAttribute(Resource.Attribute.colorPrimaryDark, value, true))
				    {
					    var color = new Android.Graphics.Color(value.Data);
					    SetStatusBarColor(color);
				    }
			    }

			    if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
			    {
				    Window.DecorView.SystemUiVisibility = StatusBarVisibility.Visible;
			    }
		    }
	    }
	}
}

