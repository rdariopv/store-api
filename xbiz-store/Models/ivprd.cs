using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xbiz_store.Models
{
    [Table("ivprd")]
    public class ivprd
    {
        [Key]
        public int ivprdcprd { get; set; }
        public string ivprdnomb { get; set; }
        public int ivprdclin { get; set; }
        public int ivprdcgru { get; set; }
        public int ivprdcsub { get; set; }
        public char ivprdcode { get; set; }
        public char ivprdcbrr { get; set; }
        public string ivprddesc { get; set; }
        public int ivprdtitm { get; set; }
        public int ivprdfstk { get; set; }
        public int ivprdfact { get; set; }
        public int ivprdfcse { get; set; }
        public decimal ivprdpesn { get; set; }
        public decimal ivprdpeso { get; set; }
        public float ivprdvolm { get; set; }
        public decimal ivprdvoll { get; set; }
        public int ivprdmodl { get; set; }
        public int ivprdtemb { get; set; }
        public int ivprduemb { get; set; }
        public char ivprdccco { get; set; }
        public char ivprdccvt { get; set; }
        public char ivprdcdev { get; set; }
        public int ivprdprop { get; set; }
        public int ivprdumba { get; set; }
        public string ivprdcfab { get; set; }
        public int ivprdmarc { get; set; }
        public int ivprdindu { get; set; }
        public int ivprdclas { get; set; }
        public string ivprdprsy { get; set; }
        public int ivprdpweb { get; set; }
        public string ivprdcpar { get; set; }
        public decimal ivprdpice { get; set; }
        public decimal ivprdpgac { get; set; }
        public int ivprdptos { get; set; }
        public int ivprdunxc { get; set; }
        public int ivprdordm { get; set; }
        public int ivprdordp { get; set; }
        public float ivprdcann { get; set; }
        public int ivprddgar { get; set; }
        public char ivprdtgar { get; set; }
        public int ivprdnofn { get; set; }
        public string ivprdurlp { get; set; }
        public int ivprdcolo { get; set; }
        public string ivprdmedi { get; set; }
        public int ivprdstap { get; set; }
        public int ivprdctvi { get; set; }
        public decimal ivprdcosi { get; set; }
        public int ivprdloto { get; set; }
        public int ivprdessc { get; set; }
        public int ivprdcimp { get; set; }
        public int ivprdcaps { get; set; }
        public int ivprdstat { get; set; }
        public int ivprdride { get; set; }

    }
}
