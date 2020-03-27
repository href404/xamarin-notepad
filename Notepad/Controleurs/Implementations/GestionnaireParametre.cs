using Notepad.Controleurs.Interfaces;
using Xamarin.Forms;

namespace Notepad.Controleurs.Implementations
{
    public class GestionnaireParametre : IGestionnaireParametre
    {
        #region Constantes

        private const string CHARGEMENT_NOTE_AU_DEMARRAGE = "ChargementNoteAuDemarrage";
        private const string SAUVEGARDE_NOTE_SUR_FERMETURE = "SauvegardeNoteSurFermeture";

        #endregion

        #region Implémentation IGestionnaireParametre

        public bool ObtenirChargementNoteAuDemarrage()
        {
            if (!Application.Current.Properties.ContainsKey(CHARGEMENT_NOTE_AU_DEMARRAGE))
                return false;

            return (bool)Application.Current.Properties[CHARGEMENT_NOTE_AU_DEMARRAGE];
        }

        public bool ObtenirSauvegarderNoteSurFermeture()
        {
            if (!Application.Current.Properties.ContainsKey(SAUVEGARDE_NOTE_SUR_FERMETURE))
                return false;

            return (bool)Application.Current.Properties[SAUVEGARDE_NOTE_SUR_FERMETURE];
        }

        public void DefinirChargementNoteAuDemarrage(bool estNoteChargeeAuDemarrage)
        {
            Application.Current.Properties[CHARGEMENT_NOTE_AU_DEMARRAGE] = estNoteChargeeAuDemarrage;
        }

        public void DefinirSauvegarderNoteSurFermeture(bool estNoteSauvegardeeSurFermeture)
        {
            Application.Current.Properties[SAUVEGARDE_NOTE_SUR_FERMETURE] = estNoteSauvegardeeSurFermeture;
        }

        #endregion

    }
}
