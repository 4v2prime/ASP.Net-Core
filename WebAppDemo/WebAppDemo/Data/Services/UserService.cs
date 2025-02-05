using Microsoft.AspNetCore.Mvc;
using WebAppDemo.Data.Infrastructure;
using WebAppDemo.Data.Model;
using WebAppDemo.Data.Repository;

namespace WebAppDemo.Data.Services
{
    public interface IUserService
    {
        void SaveUser(UserRegistrationViewModel obj);
        List<tblUser> UserListData();
        tblUser GetById(int id);
        void UpdateById(UserRegistrationViewModel obj);
        void DeleteById(UserRegistrationViewModel obj);
    }
    public class UserService : IUserService
    {
        private readonly ItblUserRepository tblUserRepository;
        private readonly IUnitOfWork UnitOfWork;
        public UserService(ItblUserRepository tblUserRepository, IUnitOfWork unitOfWork)
        {
            this.tblUserRepository = tblUserRepository;
            this.UnitOfWork = unitOfWork;

        }
        public void SaveUser(UserRegistrationViewModel objData)
        {
            tblUserRepository.Add(objData.User);
            UnitOfWork.Commit();
        }
        public tblUser GetById(int id)
        {
            return tblUserRepository.GetById(id);

        }
        public void UpdateById(UserRegistrationViewModel objData)
        {
            tblUserRepository.Update(objData.User);
            UnitOfWork.Commit();
        }
        public List<tblUser> UserListData()
        {
            return tblUserRepository.GetAllByQuery().ToList();

        }

        public void DeleteById(UserRegistrationViewModel obj)
        {
            tblUserRepository.Delete(obj.User);
            UnitOfWork.Commit();
        }
    }
}
