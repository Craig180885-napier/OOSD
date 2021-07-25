using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackAndTrace
{
    class ID
    {
        private static ID instance;
        private int _nextUserID;
        private int _nextLocationID;
        private ID()
        {
            _nextUserID = 0;
            _nextLocationID = 0;
        }

        public static ID Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ID();
                }
                return instance;
            }
        }

        public int currentUserID()
        {
             return _nextUserID;
        }
        public int currentLocationID()
        {            
            return _nextLocationID;
        }

        public int nextUserID()
        {
            _nextUserID++;
            return _nextUserID;
        }
        public int nextLocationID()
        {
            _nextLocationID++;
            return _nextLocationID;
        }
    }
}
