using System;
using Dio.Series.Enums;
using Dio.Series.Model;
using Dio.Series.Repository;

namespace Dio.Series
{
    class Program
    {
        static RepositorySerie repositorySerie = new RepositorySerie();
         private static string Menu()
        {
            Console.WriteLine("Dio - Criando app simples de cadastro de séries em .net");            
            Console.WriteLine("Informe a opção desejada");
            
            Console.WriteLine();
            
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            
            Console.WriteLine();

            string userChoice = Console.ReadLine().ToLower();
            Console.WriteLine();
            return userChoice;
        }

        static void Main(string[] args)
        {
            string userChoice = Menu();

            while(userChoice != "x")
            {
                switch(userChoice)
                {
                    case "1":
                        Console.Clear();
                        ListSeries();
                        break;
                    case "2":
                        Console.Clear();
                        InsertSerie();
                        break;
                    case "3":
                        Console.Clear();
                        UpdateSerie();
                        break;
                    case "4":
                        Console.Clear();
                        DeleteSerie();
                        break;
                    case "5":
                        ViewSeries();
                        break;
                    case "c":
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida");
                        Console.WriteLine("Escolha uma opção do menu");
                        break;
                }
                userChoice = Menu();
            }
        }

        private static void ViewSeries()
        {
            Console.Clear();
            Console.WriteLine("Opção 5 - Visualizar série");
            
            var checklist = CheckList();

            if(!checklist)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            Console.Write("Informe o id da série: ");
			int indexSerie = int.Parse(Console.ReadLine());

			var serie = repositorySerie.GetById(indexSerie);

            Console.Clear();
			Console.WriteLine(serie);
        }

        private static void DeleteSerie()
        {
            Console.Clear();
            Console.WriteLine("Opção 4 - Excluir Serie");

            var checklist = CheckList();

            if(!checklist)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            Console.Write("Informe o id da série: ");
			int indexSerie = int.Parse(Console.ReadLine());

            Console.Clear();
			repositorySerie.Delete(indexSerie);
        }

        private static void UpdateSerie()
        {
            Console.Clear();
            Console.WriteLine("Opção 3 - Atualizar Serie");

            var checklist = CheckList();

            if(!checklist)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            Console.Write("Informe o id da série: ");
			int indexSerie = int.Parse(Console.ReadLine());

			var serie = repositorySerie.GetById(indexSerie);

			Console.WriteLine(serie);
            
            Console.WriteLine("Informe o Título da série: ");
            string newTitle = Console.ReadLine();

            Console.WriteLine("Informe a descrição da série");
            string description = Console.ReadLine();

            Console.WriteLine("Informe o ano de lançamento da série");
            int year = int.Parse(Console.ReadLine());


            Console.WriteLine("Gêneros cadastrados no sistema: ");

            foreach(int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine($"{Enum.GetName(typeof(Gender), i)} - {i}");
            }

            Console.WriteLine("Digite o código do genêro, entre as opções acima: ");
            int numberGender = int.Parse(Console.ReadLine());

            var updateSerie = new Serie(id: indexSerie, gender: (Gender)numberGender, title: newTitle, year: year, description: description);
            
            Console.Clear();
            repositorySerie.Update(indexSerie, updateSerie);
        }

        private static void InsertSerie()
        {       
            Console.Clear();     
            Console.WriteLine("Opção 2 - Nova serie");

            
            Console.WriteLine("Informe o Título da série: ");
            string newTitle = Console.ReadLine();

            Console.WriteLine("Informe a descrição da série");
            string description = Console.ReadLine();

            Console.WriteLine("Informe o ano de lançamento da série");
            int year = int.Parse(Console.ReadLine());


            Console.WriteLine("Gêneros cadastrados no sistema: ");

            foreach(int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine($"Nome: {Enum.GetName(typeof(Gender), i)} - Código: {i}");               
            }

            Console.WriteLine("Digite o código do genêro, entre as opções acima: ");
            int numberGender = int.Parse(Console.ReadLine());

            var newSerie = new Serie(id: repositorySerie.NextId(), gender: (Gender)numberGender, title: newTitle, year: year, description: description);

            Console.Clear();
            repositorySerie.Add(newSerie);
        }

        private static void ListSeries()
        {
            Console.Clear();
            Console.WriteLine("Opção 1 - Listar séries");

            var checklist = CheckList();
            var listSeries = repositorySerie.GetAll();

            if(!checklist)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach(var serie in listSeries)
            {
                var excluded = serie.ReturnExcluded();
                Console.WriteLine($"#ID { serie.ReturnId() } - { serie.ReturnTitle() } { (excluded ? " Série excluído": "" )}");                
            }
            
            Console.WriteLine();
        }

        private static bool CheckList()
        {
            var listSeries = repositorySerie.GetAll();

            if(listSeries.Count == 0)
            {
                return false;
            }
            return true;
        }

    }
}
