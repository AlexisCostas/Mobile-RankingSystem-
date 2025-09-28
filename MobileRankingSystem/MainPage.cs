using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;
using MobileRankingSystem.ViewModels;

namespace MobileRankingSystem;

public sealed class MainPage : ContentPage
{
    public MainPage()
    {
        Title = "Rankings";
        BindingContext = new RankingViewModel();
        var resources = Application.Current?.Resources ?? new ResourceDictionary();

        var header = new Label
        {
            Text = "Team Rankings",
            Style = (Style)resources["SectionHeader"],
            Margin = new Thickness(0, 24, 0, 8)
        };

        var collectionView = new CollectionView
        {
            ItemsSource = ((RankingViewModel)BindingContext).RankedTeams,
            ItemTemplate = new DataTemplate(() =>
            {
                var frame = new Frame
                {
                    Style = (Style)resources["RankingCard"],
                    Margin = new Thickness(0, 8)
                };

                var rankLabel = new Label
                {
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 20,
                    VerticalOptions = LayoutOptions.Center
                };
                rankLabel.SetBinding(Label.TextProperty, nameof(Models.TeamRanking.Rank));

                var teamLabel = new Label
                {
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 20,
                    VerticalOptions = LayoutOptions.Center
                };
                teamLabel.SetBinding(Label.TextProperty, nameof(Models.TeamRanking.TeamName));

                var summaryLabel = new Label { FontSize = 14 };
                summaryLabel.SetBinding(Label.TextProperty, nameof(Models.TeamRanking.Summary));

                var playersLabel = new Label
                {
                    FontSize = 12,
                    TextColor = (Color)resources["SecondaryTextColor"]
                };
                playersLabel.SetBinding(Label.TextProperty, nameof(Models.TeamRanking.PlayersSummary));

                frame.Content = new VerticalStackLayout
                {
                    Spacing = 8,
                    Children =
                    {
                        new HorizontalStackLayout
                        {
                            Spacing = 12,
                            Children = { rankLabel, teamLabel }
                        },
                        summaryLabel,
                        playersLabel
                    }
                };

                return frame;
            })
        };

        var improvementsHeader = new Label
        {
            Text = "Upcoming Improvements",
            Style = (Style)resources["SubsectionHeader"],
            Margin = new Thickness(0, 16, 0, 4)
        };

        var improvementsText = new Label
        {
            Text = "• Add persistent storage\n• Support manual match entry\n• Sync with cloud services",
            TextColor = (Color)resources["SecondaryTextColor"],
            FontSize = 14
        };

        Content = new ScrollView
        {
            Content = new VerticalStackLayout
            {
                Padding = new Thickness(24),
                Spacing = 16,
                Children =
                {
                    header,
                    collectionView,
                    improvementsHeader,
                    improvementsText
                }
            }
        };
    }
}
