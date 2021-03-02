using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            Item.topCounter += 30;
            item.ItemCreate(this);
            button1.Top += 30;
            if(!Item.controls.Contains(button1))
            {
                Item.controls.Add(button1);
            }
        }
    }
    public class Item
    {
        public static int topCounter = 0;
        public static List<Control> controls = new List<Control>();
        TextBox text = new TextBox();
        Button delete = new Button();
        CheckBox done = new CheckBox();
        public void ItemCreate(Form Form1)
        {
            text.Left = 80;
            text.Top = topCounter;
            text.Width = 350;

            done.Top = topCounter;
            done.Left = text.Left + text.Width + 15;

            delete.Top = topCounter;
            delete.Left = done.Left + done.Width + 10;
            delete.Text = "Smazat";
            delete.Click += new EventHandler(delete_Click);

            controls.Add(done);
            controls.Add(text);
            controls.Add(delete);

            Form1.Controls.Add(text);
            Form1.Controls.Add(done);
            Form1.Controls.Add(delete);
        }
        public void delete_Click(object sender, EventArgs e)
        {
            this.text.Dispose();
            this.done.Dispose();
            this.delete.Dispose();
            MoveUp(this.delete.Top);
            topCounter -= 30;
        }
        public void MoveUp(int itemTop)
        {
            foreach(Control control in controls)
            {
                if(control.Top > itemTop)
                {
                    control.Top -= 30;
                }
            }
        }
    }
}
