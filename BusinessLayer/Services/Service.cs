using BusinessLayer.IServices;
using DataLayer.Core.Configuration;

namespace BusinessLayer.Services
{
    public class Service : IService
    {
        public IAdminServices AdminService { get; private set; }

        public Service(IUnitOfWork uow)
        {
            this.AdminService = new AdminService(uow);
        }
    }
}