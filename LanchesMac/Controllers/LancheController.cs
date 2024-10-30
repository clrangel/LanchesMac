using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List(string categoria)
        {
            //Consulta para exibir lanche por categoria
            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                //Retorna todos
                lanches = _lancheRepository.Lanches.OrderBy(l => l.Id);
                categoriaAtual = "Todos os lanches";
            }
            else
            {
                if(string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
                {
                    lanches = _lancheRepository.Lanches
                        .Where(l => l.Categoria.CategoriaNome.Equals("Normal"))
                        .OrderBy(l => l.Nome);
                }
                else
                {
                    lanches = _lancheRepository.Lanches
                        .Where(l => l.Categoria.CategoriaNome.Equals("Natural"))
                        .OrderBy(l => l.Nome);
                }
                categoriaAtual = categoria;
            }

            var lanchesListViewModel = new LancheListViewModel
            {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual
            };
            
            return View(lanchesListViewModel);
        }
    }
}
