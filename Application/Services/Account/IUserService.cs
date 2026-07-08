
using DataLayer.Entites.Account;
using Domain.Account;
namespace Application.Services.Account;

public interface IUserService
{
    #region Account

    bool CreateUser(RegisterDTO register);
    bool IsEmailExsit(string email);
    User LoginUser(LoginDTO login);
    bool EditUserProfile(EditProfileDTO editProfile);
    #endregion

}
