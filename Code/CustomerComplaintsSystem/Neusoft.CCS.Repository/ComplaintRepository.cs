using Neusoft.CCS.Model.Repositories;
using Neusoft.CCS.Repository.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Repository
{
    public class ComplaintRepository : IComplaintRepository
    {
        public int CreateComplaint(Model.Entities.CaseInfo caseInfo, Model.Entities.Complainer complainer, Model.Entities.ComplaintInfo complaintInfo)
        {
            try
            {
                lock (lockOj)
                {
                    CreateComplainer(complainer);
                    CreateCaseInfo(caseInfo);
                    CreateComplaintInfo(complaintInfo);
                }
            }
            catch
            {
                return 0;
            }
            return 1;
        }
        private int complainerID;
        private int caseID;
        object lockOj =1;
        private void CreateCaseInfo(Model.Entities.CaseInfo caseInfo)
        {
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                context.CaseInfoes.Add(new CaseInfo()
                {
                    //Com_ID = caseInfo.Complainer.ID, 
                    Com_ID = complainerID,
                    State = (int)caseInfo.State
                });
                context.SaveChanges();
                var ciR = (from ci in context.CaseInfoes select ci).ToList();
                caseID = ciR.Last().ID;
            }
        }

        private void CreateComplainer(Model.Entities.Complainer complainer)
        {
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                context.Complainers.Add(new Complainer()
                {
                    Name = complainer.Name,
                    Email = complainer.Email,
                    PhoneNumber = complainer.PhoneNumber
                });
                context.SaveChanges();
                var cmpR = (from cmp in context.Complainers select cmp).ToList();
                complainerID = cmpR.Last().ID;
            }
        }

        private void CreateComplaintInfo(Model.Entities.ComplaintInfo complaintInfo)
        {
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var BusinessID = (from p in context.Businesses
                                  where p.BussinessName.Equals(complaintInfo.Class)
                                  select p.BussinessID).FirstOrDefault();
                context.ComplaintInfoes.Add(new ComplaintInfo()
                {
                    BussinessID = BusinessID,
                    Cpt_Area = complaintInfo.Area,
                    //Cpt_BeginTime = complaintInfo.BeginTime,
                    Cpt_Class = complaintInfo.Class,
                    Cpt_Date = complaintInfo.Date,
                    Cpt_Describe = complaintInfo.Describe,
                    //Cpt_EndTime = complaintInfo.EndTime,
                    Cpt_Way = complaintInfo.Way,
                    //ID = complaintInfo.ID
                    ID = caseID
                });
                context.SaveChanges();
            }
        }


        /// <summary>
        /// 获取所有业务信息
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllBusinesses()
        {
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var result = (from p in context.Businesses select p.BussinessName).ToList();
                return result;
            }
        }

        /// <summary>
        /// 根据用户姓名和电话获取所有用户投诉信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public List<Model.Entities.ComplaintInfo> RetrieveComplaintInfoByUserEmail(string name, string email)
        {
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var result = (from p in context.ComplaintInfoes
                              where p.CaseInfo.Complainer.Name.Equals(name)
                                  && p.CaseInfo.Complainer.Email.Equals(email)
                              select p).ToList();
                return result.ToModels();
            }
        }

        /// <summary>
        /// 根据姓名和email获取所有投诉信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public List<Model.Entities.ComplaintInfo> RetrieveComplaintInfoByUserPhone(string name, string phone)
        {
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var result = (from p in context.ComplaintInfoes
                              where p.CaseInfo.Complainer.Name.Equals(name)
                                  && p.CaseInfo.Complainer.PhoneNumber.Equals(phone)
                              select p).ToList();
                return result.ToModels();
            }
        }

        /// <summary>
        /// 根据案件ID获取案件处理过程信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public List<Model.Entities.History> GetHistoriesByID(string ID)
        {
            int CaseID;
            int.TryParse(ID, out CaseID);
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var result = (from p in context.Histories
                              where p.ID == CaseID
                              select p).ToList();
                return result.ToModels();
            }
        }

        /// <summary>
        /// 根据案件ID获取案件解决方案信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Model.Entities.ComplaintDisposeAndFeedbackInfo GetSolutionByID(string ID)
        {
            int CaseID;
            int.TryParse(ID, out CaseID);
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var result = (from p in context.ComplaintDisposeAndFeedbackInfoes
                              where p.ID == CaseID
                              select p).FirstOrDefault();
                return result.ToModel();
            }
        }

        /// <summary>
        /// 根据案件ID获取案件基本信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Model.Entities.ComplaintInfo GetComplaintInfoByID(string ID)
        {
            int CaseID;
            int.TryParse(ID, out CaseID);
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var result = (from p in context.ComplaintInfoes
                              where p.ID == CaseID
                              select p).FirstOrDefault();
                return result.ToModel();
            }
        }

        /// <summary>
        /// 保存案件解决方案
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Solution"></param>
        /// <returns></returns>
        public int SaveSolution(string ID, string Solution)
        {
            int CaseID;
            int.TryParse(ID, out CaseID);
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var cpt = (from p in context.ComplaintDisposeAndFeedbackInfoes
                           where p.ID == caseID
                           select p).FirstOrDefault();
                if (cpt != null)
                {
                    cpt.CptDF_Solution = Solution;
                    context.SaveChanges();
                }
                else
                    return 0;
                return 1;
            }
        }

        /// <summary>
        /// 完成案件处理
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int FinishCase(string ID, DateTime finishTime)
        {
            int CaseID;
            int.TryParse(ID, out CaseID);
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var cpt = (from p in context.ComplaintInfoes
                           where p.ID == caseID
                           select p).FirstOrDefault();
                if (cpt != null)
                {
                    cpt.Cpt_EndTime = finishTime;
                    context.SaveChanges();
                }
                else
                    return 0;
                return 1;
            }
        }
    }
}
