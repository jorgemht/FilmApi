namespace FilmApi.Domain
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<MovieCountry> MovieCountries { get; set; }
    }
}
