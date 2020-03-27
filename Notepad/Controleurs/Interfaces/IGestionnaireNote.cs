using Notepad.Modeles;

namespace Notepad.Controleurs.Interfaces
{
    interface IGestionnaireNote
    {
        void SauvegarderNote();
        void SupprimerNote();
        void ChargerNote();
        NoteModele[] ObtenirNotes();
    }
}
