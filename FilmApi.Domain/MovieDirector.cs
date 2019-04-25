namespace FilmApi.Domain
{
    using Newtonsoft.Json;

    public class MovieDirector
    {
        public int MovieDirectorId { get; set; }

        public int FilmId { get; set; }
        public int CountryId { get; set; }

        [JsonIgnore]
        public Film Film { get; set; }

        [JsonIgnore]
        public Country Country { get; set; }
    }
}