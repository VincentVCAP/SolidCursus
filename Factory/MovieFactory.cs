using SOLID_Start.Movies;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Factory
{
    class MovieFactory
    {
        public Movie Create(int movieType, string movieName)
        {
            Movie movie = null;
            if (movieType == 1)
            {
                movie = new RegularMovie(movieName);
            }
            if (movieType == 2)
            {
                movie = new ChildrenMovie(movieName);
            }
            if (movieType == 3)
            {
                movie = new NewReleaseMovie(movieName);
            }

            return movie;
        }      
    }
}
