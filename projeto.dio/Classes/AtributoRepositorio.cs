using System;
using System.Collections.Generic;
using projeto.dio.Interfaces;

namespace projeto.dio
{
    public class AtributoRepositorio : IRepositorio<Atributos>
    {
        private List<Atributos> listaAtributos = new List<Atributos>();
        public void Atualiza(int id, Atributos objeto)
        {
            listaAtributos[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaAtributos[id].Excluir();
        }

        public void Insere(Atributos objeto)
        {
            listaAtributos.Add(objeto);
        }

        public List<Atributos> Lista()
        {
            return listaAtributos;
        }

        public int ProximoId()
        {
            return listaAtributos.Count;
        }

        public Atributos RetornaPorId(int id)
        {
            return listaAtributos[id];
        }
    }
}