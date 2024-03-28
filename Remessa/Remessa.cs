using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    internal class Remessa   
    {
        public Cliente cliente { get; set; }
        public double valor { get; set; }

        public Remessa(Cliente cliente, double valor)
        {
            this.cliente = cliente;
            this.valor = valor;
        }

      
    }
}
