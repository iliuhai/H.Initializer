using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Initializer.Model
{
    [Table("T_Sample", Schema = "demo")]
    public class SampleEntity
    {
        public SampleEntity()
        {
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }
    }
}
