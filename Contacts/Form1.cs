using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contacts
{
    public partial class Form1 : Form
    {
        private List<Contact> contacts = new List<Contact>();

        public Form1()
        {
            InitializeComponent();
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string address = textBoxAddress.Text;
            string phone = textBoxPhone.Text;
            Contact contact = new Contact(name, address, phone);
            contacts.Add(contact);
            textBoxName.Text = "";
            textBoxAddress.Text = "";
            textBoxPhone.Text = "";
            listContacts();
        }

        private void listContacts()
        {
            listBoxContacs.Items.Clear();
            foreach (var contact in contacts)
            {
                listBoxContacs.Items.Add(contact.DisplayContact());
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            int contactIndex = listBoxContacs.SelectedIndex;
            if (contactIndex >= 0)
            {
                contacts.RemoveAt(contactIndex);
                listContacts();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int contactIndex = listBoxContacs.SelectedIndex;
            if (contactIndex >= 0)
            {
                string name = textBoxName.Text;
                string address = textBoxAddress.Text;
                string phone = textBoxPhone.Text;
                contacts[contactIndex].Name = name;
                contacts[contactIndex].Address = address;
                contacts[contactIndex].Phone = phone;
                textBoxName.Text = "";
                textBoxAddress.Text = "";
                textBoxPhone.Text = "";
                listContacts();
            }
        }

        private void listBoxContacs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int contactIndex = listBoxContacs.SelectedIndex;
            if (contactIndex >= 0)
            {
                textBoxName.Text = contacts[contactIndex].Name;
                textBoxAddress.Text = contacts[contactIndex].Address;
                textBoxPhone.Text = contacts[contactIndex].Phone;
            }
        }
    }
}
