using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Correios;

namespace Projeto.Web.Correios.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Index(string cep)
        {
            var service = new CorreiosApi();

            try
            {
                var dados = (await service.consultaCEPAsync(cep)).@return;

                if (dados.cep != "")
                {
                    string endereco = dados.end;
                    string bairro = dados.bairro;
                    string cidade = dados.cidade;
                    string cepRetorno = dados.cep;
                    string complemento = dados.complemento;
                    string complemento2 = dados.complemento2;
                    string estado = dados.uf;

                    TempData["endereco"] = endereco;
                    TempData["bairro"] = bairro;
                    TempData["cidade"] = cidade;
                    TempData["cep"] = cepRetorno;
                    TempData["complemento"] = complemento;
                    TempData["complemento2"] = complemento2;
                    TempData["estado"] = estado;
                }
                else
                {
                    TempData["erro"] = "erro";
                }

                return View();
            }
            catch (Exception)
            {
                TempData["erro"] = "erro";
                return View();
            }

        }



    }
}