using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class myJsonreader : Newtonsoft.Json.JsonReader
    {
       
        public override bool Read()
        {
            return true;
        }
    }
}
