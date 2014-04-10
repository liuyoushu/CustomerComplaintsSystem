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
    public static class ComplaintInfoMapper
    {
        public static ComplaintInfoOverviewViewModel ToOverviewViewModel(this Model.Entities.ComplaintInfo complaintInfo)
        {
            var map = Mapper.CreateMap<ComplaintInfo, ComplaintInfoOverviewViewModel>();
            map.ForMember(d => d.ComplainerName, opt => opt.MapFrom(s => s.CaseInfo.Complainer.Name))//指定ComplainerName字段的映射关系
                .ForMember(d => d.BusinessName, opt => opt.MapFrom(s => s.Business.Name));//指定BusinessName字段的映射关系
            return Mapper.Map<ComplaintInfo, ComplaintInfoOverviewViewModel>(complaintInfo);
        }

        public static List<ComplaintInfoOverviewViewModel> ToOverviewViewModels(this List<Model.Entities.ComplaintInfo> complaintInfoList)
        {
            List<ComplaintInfoOverviewViewModel> result = null;
            if (complaintInfoList != null && complaintInfoList.Count > 0)
            {
                result = new List<ComplaintInfoOverviewViewModel>();
                foreach (var cpt in complaintInfoList)
                {
                    result.Add(cpt.ToOverviewViewModel());
                    
                }
                
            }
            return result;
        }


    }
}
