using System.Collections.Generic;
using Neusoft.CCS.Model.Entities;
using Neusoft.CCS.Services.ViewModels;
using AutoMapper;

namespace Neusoft.CCS.Services.Mappings
{
    public static class ComplaintDisposeAndFeedbackInfoMapper
    {
        /// <summary>
        /// 客户满意度显示转换
        /// </summary>
        /// <param name="cptDAFInfo"></param>
        /// <returns></returns>
        public static string SatisfactionToString(this Model.Entities.ComplaintDisposeAndFeedbackInfo cptDAFInfo)
        {
            switch (cptDAFInfo.Satisfaction)
            {
                case Model.Entities.Satisfaction.Normal:
                    return "一般";
                case Model.Entities.Satisfaction.Satisfied:
                    return "满意";
                case Model.Entities.Satisfaction.Unsatisfied:
                    return "不满意";
                case Model.Entities.Satisfaction.VerySatisfied:
                    return "非常满意";
                default:
                    return "满意";
            }
        }
    }
}
