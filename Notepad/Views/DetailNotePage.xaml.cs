using Notepad.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Notepad.Services;

namespace Notepad.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailNotePage : ContentPage
    {
        private readonly Note note;
        private readonly INoteService noteService;

        public DetailNotePage(INoteService noteService, Note note)
        {
            InitializeComponent();
            this.noteService = noteService;
            this.note = note;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            noteService.Load(note);
            BindingContext = note;
        }

        private async void OnSaveClicked(object sender, EventArgs e) 
        { 
            noteService.Save(note);
            await Navigation.PopModalAsync();
        }

        private async void OnDeleteClicked(object sender, EventArgs e) 
        {
            if (await DisplayAlert(
                "Suppression", 
                "Êtes-vous sur de vouloir supprimer votre note ?", 
                "Oui", 
                "Non"))
                noteService.Delete(note);
            
            await Navigation.PopModalAsync();
        }
    }
}