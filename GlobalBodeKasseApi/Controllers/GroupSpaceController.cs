using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlobalBodeKasse.Core.ApplicationService;
using GlobalBodeKasse.Core.Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace GlobalBodeKasseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupSpaceController : ControllerBase
    {
        private readonly IGroupSpaceService _groupSpaceService;

        public GroupSpaceController(IGroupSpaceService groupSpaceService)
        {
            _groupSpaceService = groupSpaceService;
        }

        // GET api/GroupSpace
        [HttpGet]
        public IEnumerable<GroupSpace> Get()
        {
            return _groupSpaceService.GetAllGroupSpaces();
        }

        // GET api/GroupSpace/5
        [HttpGet("{id}")]
        public ActionResult<GroupSpace> Get(string id)
        {
            return _groupSpaceService.FindGroupSpaceById(id);
        }
        
        /// <summary>
        /// Post new GroupSpace JSon example
        /// </summary>
        /// <param name="data">
        /// {
        /// "userId" :2,
        /// "groupSpace" : { 
        /// "id": "79865606-e01b-423f-bd09-92e116a0664a",
        /// "name": "newTestClub",
        /// "databaseConnectionString": "Data Source=newTestClub.db"
        /// }
        /// </param>
        /// <returns></returns>
        // POST api/GroupSpace
        [HttpPost]
        public ActionResult<GroupSpace> CreateGroupSpace([FromBody]JObject data)
        {
            //Skulle i fremtiden tjekker om brugeren overhovedet eksistere

            try
            {
                int userId = (int)data["userId"];
                if (userId != 0)
                {
                    GroupSpace newGroupSpace = data["groupSpace"].ToObject<GroupSpace>();

                    return _groupSpaceService.CreateGroupSpace(newGroupSpace, userId);
                }
                else
                {
                    return BadRequest("No user id parameter given.");
                }
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/GroupSpace/5
        [HttpPut]
        public ActionResult<GroupSpace> Put([FromBody] GroupSpace groupSpace)
        {
            
            //if (id != null || id != groupSpace.Id.ToString())
            //{
            //    return BadRequest("parameter id and GroupSpace id must be a match");
            //}

            return _groupSpaceService.UpdateGroupSpace(groupSpace);
        }

        // DELETE api/GroupSpace/5
        [HttpDelete("{id}")]
        public ActionResult<GroupSpace> Delete(string id)
        {

            var groupSpace = _groupSpaceService.DeleteGroupSpaceById(id);
            if (groupSpace == null)
            {
                return StatusCode(404, "Did not found GroupSpace with id: " + id);
            }
            return Ok($"GroupSpace with Id: {groupSpace.Id} is Deleted");
        }
    }
}
