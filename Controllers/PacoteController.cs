using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using role_topMVC.Enums;
using role_topMVC.Models;
using role_topMVC.Repositories;
using role_topMVC.ViewModels;


namespace role_topMVC.Controllers
{
    public class PacoteController : AbstractController
    {
        PacoteRepository pacoteRepository = new PacoteRepository();
        ContratoRepository contratoRepository = new ContratoRepository();
        ClienteRepository clienteRepository = new ClienteRepository();

        public IActionResult Index()
        {
            var contratos = contratoRepository.ObterTodos();
            
            PacoteViewModel pacote = new PacoteViewModel();

            pacote.Contratos = contratos;

            var usuarioLogado = ObterUsuarioSession();
            var nomeUsuarioLogado = ObterUsuarioNomeSession();
            if(!string.IsNullOrEmpty(nomeUsuarioLogado))
            {
                pacote.NomeUsuario = nomeUsuarioLogado;
            }

                var clienteLogado = clienteRepository.ObterPor(usuarioLogado);
                if(clienteLogado !=null)
                {
                    pacote.cliente = clienteLogado;
                }


                pacote.NomeUsuario ="Pacote";
                pacote.UsuarioEmail = ObterUsuarioSession();
                pacote.UsuarioNome = ObterUsuarioNomeSession();
                return View(pacote);
        }
  
        public IActionResult Registrar(IFormCollection form)
        {
            Pacote pacote = new Pacote();

            Contrato contrato = new Contrato();
            var nomeContrato = form["contrato"];
            contrato.Nome = nomeContrato;
            contrato.Preco = contratoRepository.ObterPrecoDe(nomeContrato);
            pacote.Contrato = contrato;


            Cliente cliente = new Cliente()
            {
                Nome = form ["nome"],
                Email = form ["email"],
                Cpf = form ["cpf"],
                NumeroCartao = form["numeroCartao"],
                SenhaCartao = form["senhaCartao"]
            };

            pacote.Cliente = cliente;

            pacote.DataContrato = DateTime.Now;

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
            

            public IActionResult Aprovar(ulong id)
        {
            Pacote pacote  = pacoteRepository.ObterPor(id);
            pacote.Status = (uint) StatusPacote.APROVADO;

            if (pacoteRepository.Atualizar(pacote))
            {
                return RedirectToAction("Dashboard","Administrador");
            }
            else
            {
                return View("Erro", new RespostaViewModel()
            {
                Mensagem = "Houve um erro ao aprovar seu pedido",
                NomeView = "Dashboard",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
            
            }
        }

        public IActionResult Reprovar(ulong id)
        {
            Pacote pacote  = pacoteRepository.ObterPor(id);
            pacote.Status = (uint) StatusPacote.REPROVADO;

            if (pacoteRepository.Atualizar(pacote))
            {
                return RedirectToAction("Dashboard","Administrador");
            }
            else
            {
                return View("Erro", new RespostaViewModel()
            {
                Mensagem = "Houve um erro ao reprovar seu pedido",
                NomeView = "Dashboard",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            });
            
            }
        }

            
        }
    }

