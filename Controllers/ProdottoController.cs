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
        public IActionResult Add()
        {

            return View();
        }
    }
}
