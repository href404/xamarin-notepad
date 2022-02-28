namespace Notepad.Services
{
    public interface ISettingsService
    {
        bool HasNotesSavedOnClose();
        bool HasNotesLoadedOnStart();
        void SetNotesLoadedOnStart(bool hasNotesLoadedOnStart);
        void SetNotesSavedOnClose(bool hasNotesSavedOnClose);
    }
}
