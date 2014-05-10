using Neusoft.CCS.Model.Entities;
using Neusoft.CCS.Services.ViewModels;
using AutoMapper;

namespace Neusoft.CCS.Services.Mappings
{
    public static class ImptEvtDeptMapper
    {
        public static ImptEvtDeptFormViewModel ToImptEvtCenterViewModel(this Model.Entities.ImportantEvent_Department imptEvtCenter)
        {
            var map = Mapper.CreateMap<ImportantEvent_Department, ImptEvtDeptFormViewModel>();
            map.ForMember(d => d.CaseID, opt => opt.MapFrom(s => s.CaseInfo.ID))//案件ID间映射
                .ForMember(d => d.ImptEvtDeptID, opt => opt.MapFrom(s => s.ID));//投诉回访信息编号间映射
            return Mapper.Map<ImportantEvent_Department, ImptEvtDeptFormViewModel>(imptEvtCenter);
        }


        /// <summary>
        /// 投诉回访单ImptEvtCenterFormViewModel修改后写回数据库前转换为业务实体
        /// </summary>
        /// <param name="rvFormVM"></param>
        /// <returns></returns>
        public static Model.Entities.ImportantEvent_Department ImptEvtDeptViewModelToEntity(this ImptEvtDeptFormViewModel iedFormVM)
        {
            var map = Mapper.CreateMap<ImptEvtDeptFormViewModel, ImportantEvent_Department>();
            map.ForMember(d => d.ID, opt => opt.MapFrom(s => s.ImptEvtDeptID));
            return Mapper.Map<ImptEvtDeptFormViewModel, ImportantEvent_Department>(iedFormVM);
        }
    }
}
