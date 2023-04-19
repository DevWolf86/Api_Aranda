using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Aranda.Models
{
    public class productos
    {
            public int idproducto { get; set; }
            public string nombreproducto { get; set; }
            public int idcategoria { get; set; }
            public int idimagen { get; set; }
            
        
    }
}