using NetflixUI.ViewModels;

namespace NetflixUI.Views;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
    {

    }
}