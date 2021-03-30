using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApplication1.Models;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Employee> emp = new List<Employee>();
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44320/api/");
            var consume = hc.GetAsync("Employee");
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsStringAsync();
                emp = JsonConvert.DeserializeObject<List<Employee>>(display.Result).ToList();
                label1.Text = emp[0].Name;
                label2.Text = emp[1].Name;
                label3.Text = emp[2].Name;

            }
        }
    }
}
