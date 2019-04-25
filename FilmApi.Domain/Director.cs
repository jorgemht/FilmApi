namespace FilmApi.Domain
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Director
    {
        public int DirectorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [JsonIgnore]
        public ICollection<MovieDirector> MovieDirectors { get; set; }
    }
}
