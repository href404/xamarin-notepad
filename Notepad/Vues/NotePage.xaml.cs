using Notepad.Controleurs.Implementations;
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
        private readonly IGestionnaireParametre GestionnaireParametre;
        
        #endregion

        #region Constructeur

        public NotePage()
        {
            InitializeComponent();
            
            Note = new NoteModele();
            GestionnaireParametre = new GestionnaireParametre();
            GestionnaireNote = new GestionnaireNote(Note, GestionnaireParametre);
            GestionnaireNote.ChargerNote();
            BindingContext = Note;
        }

        #endregion

        #region Evenements

        private void SurAppuiSauvegarder(object sender, EventArgs e) 
        { 
            GestionnaireNote.SauvegarderNote();
            DisplayAlert("Sauvgarde", "Votre note a bien été enregistrée", "OK");
        }

        private async void SurAppuiSupprimer(object sender, EventArgs e) 
        {
            if (await DisplayAlert("Suppression", "Êtes-vous sur de vouloir supprimer votre note ?", "Oui", "Non"))
                GestionnaireNote.SupprimerNote(); 
        }

        private async void SurAppuiParametres(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ParametrePage(GestionnaireParametre));
        }

        #endregion

    }
}