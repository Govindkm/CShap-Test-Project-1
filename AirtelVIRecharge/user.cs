using System;
using System.Collections.Generic;
using System.Text;

namespace AirtelVIRecharge
{
    public class user
    {
        private String _contactNumber;
        private int _currentPlan;
        public String Name { get; set; }
        public int Age { get; set; }
        public String ContactNumber
        {
            get { return _contactNumber; }
        }

        protected void SetContact(string value)
        {
            
            

                value = value.Trim();
            if (value.Length > 14 || value.Length < 10)
                throw new FormatException("Unrecoganised Contact Number! Please check the number!");
            else
            {
                if (value.StartsWith("+91"))
                {
                    _contactNumber = value.Substring(2, 10);
                }
                else if(value.StartsWith('+')) 
                {
                    throw new FormatException("Cannot provide services to users from other countries than INDIA.");
                }
                else 
                {
                    if (value.Length == 10)
                    {
                        _contactNumber = value;
                    }
                    else
                        throw new FormatException("Unrecoganised Contact Number! Please check the number!");
                }
            }
        }

        public String Brand { get; }

        public int CurrentPlan { get { return _currentPlan; } }

        public user(string name, int age, string contact, string brand)
        {
            Name = name;
            Age = age;
            this.SetContact(contact);
            Brand = brand;
            this.changePlan(0);
        }

        public void ChangeAge(int newAge)
        {
            Age = newAge;
        }

        public void ChangeName(String newName)
        {
            Name = newName;
        }

        public bool changePlan(int newPlan)
        {
            if(Age<10)
            {
                throw new Exception("User is too young!!!");
                return false;
            }

            else 
            {
                this._currentPlan=newPlan;
                return true;
            }
        }
    }

    public class PlanSelector
    {
        user newUser;
        public PlanSelector(user obj)
        {
            string brandLower = obj.Brand.ToLower();
            if (!(brandLower.Contains("airtel") || brandLower.Contains("vodafone")))
            {
                throw new Exception("Brand not Supported!!!");
            }
            else
                newUser = obj;   
        }

        public bool ChangePlan(int plan, bool unlimitedCall, bool morethan3GB)
        {
            if(newUser.Age < 18 || plan==99)
            {
                if(plan>99)
                {
                    return false;
                }
                else
                    return newUser.changePlan(plan);
            }
            else if(unlimitedCall || morethan3GB)
            {
                if(plan < 199)
                {
                    throw new Exception("Wrong Plan Chosen!");
                }

                else
                return newUser.changePlan(199);
            }

            return false;
        }
    }
}
