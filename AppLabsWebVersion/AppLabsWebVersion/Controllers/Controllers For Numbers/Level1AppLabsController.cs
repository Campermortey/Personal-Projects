using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppLabs.Models.Level1Numbers;
using AppLabsWebVersion.Models;
using AppLabsWebVersion.Models.Level1Numbers;
using OperationsLayer.BLL.Level1Numbers;


namespace AppLabsWebVersion.Controllers
{
    public class Level1AppLabsController : Controller
    {
        //
        // GET: /Level1AppLabs/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TipRequestForm()
        {
            var model = new TipCalculation();
            return View(model);
            
        }

        [HttpPost]
        public ActionResult TipRequestForm(TipCalculation request)
        {
            if (ModelState.IsValid)
            {
                var calc = new TipCalculations();

                //convert tipcalculation to tipcalculationrequest

                var tipdata = new TipCalculatorRequest();

                tipdata.DollarValue = request.DollarValue.Value;
                tipdata.TipPercentage = request.TipPercentage.Value;

                var result = calc.Calculate(tipdata);
                return View("TipCalculationResult", result);
            }
            else
            {
                return View(request);
            }

       }

        public ActionResult LeapYearsForm()
        {
            var model = new LeapYearsValidation();
            return View(model);
        }

        [HttpPost]
        public ActionResult LeapYearsForm(LeapYearsValidation request)
        {
            if (ModelState.IsValid)
            {
                var calc = new LeapYearCalculation();

                //set tipdata to the request
                var tipdata = new LeapYearRequest();

                //set the validated inputs to the new request
                tipdata.BeginningDate = request.BeginningDate.Value;
                tipdata.EndingDate = request.EndingDate.Value;
                
                //set the result equal to the result of the the caculated method (returns a response)
                var result = calc.TotalDates(tipdata.BeginningDate, tipdata.EndingDate);

                //return a view linking to "LeapYearsResult" and pass in the result
                return View("LeapYearsResult", result);
                }
            else
            {
                return View(request);
            }
        }

        public ActionResult FlooringCalculatorForm()
        {
            var model = new FlooringCalculatorValidation();
            return View(model);
        }

        [HttpPost]
        public ActionResult FlooringCalculatorForm(FlooringCalculatorValidation request)
        {
            if (ModelState.IsValid)
            {
                var calc = new FlooringCalculatorWork();

                var floorData = new FlooringCalculatorRequest();

                floorData.Cost = request.Cost.Value;
                floorData.Length = request.Length.Value;
                floorData.Width = request.Width.Value;

                var result = calc.CalculateFloor(floorData);

                return View("FloorCalculatorResult", result);

            }
            return View(request);
        }

	}
}