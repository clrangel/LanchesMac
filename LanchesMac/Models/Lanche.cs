namespace LanchesMac.Models
{
    public class Lanche
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoDetalhada { get; set; }
        public double Preco { get; set; }
        public string ImagemUrl { get; set; }
        public string ImagemThumbnailUrl { get; set; }
        public bool IsLanchePreferido { get; set; }
        public bool EmEstoque { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public Lanche()
        {
        }

        public Lanche(int id, string nome, string descricaoCurta, string descricaoDetalhada, double preco, string imagemUrl, string imagemThumbnailUrl, bool isLanchePreferido, bool emEstoque, Categoria categoria)
        {
            Id = id;
            Nome = nome;
            DescricaoCurta = descricaoCurta;
            DescricaoDetalhada = descricaoDetalhada;
            Preco = preco;
            ImagemUrl = imagemUrl;
            ImagemThumbnailUrl = imagemThumbnailUrl;
            IsLanchePreferido = isLanchePreferido;
            EmEstoque = emEstoque;
            Categoria = categoria;
        }
    }
}
