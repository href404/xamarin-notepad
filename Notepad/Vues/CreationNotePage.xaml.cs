using Notepad.Controleurs.Interfaces;
using Notepad.Modeles;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notepad.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreationNotePage : ContentPage
    {

        #region Variables

        private readonly NoteModele Note;
        private readonly IGestionnaireNote GestionnaireNote;

        #endregion

        #region Constructeur

        public CreationNotePage(IGestionnaireNote gestionnaireNote)
        {
            InitializeComponent();
            GestionnaireNote = gestionnaireNote;
            Note = new NoteModele();
            BindingContext = Note;
        }

        #endregion


        #region Evenements

        private async void SurAppuiCreerNote(object sender, EventArgs e)
        {
            GestionnaireNote.SauvegarderNote(Note);
            await Navigation.PopModalAsync();
        }

        private async void SurAppuiAnnuler(object sender, EventArgs e)
        {
            if (await DisplayAlert("Annuler", "Êtes-vous sur de vouloir annuler la création de votre note ?", "Oui", "Non"))
                GestionnaireNote.SupprimerNote(Note);
        }

        #endregion

    }
}