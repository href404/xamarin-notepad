namespace Notepad.Controleurs.Interfaces
{
    public interface ISettingsService
    {
        bool HasNotesSavedOnClose();
        bool HasNotesLoadedOnStart();
        void SetNotesLoadedOnStart(bool hasNotesLoadedOnStart);
        void SetNotesSavedOnClose(bool hasNotesSavedOnClose);
    }
}
