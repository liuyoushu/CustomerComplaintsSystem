using AutoMapper;
using Neusoft.CCS.Model.Entities;
using Neusoft.CCS.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Services.Mappings
{
    public static class ComplaintMapper
    {
        # region 发起投诉mapping
        public static CaseInfo ToCaseInfo(this CreateComplaintViewModel createComplaintViewModel)
        {
            return new CaseInfo() { State = Model.Entities.CaseState.Start };
        }
        public static Complainer ToComplainer(this CreateComplaintViewModel createComplaintViewModel)
        {
            var map = Mapper.CreateMap<CreateComplaintViewModel, Complainer>();
            map.ForMember(d => d.Name, opt => opt.MapFrom(s => s.Cmp_Name))
                .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.Phone))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email));
            return Mapper.Map<CreateComplaintViewModel, Complainer>(createComplaintViewModel);
        }
        public static ComplaintInfo ToComplaintInfo(this CreateComplaintViewModel createComplaintViewModel)
        {
            var map = Mapper.CreateMap<CreateComplaintViewModel, ComplaintInfo>();
            map.ForMember(d => d.Way, opt => opt.MapFrom(s => s.Way))
                .ForMember(d => d.Area, opt => opt.MapFrom(s => s.Cmp_Area))
                .ForMember(d => d.Describe, opt => opt.MapFrom(s => s.Describe))
                .ForMember(d => d.Class, opt => opt.MapFrom(s => s.Class))
                .ForMember(d => d.Date, opt => opt.MapFrom(s => s.Date))
                ;
            return Mapper.Map<CreateComplaintViewModel, ComplaintInfo>(createComplaintViewModel);
        }
        #endregion

        public static RetrieveComplaintInfoByUserViewModel ToRetrieveComplaintInfoByUser(this ComplaintInfo complaintInfo)
        {
            var map = Mapper.CreateMap<ComplaintInfo, RetrieveComplaintInfoByUserViewModel>();
            map.ForMember(d => d.ID, opt => opt.MapFrom(s => s.ID))
                .ForMember(d => d.Phone, opt => opt.MapFrom(s => s.CaseInfo.Complainer.PhoneNumber))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.CaseInfo.Complainer.Email))
                .ForMember(d => d.Area, opt => opt.MapFrom(s => s.Area))
                .ForMember(d => d.Class, opt => opt.MapFrom(s => s.Class))
                .ForMember(d => d.ComplainerName, opt => opt.MapFrom(s => s.CaseInfo.Complainer.Name))
                .ForMember(d => d.Way, opt => opt.MapFrom(s => s.Way))
                .ForMember(d => d.Date, opt => opt.MapFrom(s => s.Date));
            return Mapper.Map<ComplaintInfo, RetrieveComplaintInfoByUserViewModel>(complaintInfo);
        }
        public static List<RetrieveComplaintInfoByUserViewModel> ToRetrieveComplaintInfoesByUser(this List<ComplaintInfo> complaintInfoes)
        {
            List<RetrieveComplaintInfoByUserViewModel> result = null;
            if (complaintInfoes != null && complaintInfoes.Count() > 0)
            {
                result = new List<RetrieveComplaintInfoByUserViewModel>();
                foreach (var cpt in complaintInfoes)
                {
                    result.Add(cpt.ToRetrieveComplaintInfoByUser());
                }

            }
            return result;
        }
    }
}
