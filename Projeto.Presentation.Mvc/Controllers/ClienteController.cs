using Microsoft.AspNetCore.Mvc;
using Projeto.Presentation.Mvc.Models;
using Projeto.Repository.Entities;
using Projeto.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Mvc.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(ClienteCadastroModel model, [FromServices]ClienteRepository clienteRepository)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    if ((ValidarUsuario(model.Usuario) == "") && (ValidarData(model.DataNascimento) == "")) 
                    { 
                        var cliente = new Cliente();

                        cliente.Nome = model.Nome;
                        cliente.Email = model.Email;
                        cliente.DataNascimento = DateTime.Parse(model.DataNascimento);
                        cliente.Usuario = model.Usuario;
                        cliente.Senha = model.Senha;


                        clienteRepository.Create(cliente);


                        TempData["MensagemSucesso"] = "Você foi cadastrado com Sucesso";
                        ModelState.Clear();
                    }
                }
                catch(Exception e)
                {
                    TempData["MensagemErro"] = "Erro : " + e.Message;
                }
            }

            return View();
        }


        public IActionResult Consulta([FromServices] ClienteRepository clienteRepository)
        {

            var clientes = new List<Cliente>();

            try
            {

                clientes = clienteRepository.GetAll();

            }
            catch(Exception e)
            {
                TempData["MensagemErro"] = "Erro : " + e.Message;
            }

            return View(clientes);
        }


        public string ValidarUsuario(string Usuario)
        {

            string[] nomesIndisponiveis = { "mastercoin", "mc", };

            

            foreach (var sVetor in nomesIndisponiveis)
            {
                if (Usuario.ToLower().Contains(sVetor))
                {
                    throw new Exception("Nome Invalido não pode conter : " + sVetor);
                }
            }

               

            return "";
        }

        public string ValidarData(string DataNascimento)
        {

            if (DateTime.Parse(DataNascimento) > DateTime.Now)
                throw new Exception("Data Invalida");

            return "";

            
        }
    }
}
