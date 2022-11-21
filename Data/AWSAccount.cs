using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace AwaytoMAUI.Data
{
    internal class AWSAccount
    {
        public string? Name { get; set; }
        public string? Key { get; set; }  
        public string? Secret { get; set; }  
    }
}
