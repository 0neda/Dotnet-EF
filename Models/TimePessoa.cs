using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetEF.Models
{
    public class TimePessoa
    {
        public long Id { get; set; }

        public long TimeId { get; set; }
        [ForeignKey("TimeId")]
        public Time? Time { get; set; }

        public long PessoaId { get; set; }
        [ForeignKey("PessoaId")]
        public Pessoa? Pessoa { get; set; }

        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
    }
}
