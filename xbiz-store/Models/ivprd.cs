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
        public string ivprddesc { get; set; }

        public int ivprdcmon { get; set; }
    }
}
