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

        private void SurAppuiSauvegarder(object sender, EventArgs e) { GestionnaireNote.SauvegarderNote(); }
        private void SurAppuiSupprimer(object sender, EventArgs e) { GestionnaireNote.SupprimerNote(); }

        #endregion

    }
}