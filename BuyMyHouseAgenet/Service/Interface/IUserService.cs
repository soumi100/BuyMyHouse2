using BuyMyHouseAgenet.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouseAgenet.Service.Interface
{
    public interface IUserService
    {
        AuthenticateResponseDTO Authenticate(AuthenticateRequestDTO model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Register(RegisterRequestDTO model);
        void Delete(int id);
    }
}
