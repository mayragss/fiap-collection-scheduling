using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Dtos
{
    public class AddressDto
    {
        public string Cep { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int? Number { get; set; }
        public int Complement { get; set; }
    }
}
