using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notepad.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParametrePage : ContentPage
    {

        private const string CHARGEMENT_NOTE_AU_DEMARRAGE = "ChargementNoteAuDemarrage";
        private const string SAUVEGARDE_NOTE_SUR_FERMETURE = "SauvegardeNoteSurFermeture";


        public ParametrePage()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey(CHARGEMENT_NOTE_AU_DEMARRAGE))
                ChargementNoteDemarrage.IsToggled = (bool) Application.Current.Properties[CHARGEMENT_NOTE_AU_DEMARRAGE];

            if (Application.Current.Properties.ContainsKey(SAUVEGARDE_NOTE_SUR_FERMETURE))
                SauvegardeNoteFermeture.IsToggled = (bool) Application.Current.Properties[SAUVEGARDE_NOTE_SUR_FERMETURE];
        }

        private async void SurAppuiAnnuler(object sender, EventArgs e) { await Navigation.PopModalAsync(); }

        private async void SurAppuiEnregistrer(object sender, EventArgs e)
        {
            Application.Current.Properties[CHARGEMENT_NOTE_AU_DEMARRAGE] = ChargementNoteDemarrage.IsToggled;
            Application.Current.Properties[SAUVEGARDE_NOTE_SUR_FERMETURE] = SauvegardeNoteFermeture.IsToggled;
            
            await Navigation.PopModalAsync();
        }
    }
}