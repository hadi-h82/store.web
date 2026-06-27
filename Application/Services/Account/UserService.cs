
using Application.Tools;
using DataLayer.Contexts;
using DataLayer.Entites.Account;
using Domain.Account;

namespace Application.Services.Account;

public class UserService : IUserService
{



    #region Costructor

    private readonly DBContext _db;

    public UserService(DBContext dB)
    {
        _db = dB;
    }   

    #endregion




    #region Account

    public bool CreateUser(RegisterDTO register)
    {
        var user = new User();
        user.Email = register.Email;
        user.Password = Hashing.EncodePasswordMd5(register.Password);
        return true;
    }

    #endregion

}
