using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.Linq; 
using Scholia.Models;
using System;
using System.Collections.Generic;

namespace Scholia.Services.GutenbergService {
    public class GutenbergClient {

        private string gutenbergEndpoint = "http://gutendex.com/books/";
        private string gutenAPIEndpoint = "http://gutendex.com/books";
        private RestClient client;
        private RestClient apiClient; 

        public GutenbergClient() {
            this.client = new RestClient(gutenbergEndpoint);
            this.apiClient = new RestClient(gutenAPIEndpoint);
        }

        public Book GutenGet(int id) {

            var response = Lookup(id);
            var data = ParseLookup(response.Content);
            var text = FetchText(data["path"]);

            var found = new Book() {Title= data["title"], Author= data["author"], Body= text, GutenbergId = id};

            return found; 
        }

        public Dictionary<Object, Object> GutenSearch(string query) {

            var request = new RestRequest(gutenAPIEndpoint + "?search=" + query);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = client.Execute(request).Content;

            return ParseSearch(response);
        }

        private Dictionary<Object, Object> ParseSearch(string response) {
            JObject jObject = JObject.Parse(response);

            var resp = new Dictionary<Object, Object>();
            if (jObject.Value<int>("count") > 0) {
                var results = jObject["results"];

                var serialized = new List<Dictionary<string, string>>();

                foreach (var result in results) {

                    var package = new Dictionary<string, string>() {
                    { "id", result.Value<string>("id") },
                    { "title", result.Value<string>("title") } };
                    package["author"] = result["authors"].FirstOrDefault().Value<string>("name");

                    serialized.Add(package);
                }
                resp["success"] = "true";
                resp["results"] = serialized;
            } else {
                resp["success"] = "false";
            }
            return resp;
        }

        private IRestResponse Lookup (int i) {
            var lookupRequest = new RestRequest(gutenbergEndpoint + i, Method.GET);
            lookupRequest.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            return client.Execute(lookupRequest);
        }

        private Dictionary<string,string> ParseLookup(string response) {

            var ret = new Dictionary<string, string>();
            JObject jObject = JObject.Parse(response);
            ret["title"] = jObject.Value<string>("title");
            ret["author"] = GetAuthor(jObject);
            ret["path"] = CleanPath(GetTextFile(jObject));
            return ret; 
        }

        private string GetAuthor(JObject jObject) {
            if (jObject.ContainsKey("authors") && jObject["authors"].First() != null) {
                return jObject["authors"].First().Value<string>("name");
            }
            return "No Author";
        }

        private string GetTextFile(JObject jObject) {

            
            if (jObject.ContainsKey("formats")) {

                var formats = jObject["formats"];

                var key = formats.FirstOrDefault(f => {
                    JProperty prop = f.ToObject<JProperty>();
                    return prop.Name.StartsWith("text/plain");
                }).ToObject<JProperty>().Name;
                var value = jObject["formats"].Value<string>(key);
                return value;
            }
            return "";
        }

        private string CleanPath(string path) {
            if (path.EndsWith(".zip")) {
                return path.Remove(path.Length - 4) + ".txt";
            }
            return path;
        }

        private string FetchText(string path) {
            var fetchRequest = new RestRequest(path, Method.GET);
            fetchRequest.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            var response = client.Execute(fetchRequest);

            return response.Content;
        }

      

    }
}
