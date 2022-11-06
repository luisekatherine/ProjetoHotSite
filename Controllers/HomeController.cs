using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hotsite.Models;

namespace Hotsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Interesse cad)
        {
            try
            {
                //tentará executar o que tem aqui dentro
                DatabaseService dbs = new DatabaseService();
                dbs.CadastraInteresse(cad);
            }
            catch (Exception e)
            {
                //aqui realizarei o tratamento de erros
                _logger.LogError("Erro no cadastro de interesses!!" + e.Message);
            }
            return View("Index",cad);
        }

    }
}
