using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View(new CalculatorModel());
        }

        [HttpPost]
        public IActionResult Calculate(CalculatorModel model)
        {
            try
            {
                // Kullanıcıdan alınan ifadeyi hesapla
                var result = new DataTable().Compute(model.Expression, null);
                model.Result = Convert.ToDouble(result);
            }
            catch
            {
                ModelState.AddModelError("", "Geçersiz ifade. Lütfen doğru bir matematiksel ifade girin.");
            }
            return View("Index", model);
        }
    }
}
