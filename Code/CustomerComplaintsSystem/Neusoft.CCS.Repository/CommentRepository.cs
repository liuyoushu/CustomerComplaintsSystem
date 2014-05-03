using Neusoft.CCS.Model.Repositories;
using Neusoft.CCS.Repository.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Repository
{
    public class CommentRepository : ICommentRepository
    {
        /// <summary>
        /// 保存客户评价信息
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Comment"></param>
        /// <returns></returns>
        public int SaveComment(string ID, string Comment)
        {
            int CaseID;
            int.TryParse(ID, out CaseID);
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var result = (from p in context.ComplaintInfoes
                              where p.CaseInfo.ID.Equals(CaseID)
                              select p).FirstOrDefault();
                if (result != null)
                {
                    result.Cpt_Comment = Comment;
                    context.SaveChanges();
                    return 1;
                }
                return 0;
            }
        }

        /// <summary>
        /// 判断是否已经评价过该投诉案件
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool IsCommented(string ID)
        {
            int CaseID;
            int.TryParse(ID, out CaseID);
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var result = (from p in context.ComplaintInfoes
                              where p.CaseInfo.ID.Equals(CaseID)
                              && !string.IsNullOrEmpty(p.Cpt_Comment)
                              select p).FirstOrDefault();
                if (result != null)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 获取已评价案件列表
        /// </summary>
        /// <returns></returns>
        public List<Model.Entities.ComplaintInfo> GetCommentedCases()
        {
            using (NeusoftCCSEntities context = new NeusoftCCSEntities())
            {
                var result = (from p in context.ComplaintInfoes
                              where !string.IsNullOrEmpty(p.Cpt_Comment)
                              select p).ToList();
                return result.ToModels();
            }
        }
    }
}
