
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
        user.Email = TextFixed.FixedEmail(register.Email);
        user.CreateDate = DateTime.Now;
        user.Password = Hashing.EncodePasswordMd5(register.Password);

        _db.Add(user);
        _db.SaveChanges();

        return true;
    }

    public bool IsEmailExsit(string email)
    {
        return _db.Users.Any(u => u.Email == email);
    }

    public User LoginUser(LoginDTO login)
    {
        string email = TextFixed.FixedEmail(login.Email);
        string pass = Hashing.EncodePasswordMd5(login.Password);
        return _db.Users.SingleOrDefault(u=>u.Email == email && u.Password == pass);
    }
    #endregion



}
