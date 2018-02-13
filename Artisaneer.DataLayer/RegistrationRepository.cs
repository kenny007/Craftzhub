using Artisaneer.DataLayer.Repository;
using Artisaneer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artisaneer.DataLayer
{
    public class RegistrationRepository: RepositoryBase<ArtisanHubEntities, State>, IRegistrationRepository
    {
        public IEnumerable GetOnce() 
        {
            var ret = _entities.States.Include("StateLGA").Select(x => new  { x.StateName,  x.StateID,
                StateLGAs = x.StateLGAs.Select(y => new { y.StateLGID, y.LGName })}).ToList();
            return ret;
        }

        public IEnumerable GetStates()
        {
           return _entities.States.Select(x =>  new { x.StateID, x.StateName }).ToList();
        }

        public IEnumerable GetLGA(int stateId)
        {
            return _entities.StateLGAs.Where(x => x.StateID == stateId).Select(x => new {x.StateLGID, x.LGName }).ToList();
        }

        public IEnumerable GetSkills()
        {
            return _entities.Skills.Select(x => new { x.SkillId, x.SkillName }).ToList();
        }

    }
}
