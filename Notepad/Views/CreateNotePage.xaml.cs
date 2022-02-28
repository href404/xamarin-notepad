using Notepad.Models;
using Notepad.Services;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notepad.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateNotePage : ContentPage
    {
        private readonly Note note;
        private readonly INoteService noteService;

        public CreateNotePage(INoteService noteService)
        {
            InitializeComponent();
            this.noteService = noteService;
            note = new Note();
            BindingContext = note;
        }

        private async void OnCreateNoteClicked(object sender, EventArgs e)
        {
            noteService.Save(note);
            await Navigation.PopModalAsync();
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            if (await DisplayAlert(
                "Annuler", 
                "Êtes-vous sur de vouloir annuler la création de votre note ?", 
                "Non", 
                "Oui"))
                noteService.Delete(note);

            await Navigation.PopModalAsync();
        }
    }
}