using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CL2.Models
{
    public class Libro
    {
        [DisplayName("CODIGO")]
        public int codigo { get; set; }

        [DisplayName("AUTOR")]
        public string autor { get; set; }

        [DisplayName("TITULO")]
        public string titulo { get; set; }

        [DisplayName("EDITORIAL")]
        public string editorial { get; set; }

        [DisplayName("PRECIO")]
        public double costo { get; set; }

        [DisplayName("CANTIDAD")]
        public int cantidad { get; set; }

        [DisplayName("FOTO")]
        public string foto { get; set; }
    }
}