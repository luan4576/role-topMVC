using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using role_topMVC.Models;
using role_topMVC.Repositories;
using role_topMVC.ViewModels;

namespace role_topMVC.Controllers
{
    public class ClienteController : AbstractController
    {
        private ClienteRepository clienteRepository = new ClienteRepository();
    
        [HttpGet]
        public IActionResult Login () {
            return View (new BaseViewModel()
            {
                NomeView = "Login",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
        }

        [HttpPost]
        
        public IActionResult Login (IFormCollection form)
        
        {
            ViewData["Action"] = "Login";
            try {

                System.Console.WriteLine ("===============");
                System.Console.WriteLine (form["email"]);
                System.Console.WriteLine (form["senha"]);
                System.Console.WriteLine ("===============");

                var usuario = form["email"];
                var senha = form ["senha"];

                var cliente = clienteRepository.ObterPor(usuario);

                if (cliente != null)
                {
                    if(cliente.Senha.Equals(senha))
                    {
                        HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                        HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);
                    

                        return RedirectToAction("Historico","Cliente");
                    }
                    else
                    {
                        return View ("Erro" , new RespostaViewModel("Senha incorreta"));
                    }
                }
                else
                {

                return View ("Erro", new RespostaViewModel($"Usuario{usuario} não foi encontrado"));
                }

            } catch (Exception e) {
                System.Console.WriteLine (e.StackTrace);
                return View ("erro");
            }
        }

        public IActionResult Historico()
        {
            var emailCliente = ObterUsuarioSession();
            var pedidos = pedidoRepository.ObterTodosPorCliente(emailCliente);

            return View (new HistoricoViewModel (){
                Pedidos = pedidos,
                NomeView = "Historico",
                UsuarioNome = ObterUsuarioNomeSession(),
                UsuarioEmail = ObterUsuarioSession()
            });
        }

        public IActionResult Logoff()
        {
            HttpContext.Session.Remove(SESSION_CLIENTE_EMAIL);
            HttpContext.Session.Remove(SESSION_CLIENTE_NOME);
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");

        }

        public IActionResult Index () {
            return View (new BaseViewModel()
                {
                    NomeView ="cadastro",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                }
            );
        }

        public IActionResult CadastrarCliente (IFormCollection form) {
            ViewData["Action"] = "Cadastro";
            try{
            Cliente cliente = new Cliente (form["nome"],
                form["Cpf"],
                form["senha"],
                form["email"]
                );

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