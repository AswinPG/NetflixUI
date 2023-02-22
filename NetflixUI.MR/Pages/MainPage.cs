using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiReactor;
using MauiReactor.Shapes;
using NetflixUI.MR.Services;

namespace NetflixUI.MR.Pages;

class MainPageState
{
    public int Counter { get; set; }
    public List<string> MoviesList { get; set; }
    public MainPageState()
    {
        MoviesList = new List<string>()
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

class MainPage : Component<MainPageState>
{
    MauiControls.Border TopBackBar;
    public override VisualNode Render()
    {
        return new ContentPage
        {
            new Grid("70,*", "*")
            {
                new ScrollView()
                {
                    new Grid("70,510,*", "*")
                    {
                        new Image("spidermanwide.png")
                            .Aspect(Aspect.AspectFill)
                            .GridRowSpan(2),

                        new BoxView()
                            .GridRowSpan(2)
                            .HFill()
                            .VFill()
                            .Opacity(.5)
                            .Color(Colors.Transparent)
                            .Background(new MauiControls.LinearGradientBrush(
                                new MauiControls.GradientStopCollection()
                                {
                                    new MauiControls.GradientStop(Colors.Transparent,0.0f),
                                    new MauiControls.GradientStop(Colors.Transparent,0.25f),
                                    new MauiControls.GradientStop(Colors.Transparent,0.5f),
                                    new MauiControls.GradientStop(Colors.Black,0.95f),
                                    new MauiControls.GradientStop(Colors.Black,1f),
                                },
                                new Point(1,0),
                                new Point(1,1))),

                        new Grid("*","*,*,*")
                        {
                            new Label("TV Shows")
                                .FontFamily("Bold")
                                .FontSize(16),
                            new Label("Movies")
                                .FontFamily("Bold")
                                .FontSize(16)
                                .GridColumn(1),
                            new Label()
                                .FontFamily("Bold")
                                .FontSize(16)
                                .GridColumn(2)
                                .FormattedText(GetCategoriesFormattedString())

                        }
                        .HCenter()
                        .VStart()
                        .ColumnSpacing(25)
                        .Padding(10,28,10,10)
                        .GridRow(1),

                        new VerticalStackLayout()
                        {
                            new HorizontalStackLayout()
                            {
                                new Image("logo")
                                    .HeightRequest(20),
                                new Label("MOVIE")
                                    .CharacterSpacing(3)
                                    .FontFamily("Bold")
                                    .TextColor(Colors.LightGray),
                            }
                            .HCenter()
                            .Spacing(6),
                            new Label("SPIDER MAN")
                                .HCenter()
                                .TextColor(Colors.White)
                                .FontFamily("Bold")
                                .FontSize(40),
                            new Label("Slick . Psychological . Thriller . Love . Obsession . US . Dark")
                                .HCenter()
                                .FontSize(10),
                            new Grid("Auto,Auto", "*,*,*")
                            {
                                new Image()
                                    .HeightRequest(20)
                                    .Source(new MauiControls.FontImageSource()
                                    {
                                        FontFamily = "MaterialIcons",
                                        Glyph = IconFont.Check
                                    }),
                                new Label("My List")
                                    .GridRow(1)
                                    .FontSize(8)
                                    .HorizontalTextAlignment(TextAlignment.Center),
                                new Button("Play")
                                    .GridRowSpan(2)
                                    .GridColumn(1)
                                    .Padding(20,0)
                                    .Background(Colors.White)
                                    .CornerRadius(4)
                                    .HeightRequest(35)
                                    .FontFamily("Bold")
                                    .FontSize(12)
                                    .TextColor(Colors.Black)
                                    .VCenter()
                                    .ImageSource(new MauiControls.FontImageSource()
                                    {
                                        FontFamily = "MaterialIcons",
                                        Glyph = IconFont.Play_arrow,
                                        Size = 15,
                                        Color = Colors.Black
                                    }),
                                new Image()
                                {

                                }
                                .GridColumn(2)
                                .HeightRequest(20)
                                .Source(new MauiControls.FontImageSource()
                                {
                                    FontFamily = "MaterialIcons",
                                    Glyph = IconFont.Info_outline
                                }),
                                 new Label("Info")
                                    .GridRow(1)
                                    .GridColumn(2)
                                    .FontSize(8)
                                    .HorizontalTextAlignment(TextAlignment.Center),
                            }
                            .ColumnSpacing(30)
                            .RowSpacing(6)
                            .Padding(25,10)
                            .HFill()

                        }
                        .VEnd()
                        .GridRow(1),
                        new VerticalStackLayout()
                        {
                            new Label("Because you watched The Good Doctor")
                                .Padding(10)
                                .FontFamily("Bold"),
                            new CollectionView()
                                .HeightRequest(160)
                                .ItemsLayout(new HorizontalLinearItemsLayout())
                                .ItemsSource(State.MoviesList,MovieTemplate),
                            new Label("Continue Watching for Aswin")
                                .Padding(10)
                                .FontFamily("Bold"),
                            new CollectionView()
                                .HeightRequest(160)
                                .ItemsLayout(new HorizontalLinearItemsLayout())
                                .ItemsSource(State.MoviesList,MovieTemplate)

                        }
                        .GridRow(2)




                    }
                }
                .GridRowSpan(2)
                .Margin(0,-28,0,0)
                .VerticalScrollBarVisibility(ScrollBarVisibility.Never),
                new Border(border => TopBackBar = border)
                    .Margin(0,-28,0,0)
                    .Background(Colors.Black)
                    .Opacity(.3),
                new Image("logo")
                    .HeightRequest(40)
                    .HStart()
                    .Margin(20,0,0,0),
                new Image()
                    .Margin(10,0,70,0)
                    .HeightRequest(30)
                    .HEnd()
                    .Source(new MauiControls.FontImageSource()
                    {
                        FontFamily = "MaterialIcons",
                        Glyph = IconFont.Search
                    }),
                new Image("beastposter")
                    .Aspect(Aspect.AspectFill)
                    .HeightRequest(30)
                    .WidthRequest(30)
                    .HEnd()
                    .Margin(0,0,20,0)
                    .Clip(new RoundRectangleGeometry()
                              .CornerRadius(5)
                              .Rect(new Rect(0,0,30,30)))
            }
            .Padding(0,28,0,0)
        };
    }


    MauiControls.FormattedString GetCategoriesFormattedString()
    {
        MauiControls.FormattedString formattedString = new MauiControls.FormattedString();
        formattedString.Spans.Add(new MauiControls.Span
        {
            Text = "Categories",
            FontFamily = "Bold",
            FontSize = 16,
        });
        formattedString.Spans.Add(new MauiControls.Span
        {
            Text = IconFont.Arrow_drop_down,
            FontFamily = "MaterialIcons",
            FontSize = 16,
        });
        return formattedString;
    }

    VisualNode MovieTemplate(string data)
    {
        return new Grid()
        {
            new Image()
                .Source(data)
                .Aspect(Aspect.AspectFill)
                .BackgroundColor(Colors.Transparent)
                .HeightRequest(160)
                .WidthRequest(106)
                .Clip(new RoundRectangleGeometry()
                        .CornerRadius(8)
                        .Rect(new Rect(0,0,106,160)))
        }
        .Padding(5, 0);
    }
}
