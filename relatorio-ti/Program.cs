using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;

namespace relatorio_ti
{
   

    internal class Program
    {
        public List<Produto> produtos = new List<Produto>();
        public Program() 
        {
            this.produtos = ReadFile();
        }    
        static void Main(string[] args)
        {
            Program program = new Program();

            double averageProductsPrice = program.AverageProductsPrice();
            Console.WriteLine("A média dos preços dos produtos é " + averageProductsPrice.ToString("C", CultureInfo.CurrentCulture) + "\n\r");
           
            List<Produto> productsGreaterThan700 = program.ProductsGreaterThan(700);

            Console.WriteLine("\n\rOs produtos com preço superior a R$ 700,00 são: \n\r");
            foreach (var produto in productsGreaterThan700)
            {
                Console.WriteLine(" -- " + produto.ProductName + " - " + produto.ProductPrice.ToString("C", CultureInfo.CurrentCulture) + "\n\r");
            }

            Console.WriteLine("\n\r");
            

            List<Produto> periphalCategoryProducts = program.GetProductsInPeripheralCategory();
            double totalPeriphalCategoryProducts = program.SumValuesFromList(periphalCategoryProducts);

            Console.WriteLine("Os produtos presentes na categoria \"periféricos\" são: \n\r");
            foreach (var produto in periphalCategoryProducts)
            {
                Console.WriteLine(" -- " + produto.ProductName + " - " + produto.ProductPrice.ToString("C", CultureInfo.CurrentCulture) + "\n\r");
            }

            Console.WriteLine("O total dos produtos da categoria de periféricos é de " + totalPeriphalCategoryProducts.ToString("C", CultureInfo.CurrentCulture));

            Console.WriteLine("\n\r");

            List<Produto> productsSmallerThan100 = program.ProductsSmallerThan(100);

            if (productsSmallerThan100.Count > 0)
            {
                Console.WriteLine("Existem " + Convert.ToString(productsSmallerThan100.Count) + " com valores menores que R$ 100,00: \n\r");
                foreach (var produto in productsSmallerThan100)
                {

                    Console.WriteLine(" -- " + produto.ProductName + " - " + produto.ProductPrice.ToString("C", CultureInfo.CurrentCulture) + "\n\r");
                }

            }

        }

        public List<Produto> ReadFile()
        {
            string[] vetorProdutos;
            List<Produto> produtos = new List<Produto>();

            // Ler arquivo
            string path = "C:\\Users\\danieloliveira\\OneDrive - Grupo Unimaq\\Documents\\Faculdade\\3 Termo\\PDS\\relatorio-ti\\files\\relatorio-ti.txt";
            TextReader file = new StreamReader(path);

            string text = file.ReadLine();

            while (text != null)
            {
                Produto produto = new Produto();

                vetorProdutos = text.Split(',');

                produto.ProductName = vetorProdutos[0];
                produto.ProductCategory = vetorProdutos[1];
                produto.ProductPrice = Convert.ToDouble(vetorProdutos[2].Replace("R$", ""));

                produtos.Add(produto);

                text = file.ReadLine();
            }

            return produtos;
        }
        public  double AverageProductsPrice()
        {
            double productPrice = 0;
            double averageProductsPrice;

            int countProducts = this.produtos.Count; 

            foreach (Produto product in this.produtos)
            {
                productPrice += product.ProductPrice;
            }

            averageProductsPrice = productPrice / countProducts;

            return averageProductsPrice;

        }

        public  List<Produto> ProductsGreaterThan(int value)
        {
            List<Produto> filteredProducts = this.produtos.Where(produto => produto.ProductPrice > value).ToList();

            return filteredProducts;
        }

        public List<Produto> GetProductsInPeripheralCategory()
        {
            List<Produto> filteredProducts = this.produtos.Where(produto => produto.ProductCategory == "Periféricos").ToList();

            return filteredProducts;
        }

        public double SumValuesFromList(List<Produto> produtos) 
        {
            double total = 0;
            foreach (var produto in produtos)
            {
                total += produto.ProductPrice;
            }

            return total;
        }

        public List<Produto> ProductsSmallerThan(int value)
        {
            List<Produto> filteredProducts = this.produtos.Where(produto => produto.ProductPrice < value).ToList();

            return filteredProducts;
        }


    }
}
