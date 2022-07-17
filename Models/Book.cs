using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BookShelf_Blazor.Enum;
namespace BookShelf_Blazor.Models
{
    public class Book
    {
        private Blazored.LocalStorage.ISyncLocalStorageService localStorage;
        public string? key { get; set; }
        public string? title { get; set; }
        public int? first_publish_year { get; set; }
        public string? cover_edition_key { get; set; }
        public string? cover
        {
            get { return $"https://covers.openlibrary.org/b/olid/{cover_edition_key}-L.jpg"; }
        }
        public List<string>? author_name { get; set; }
        public List<string>? publisher { get; set; }
        public List<string>? isbn { get; set; }
        public BookStatus? bookStatus {get; set;}
        public DateTime? DateAddToShelf {get;set;}
        public DateTime? DateStartedRead{get;set;}
        public DateTime? DateFinished{get;set;}

        public bool isOnShelf(){
            return localStorage.GetItem<List<Book>>("Books").Any(x => x.key == this.key);
        }
        public async Task<string> getDescription(){
            HttpClient client = new HttpClient();
            var description = "";
            string path = $"https://openlibrary.org/works/{this.key}.json";
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var infoRes = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
                return Convert.ToString(infoRes.description);
            }
            return description;
        }

    }
    
}
