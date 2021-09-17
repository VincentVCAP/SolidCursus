using SOLID_Start.Movies;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Factory
{
    class MovieFactory
    {
        public Movie Create(string type, string movieName)
        {
            try
            {
                Movie m = (Movie)Activator.CreateInstance(Type.GetType($"SOLID_Start.Movies.{type}"), new Object[] { movieName });
                return m;
            }
            catch (Exception)
            {
                return new NullMovie(movieName);
            }
        }      
    }
}
