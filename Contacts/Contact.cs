using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    public class Contact
    {
        public string Name;
        public string Address;
        public string Phone;

        public Contact(
            string Name,
            string Address,
            string Phone)
        {
            this.Name = Name;
            this.Address = Address;
            this.Phone = Phone;
        }

        public string DisplayContact()
        {
            return $"Nome:{Name}\tTelefone:{Phone}";
        }
    }
}
