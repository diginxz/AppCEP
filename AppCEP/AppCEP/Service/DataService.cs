using AppCEP.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;

namespace AppCEP.Service
{
    public class DataService
    {
        public static async Task<Endereco> GetEnderecoByCep(string cep)
        {
            Endereco end;
            using (HttpClient client= new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/endereco/by-cep?cep=" + cep);
                
                if (response.IsSuccessStatusCode)
                { 
                    string json = response.Content.ReadAsStringAsync().Result;
                    
                    end = JsonConvert.DeserializeObject<Endereco>(json);
                }
                else
                {
                    throw new Exception(response.RequestMessage.Content.ToString());
                }
                return end;
            }
        public static async Task<List<Bairro>> GetBairroByIdCidade(int id_cidade)
            
            {
                List<Bairro> arr_bairros = new List<Bairro>();
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/bairro/by-cidade?id_cidade" + id_cidade);


                    if (response.IsSuccessStatusCode)
                    {
                        string json = response.Content.ReadAsStringAsync().Result;

                        arr_bairros = JsonConvert.DeserializeObject<List<Bairro>>(json);
                    }
                    else
                        throw new Exception(response.RequestMessage.Content.ToString());
                }
                return arr_bairros;
            }
        public static async Task<List<Bairro>> GetLougradourosByBairroAndIdCidade(string bairro, int id_cidade)
            
            {
                List<Bairro> arr_bairros = new List<Bairro>();
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync("https://cep.metoda.com.br/bairro/by-cidade?id_cidade" + id_cidade);


                    if (response.IsSuccessStatusCode)
                    {
                        string json = response.Content.ReadAsStringAsync().Result;

                        arr_bairros = JsonConvert.DeserializeObject<List<Bairro>>(json);
                    }
                    else
                        throw new Exception(response.RequestMessage.Content.ToString());
                }
                return arr_bairros;
            }
        }
    }
