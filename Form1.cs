using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_Crytical_Section_Lock_31._08
{/*Создайте приложение , испольуещеемеханизм критических секций.
    Первый поток генерирует несколько пар чисел и сохраняет в файл
    Второлй поток подсчитывает сумму каждой пары и записывает в файл
    Третий поток подсчитывает произведение и записывает в файл*/
    public partial class Form1 : Form
    {

        Controller controller;
        public Form1()
        {
            InitializeComponent();
            controller = new Controller();
            controller.MakeSomNums();

        }





        private void button1_Click(object sender, EventArgs e)
        {

            Task ts = new Task(controller.CreateSomeNums);
            Task ts2 = new Task(controller.CreateSummNums);
            Task ts3 = new Task(controller.CreateProd);
            ts.Start();
            ts2.Start();
            ts3.Start();

            Task.WaitAll(ts, ts2, ts3);
            iniListBox();


        }


        public void iniListBox()
        {
            for (int i = 0; i < controller.list.Count; i++)
            {
                listBox1.Items.Add($"{controller.list.ElementAt(i)}   {controller.list2.ElementAt(i)}");
                listBox2.Items.Add($"{controller.list.ElementAt(i) + controller.list2.ElementAt(i)}  ");
                listBox3.Items.Add($"{controller.list.ElementAt(i) * controller.list2.ElementAt(i)}");


            }
        }
    }
}
