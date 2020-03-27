using Notepad.Controleurs.Interfaces;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notepad.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParametrePage : ContentPage
    {

        #region Variables

        private readonly IGestionnaireParametre GestionnaireParametre;

        #endregion

        #region Constructeur

        public ParametrePage(IGestionnaireParametre gestionnaireParametre)
        {
            InitializeComponent();
            GestionnaireParametre = gestionnaireParametre;

            ChargementNoteDemarrage.IsToggled = GestionnaireParametre.ObtenirChargementNoteAuDemarrage();
            SauvegardeNoteFermeture.IsToggled = GestionnaireParametre.ObtenirSauvegarderNoteSurFermeture();
        }

        #endregion

        #region Evenements

        private async void SurAppuiAnnuler(object sender, EventArgs e) { await Navigation.PopModalAsync(); }

        private async void SurAppuiEnregistrer(object sender, EventArgs e)
        {
            GestionnaireParametre.DefinirChargementNoteAuDemarrage(ChargementNoteDemarrage.IsToggled);
            GestionnaireParametre.DefinirSauvegarderNoteSurFermeture(SauvegardeNoteFermeture.IsToggled);
            await Navigation.PopModalAsync();
        }

        #endregion

    }
}