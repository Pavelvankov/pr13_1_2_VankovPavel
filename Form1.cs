using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr13
{
    public partial class Form1 : Form
    {


        //Колекция List
        private IList<Student> studentList = new List<Student>();
        //Колонки таблицы
        private DataGridViewColumn dataGridViewColumn1 = null;
        private DataGridViewColumn dataGridViewColumn2 = null;
        private DataGridViewColumn dataGridViewColumn3 = null;
        private DataGridViewColumn dataGridViewColumn4 = null;
        private DataGridViewColumn dataGridViewColumn5 = null;
        //Инициализация таблицы
        private void initDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add(getDataGridViewColumn1());
            dataGridView1.Columns.Add(getDataGridViewColumn2());
            dataGridView1.Columns.Add(getDataGridViewColumn3());
            dataGridView1.Columns.Add(getDataGridViewColumn4());
            dataGridView1.Columns.Add(getDataGridViewColumn5());
            dataGridView1.AutoResizeColumns();
        }
        //Динамическое создание первой колонки в таблице
        private DataGridViewColumn getDataGridViewColumn1()
        {
            if (dataGridViewColumn1 == null)
            {
                dataGridViewColumn1 = new DataGridViewTextBoxColumn();
                dataGridViewColumn1.Name = "";
                dataGridViewColumn1.HeaderText = "Имя";
                dataGridViewColumn1.ValueType = typeof(string);
                dataGridViewColumn1.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn1;
        }
        //Динамическое создание второй колонки в таблице
        private DataGridViewColumn getDataGridViewColumn2()
        {
            if (dataGridViewColumn2 == null)
            {
                dataGridViewColumn2 = new DataGridViewTextBoxColumn();
                dataGridViewColumn2.Name = "";
                dataGridViewColumn2.HeaderText = "Фамилия";
                dataGridViewColumn2.ValueType = typeof(string);
                dataGridViewColumn2.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn2;
        }
        //Динамическое создание третей колонки в таблице
        private DataGridViewColumn getDataGridViewColumn3()
        {
            if (dataGridViewColumn3 == null)
            {
                dataGridViewColumn3 = new DataGridViewTextBoxColumn();
                dataGridViewColumn3.Name = "";
                dataGridViewColumn3.HeaderText = "Зачетка";
                dataGridViewColumn3.ValueType = typeof(string);
                dataGridViewColumn3.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn3;
        }

        //Динамическое создание третей колонки в таблице
        private DataGridViewColumn getDataGridViewColumn4()
        {
            if (dataGridViewColumn4 == null)
            {
                dataGridViewColumn4 = new DataGridViewTextBoxColumn();
                dataGridViewColumn4.Name = "";
                dataGridViewColumn4.HeaderText = "Возраст";
                dataGridViewColumn4.ValueType = typeof(string);
                dataGridViewColumn4.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn4;
        }

        //Динамическое создание третей колонки в таблице
        private DataGridViewColumn getDataGridViewColumn5()
        {
            if (dataGridViewColumn5 == null)
            {
                dataGridViewColumn5 = new DataGridViewTextBoxColumn();
                dataGridViewColumn5.Name = "";
                dataGridViewColumn5.HeaderText = "группа";
                dataGridViewColumn5.ValueType = typeof(string);
                dataGridViewColumn5.Width = dataGridView1.Width / 3;
            }
            return dataGridViewColumn5;
        }


        private void addStudent(string name, string surname, string recordBookNumber, int age, string group)
        {
            Student student = new Student(name, surname, recordBookNumber, age, group);
            studentList.Add(student);
            showListInGrid();
        }
        //Удаление студента с колекции
        private void deleteStudent(int elementIndex)
        {
            if (elementIndex >= 0 && elementIndex < studentList.Count)
            {
                studentList.RemoveAt(elementIndex);
                showListInGrid();
            }
        }
        //Отображение колекции в таблице
        private void showListInGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (Student s in studentList)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell cell1 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell2 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell3 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell4 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell5 = new
                DataGridViewTextBoxCell();
                cell1.ValueType = typeof(string);
                cell1.Value = s.getName();
                cell2.ValueType = typeof(string);
                cell2.Value = s.getSurname();
                cell3.ValueType = typeof(string);
                cell3.Value = s.getRecordBookNumber();
                cell4.ValueType = typeof(int);
                cell4.Value = s.getAge();
                cell5.ValueType = typeof(string);
                cell5.Value = s.getGroup();
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
                row.Cells.Add(cell5);
                dataGridView1.Rows.Add(row);
            }
        }
        public Form1()
        {
            InitializeComponent();
            initDataGridView();
        }

        private void добавить_Click(object sender, EventArgs e)
        {

            string name = textBox1.Text;
            string surname = textBox2.Text;
            string recordBookNumber = textBox3.Text;
            int age = (int)numericUpDown1.Value;
            string group = textBox5.Text;
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(recordBookNumber) || age <= 0 || string.IsNullOrWhiteSpace(group))
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
                return;
            }

            bool est = studentList.Any(s => s.getName() == name && s.getRecordBookNumber() == recordBookNumber);
            if (est)
            {
                MessageBox.Show("Такой студен уже есть");
                return;
            }

            DialogResult dr = MessageBox.Show("Добавить студента?", " ", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    addStudent(name, surname, recordBookNumber, age, group);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.SelectedCells[0].RowIndex;
            DialogResult dr = MessageBox.Show("Удалить студента?", " ", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    deleteStudent(selectedRow);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }



        private void editStudent(int elementIndex, string name, string surname, string recordBookNumber, int age, string group)
        {
            if (elementIndex >= 0 && elementIndex < studentList.Count)
            {
                studentList.RemoveAt(elementIndex);
                Student student = new Student(name, surname, recordBookNumber, age, group);
                studentList.Add(student);
            }
            showListInGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string recordBookNumber = textBox3.Text;
            int age = (int)numericUpDown1.Value;
            string group = textBox5.Text;

     
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) ||
                string.IsNullOrWhiteSpace(recordBookNumber) || age <= 0 || string.IsNullOrWhiteSpace(group))
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
                return;
            }

            int elementIndex = dataGridView1.SelectedCells[0].RowIndex;


            Student currentStudent = studentList[elementIndex];

            bool duplicateFound = false;
            for (int i = 0; i < studentList.Count; i++)
            {
                if (i == elementIndex)
                    continue;
                if (studentList[i].getName() == name || studentList[i].getRecordBookNumber() == recordBookNumber)
                {
                    duplicateFound = true;
                    break;
                }
            }
            if (duplicateFound)
            {
                MessageBox.Show("Студент с таким именем и номером зачетки уже существует");
                return;
            }
            DialogResult dr = MessageBox.Show("Редактировать студента?", " ", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    editStudent(elementIndex, name, surname, recordBookNumber, age, group);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }
    }
    


}
