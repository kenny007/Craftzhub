using Artisaneer.DataLayer.Repository;
using Artisaneer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artisaneer.DataLayer
{
    public class AccountRepository: RepositoryBase<ArtisanHubEntities, Person>, IAccountRepository
    {

    }
}
