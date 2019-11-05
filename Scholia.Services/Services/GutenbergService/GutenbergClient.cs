﻿using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.Linq; 
using Scholia.Models;
using System;
using System.Collections.Generic;

namespace Scholia.Services.GutenbergService {
    public class GutenbergClient {

        private string endpoint = "http://gutendex.com/books/";
        private RestClient client; 

        public GutenbergClient() {
            this.client = new RestClient(endpoint);
        }

        public Book GutenGet(int id) {

            var response = Lookup(id);
            var data = ParseLookup(response.Content);
            var text = FetchText(data["path"]);

            var found = new Book() {Title= data["title"], Author= data["author"], Body= text, GutenbergId = id};

            return found; 
        }

        private IRestResponse Lookup (int i) {
            var lookupRequest = new RestRequest(endpoint + i, Method.GET);
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
