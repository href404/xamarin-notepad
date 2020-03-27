using Notepad.Controleurs.Implementations;
using Notepad.Controleurs.Interfaces;
using Notepad.Modeles;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notepad.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListeNotesPage : ContentPage
    {

        #region Variables

        private readonly IGestionnaireParametre GestionnaireParametre;
        private readonly IGestionnaireNote GestionnaireNote;

        #endregion

        #region Constructeur

        public ListeNotesPage() 
        { 
            InitializeComponent();
            GestionnaireParametre = new GestionnaireParametre();
            GestionnaireNote = new GestionnaireNote(GestionnaireParametre);
        }

        #endregion

        #region Implémentation ContentPage

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ListeNotes.ItemsSource = GestionnaireNote.ObtenirNotes();
        }

        #endregion

        #region Evenements

        private async void SurElementListeNoteSelectionnee(object sender, SelectedItemChangedEventArgs e)
        {
            ListView notes = sender as ListView;
            NoteModele note = notes.SelectedItem as NoteModele;
            await Navigation.PushModalAsync(new NotePage(GestionnaireNote, note));
        }

        private async void SurAppuiParametres(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ParametrePage(GestionnaireParametre));
        }
        private async void SurAppuiNouvelleNote(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CreationNotePage(GestionnaireNote));
        }

        #endregion

    }
}