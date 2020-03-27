using Notepad.Controleurs.Interfaces;
using Notepad.Modeles;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notepad.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotePage : ContentPage
    {

        #region Variables

        private readonly NoteModele Note;
        private readonly IGestionnaireNote GestionnaireNote;
        
        #endregion

        #region Constructeur

        public NotePage(IGestionnaireNote gestionnaireNote, NoteModele note)
        {
            InitializeComponent();
            GestionnaireNote = gestionnaireNote;
            Note = note;
        }

        #endregion

        #region Implémentation ContentPage

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GestionnaireNote.ChargerNote(Note);
            BindingContext = Note;
        }

        #endregion

        #region Evenements

        private async void SurAppuiSauvegarder(object sender, EventArgs e) 
        { 
            GestionnaireNote.SauvegarderNote(Note);
            await Navigation.PopModalAsync();
        }

        private async void SurAppuiSupprimer(object sender, EventArgs e) 
        {
            if (await DisplayAlert("Suppression", "Êtes-vous sur de vouloir supprimer votre note ?", "Oui", "Non"))
                GestionnaireNote.SupprimerNote(Note); 
        }

        #endregion

    }
}