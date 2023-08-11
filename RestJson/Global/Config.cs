using RestJson.Models;

namespace RestJson.Global
{
    public class Config
    {
        public static List<Produto> listProdutos = new List<Produto>();

        public static void GerarProdutos()
        {
            Produto produto = new Produto();

            produto.id = 1;
            produto.nome = "Mesa";
            produto.price = 100.5f;
            produto.quantity = 1;
            produto.description = "Produto teste 1";

            listProdutos.Add(produto);

            produto = new Produto();

            produto.id = 2;
            produto.nome = "Cadeira";
            produto.price = 75.83f;
            produto.quantity = 20;
            produto.description = "Produto teste 2";

            listProdutos.Add(produto);

        }
    }
}
