using ApartmentMng.Core.Models;
using ApartmentMng.Entities.Concrete;
using ApartmentMng.Models.ViewModels.Personels;
using System.Threading.Tasks;

namespace ApartmentMng.Business.Abstract
{
    public interface IPersonelService
    {
        GetManyResult<Personel> GetAllPersonels(); //Test
        Task<GetOneResult<PersonelMainRole>> GetPersonelRoles(string id);

        Task<GetOneResult<Personel>> UpdatePersonelRoles(string personelId, string[] personelRoleList);
    }
}
