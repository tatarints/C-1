using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_5
{
    class Person
    {
        public string name { get; set; }
        public string position { get; set; } 
        public string email { get; set; }   
        public string telephone { get; set; }
        public float wage { get; set; }        
        public int birthyear { get; set; }
        public Person(string name,
        string position,
        string email,
        string telephone,
        float wage,
        int birthyear)
        {
            this.name = name;
            this.position = position;
            this.email = email;
            this.telephone = telephone;
            this.wage = wage;
            this.birthyear = birthyear;
        }
       
        public string Info()
        {
            return
                this.name +", "+ this.position +", "+ this.email +", " + this.telephone +", " + this.wage +", "+ this.birthyear;
                
        }
    }
}
