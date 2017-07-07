using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QCPhantom.Domain.Other
{
    public class UriQuery
    {
        #region "Fields"

        private Uri uri;

        #endregion

        #region "Constructors"

        public UriQuery(string uri)
        {
            this.uri = new Uri(uri);
        }

        #endregion

        #region "Properties"



        #endregion

        #region "Methods"

        public string GetParam(string name)
        {
            string query = uri.Query;
            return query;
        }

        #endregion

        #region "Abstract/Virtual Methods"



        #endregion

        #region "Inherited Methods"



        #endregion

        #region "Static Methods"



        #endregion

        #region "Operators"



        #endregion
    }
}
