namespace FilmApi.Domain
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class Film
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public decimal Imdb { get; set; }
        public DateTime Year { get; set; }
        public short Duration { get; set; }

        [JsonIgnore]
        public ICollection<MovieDirector> MovieDirectors { get; set; }
        [JsonIgnore]
        public ICollection<MovieCountry> MovieCountries { get; set; }
    }
}
