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
    public partial class FormAddContact : Form
    {

        public string ContactName = "";
        public string Address = "";
        public string Phone = "";

        public FormAddContact()
        {
            InitializeComponent();
        }

        public FormAddContact(string name, string address, string phone)
        {
            InitializeComponent();
            this.ContactName = name;
            this.Address = address;
            this.Phone = phone;
            textBoxName.Text = name;
            textBoxAddress.Text = address;
            textBoxPhone.Text = phone;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            ContactName = textBoxName.Text;
            Address = textBoxAddress.Text;
            Phone = textBoxPhone.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
