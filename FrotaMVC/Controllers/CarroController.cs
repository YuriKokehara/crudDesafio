using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrotaMVC.Models;
using FrotaMVC.Repositorio;

namespace FrotaMVC.Controllers
{
    public class CarroController : Controller
    {
        private CarroRepositorio _repositorio;

        
        public ActionResult ObterCarros()
        {
            _repositorio = new CarroRepositorio();
            var carros = _repositorio.ListarCarros();
            ModelState.Clear();
            
            return View(carros);
        }

        
        public ActionResult IncluirCarro()
        {
            return View(new Carros());
        }

        [HttpPost]
        public ActionResult IncluirCarro(Carros carroObj)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _repositorio = new CarroRepositorio();

                    if(_repositorio.AdicionarCarro(carroObj))
                    {
                        ViewBag.Mensagem = "Carro cadastrado com sucesso.";
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return View("ObterCarros");
            }
        }

        
        public ActionResult EditarCarro(int id)
        {
            _repositorio = new CarroRepositorio();
            var carro = _repositorio.ListarCarros().Find(t => t.IdCarro == id);
            return View(carro);
        }

        [HttpPost]
        public ActionResult EditarCarro(Carros carroObj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio = new CarroRepositorio();
                    _repositorio.AtualizarCarro(carroObj);
                }

                return RedirectToAction("ObterCarros");
            }
            catch (Exception)
            {
                return View("ObterCarros");
            }
        }

        public ActionResult ExcluirCarro(int id)
        {
            try 
            {
                _repositorio = new CarroRepositorio();
                if (_repositorio.ExcluirCarro(id))
                {
                    ViewBag.Mensagem = "Carro excluído com sucesso.";
                }
                return RedirectToAction("ObterCarros");
            }
            catch (Exception)
            {
                return View("ObterCarros");
            }
        }
    }
}