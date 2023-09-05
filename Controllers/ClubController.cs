using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Models;
using System;
namespace RunGroopWebApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext _context; 
        public ClubController(ApplicationDbContext context) /* ApplicationDbContext is our Database */
        {
            this._context = context;
        }
        
        public IActionResult Index( )
        {
            List<Club> clubs = _context.Clubs.ToList( ); /* Bringing all the table from database and drop into your table */
            return View(clubs);
        }


        public IActionResult Detail(int id)
        {
            Club club = _context.Clubs.Include(a => a.Address).FirstOrDefault(c=> c.Id == id);
            return View(club);
        }

    }
}
