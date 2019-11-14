using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using role_topMVC.Models;
using role_topMVC.Repositories;

namespace role_topMVC.Controllers
{
    public class CadastroController : Controller
    {
        ClienteRepository clienteRepository = new ClienteRepository();
        public IActionResult Index () {
            return View ();
        }

        public IActionResult CadastrarCliente (IFormCollection form) {
            ViewData["Action"] = "Cadastro";
            try{
            Cliente cliente = new Cliente (form["nome"],
                form["endereço"],
                form["telefone"],
                form["senha"],
                form["email"],
                DateTime.Parse (form["data-nascimento"]));

                clienteRepository.Inserir(cliente);


            return View ("Sucesso");
            }
            catch(Exception e)
            {
                return View("Erro");
            }
        }
    }
}