using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern_Repository
{
    //POCO plain old C# object

    public class StreamingContent
    {

        public StreamingContent() { }

        public StreamingContent(string title, string description, MaturityRating ageRating, double starRating, int releaseYear, GenreType genre)
        {
            Title = title;
            Description = description;
            AgeRating = ageRating;
            StarRating = starRating;
            ReleaseYear = releaseYear;
            Genre = genre;


        }
        //Full Constructor
        public string Title { get; set; }
        public string Description { get; set; }

        public MaturityRating AgeRating { get; set; }
        public double StarRating { get; set; }
        public int ReleaseYear { get; set; }
        public GenreType Genre{ get; set; }

      

    }

    public enum MaturityRating
    {
        G,
        PG,
        PG13,
        R,
        NC17
    }

    public enum GenreType
    {
        Thriller,
        SciFi,
        Action,
        Drama,
        Horror,
        Mystery,
        Romance,
        RomCom,
        Comedy,
        Documentary,
        Western
    }
}











