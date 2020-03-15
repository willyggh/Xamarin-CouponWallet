using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CouponWallet
{
    public class MainPage : ContentPage
    {
        Label infoLabel;
        Entry input;
        Button searchButton;

        public MainPage()
        {
            BackgroundColor = Color.PowderBlue;

            infoLabel = new Label
            {
                FontSize = 20,
                Margin = new Thickness(10)
            };

            input = new Entry
            {
                Placeholder = "Enter Text",
                BackgroundColor = Color.White,
                Margin = new Thickness(10)
            };

            searchButton = new Button
            {
                Text = "Search",
                TextColor = Color.White,
                BackgroundColor = Color.Green,
                Margin = new Thickness(10),
                CornerRadius = 5
            };
            searchButton.Clicked += SearchButton_Clicked;

            var grid = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                },
                RowDefinitions = 
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                }
            };

            grid.Children.Add(infoLabel, 0, 0);
            grid.Children.Add(input, 0, 1);
            grid.Children.Add(searchButton, 0, 2);

            Content = grid;
        }

        private void SearchButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(input.Text))
            {
                infoLabel.Text = input.Text;
                input.Text = string.Empty; 
            }
        }
    }
}
