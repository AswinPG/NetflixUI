using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using NetflixUI.ViewModels;
using NetflixUI.Views;

namespace NetflixUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureLifecycleEvents(events =>
            {
#if ANDROID
                events.AddAndroid(android => android.OnCreate((activity, bundle) => MakeStatusBarTranslucent(activity)));

                static void MakeStatusBarTranslucent(Android.App.Activity activity)
                {
                    activity.Window.SetFlags(Android.Views.WindowManagerFlags.LayoutNoLimits, Android.Views.WindowManagerFlags.LayoutNoLimits);

                    activity.Window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);

                    activity.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
                }
#endif
            })
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("MartelSans-Bold.ttf", "Bold");
				fonts.AddFont("MartelSans-Regular.ttf", "Regular");
				fonts.AddFont("MartelSans-Light.ttf", "Light");
				fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcons");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		AddServices(builder.Services);
		return builder.Build();
	}

	static void AddServices(IServiceCollection services)
	{
		services.AddSingleton<HomePage>();
		services.AddSingleton<HomePageViewModel>();
	}
}
