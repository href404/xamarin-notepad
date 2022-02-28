using Notepad.Services.Implementations;
using Notepad.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Notepad.Services;

namespace Notepad.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {
        private readonly ISettingsService settingsService;
        private readonly INoteService noteService;

        public NotesPage() 
        { 
            InitializeComponent();
            settingsService = new SettingsService();
            noteService = new NoteService(settingsService);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ListeNotes.ItemsSource = noteService.Get();
        }

        private async void OnNotesSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView notes = sender as ListView;
            Note note = notes.SelectedItem as Note;
            await Navigation.PushModalAsync(new DetailNotePage(noteService, note));
        }

        private async void OnSettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SettingsPage(settingsService));
        }
        private async void OnNewNoteClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CreateNotePage(noteService));
        }
    }
}