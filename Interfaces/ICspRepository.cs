using RunGroopWebApp.Models;

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Text.Json;
namespace RunGroopWebApp.Interfaces
{

    public interface ICspRepository
    {
        
        Task<IEnumerable<CspViolationModel>> GetAll();

        Task<CspViolationModel> GetByIdAsync(int id);
        
        bool Add(CspViolationModel _cspViolationModel);
        bool Update(CspViolationModel _cspViolationModel);

        bool Delete(CspViolationModel _cspViolationModel);
        bool Save();
    }
}