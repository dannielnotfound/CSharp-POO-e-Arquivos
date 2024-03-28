using System.Globalization;
using System.Text.RegularExpressions;

namespace P1
{
    internal class Program
    {
        private string path = "C:\\Users\\danieloliveira\\OneDrive - Grupo Unimaq\\Documents\\Faculdade\\3 Termo\\PDS\\P1\\files\\p1parte1.txt";
        private List<Cliente> clientes = new List<Cliente>();
        private List<Remessa> remessas = new List<Remessa>();

        public Program()
        {
            this.ReadFile();
        }
        static void Main(string[] args)
        {
            Program program = new Program();

            double total = program.ValorTotal();
            Console.WriteLine("A soma total dos valores de todas as remessas é de " + total.ToString("C", CultureInfo.CurrentCulture) + "\n\b");


            double media = program.Media();
            Console.WriteLine("A média aritmética de todas as remessas é de " + media.ToString("C", CultureInfo.CurrentCulture) + "\n\b");


            List<Remessa> remessasMaioresQue5000 = program.ValoresMaiores5000();
            Console.WriteLine("Os remessas com valores maiores que o montante de R$ 5.000,00 são: \n\b");

            foreach (Remessa remessa in remessasMaioresQue5000)
            {
                Console.WriteLine("  - " + remessa.cliente.nome + " - " + remessa.valor.ToString("C", CultureInfo.CurrentCulture));
            }

        }


        private Double ValorTotal()
        {
            double total = 0;

            foreach (Remessa remessa in remessas)
            {
                total += remessa.valor;
            }

            return total;
        }

        private Double Media()
        {
            double total = 0;
            int count = this.remessas.Count;

            foreach (Remessa remessa in remessas)
            {
                total += remessa.valor;
            }

            return Math.Round(total / count);
        }

        private List<Remessa> ValoresMaiores5000()
        {
            List<Remessa> valoresMaiores5000 = this.remessas.Where(remessa => remessa.valor > 5000).ToList();

            return valoresMaiores5000;
        }

        private void ReadFile()
        {
            string cpf;
            string nome;
            string email;
            double valor;
            string[] dados = [];
            TextReader reader = new StreamReader(this.path);
            string line = reader.ReadLine();
            List<Cliente> clientes = new List<Cliente>();
            List<Remessa> remessas = new List<Remessa>();
            List<Object> objects = new List<Object>();
            
            while (line != null)
            {

                if (line.StartsWith('9'))
                {   
            
                    cpf = line.Substring(0, line.IndexOf('-') + 3).Trim();
                    nome = line.Substring(line.IndexOf("-") + 3, line.IndexOf('&') - line.IndexOf("-") - 3).Trim();
                    email = line.Substring(line.IndexOf("&") + 1, line.IndexOf('#') - line.IndexOf("&") - 1).Trim();
                    valor = Convert.ToDouble(line.Substring(line.IndexOf("#") + 1).Trim());

                    Cliente cliente = new Cliente(nome, email, cpf);
                    Remessa remessa = new Remessa(cliente, valor);

                    clientes.Add(cliente);
                    remessas.Add(remessa);
                }


                line = reader.ReadLine();
            }

            this.clientes = clientes;
            this.remessas = remessas;

        }



    }
}
