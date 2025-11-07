using BlazorCurseach.Models;

namespace BlazorCurseach.Interfaces;

    public interface IClient
    {
        public List<Client> GetUserDetails();
        public Client GetClietnData(int idClient);
    }