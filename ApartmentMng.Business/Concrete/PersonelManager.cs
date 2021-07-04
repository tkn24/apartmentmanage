using ApartmentMng.Business.Abstract;
using ApartmentMng.Core.Models;
using ApartmentMng.DataAccess.Abstract;
using ApartmentMng.Entities.Concrete;
using ApartmentMng.Models.ViewModels.Personels;
using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentMng.Business.Concrete
{
    public class PersonelManager : IPersonelService
    {
        private readonly IPersonelRepository _personelRepository;
        private readonly RoleManager<MongoIdentityRole> _roleManager;

        public PersonelManager(IPersonelRepository personelRepository, RoleManager<MongoIdentityRole> roleManager)
        {
            _personelRepository = personelRepository;
            _roleManager = roleManager;
        }

        public GetManyResult<Personel> GetAllPersonels()
        {
            var userList = _personelRepository.GetAll();
            //Kısıt verilebilir, filtre vb.
            return userList;
        }

        public async Task<GetOneResult<PersonelMainRole>> GetPersonelRoles(string id)
        {
            var result = new GetOneResult<PersonelMainRole>();

            try
            {
                var roles = _roleManager.Roles != null ? _roleManager.Roles.ToList() : null;

                var personel = await _personelRepository.GetByIdAsync(id, "guid");

                var personelRoles = personel != null && personel.Entity != null
                    && personel.Entity.Roles != null ?
                    personel.Entity.Roles.Select(x => new PersonelRoles
                    {
                        Id = x.ToString(),
                        Name = roles.FirstOrDefault(y => y.Id == x).Name
                    }).ToList() : null;

                result.Entity = new PersonelMainRole
                {
                    Roles = roles,
                    PersonelRoleList = personelRoles
                };
                result.Success = true;
            }
            catch (Exception)
            {
                result.Entity = null;
                result.Success = false;
            }
            return result;
        }

        public async Task<GetOneResult<Personel>> UpdatePersonelRoles(string personelId, string[] personelRoleList)
        {
            var personel = await _personelRepository.GetByIdAsync(personelId, "guid");

            var roles = personelRoleList.Select(x => new Guid(x)).ToList();
            personel.Entity.Roles = null;
            personel.Entity.Roles = roles;

            var result = _personelRepository.ReplaceOne(personel.Entity, personelId, "guid");
            return result;

        }
    }
}
