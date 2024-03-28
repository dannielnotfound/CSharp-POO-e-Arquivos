using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    internal class Cliente
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string cpf { get; set; }

        public Cliente(string name, string email, string cpf)
        {
            this.nome = name;
            this.email = email;
            this.cpf = cpf;
        }

    }
}
