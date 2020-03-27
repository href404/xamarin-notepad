using Notepad.Modeles;

namespace Notepad.Controleurs.Interfaces
{
    public interface IGestionnaireNote
    {
        void SauvegarderNote(NoteModele note);
        void SupprimerNote(NoteModele note);
        void ChargerNote(NoteModele note);
        NoteModele[] ObtenirNotes();
    }
}
