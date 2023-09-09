using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Interfaces;
using RunGroopWebApp.Models;
using RunGroopWebApp.ViewModels;

namespace RunGroopWebApp.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository _raceRepository;
        public RaceController(IRaceRepository raceRepository)
        {
            _raceRepository = raceRepository;
        }
        public async Task<IActionResult> Index( )
        {
            IEnumerable<Race> races = await _raceRepository.GetAll( );
            return View(races);
        }
        
        public async Task<IActionResult> Detail(int id)
        {
            Race race = await _raceRepository.GetByIdAsync(id);
            return View(race);
        }
         public IActionResult Create()
        {
            return View( );
        }

           [HttpPost]
        public async Task<IActionResult> Create(Race race)
        {
            if (!ModelState.IsValid)
            {
                return View(race);
            }
            

            _raceRepository.Add(race);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var race = await _raceRepository.GetByIdAsync(id);
            if(race == null) return View("Error");
            var raceVM = new EditRaceViewModel
            {
                Title = race.Title,
                Description = race.Description,
                AddressId = race.AddressId,
                Address = race.Address,
                URL = race.Image,
                RaceCategory = race.RaceCategory,
            };
            return View(raceVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditRaceViewModel raceVM)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("","Failed to edit race");
                return View("Edit", raceVM);
            }
            var userRace = await _raceRepository.GetByIdAsyncNoTracking(id);
            if(userRace != null)
            {
                try
                {
                    //await _photoService.DeletePhotoAsync(userRace.Image);
                    int x = 5; 
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("","Could not delete photo");
                    return View(raceVM);
                }
                //var photoResult = await _photoService.AddPhotoAsync(clubVM.Image);
                var race = new Race
                {
                    Id = id,
                    Title = raceVM.Title,
                    Description = raceVM.Description,
                    //Image = photoResult.Url.ToString( ),
                    Image = "Default",
                    AddressId = raceVM.AddressId,
                    Address = raceVM.Address,

                };
                _raceRepository.Update(race);
                return  RedirectToAction("Index");
            }
            else
            {
                return View(raceVM);
            }
        }    
    }
}
