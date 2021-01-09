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
            BindingContext = this;
        }

        public string ExcitedPercent { get; set; }
        public string HappyPercent { get; set; }
        public string IndifferPercent { get; set; }
        public string SadPercent { get; set; }
       public string ExtraSadPercent { get; set; }

        async void UpdatePercents()
        {
            if (App.Database == null) return;

            var data = await App.Database.GetMoodAsync();

            if (data == null) return;

            var total = data.Count;

            var excited = data.Where<Mood.Mood>(mood => mood.Response == 5).Count();
            var happy = data.Where<Mood.Mood>(mood => mood.Response == 4).Count();
            var indiffer = data.Where<Mood.Mood>(mood => mood.Response == 3).Count();
            var sad = data.Where<Mood.Mood>(mood => mood.Response == 2).Count();
            var extraSad = data.Where<Mood.Mood>(mood => mood.Response == 1).Count();

            ExcitedPercent = $"{Math.Round((excited * 100.0) / total)}%";
            HappyPercent = $"{Math.Round((happy * 100.0) / total)}%";
            IndifferPercent = $"{Math.Round((indiffer * 100.0) / total)}%";
            SadPercent = $"{Math.Round((sad * 100.0) / total)}%";
            ExtraSadPercent = $"{Math.Round((extraSad * 100.0) / total)}%";

            OnPropertyChanged(nameof(ExcitedPercent));
            OnPropertyChanged(nameof(HappyPercent));
            OnPropertyChanged(nameof(IndifferPercent));
            OnPropertyChanged(nameof(SadPercent));
            OnPropertyChanged(nameof(ExtraSadPercent));
        } 
        async void OnExcitedButtonClicked(object sender, EventArgs e)
        {
            var mood = new Mood.Mood
            {
                Date = DateTime.UtcNow,
                Response = 5
            };
            
            await App.Database.SaveMoodAsync(mood);
            UpdatePercents();  
        }
        async void OnHappyButtonClicked(object sender, EventArgs e)
        {
            var mood = new Mood.Mood
            {
                Date = DateTime.UtcNow,
                Response = 4
            };

            await App.Database.SaveMoodAsync(mood);
            UpdatePercents();
        }
        async void OnIndifferButtonClicked(object sender, EventArgs e)
        {
            var mood = new Mood.Mood
            {
                Date = DateTime.UtcNow,
                Response = 3
            };

            await App.Database.SaveMoodAsync(mood);
            UpdatePercents();
        }
        async void OnSadButtonClicked(object sender, EventArgs e)
        {
            var mood = new Mood.Mood
            {
                Date = DateTime.UtcNow,
                Response = 2
            };

            await App.Database.SaveMoodAsync(mood);
            UpdatePercents();
        }
        async void OnExtraSadButtonClicked(object sender, EventArgs e)
        {
            var mood = new Mood.Mood
            {
                Date = DateTime.UtcNow,
                Response = 1
            };

            await App.Database.SaveMoodAsync(mood);
            UpdatePercents();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var mood = (Mood.Mood)BindingContext;
            await App.Database.DeleteMoodAsync(mood);
            UpdatePercents(); 
        }
    }
}
