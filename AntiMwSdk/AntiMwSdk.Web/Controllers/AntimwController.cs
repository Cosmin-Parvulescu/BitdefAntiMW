using AntiMwSdk.Core;
using AntiMwSdk.CSharpApi.Ipc;
using System.Web.Http;

namespace AntiMwSdk.Web.Controllers
{
    public class AntimwController : ApiController
    {
        private readonly IAntimwApi _antimwApi;

        public AntimwController()
        {
            _antimwApi = new AntimwApi(new ZmqIpcInput());
        }

        [HttpGet()]
        [Route("startrealtime")]
        public IHttpActionResult StartRealtime()
        {
            return Ok(_antimwApi.StartRealTime());
        }

        [HttpGet()]
        [Route("stoprealtime")]
        public IHttpActionResult StopRealtime()
        {
            return Ok(_antimwApi.StopRealTime());
        }

        [HttpGet()]
        [Route("startondemand")]
        public IHttpActionResult StartOndemand()
        {
            return Ok(_antimwApi.StartOnDemand());
        }

        [HttpGet()]
        [Route("stopondemand")]
        public IHttpActionResult StopOndemand()
        {
            return Ok(_antimwApi.StopOnDemand());
        }
    }
}
