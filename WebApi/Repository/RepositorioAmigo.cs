using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Tp3WebApiMarcio.Models;

namespace WebApi.Repository
{
    public class RepositorioAmigo
    {
        public async void Login(string username, string senha)
        {
            var data = new Dictionary<string, string>
            {
                { "grant_type", "password"},
                { "username", username },
                { "password", senha}
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49756/");
                using (var requestContent = new FormUrlEncodedContent(data))
                {
                    var response = await client.PostAsync("/Token", requestContent);
                    if (response.IsSuccessStatusCode)
                    {

                    }
                }
            }
        }

        public async void RegistrarAmigo(Amigo amigo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49756/");
                var response = await client.PostAsJsonAsync("api/Account/Register", amigo);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Usuário cadastrado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Usuário não pode ser cadastrado.");
                }
            }
        }
    }
}