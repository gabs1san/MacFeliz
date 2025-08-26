using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MacFeliz.Models
{

    [Table("Lanches")]
    public class Lanche
    {

        [Key]
        public int LancheId { get; set; }
        [StringLength(80,MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2}")]
        [Required(ErrorMessage = "O nome do lanche deve ser informado")]
        [Display(Name = "Nome do Lanche")]
        public string Nome { get; set; }

        [StringLength(200, MinimumLength = 20, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2}")]
        [Required(ErrorMessage = "A descrição do lanche deve ser informada")]
        [Display(Name = "Nome do Lanche")]
        public string DescricaoCurta { get; set; }

        [StringLength(200, MinimumLength = 20, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2}")]
        [Required(ErrorMessage = "A descrição detalhada do lanche deve ser informada")]
        [Display(Name = "Nome do Lanche")]
        public string DescricaoDetalahada { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Required(ErrorMessage = "Informe o preço do Lanche")]
        [Display(Name = "Preço")]
        [Range(1,99.99, ErrorMessage = "OO preço deve estar entre 1 e 99.99")]
        public decimal Preco { get; set; }

        [Display(Name = "Camimho da imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }

        [Display(Name = "Camimho da imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        public  int CategoriaId { get; set; }
        public virtual  Categoria Categoria { get; set; }
    }
}
