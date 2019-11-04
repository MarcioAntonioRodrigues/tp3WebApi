using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Tp3WebApiMarcio.Models;
using WebApi.Repository;

namespace ConsoleAmigo
{
    class Program
    {
        static void Main(string[] args)
        {
            Action();


            using (var apiClient = new HttpClient())
            {
                var mediaType = new MediaTypeWithQualityHeaderValue("application/json");

                apiClient.BaseAddress = new Uri("http://localhost:49756");
                apiClient.DefaultRequestHeaders.Accept.Add(mediaType);

                var message = apiClient.GetAsync("api/amigos").Result;

                if(message.IsSuccessStatusCode)
                {
                    Console.Write(message.Content.ReadAsStringAsync().Result);
                }
            }
        }

        //START
        public static void Start()
        {
            Escrever("Seleciona uma das opções abaixo"+
                        "1 - Registre-se"+
                        "2 - Logar");
        }

        //ACTIONS
        public static void Action()
        {
            Console.Clear();
            Start();
            var option = Ler();
            if (option == "1")
            {
                RegistrarAmigo();
            }
            if (option == "2")
            {
                Login();
            }
            Action();
        }

        //LOGIN
        public static void Login()
        {
            Amigo amigo = new Amigo();
            Escrever("Insira o seu e-mail");
            var login = Ler();
            Escrever("Insira sua senha");
            var senha = Ler();
            RepositorioAmigo repositorio = new RepositorioAmigo();
            repositorio.Login(login, senha);
        }

        //REGISTER
        public static void RegistrarAmigo()
        {
            Amigo amigo = new Amigo();
            Escrever("Digite seu nome");
            amigo.Nome = Ler();
            Escrever("Digite seu sobrenome");
            amigo.Sobrenome = Ler();
            Escrever("Digite seu e-mail");
            amigo.Email = Ler();
            Escrever("Digite seu telefone");
            amigo.Telefone = Ler();
            Escrever("Digite seu aniversário");
            amigo.Aniversario = DateTime.Parse(Ler());

            RepositorioAmigo repositorio = new RepositorioAmigo();
            repositorio.RegistrarAmigo(amigo);
        }


        //GENERIC FUNCTIONS
        public static void Escrever(string msg)
        {
            Console.WriteLine(msg);
        }

        public static string Ler()
        {
            return Console.ReadLine();
        }
    }
}
