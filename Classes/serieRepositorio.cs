using System;

using System.Collections.Generic;


namespace App.Series
{
    public class serieRepositorio : IRepositorios<series>
    {
        private List<series> listaSerie= new List<series>();
        public void Atualiza(int id, series objeto)
        {
         listaSerie[id]=objeto;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(series objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<series> Lista()
        {
           return listaSerie;

        }
        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public series RetornaPorId(int id)
        {
           return listaSerie[id];
        }
    }
}