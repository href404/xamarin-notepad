using Notepad.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notepad.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        private readonly ISettingsService settingsService;

        public SettingsPage(ISettingsService settingsService)
        {
            InitializeComponent();
            this.settingsService = settingsService;

            HasNotesLoadedOnStart.IsToggled = this.settingsService.HasNotesLoadedOnStart();
            HasNotesSavedOnClose.IsToggled = this.settingsService.HasNotesSavedOnClose();
        }

        private async void OnCancelClicked(object sender, EventArgs e) 
        { 
            await Navigation.PopModalAsync(); 
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            settingsService.SetNotesLoadedOnStart(HasNotesLoadedOnStart.IsToggled);
            settingsService.SetNotesSavedOnClose(HasNotesSavedOnClose.IsToggled);
            await Navigation.PopModalAsync();
        }
    }
}