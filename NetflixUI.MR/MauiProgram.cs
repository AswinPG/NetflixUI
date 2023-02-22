using MauiReactor;
using Microsoft.Maui.LifecycleEvents;
using NetflixUI.MR.Pages;


namespace NetflixUI.MR;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiReactorApp<MainPage>(app =>
            {
                app.AddResource("Resources/Styles/Colors.xaml");
                app.AddResource("Resources/Styles/Styles.xaml");

                app.SetWindowsSpecificAssectDirectory("Assets");
            })
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
#if DEBUG
            .EnableMauiReactorHotReload()
#endif
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("MartelSans-Bold.ttf", "Bold");
                fonts.AddFont("MartelSans-Regular.ttf", "Regular");
                fonts.AddFont("MartelSans-Light.ttf", "Light");
                fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcons");
            });

        return builder.Build();
    }
}
