namespace App.Series

{
    public class series : entidadeBase
    {

        private genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public series(int id, genero genero, string titulo, string descricao, int ano)
        {
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
            this.Id = id;
        }


        public override string ToString()
        {
            string retorno = "";

            retorno += "Id:" + this.Id + Environment.NewLine;
            retorno += "Genero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Inicio: " + this.Ano + Environment.NewLine;        
            retorno += "Excluida: " + (this.Excluido? "Sim":"Não") + Environment.NewLine;
            return retorno;
        }


        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }


        public void Excluir()
        {
            this.Excluido = true;

        }
    }


}
