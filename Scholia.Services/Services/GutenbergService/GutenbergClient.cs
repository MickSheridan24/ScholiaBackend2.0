using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using System.Threading.Tasks;




namespace Scholia.Services.GutenbergService {
    public class GutenbergClient {


        public GutenbergClient() {
          
         }

        public string GutenGet() {
            string endpoint = @"https://swapi.co/api";

            var client = new RestClient(endpoint);
            var request = new RestRequest("/people", Method.GET);
            IRestResponse response = client.Execute(request);
            return response.Content; 
        }
    }
}
