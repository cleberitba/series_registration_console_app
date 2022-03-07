using System;

namespace App.Series
{
    class Program
    {
        static serieRepositorio repositorio = new serieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListaSeries();
                        break;

                    case "2":
                        InserirSerie();
                        break;

                    case "3":
                        AtualizaSerie();
                        break;

                    case "4":
                        ExcluirSerie();
                        break;

                    case "5":
                        VisualizarSerie();
                        break;

                    case "6":
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine($"Measured value is {opcaoUsuario}.");
                        break;
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("obrigado por utilizar nossos servicos");
            Console.ReadLine();
        }
        private static void ExcluirSerie()
        {
            Console.Write("Digite o Id da serie:");
            int indiceSerie = int.Parse(Console.ReadLine());
            var lista = repositorio.Lista();

            foreach (var serie in lista)

                if (indiceSerie == serie.retornaId())
                {
                    if (serie.retornaExcluido() != true)
                    {
                        Console.WriteLine("ID:" + serie.retornaId() + " Titulo: " + serie.retornaTitulo());
                        Console.Write("DIGITE 1 PARA EXCLUIR OU 2 PARA NÃO EXCLUIR:");
                        int condicao = int.Parse(Console.ReadLine());
                        if (condicao == 1)
                        {
                            repositorio.Exclui(indiceSerie);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Essa serie ja foi excluido");
                        Console.ReadLine();
                    }
                }

        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da Serie:");
            int indiceSerie = int.Parse(Console.ReadLine());
            var lista = repositorio.Lista();
            if (lista.Count >= indiceSerie)
            {
                var serie = repositorio.RetornaPorId(indiceSerie);
                Console.WriteLine(serie);
                Console.ReadLine();
            }
            else{
            Console.Write("Serie nao  cadastrada");
            Console.ReadLine();
            }

        }
        private static void AtualizaSerie()
        {
            Console.Write("Digita o id da serie:");
            int indiceSerie = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(genero), i));
            }

            Console.Write("digite o genero entre as opcoes acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da serie:");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite Ano de inicio da Serie:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da Serie:");
            string entradaDescricao = Console.ReadLine();


            series atualizaSerie = new series(id: indiceSerie,
                                            genero: (genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);

        }

        private static void InserirSerie()
        {
            Console.WriteLine("inserir nova serie");
            foreach (int i in Enum.GetValues(typeof(genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(genero), i));
            }
            Console.Write("Digite o genero entre opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da serie:");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de inicio da serie:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da serie:");
            string entradaDescricao = Console.ReadLine();

            Console.WriteLine("proximmo id" + repositorio.ProximoId());
            series novaSerie = new series(id: repositorio.ProximoId(),
            genero: (genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao);
            repositorio.Insere(novaSerie);


        }
        private static void ListaSeries()
        {
            Console.WriteLine("listar series");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("nenhuma serie cadastrada");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                if (serie.retornaExcluido() == false)
                    Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido" : ""));
            }
            Console.Write("Aperte enter para continuar");
            Console.ReadLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("App Series!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Lista Series");
            Console.WriteLine("2- Inserir nova Serie");
            Console.WriteLine("3- Atualizar Serie");
            Console.WriteLine("4- Excluir Serie");
            Console.WriteLine("5- Visualizar Serie");
            Console.WriteLine("6- Limpar Tela");
            Console.WriteLine("x- Sair");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}