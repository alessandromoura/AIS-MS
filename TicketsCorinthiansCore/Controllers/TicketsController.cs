using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TicketsCorinthiansCore.Entities;
using TicketsCorinthiansCore.Models;

namespace TicketsCorinthiansCore.Controllers
{
    public class TicketsController : Controller
    {
        private readonly TicketsDbContext _context;

        public TicketsController(TicketsDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var games = _context.Games
                .Include("TeamHome")
                .Include("TeamAway")
                .Include("Stadium")
                .Include("Championship");

            return View(games);
        }

        public async Task<IActionResult> Buy(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = _context.Games
                .Include("TeamHome")
                .Include("TeamAway")
                .Include("Stadium")
                .Include("Championship")
                .FirstOrDefault(x => x.Id == id);
            if (game == null) 
            {
                return NotFound();
            }

            GameDto dto = new GameDto()
            {
                Championship = game.Championship.Name,
                TeamHome = game.TeamHome.Name,
                TeamAway = game.TeamAway.Name,
                CustomerName = "Alessandro",
                Place = $"{game.Stadium.City}, {game.Stadium.Country}",
                Quantity = 1,
                Stadium = game.Stadium.Name,
                Year = game.Championship.Year
            };

            string json = JsonConvert.SerializeObject(dto, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("https://corinthians-apim2.azure-api.net/frontend", content).ConfigureAwait(false);

                    
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

                return View();
        }
    }
}