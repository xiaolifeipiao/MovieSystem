using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovie.Model
{
    class MoviePlayInfo
    {

        public MoviePlayInfo()
		{}
		#region Model
        private int? _id;

        public int? Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _moviename;

        public string Moviename
        {
            get { return _moviename; }
            set { _moviename = value; }
        }

        private string _screeningroomname;

        public string Screeningroomname
        {
            get { return _screeningroomname; }
            set { _screeningroomname = value; }
        }


        private DateTime? _movietime;

        public DateTime? Movietime
        {
            get { return _movietime; }
            set { _movietime = value; }
        }
        private int? _movielength;

        public int? Movielength
        {
            get { return _movielength; }
            set { _movielength = value; }
        }

       
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        #endregion
    }
}
