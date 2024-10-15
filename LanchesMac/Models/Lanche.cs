using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    public class Lanche
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do lanche deve ser informado")]
        [Display(Name = "Nome do Lanche")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do lanche deve ser informada")]
        [Display(Name = "Descrição do lanche")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição deve ter no máximo {1} caracteres")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "A descrição detalhada do lanche deve ser informada")]
        [Display(Name = "Descrição detalhada do Lanche")]
        [MinLength(20, ErrorMessage = "Descrição detahada deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição detalhada deve ter no máximo {1} caracteres")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "Informe o valor do lanche")]
        [Display(Name = "Preço")]
        [Column(TypeName ="double(10,2)")]
        [Range(1.0, 999.99, ErrorMessage = "O preço deve estar entre {0} e {1}")]
        public double Preco { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Estoque")]
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
