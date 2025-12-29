namespace BlazorCurseach.Interfaces;

    public interface ICrudService<T>
    {
        public Task CreateAsync(T parameter);
        //public Task<T?> ReadAsync(int id);
        public Task UpdateAsync(T parameter);
        public Task DeleteAsync(T parameter);
    }