using Neusoft.CCS.Model.Entities;
using Neusoft.CCS.Services.ViewModels;
using AutoMapper;

namespace Neusoft.CCS.Services.Mappings
{
    public static class ImptEvtStaffMapper
    {
        public static ImptEvtStaffFormViewModel ToImptEvtStaffViewModel(this Model.Entities.ImportantEvent_Staff imptEvtStaff)
        {
            var map = Mapper.CreateMap<ImportantEvent_Staff, ImptEvtStaffFormViewModel>();
            map.ForMember(d => d.CaseID, opt => opt.MapFrom(s => s.CaseInfo.ID))//案件ID间映射
                .ForMember(d => d.ImptEvtStaffID, opt => opt.MapFrom(s => s.ID));//投诉回访信息编号间映射
            return Mapper.Map<ImportantEvent_Staff, ImptEvtStaffFormViewModel>(imptEvtStaff);
        }


        /// <summary>
        /// 投诉回访单ImptEvtCenterFormViewModel修改后写回数据库前转换为业务实体
        /// </summary>
        /// <param name="rvFormVM"></param>
        /// <returns></returns>
        public static Model.Entities.ImportantEvent_Staff ImptEvtStaffViewModelToEntity(this ImptEvtStaffFormViewModel iedFormVM)
        {
            var map = Mapper.CreateMap<ImptEvtStaffFormViewModel, ImportantEvent_Staff>();
            map.ForMember(d => d.ID, opt => opt.MapFrom(s => s.ImptEvtStaffID));
            return Mapper.Map<ImptEvtStaffFormViewModel, ImportantEvent_Staff>(iedFormVM);
        }
    }
}
