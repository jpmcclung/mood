using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Mood;


namespace mood
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            {
                var mood = (Mood.Mood)BindingContext;
                mood.Date = DateTime.UtcNow;
                await App.Database.SaveMoodAsync(mood);
                await Navigation.PopAsync();
            }
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var mood = (Mood.Mood)BindingContext;
            await App.Database.DeleteMoodAsync(mood);
            await Navigation.PopAsync();
        }
    }
}
