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
        async void OnButtonClicked(object sender, EventArgs e)
        {
            {
                var note = (Mood)BindingContext;
                note.Date = DateTime.UtcNow;
                await App.Database.SaveNoteAsync(note);
                await Navigation.PopAsync();
            }
            async void OnDeleteButtonClicked(object sender, EventArgs e)
            {
                var note = (Mood)BindingContext;
                await App.Database.DeleteNoteAsync(note);
                await Navigation.PopAsync();
            }

        }
    }
}
