using Notepad.Models;

namespace Notepad.Services
{
    public interface INoteService
    {
        void Save(Note note);
        void Delete(Note note);
        void Load(Note note);
        Note[] Get();
    }
}
