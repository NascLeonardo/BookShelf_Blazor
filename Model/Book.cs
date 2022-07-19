using BookShelf_Blazor.Enums;
using Newtonsoft.Json;

namespace BookShelf_Blazor.Model
{
    public class Book
    {

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
        public BookStatus? bookStatus { get; set; }
        public DateTime? DateAddToShelf { get; set; }
        public DateTime? DateStartedRead { get; set; }
        public DateTime? DateFinished { get; set; }
        public int rating { get; set; }

        public async Task<string> getDescription()
        {
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
