
using AutoMapper;
using br.com.fiap.alert.Data.Contexts;
using br.com.fiap.alert.Models;
using br.com.fiap.alert.ViewModel;
using Microsoft.AspNetCore.Mvc;
namespace br.com.fiap.alert.Controllers
{
    public class AlertController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
       
        public AlertController(DatabaseContext databaseContext,IMapper mapper) { 
          
          _databaseContext = databaseContext;
            _mapper = mapper;   
         
        }
        public IActionResult Index()
        {
            var totalAlerts = _databaseContext.Alerts.Count();
            var Alerts = _databaseContext.Alerts.ToList();

            var viewModel = new AlertPaginacaoViewModel
            {
                Alerts = Alerts,
                CurrentPage = 1,
                PageSize = 10 // Define o tamanho da página (ou ajuste conforme necessário)
            };

            // Calcula o número total de páginas
            viewModel.TotalPages = (int)Math.Ceiling(totalAlerts / (double)viewModel.PageSize);

            viewModel.SetPaginationValues(totalAlerts); 

            return View("Index", viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
           var viewModel = new AlertCreateViewModel();
            return View();
        }

        public IActionResult IndexPaginated(int pagina = 1, int tamanhoPagina = 10)
        {
            var totalAlerts = _databaseContext.Alerts.Count();
            var alerts = _databaseContext.Alerts
                                .Skip((pagina - 1) * tamanhoPagina)
                                .Take(tamanhoPagina)
                                .ToList();

            var viewModel = new AlertPaginacaoViewModel
            {
                Alerts = alerts,
                CurrentPage = pagina,
                PageSize = tamanhoPagina
            };

            viewModel.TotalPages = (int)Math.Ceiling(totalAlerts / (double)tamanhoPagina);
            viewModel.SetPaginationValues(totalAlerts);

            return View("Index", viewModel); // Especifica a view "Index"
        }


        [HttpPost]
        public IActionResult Create(AlertCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var alertModel = _mapper.Map<AlertModel>(viewModel);
               
                _databaseContext.Alerts.Add(alertModel);
                _databaseContext.SaveChanges();
                Console.WriteLine("Alert registrado");
                TempData["mensagemSucesso"] = "Alert registrado";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(viewModel);
            }
            
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
            TempData["mensagemSucesso2"] = "Alert editado com sucesso";
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
