﻿using br.com.fiap.alert.Data.Contexts;
using br.com.fiap.alert.Models;
using Microsoft.AspNetCore.Mvc;
namespace br.com.fiap.alert.Controllers
{
    public class AlertController : Controller
    {
        private readonly DatabaseContext _databaseContext;
       
        public AlertController(DatabaseContext databaseContext) { 
          
          _databaseContext = databaseContext;
         
        }
        public IActionResult Index()
        {
            var Alerts = _databaseContext.Alerts.ToList();
            
            return View(Alerts);
        }

        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(AlertModel alertModel)
        {
            _databaseContext.Alerts.Add(alertModel);
            _databaseContext.SaveChanges();
            Console.WriteLine("Alert registered");
            TempData["mensagemSucesso"] = "Alert registered";
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {


            var AlertConsultado =
                _databaseContext.Alerts.Find(id);
            // Retornando o cliente consultado para a View
            return View(AlertConsultado);
        }
        [HttpPost]
        public IActionResult Edit(AlertModel alertModel)
        {
            _databaseContext.Alerts.Update(alertModel);
            _databaseContext.SaveChanges(); 
            TempData["mensagemSucesso2"] = "Alert consultado com sucesso";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {

            // Simulando a busca no banco de dados 
            var AlertConsultado = _databaseContext.Alerts.Find(id);
            // Retornando o cliente consultado para a View
            return View(AlertConsultado);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Simulando a busca no banco de dados 
            var AlertConsultado = _databaseContext.Alerts.Find(id);
                
            if (AlertConsultado != null)
            {
                _databaseContext.Alerts.Remove(AlertConsultado);
                _databaseContext.SaveChanges();
                TempData["mensagemSucesso"] = $"Os dados do alert {AlertConsultado.TypeAlert} foram removidos com sucesso";
            }
            else
            {
                TempData["mensagemSucesso"] = $"OPS !!! Alert nao inexistente.";
            }
            return RedirectToAction(nameof(Index));
        }




        public static List<AlertModel> AlertMocados()
        {
            var alerts = new List<AlertModel>();
            for (int i = 1; i <= 5; i++)
            {
                var alert = new AlertModel
                {
                    AlertId = i,
                    TypeAlert = "TypeAlert" + i,
                    Message = "Message" + i,
                    Coords = "Coords" + i,
                    Author = "Author" + i,
                    
                };
                alerts.Add(alert);
            }
            return alerts;
        }

    }
}
