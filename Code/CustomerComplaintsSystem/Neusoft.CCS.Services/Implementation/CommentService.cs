using Neusoft.CCS.Infrastructure.Logging;
using Neusoft.CCS.Model.Entities;
using Neusoft.CCS.Model.Repositories;
using Neusoft.CCS.Services.Interfaces;
using Neusoft.CCS.Services.Messages;
using Neusoft.CCS.Services.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neusoft.CCS.Services.Implementation
{
    public class CommentService : ICommentService
    {

        private ICommentRepository _commentRepository;
        private ILogger _logger;
        public CommentService()
        {
            _commentRepository = DI.SpringHelper.GetObject<ICommentRepository>("CommentRepository");    
        }

        /// <summary>
        /// 保存客户评论
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Comment"></param>
        /// <returns></returns>
        public SaveCommentResponse SaveComment(string ID, string Comment)
        {
            SaveCommentResponse response = new SaveCommentResponse();
            int result = 0;
            if (!_commentRepository.IsCommented(ID))
            {//第一次评价该案件
                result = _commentRepository.SaveComment(ID, Comment);
                if (result == 1)
                {
                    response.IsSuccess = true;
                }
                else
                {
                    response.IsSuccess = false;
                    response.ErrorMessage = "保存客户评价错误";
                }
            }
            else
            {//已经评价过该案件
                response.IsSuccess = false;
                response.ErrorMessage = "您已经评价过该投诉案件";
            }
            return response;
        }

        /// <summary>
        /// 获取已评论案件列表
        /// </summary>
        /// <returns></returns>
        public GetCommentedResponse GetCommentedCases()
        {
            GetCommentedResponse response = new GetCommentedResponse();
            List<ComplaintInfo> result =  _commentRepository.GetCommentedCases();
            if (result != null && result.Count > 0)
            {
                response.IsSuccess = true;
                response.CommentedCases = result.ToRetrieveComplaintInfoesByUser();
            }
            else
            {
                response.IsSuccess = false;
                response.ErrorMessage = "获取已评价案件信息错误";
            }
            return response;
        }
    }
}
