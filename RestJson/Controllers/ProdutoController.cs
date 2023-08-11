using Microsoft.AspNetCore.Mvc;
using RestJson.Models;
using RestJson.Global;

namespace RestJson.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : Controller
    {
        [HttpGet]
        [Route("GetAll")]
       public JsonResult GetAll()
        {
            List<Produto> listProdutos = new List<Produto>();

            try
            {
                listProdutos = Config.listProdutos;

                if(listProdutos.Count > 0)
                {
                    return new JsonResult(new {success = true, produtos =  listProdutos});
                }
                else
                {
                    return new JsonResult(new { success = true, produtos = "0 produtos na lista" });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        [Route("Add")]
        public JsonResult Add(Produto produto)
        {
            try
            {
                Config.listProdutos.Add(produto);
                return new JsonResult(new {success=true, msg = "Produto " + produto.nome + " adicionado com sucesso"});


            }catch(Exception ex) 
            {
                return new JsonResult(new {success = false, msg = ex.Message});
            }
        }


        [HttpPut]
        [Route("Update")]
        public JsonResult Update(Produto produto)
        {
            int idx = -1;

            try
            {
                idx = Config.listProdutos.FindIndex(x => x.id == produto.id);

                if(idx >= 0)
                {
                    Config.listProdutos[idx] = produto;
                    return new JsonResult(new { success = true, msg = "Produto " + produto.id + " alterado com sucesso" });
                }
                else
                {
                    return new JsonResult(new { success = true, msg = "Produto não encontrado " });
                }
            }catch(Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public JsonResult Delete(int id)
        {
            int idx = -1;

            try
            {
                idx = Config.listProdutos.FindIndex(x => x.id == id);

                if (idx >= 0)
                {
                    Config.listProdutos.RemoveAt(idx);
                    return new JsonResult(new { success = true, msg = "Produto " + id + " excluido com sucesso" });
                }
                else
                {
                    return new JsonResult(new { success = true, msg = "Produto não encontrado " });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, msg = ex.Message });
            }
        }
    }
}
