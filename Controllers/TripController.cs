using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trip_log.Models;

namespace Trip_log.Controllers
{
    public class TripController : Controller
    {
        //loading data from db
        private TripContext context { get; set; }

        public TripController(TripContext ctx)
        {
            context = ctx;
        }

        //Default path index action method returning model list
        public IActionResult Index()
        {
            var trips = context.Trips.ToList();
            return View(trips);
        }


        [HttpGet]
        public IActionResult Page1()
        {
            return View("Add/Page-1");
        }

        [HttpPost]
        public IActionResult Page1(Trip trip)
        {
            // Store manditory individual properties in TempData
            TempData["Destination"] = trip.Destination;
            TempData["StartDate"] = trip.StartDate;
            TempData["EndDate"] = trip.EndDate;

            if (!ModelState.IsValid)
            {
                return View("Add/Page-1", trip);
            }
            if (trip.Accommodation == null)
            {
                TempData["Accommodation"] = "None";
                return RedirectToAction("Page3");
            }
            TempData["Accommodation"] = trip.Accommodation;
            return RedirectToAction("Page2");
        }


        [HttpGet]
        public IActionResult Page2()
        {
            // Create a new Trip object with retrieved properties
            var trip = new Trip
            {
                Destination = TempData["Destination"] as string,
                Accommodation = TempData["Accommodation"] as string,
                StartDate = (DateTime)TempData["StartDate"],
                EndDate = (DateTime)TempData["EndDate"]
            };

            return View("Add/Page-2", trip);
        }


        [HttpPost]
        public IActionResult Page2(Trip trip)
        {

            // Store individual properties in TempData
            TempData["Destination"] = trip.Destination;
            TempData["Accommodation"] = trip.Accommodation;
            TempData["StartDate"] = trip.StartDate;
            TempData["EndDate"] = trip.EndDate;
            TempData["AccommodationPhone"] = trip.AccommodationPhone;
            TempData["AccommodationEmail"] = trip.AccommodationEmail;

            if (!ModelState.IsValid)
            {
                return View("Add/Page-2", trip);
            }

            return RedirectToAction("Page3", trip);
        }

        [HttpGet]
        public IActionResult Page3()
        {
            // Create a new Trip object with retrieved properties
            var trip = new Trip
            {
                Destination = TempData["Destination"] as string,
                Accommodation = TempData["Accommodation"] as string,
                StartDate = (DateTime)TempData["StartDate"],
                EndDate = (DateTime)TempData["EndDate"],
                AccommodationPhone = TempData["AccommodationPhone"] as string,
                AccommodationEmail = TempData["AccommodationEmail"] as string
            };

            return View("Add/Page-3", trip);
        }

        [HttpPost]
        public IActionResult Page3(Trip trip)
        {
            if (!ModelState.IsValid)
            {
                return View("Add/Page-3", trip);
            }
            TempData["TripAdded"] = "Trip to " + trip.Destination + " Added";
            //save to db as Trip
            context.Trips.Add(trip);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Trip/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = context.Trips.Find(id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trip/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Trip trip)
        {
            if (id != trip.TripId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(trip);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(trip.TripId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(trip);
        }

        private bool TripExists(int id)
        {
            return context.Trips.Any(e => e.TripId == id);
        }
        // GET: Trip/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = context.Trips.FirstOrDefault(m => m.TripId == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var trip = context.Trips.Find(id);
            if (trip == null)
            {
                return NotFound();
            }

            context.Trips.Remove(trip);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }

}
