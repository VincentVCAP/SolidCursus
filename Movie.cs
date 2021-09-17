using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start
{
    public class Movie
    {
        public string Title { get; set; }
        public Movie(string title)
        {
            this.Title = title;
        }

        public virtual double RekeningVoor(int AantalDagen)
        {
            return 0;
        }
    }
}
