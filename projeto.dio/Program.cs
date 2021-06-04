using System;
using projeto.dio;

namespace projeto.dio
{
    class Program
    {
        static AtributoRepositorio repositorio = new AtributoRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    InserirGasto();                      
                        break;

                    case "2":
                    listaAtributos();
                        break;

                    case "3":
                    AtualizarGasto();
                        break;
                    //case "3.1":
                    //Gostaria de adicionar a soma de todos os gastos
                    
                    case "4":
                    VisualizarGasto();
                        break;
                    
                    case "5":
                    ExcluirGasto();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void listaAtributos()
        {
            Console.WriteLine("Listar Gastos: ");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum gasto cadastrado. ");
                return;
            }

            foreach (var atributo in lista)
            {
                var excluido = atributo.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", atributo.retornaid(), atributo.retornaGasto(), (excluido ? "*Excluído*" : ""));
                //No futuro, como é um gasto gostaria que listasse o valor.
            }
        }
        
        private static void InserirGasto()
            {
                Console.WriteLine("Descreva o nome do novo gasto:");
                string entradaDescricao = Console.ReadLine();

                Console.WriteLine("Inserir a data da compra:" );
                string entradaData = Console.ReadLine();

                Console.WriteLine("Digite o valor do seu gasto: ");
                
                if (decimal.TryParse(Console.ReadLine(), out decimal valor))
                {
                decimal entradaValor = valor;

                Atributos novoAtributos = new Atributos(id: repositorio.ProximoId(),
                                                        Data: entradaData,
                                                        Descricao: entradaDescricao,
                                                        valor: entradaValor);

                repositorio.Insere(novoAtributos);
                }
            }

        private static void AtualizarGasto()
            {
                Console.WriteLine("Digite o id do gasto: ");
                int indiceGasto = int.Parse(Console.ReadLine());

                Console.WriteLine("Descreva o nome do novo gasto:");
                string entradaDescricao = Console.ReadLine();

                Console.WriteLine("Inserir a data da compra:" );
                string entradaData = Console.ReadLine();

                Console.WriteLine("Digite o valor do seu gasto: ");
                    
                if (decimal.TryParse(Console.ReadLine(), out decimal valor))
                {
                decimal entradaValor = valor;

                Atributos atualizaAtributos = new Atributos(id: indiceGasto,
                                                            Data: entradaData,
                                                            Descricao: entradaDescricao,
                                                            valor: entradaValor);

                    repositorio.Atualiza(indiceGasto, atualizaAtributos);
                }
            }

        private static void ExcluirGasto()
        {
            Console.WriteLine("Digite o id do Gasto:");
            int indiceGasto = int.Parse(Console.ReadLine());
            //Como acrescentar a pergunta se o usuário deseja mesmo excluir esse registro?

            repositorio.Exclui(indiceGasto);
        }        

        private static void VisualizarGasto()
        {
            Console.Write("Digite o id do Gasto: ");
            int indiceGasto = int.Parse(Console.ReadLine());
            
            var Gasto = repositorio.RetornaPorId(indiceGasto);

            Console.WriteLine(Gasto);
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Control Controle Financeiro a seu dispor!");        
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Inserir novo gasto: ");
            Console.WriteLine("2 - Listar Gastos: ");
            Console.WriteLine("3 - Atualizar Gasto: ");
            //Console.WriteLine("3.1 - Calcular Gastos totais: ");
            Console.WriteLine("4 - Visualizar Gasto: ");
            Console.WriteLine("5 - Exluir Gasto: ");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
