using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;
using RunGroopWebApp.ViewModels;
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
        public IActionResult Create()
        {
            return View( );
        }

        [HttpPost]
        public async Task<IActionResult> Create(Club club)
        {
            if (!ModelState.IsValid)
            {
                return View(club);
            }
            

            _clubRepository.Add(club);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var club = await _clubRepository.GetByIdAsync(id);
            if(club == null) return View("Error");
            var clubVM = new EditClubViewModel
            {
                Title = club.Title,
                Description = club.Description,
                AddressId = club.AddressId,
                Address = club.Address,
                URL = club.Image,
                ClubCategory = club.ClubCategory
            };
            return View(clubVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditClubViewModel clubVM)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("","Failed to edit club");
                return View("Edit", clubVM);
            }
            var userClub = await _clubRepository.GetByIdAsyncNoTracking(id);
            if(userClub != null)
            {
                try
                {
                    //await _photoService.DeletePhotoAsync(userClub.Image);
                    int x = 5; 
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("","Could not delete photo");
                    return View(clubVM);
                }
                //var photoResult = await _photoService.AddPhotoAsync(clubVM.Image);
                var club = new Club
                {
                    Id = id,
                    Title = clubVM.Title,
                    Description = clubVM.Description,
                    //Image = photoResult.Url.ToString( ),
                    Image = "Default",
                    AddressId = clubVM.AddressId,
                    Address = clubVM.Address,

                };
                _clubRepository.Update(club);
                return  RedirectToAction("Index");
            }
            else
            {
                return View(clubVM);
            }
        }    
        public async Task<IActionResult> Delete(int id)
        {
            var clubDetails = await _clubRepository.GetByIdAsync(id);
            if(clubDetails == null) return View("Error");
            return View(clubDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var clubDetails = await _clubRepository.GetByIdAsync(id);
            if(clubDetails == null) return View("Error");

            _clubRepository.Delete(clubDetails);
            return RedirectToAction("Index");
        }

    }
}
