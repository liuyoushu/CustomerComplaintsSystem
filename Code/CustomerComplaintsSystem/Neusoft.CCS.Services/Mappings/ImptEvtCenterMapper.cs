using Neusoft.CCS.Model.Entities;
using Neusoft.CCS.Services.ViewModels;
using AutoMapper;

namespace Neusoft.CCS.Services.Mappings
{
    public static class ImptEvtCenterMapper
    {
        public static ImptEvtCenterFormViewModel ToImptEvtCenterViewModel(this Model.Entities.ImportantEvent_Center imptEvtCenter)
        {
            var map = Mapper.CreateMap<ImportantEvent_Center, ImptEvtCenterFormViewModel>();
            map.ForMember(d => d.CaseID, opt => opt.MapFrom(s => s.CaseInfo.ID))//案件ID间映射
                .ForMember(d => d.ImptEvtCenterID, opt => opt.MapFrom(s => s.ID));//投诉回访信息编号间映射
            return Mapper.Map<ImportantEvent_Center, ImptEvtCenterFormViewModel>(imptEvtCenter);
        }


        /// <summary>
        /// 投诉回访单ImptEvtCenterFormViewModel修改后写回数据库前转换为业务实体
        /// </summary>
        /// <param name="rvFormVM"></param>
        /// <returns></returns>
        public static Model.Entities.ImportantEvent_Center ImptEvtCenterViewModelToEntity(this ImptEvtCenterFormViewModel iecFormVM)
        {
            var map = Mapper.CreateMap<ImptEvtCenterFormViewModel, ImportantEvent_Center>();
            map.ForMember(d=> d.ID, opt => opt.MapFrom(s=>s.ImptEvtCenterID));
            return Mapper.Map<ImptEvtCenterFormViewModel, ImportantEvent_Center>(iecFormVM);
        }
    }
}
