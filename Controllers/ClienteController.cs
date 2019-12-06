using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using role_topMVC.Enums;
using role_topMVC.Models;
using role_topMVC.Repositories;
using role_topMVC.ViewModels;

namespace role_topMVC.Controllers
{
    public class ClienteController : AbstractController
    {
        private ClienteRepository clienteRepository = new ClienteRepository();
        private PacoteRepository pacoteRepository = new PacoteRepository();
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
                        switch(cliente.TipoUsuario)
                        {

                        case (uint) TiposUsuario.CLIENTE:
                        HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                        HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);
                        HttpContext.Session.SetString(SESSION_CLIENTE_USUARIO,cliente.TipoUsuario.ToString());
                        return RedirectToAction("Historico","Cliente");
                        default:
                        HttpContext.Session.SetString(SESSION_CLIENTE_EMAIL, usuario);
                        HttpContext.Session.SetString(SESSION_CLIENTE_NOME, cliente.Nome);
                        HttpContext.Session.SetString(SESSION_CLIENTE_USUARIO,cliente.TipoUsuario.ToString());
                        return RedirectToAction("Dashboard","Administrador");
                        }
                        
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
            var pacotes = pacoteRepository.ObterTodosPorCliente(emailCliente);

            return View (new HistoricoViewModel (){
                Pacotes = pacotes,
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
                form["cpf"],
                form["senha"],
                form["email"]
                );

                cliente.TipoUsuario = (uint) TiposUsuario.CLIENTE;
                clienteRepository.Inserir(cliente);


            return View ("Sucesso",new RespostaViewModel()
            {
                NomeView ="Cadastro",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                return View("Erro",new RespostaViewModel()
                {
                NomeView ="Cadastro",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
                });
            }
        }
    }
}