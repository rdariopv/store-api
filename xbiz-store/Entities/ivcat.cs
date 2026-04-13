using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xbiz_store.Models
{
    [Table("ivcat")]
    public  class ivcat
    {
        public int ivcatclin { get; set; }
        public int ivcatcgru { get; set; }
        public int ivcatcsub { get; set; }
        public string ivcatdesc { get; set; }
        public string ivcatabrv { get; set; }
        public string ivcatccco { get; set; }
        public string ivcatccvt { get; set; }
        public string ivcatcdev { get; set; }
        public string ivcatcdes { get; set; }
        public int ivcatstat { get; set; }
        public int ivcatride { get; set; }

    }
}
