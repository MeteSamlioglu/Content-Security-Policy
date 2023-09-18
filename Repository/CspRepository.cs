using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;
using System;


namespace RunGroopWebApp.Repository
{   

    public class CspRepository : ICspRepository
    { 
        private readonly ApplicationDbContext _context;
        public CspRepository(ApplicationDbContext context)
        {
            _context = context;
        } 
       
        public async Task<CspViolationModel> GetByIdAsync(int id)
        {
            return await _context.CspViolationModels.Include(i => i.Id == id).FirstOrDefaultAsync(i => i.Id == id);
        }
        
        public bool Add(CspViolationModel cspReportModel)
        {
            _context.Add(cspReportModel);
            return Save();
        }

        public bool Delete(CspViolationModel cspReportModel)
        {
            _context.Remove(cspReportModel);
            return Save( );
        }

        public async Task<IEnumerable<CspViolationModel>> GetAll( )
        {
            return await _context.CspViolationModels.ToListAsync();
        }

        public bool Save( )
        {
            var saved = _context.SaveChanges( );
            return saved > 0 ? true : false;
        }

        public bool Update(CspViolationModel cspReportModel)
        {
            _context.Update(cspReportModel);
            return Save( );
        }
    
    }
}
