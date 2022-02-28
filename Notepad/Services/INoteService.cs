using Notepad.Modeles;

namespace Notepad.Controleurs.Interfaces
{
    public interface INoteService
    {
        void Save(Note note);
        void Delete(Note note);
        void Load(Note note);
        Note[] Get();
    }
}
