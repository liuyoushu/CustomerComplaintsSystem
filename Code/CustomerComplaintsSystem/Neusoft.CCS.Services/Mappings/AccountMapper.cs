using System.Collections.Generic;
using Neusoft.CCS.Model.Entities;
using Neusoft.CCS.Services.ViewModels;
using AutoMapper;

namespace Neusoft.CCS.Services.Mappings
{
    public static class AccountMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="complaintInfo"></param>
        /// <returns></returns>
        public static LoginedStaffViewModel ToOverviewViewModel(this Model.Entities.Staff staff)
        {
            //var map = Mapper.CreateMap<ComplaintInfo, ComplaintInfoOverviewViewModel>();
            //map.ForMember(d => d.ComplainerName, opt => opt.MapFrom(s => s.CaseInfo.Complainer.Name))//指定ComplainerName字段的映射关系
            //    .ForMember(d => d.BusinessName, opt => opt.MapFrom(s => s.Business.Name));//指定BusinessName字段的映射关系
            return Mapper.Map<Staff, LoginedStaffViewModel>(staff);
        }
    }
}
