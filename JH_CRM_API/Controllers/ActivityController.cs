using JH_CRM_API.Models;
using JH_CRM_API.Repository;
using JH_CRM_API.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace JH_CRM_API.Controllers
{
    public class ActivityController : ApiController
    {

        [Route("api/get/activity")]
        public async Task<HttpResponseMessage> GetActivities()
        {
            HttpResponseMessage response = null;
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, new JHResponseMessage("JH_001", "Success", ActivityRepo.getActivityDocuments()));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, new JHResponseMessage("JH_101", "Application Error", exception.Message));
            }
            return response;
        }

        [Route("api/get/activity/{id?}")]
        public async Task<HttpResponseMessage> GetActivityById(string id)
        {
            HttpResponseMessage response = null;
            try
            {
                if (id != null)
                {
                    Activity activity = await ActivityRepo.getActivityDocument(id);
                    response = Request.CreateResponse(HttpStatusCode.OK, new JHResponseMessage("JH_001", "Success", activity));
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, new JHResponseMessage("JH_104", "Invalid activity Id", "Invalid activity Id"));
                }

            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.GetBaseException());
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, new JHResponseMessage("JH_101", "Application Error", exception.Message));
            }
            return response;
        }



        //[Route("api/get/keywords")]
        //public async Task<HttpResponseMessage> GetKeywords()
        //{

        //    HttpResponseMessage response = null;
        //    try
        //    {
        //        List<KeywordResult> keywordList = await ActivityRepo.getKeywords();
        //        response = Request.CreateResponse(HttpStatusCode.OK, new JHResponseMessage("ARC_001", "Success", keywordList));
        //    }
        //    catch (Exception exception)
        //    {
        //        Debug.WriteLine(exception.GetBaseException());
        //        response = Request.CreateResponse(HttpStatusCode.InternalServerError, new JHResponseMessage("ARC_101", "Application Error", exception.Message));
        //    }
        //    return response;
        //}
    }
}
