using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Boutique.DataAcces
{
    public class Conection
    {

        protected string _cadena = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

    }
}
