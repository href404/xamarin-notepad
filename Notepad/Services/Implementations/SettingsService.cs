using Notepad.Controleurs.Interfaces;
using Xamarin.Forms;

namespace Notepad.Controleurs.Implementations
{
    public class SettingsService : ISettingsService
    {
        private const string CHARGEMENT_NOTE_AU_DEMARRAGE = "Load";
        private const string SAUVEGARDE_NOTE_SUR_FERMETURE = "Save";

        public bool HasNotesLoadedOnStart()
        {
            if (!Application.Current.Properties.ContainsKey(CHARGEMENT_NOTE_AU_DEMARRAGE))
                return false;

            return (bool)Application.Current.Properties[CHARGEMENT_NOTE_AU_DEMARRAGE];
        }

        public bool HasNotesSavedOnClose()
        {
            if (!Application.Current.Properties.ContainsKey(SAUVEGARDE_NOTE_SUR_FERMETURE))
                return false;

            return (bool)Application.Current.Properties[SAUVEGARDE_NOTE_SUR_FERMETURE];
        }

        public void SetNotesLoadedOnStart(bool estNoteChargeeAuDemarrage)
        {
            Application.Current.Properties[CHARGEMENT_NOTE_AU_DEMARRAGE] = estNoteChargeeAuDemarrage;
        }

        public void SetNotesSavedOnClose(bool estNoteSauvegardeeSurFermeture)
        {
            Application.Current.Properties[SAUVEGARDE_NOTE_SUR_FERMETURE] = estNoteSauvegardeeSurFermeture;
        }
    }
}
