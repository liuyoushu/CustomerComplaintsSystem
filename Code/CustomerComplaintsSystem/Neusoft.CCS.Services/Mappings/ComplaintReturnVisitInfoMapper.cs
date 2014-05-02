using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neusoft.CCS.Model.Entities;
using Neusoft.CCS.Services.ViewModels;
using AutoMapper;

namespace Neusoft.CCS.Services.Mappings
{
    public static class ComplaintReturnVisitInfoMapper
    {
        /// <summary>
        /// ReturnVisitForm的视图模型Mapping
        /// </summary>
        /// <param name="cptRVInfo"></param>
        /// <returns></returns>
        public static ReturnVisitFormViewModel ToReturnVisitFormViewModel(this Model.Entities.ComplaintReturnVisitInfo cptRVInfo)
        {
            var map = Mapper.CreateMap<ComplaintReturnVisitInfo, ReturnVisitFormViewModel>();
            map.ForMember(d=>d.CaseID, opt => opt.MapFrom(s=>s.CaseInfo.ID))//案件ID间映射
                .ForMember(d=>d.ReturnVisitDate, opt=>opt.MapFrom(s=> s.Date));
            return Mapper.Map<ComplaintReturnVisitInfo, ReturnVisitFormViewModel>(cptRVInfo);
        }

        /// <summary>
        /// 投诉回访单ReturnVisitForm修改后写回数据库前转换为业务实体
        /// </summary>
        /// <param name="rvFormVM"></param>
        /// <returns></returns>
        public static Model.Entities.ComplaintReturnVisitInfo ReturnVisitFormToEntity(this ReturnVisitFormViewModel rvFormVM)
        {
            return Mapper.Map<ReturnVisitFormViewModel, ComplaintReturnVisitInfo>(rvFormVM);
        }
    }
}
