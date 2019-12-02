using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using role_topMVC.Models;
using role_topMVC.Repositories;
using role_topMVC.ViewModels;


namespace role_topMVC.Controllers
{
    public class PacoteController : AbstractController
    {
        PacoteRepository pacoteRepository = new PacoteRepository();
        ClienteRepository clienteRepository = new ClienteRepository();

        public IActionResult Index()
        {
            
            PacoteViewModel pedido = new PacoteViewModel();


            var usuarioLogado = ObterUsuarioSession();
            var nomeUsuarioLogado = ObterUsuarioNomeSession();
            if(!string.IsNullOrEmpty(nomeUsuarioLogado))
            {
                pedido.NomeUsuario = nomeUsuarioLogado;
            }

                var clienteLogado = clienteRepository.ObterPor(usuarioLogado);
                if(clienteLogado !=null)
                {
                    pedido.cliente = clienteLogado;
                }


                pedido.NomeUsuario ="Pedido";
                pedido.UsuarioEmail = ObterUsuarioSession();
                pedido.UsuarioNome = ObterUsuarioNomeSession();
                return View(pedido);
        }
  
         public IActionResult Registrar(IFormCollection form)
        {
            Pacote pacote = new Pacote();


            Cliente cliente = new Cliente()
            {
                Nome = form ["nome"],
                Email = form ["email"],
                Cpf = form ["cpf"]
            };

            pacote.Cliente = cliente;

            pacote.DataDoContrato = DateTime.Now;

            pacote.PrecoTotal = pacote.PrecoTotal;

            if(pacoteRepository.Inserir(pacote))
            {

            return View("Sucesso", new RespostaViewModel()
            {
                Mensagem = "Aguarde a aprovaçao dos nossos administradores",
                NomeView = "Sucesso",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
            }
            else{
                return View("Erro", new RespostaViewModel()
            {
                Mensagem = "Houve um erro ao processar seu pedido. Tente novamente",
                NomeView = "Erro",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
            }

            
        }
    }
}