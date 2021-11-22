using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoPersonaleMultiTier.Models
{
    public class ProdottoListaViewModel
    {
        public List<ProdottoViewModel> ProdottoLista { get; set; }

        public ProdottoListaViewModel()
            {
                this.ProdottoLista = new List<ProdottoViewModel>();
            }
    }
}
