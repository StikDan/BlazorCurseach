using BlazorCurseach.Models;

namespace BlazorCurseach.Interfaces;

    public interface IClient
    {
        public List<Client> GetClientDetails();
        public Client GetClientData(int idClient);
    }