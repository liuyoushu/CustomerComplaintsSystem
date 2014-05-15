using Neusoft.CCS.Services.Interfaces;
using Neusoft.CCS.Services.Messages;
using Neusoft.CCS.Model.Repositories;
using Neusoft.CCS.Infrastructure.Logging;
using Neusoft.CCS.Services.Mappings;
using Neusoft.CCS.Services.ViewModels;
using System;
using System.Linq;
using Neusoft.CCS.Model.Entities;

namespace Neusoft.CCS.Services.Implementation
{
    public class StaffService : IStaffService
    {

        private IStaffRepository _staffRepository;
        private ILogger _logger;

        public StaffService()
        {
            _staffRepository = DI.SpringHelper.GetObject<IStaffRepository>("StaffRepository");

            _logger = DI.SpringHelper.GetObject<ILogger>("DefaultLogger");
        }

        public LoginedStaffViewModel Login(LoginedStaffViewModel loginedStaff)
        {
            var result = new LoginedStaffViewModel();
            var staff = _staffRepository.RetrieveByIdAndPwd(loginedStaff.ID, loginedStaff.Password);
            if (staff != null)
            {
                result.Permissions = staff.Position.Permissions;
            }
            return result;
        }
    }
}
