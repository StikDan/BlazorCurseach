using BlazorCurseach.Models;

namespace BlazorCurseach.Interfaces;

    public interface IClient
    {
        public List<string> HandleClientData(string login, string password);
    }