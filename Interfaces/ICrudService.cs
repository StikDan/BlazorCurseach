using BlazorCurseach.Models;

namespace BlazorCurseach.Interfaces;

    public interface ICrudService<T>
    {
        public Task CreateElementAsync(T parameter);
        public Task<T?> ReadElementAsync(int id);
        public Task UpdateElementAsync(T parameter);
        public Task DeleteElementAsync(int id);
    }