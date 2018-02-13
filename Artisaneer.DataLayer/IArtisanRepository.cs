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
    public interface IArtisanRepository: IRepositoryBase<Person>
    {
        IEnumerable SearchArtisans(string q = null, string sort = null, bool desc = false,
                                                        int? limit = null, int offset = 0);
        IEnumerable GetArts();

       
    }
}
