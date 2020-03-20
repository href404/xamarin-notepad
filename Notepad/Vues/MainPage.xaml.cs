using Notepad.Implementations;
using Notepad.Interfaces;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notepad.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        #region Variables

        private readonly IGestionnaireNote GestionnaireNote;

        #endregion

        #region Implémentation ContentPage

        public MainPage()
        {
            InitializeComponent();

            GestionnaireNote = new GestionnaireNote(ZoneTextuel);
            GestionnaireNote.ChargerNote();
        }

        #endregion

        #region Evenements

        private void SurAppuiSauvegarder(object sender, EventArgs e) { 
            GestionnaireNote.SauvegarderNote();
            DisplayAlert("Sauvgarde", "Votre note a bien été enregistrée", "OK");
        }

        private async void SurAppuiSupprimer(object sender, EventArgs e) {
            if (await DisplayAlert("Suppression", "Êtes-vous sur de vouloir supprimer votre note ?", "Oui", "Non"))
                GestionnaireNote.SupprimerNote(); 
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ParametrePage());
        }

        #endregion

    }
}