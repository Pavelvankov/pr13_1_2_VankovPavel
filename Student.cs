using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr13
{
    class Student
    {

        private string name;
        private string surname;
        private string recordBookNumber;
        private int age;  
        private string group;
        public Student(string name, string surname, string recordBookNumber, int age, string group)
        {
            this.name = name;
            this.surname = surname;
            this.recordBookNumber = recordBookNumber;
            this.age = age;
            this.group = group;
        }
        public string getName()
        {
            return this.name;
        }
        public string getSurname()
        {
            return this.surname;
        }
        public string getRecordBookNumber()
        {
            return this.recordBookNumber;
        }

        public int getAge()
        {
            return this.age;
        }

        public string getGroup()
        {
            return this.group;
        }

        public void setName(string name)
        {
            this.name = name;
        }
        public void setSurname(string surname)
        {
            this.surname = surname;
        }
        public void setRecordBookNumber(string recordBookNumber)
        {
            this.recordBookNumber = recordBookNumber;
        }

        public void setAge(int age)
        {
            this.age = age;
        }

        public void setGroup(string group)
        {
            this.group = group;
        }
    }
}
       
