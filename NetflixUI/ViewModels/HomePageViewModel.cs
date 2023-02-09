using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace NetflixUI.ViewModels
{
    
    public partial class HomePageViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<string> moviesList;
        public HomePageViewModel()
        {
            MoviesList = new ObservableCollection<string>()
            {
                "beastposter",
                "beautyandthebeast",
                "gothamposter",
                "minnalmuraliposter",
                "spidermanposter",
                "wednesdayposter",
                "youposter",
            };
        }
    }
}
