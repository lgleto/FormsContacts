using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Contacts
{
    public partial class Form1 : Form
    {
        private List<Contact> contacts = new List<Contact>();
        private static string FILE_NAME = "contacts.txt";
        private static string [] SEPARATOR = new string[] { "<separator>" };
        
        public Form1()
        {
            InitializeComponent();
            if (File.Exists(FILE_NAME))
            {
                string[] lines = File.ReadAllLines(FILE_NAME);
                foreach (var line in lines)
                {
                    string[] fields = line.Split(SEPARATOR, StringSplitOptions.None);
                    string name = "";
                    string address = "";
                    string phone = "";
                    if (fields.Length > 0)
                    {
                        name = fields[0];
                    }
                    if (fields.Length > 1)
                    {
                        address = fields[1];
                    }
                    if (fields.Length > 2)
                    {
                        phone = fields[2];
                    }
                    contacts.Add(new Contact(name, address, phone));

                }
            }


            listContacts();
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {

            FormAddContact formAddContact = new FormAddContact();
            if (formAddContact.ShowDialog() == DialogResult.OK) {
                string name = formAddContact.ContactName;
                string address = formAddContact.Address;
                string phone = formAddContact.Phone;
                Contact contact = new Contact(name, address, phone);
                contacts.Add(contact);

                listContacts();
            }

        }

        private void listContacts()
        {
            listBoxContacs.Items.Clear();
            foreach (var contact in contacts)
            {
                listBoxContacs.Items.Add(contact.DisplayContact());
            }

            string[] lines = new string[contacts.Count];

            for (int i = 0; i < contacts.Count; i++)
            {
                lines[i] = contacts[i].Name + SEPARATOR[0] +
                    contacts[i].Address + SEPARATOR[0] +
                    contacts[i].Phone;
            }

            File.WriteAllLines(FILE_NAME, lines);

        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            int contactIndex = listBoxContacs.SelectedIndex;
            if (contactIndex >= 0)
            {

                if (MessageBox.Show(
                "Deseja apagar o contact0?",
                "Alerta",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    contacts.RemoveAt(contactIndex);
                    listContacts();
                }
            }
        }


        private void listBoxContacs_DoubleClick(object sender, EventArgs e)
        {
            int contactIndex = listBoxContacs.SelectedIndex;
            if (contactIndex >= 0)
            {
                FormAddContact formAddContact = new FormAddContact(
                    contacts[contactIndex].Name,
                    contacts[contactIndex].Address,
                    contacts[contactIndex].Phone
                    );
                if (formAddContact.ShowDialog() == DialogResult.OK)
                {
                    contacts[contactIndex].Name = formAddContact.ContactName;
                    contacts[contactIndex].Address = formAddContact.Address;
                    contacts[contactIndex].Phone = formAddContact.Phone;
                    listContacts();
                }



            }
        }
    }
}
