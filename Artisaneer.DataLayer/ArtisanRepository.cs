using Artisaneer.DataLayer.Repository;
using Artisaneer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
//using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace Artisaneer.DataLayer
{
    public class ArtisanRepository : RepositoryBase<ArtisanHubEntities, Person>, IArtisanRepository
    {
        public IEnumerable SearchArtisans(string q = null, string sort = null, bool desc = false,
                                                        int? limit = null, int offset = 0) {
    
        var list = (from item in _entities.People
                    select new PersonVm
                    {
                        PersonId = item.PersonId,FirstName = item.FirstName,
                        LastName = item.LastName, Skill = item.Skill.SkillName,
                        Email = item.Email,RegDate = item.RegDate
                    }).AsQueryable<PersonVm>();

        IQueryable<PersonVm> items = string.IsNullOrEmpty(sort) ? list.OrderBy(a => a.LastName)
            : from item in list orderby item.LastName select item ;
          
        if (!string.IsNullOrEmpty(q) && q != "undefined") items = items.Where(t => t.Skill.Contains(q));

        if (offset > 0) items = items.Skip(offset);
        if (limit.HasValue) items = items.Take(limit.Value);

        return items;
}

        public IEnumerable GetArts()
        {
            var GAI = (from item in _entities.People
                               select new PersonVm
                               {
                                   PersonId = item.PersonId,
                                   FirstName = item.FirstName,
                                   LastName = item.LastName,
                                   Skill = item.Skill.SkillName,
                                   Email = item.Email,
                                   RegDate=item.RegDate
                               }).ToList<PersonVm>();

            return GAI;
        }

     

    }
}
