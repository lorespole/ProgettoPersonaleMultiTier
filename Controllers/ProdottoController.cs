using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProgettoPersonaleMultiTier.domain;
using ProgettoPersonaleMultiTier.Models;
using ProgettoPersonaleMultiTier.servizi.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoPersonaleMultiTier.Controllers
{
    public class ProdottoController : Controller
    {
        private readonly ILogger<ProdottoController> _logger;
        private IProdottoServizio _prodottoServizio;
        private ICategoriaServizio _categoriaServizio;
        public ProdottoController(ILogger<ProdottoController> logger, IProdottoServizio prodottoServizio, ICategoriaServizio categoriaServizio)
        {
            _logger = logger;
            _prodottoServizio = prodottoServizio;
            _categoriaServizio = categoriaServizio;
        }
        public IActionResult Index(int prodottoId)
        {
            var prodotto = _prodottoServizio.SearchById(prodottoId);
            ProdottoViewModel model = new ProdottoViewModel();

            model.ProductId = prodotto.ProductId;
            model.ProductName = prodotto.ProductName;
            model.SupplierId = prodotto.SupplierId;
            model.CategoryId = prodotto.CategoryId;
            model.QuantityPerUnit = prodotto.QuantityPerUnit;
            model.UnitPrice = prodotto.UnitPrice;
            model.UnitsInStock = prodotto.UnitsInStock;
            model.UnitsOnOrder = prodotto.UnitsOnOrder;
            model.ReorderLevel = prodotto.ReorderLevel;
            model.Discontinued = prodotto.Discontinued;
            
            return View();
        }
        public IActionResult Save(Prodotto prodotto)
        {
            try
            {
                if (prodotto == null)
                {
                    return View("Error", "Shared");
                }

                _prodottoServizio.Add(prodotto);
                _prodottoServizio.Save(prodotto);
            }
            catch (Exception eccezione)
            {
                RedirectToAction("Error", eccezione.Message, "Home");
            }
            
            return View();
        }
        public IActionResult Update(int prodottoId)
        {
            Prodotto prodotto = new Prodotto();
            var prodottoAggiornato = _prodottoServizio.SearchById(prodottoId);
            prodottoAggiornato.ProductId = prodotto.ProductId;
            prodottoAggiornato.ProductName = prodotto.ProductName;
            prodottoAggiornato.SupplierId = prodotto.SupplierId;
            prodottoAggiornato.CategoryId = prodotto.CategoryId;
            prodottoAggiornato.QuantityPerUnit = prodotto.QuantityPerUnit;
            prodottoAggiornato.UnitPrice = prodotto.UnitPrice;
            prodottoAggiornato.UnitsInStock = prodotto.UnitsInStock;
            prodottoAggiornato.UnitsOnOrder = prodotto.UnitsOnOrder;
            prodottoAggiornato.ReorderLevel = prodotto.ReorderLevel;
            prodottoAggiornato.Discontinued = prodotto.Discontinued;
            _prodottoServizio.Save(prodottoAggiornato);
            return View();
        }
        public IActionResult Delete(Prodotto prodotto)
        {
            try
            {
                if(prodotto != null)
                {
                    _prodottoServizio.Delete(prodotto);
                    RedirectToAction("Index", "Prodotto");
                }
            }
            catch (Exception e)
            {
               RedirectToAction("Error", e.Message.ToString(), "Home");
            }
            return View();
        }
    }
}
