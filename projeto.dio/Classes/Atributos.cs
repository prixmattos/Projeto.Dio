using System;

namespace projeto.dio
{
    public class Atributos : EntidadeBase
    {
        //Será que vale a pena ao invés da data, colocar o número do mês? Assim não corre o risco
        //do usuário escrever a data em formatos diferentes
        private string Data { get; set; }
        private string Descricao {get; set; }
        private decimal valor {get; set;}
        private bool Excluido {get; set; }
        
        //Depois quero tentar acrescentar o Tipo de Gasto, para conseguir colocar vários gastos num tipo único.
        //Ex: Lazer, Alimentação.
        //A descrição é mais para a pessoa lembrar o que comprou. Ex: Viajem para Bahia, seria Lazer. 
        public Atributos(int id, string Data, string Descricao, decimal valor)
        {
            this.id = id;
            this.Data = Data;
            this.Descricao = Descricao;
            this.valor = valor;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Data da compra: " + this.Data + Environment.NewLine;
            retorno += "Valor da compra: " + this.valor + Environment.NewLine;
            retorno += "Excluído? " + this.Excluido + Environment.NewLine;
            return retorno;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }

        public int retornaid()
        {
            return this.id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public string retornaGasto()
        {
            return this.Descricao;
        }
    }
}