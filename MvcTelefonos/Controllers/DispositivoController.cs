using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MvcTelefonos.Models;
using MvcTelefonos.Servicios;

namespace MvcTelefonos.Controllers
{
    public class DispositivoController : Controller
    {
        private IServicios<Dispositivo> _servicios;

        public DispositivoController(IServicios<Dispositivo> 
            servicios)
        {
            _servicios = servicios;
        }

        // GET: Dispositivo
        public ActionResult Index()
        {
            return View(_servicios.Get());
        }

        public ActionResult Alta()
        {
            return View(new Dispositivo());
        }

        [HttpPost]
        public async Task<ActionResult> Alta(Dispositivo model)
        {
            if (ModelState.IsValid)
            {
                await _servicios.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public  ActionResult Editar(int id)
        {
            var o = _servicios.Get(id);
            return View(o);
        }

        [HttpPost]
        public async Task<ActionResult> Editar(Dispositivo model)
        {
            if (ModelState.IsValid)
            {
                await _servicios.Update(0,model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<ActionResult> Borrar(int id)
        {
            await _servicios.Delete(id);
            return RedirectToAction("Index");
        }
    }
}