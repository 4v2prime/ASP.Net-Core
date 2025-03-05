using Core_APISendMail.Modal;
namespace Core_APISendMail.Services
{
    public interface IMailServices
    {
        Task<bool> SendEmailAsync(Email model);
    }
}
