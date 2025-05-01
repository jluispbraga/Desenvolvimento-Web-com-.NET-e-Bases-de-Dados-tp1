using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace RazorPagesApp.Pages
{
    public class IndexModel : PageModel
    {
        public string Nome { get; set; }
        public List<Produto> Produtos { get; set; }

        public IndexModel()
        {
            Produtos = new List<Produto>();
            Nome = "Produto Default";
        }

        public void OnGet()
        {
            Produtos.Add(new Produto { Nome = "Produto 1", Preco = 10.0m });
            Produtos.Add(new Produto { Nome = "Produto 2", Preco = 20.0m });
            Produtos.Add(new Produto { Nome = "Produto 3", Preco = 30.0m });
        }
    }
    
    public class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}