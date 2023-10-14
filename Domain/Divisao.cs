using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Avaliacoes.Domain
{
    public class Divisao
    {
        [Key]
        public int DivisaoId { get; set; }
        public string Nome { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }        
    }
}
