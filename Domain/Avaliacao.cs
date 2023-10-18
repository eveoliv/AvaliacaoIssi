using System.ComponentModel;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Avaliacoes.Domain
{
    public class Avaliacao
    {
        [Key]
        public int AvaliacaoId { get; set; }      
        public string Nome { get; set; }
        public string Grau { get; set; }
        [DisplayName("PP")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DataPP { get; set; }
        [DisplayName("Meio")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DataMeio { get; set; }
        [DisplayName("Full")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DataFull { get; set; }
        [DisplayName("Ações")]
        public int Acoes { get; set; }
        public int Pubs { get; set; }
        public int Bondes { get; set; }
        [DisplayName("Contenção")]
        public int Contencao { get; set; }
        public int Estudos { get; set; }
        public int Financeiro { get; set; }
        public int Operacional { get; set; }
        [DisplayName("Dedicação")]
        public int Dedicacao { get; set; }
        [DisplayName("Frequência")]
        public int Frequencia { get; set; }
        public int Nota { get; set; }
        public string Avaliador { get; set; }
        public bool Exibir { get; set; }
        [DisplayName("Observação")]
        public string Observacao { get; set; }
        public int DivisaoId { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set;}
    }
}
