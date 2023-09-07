using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;
using System;
namespace RunGroopWebApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepository;
        public ClubController(IClubRepository clubRepository) /* ApplicationDbContext is our Database */
        {
            _clubRepository = clubRepository;
        }
        
        public async Task<IActionResult> Index( )
        {
            IEnumerable<Club> clubs = await _clubRepository.GetAll( ); /* Bringing all the table from database and drop into your table */
            return View(clubs);
        }


        public async Task<IActionResult> Detail(int id)
        {
            Club club = await _clubRepository.GetByIdAsync(id);
            return View(club);
        }

    }
}
