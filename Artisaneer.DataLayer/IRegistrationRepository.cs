using Artisaneer.DataLayer.Interfaces;
using Artisaneer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artisaneer.DataLayer
{
    public interface IRegistrationRepository: IRepositoryBase<State>
    {
        IEnumerable GetStates();
        IEnumerable GetLGA(int stateId);
        IEnumerable GetOnce();
        IEnumerable GetSkills();
    }
}
