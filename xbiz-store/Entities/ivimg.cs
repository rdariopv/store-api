using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace xbiz_store.Models
{
    [Table("ivimg")]
    public  class ivimg
    {
        public int ivimgnitm { get; set; }
        public int ivimgcprd { get; set; }
        public int ivimgnord { get; set; }
        public string ivimgnota { get; set; }
        public byte[] ivimgimag { get; set; }
        public int ivimgstat { get; set; }
        public int ivimgride { get; set; }





    }
}
