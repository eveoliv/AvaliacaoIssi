using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Avaliacoes.Domain
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int DivisaoId { get; set; }
        public int Admin { get; set; }
        public Divisao Divisao { get; set; }       
                
        public ICollection<Avaliacao> Avaliacoes { get; set; }
    }
}
