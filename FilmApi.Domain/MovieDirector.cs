namespace FilmApi.Domain
{
    using Newtonsoft.Json;

    public class MovieDirector
    {
        public int MovieDirectorId { get; set; }

        public int FilmId { get; set; }
        public int DirectorId { get; set; }

        [JsonIgnore]
        public Film Film { get; set; }

        [JsonIgnore]
        public Director Director { get; set; }
    }
}