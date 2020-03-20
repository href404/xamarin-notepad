using Notepad.Controleurs.Interfaces;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notepad.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParametrePage : ContentPage
    {

        private readonly IGestionnaireParametre GestionnaireParametre;

        public ParametrePage(IGestionnaireParametre gestionnaireParametre)
        {
            InitializeComponent();
            GestionnaireParametre = gestionnaireParametre;

            ChargementNoteDemarrage.IsToggled = GestionnaireParametre.ObtenirChargementNoteAuDemarrage();
            SauvegardeNoteFermeture.IsToggled = GestionnaireParametre.ObtenirSauvegarderNoteSurFermeture();
        }

        private async void SurAppuiAnnuler(object sender, EventArgs e) { await Navigation.PopModalAsync(); }

        private async void SurAppuiEnregistrer(object sender, EventArgs e)
        {
            GestionnaireParametre.DefinirChargementNoteAuDemarrage(ChargementNoteDemarrage.IsToggled);
            GestionnaireParametre.DefinirSauvegarderNoteSurFermeture(SauvegardeNoteFermeture.IsToggled);
            await Navigation.PopModalAsync();
        }
    }
}