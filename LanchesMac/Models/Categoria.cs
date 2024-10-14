namespace LanchesMac.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string CategoriaNome { get; set; }
        public string Descricao { get; set; }

        public List<Lanche> Lanches { get; set;} = new List<Lanche>();

        //Usando o ICollection.
        //public ICollection<Lanche> Lanches { get; set;} = new List<Lanche>();

        public Categoria()
        {
        }

        public Categoria(int id, string categoriaNome, string descricao)
        {
            Id = id;
            CategoriaNome = categoriaNome;
            Descricao = descricao;
        }

    }
}
