using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppLabs.Models.Interfaces;
using AppLabs.Models.Level2Numbers;
using AppLabsWebVersion.Models.Level2Numbers;
using OperationsLayer.BLL.Level2Numbers;
using OperationsLayer.BLL.Level2Numbers.TemperatureConverters;

namespace AppLabsWebVersion.Controllers
{
    public class Level2AppLabsController : Controller
    {
        //
        // GET: /Level2AppLabs/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangeReturnForm()
        {
            var model = new ChangeReturnValidation();

            return View(model);
        }

        [HttpPost]

        public ActionResult ChangeReturnForm(ChangeReturnValidation model)
        {
            if (ModelState.IsValid)
            {
                var calc = new ReturnChangeOperations();
                var request = new ReturnChangeRequest();

                request.Cost = model.Cost.Value;
                request.EnteredCash = model.EnteredCash.Value;
                request.Product = model.Product;

                var response = calc.CalculateDifferent(request);

                var result = calc.CalculateChange(response);
                
                return View("ChangeReturnResult", result);
            }
            return View(model);
        }

        public ActionResult FibonacciSequenceForm()
        {
            var model = new FibonacciValidation();

            return View(model);
        }

        [HttpPost]
        public ActionResult FibonacciSequenceForm(FibonacciValidation model)
        {
            if (ModelState.IsValid)
            {
                var calc = new FibonacciSequenceOperations();
                var request = new FibonacciSequence();
                request.Term = model.Term.Value;

                var result = calc.CalculateSequence(request.Term);

                return View("FibonacciSequenceResult", result);
            }
            return View(model);
        }

        public ActionResult PrimeNumberForm()
        {
            var model = new PrimeNumberValidation();

            return View(model);
        }

        public JsonResult GetPrime(int id)
        {
            PrimeNumberCalculation prime = new PrimeNumberCalculation();
            int result = prime.Calculation(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ConversionCategoryForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Conversion(string category)
        {
            IUnitConverter converter;

            switch (category)
            {
                case "F2C":
                    converter = new FahrenheitToCelciusConverter();
                    converter.Convert()
            }
        }
	}
}