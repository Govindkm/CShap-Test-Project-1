using AirtelVIRecharge;
using NUnit.Framework;
using System;

namespace TestApp
{
    public class Tests
    {
        user testUser;
        
        [Test]
        [TestCase("Govind", 22, "8698667843", "airtel", 199, true, false)]
        [TestCase("Charan", 15, "+918765487645", "vodafone", 99, false, false)]
        public void Success(string name, int age, string number, string brand, int plan, bool more3GB, bool unlimitedCall)
        {
            testUser = new user(name, age, number, brand);
            PlanSelector selector = new PlanSelector(testUser);
            Assert.IsTrue(selector.ChangePlan(plan, unlimitedCall, more3GB));
            Assert.AreEqual(plan, testUser.CurrentPlan);
        }

        [Test]
        [TestCase("Charan", 15, "+918765487645", "vodafone", 199, true, false)]
        public void Faliure(string name, int age, string number, string brand, int plan, bool more3GB, bool unlimitedCall)
        {
            testUser = new user(name, age, number, brand);
            PlanSelector selector = new PlanSelector(testUser);
            Assert.IsFalse(selector.ChangePlan(plan, unlimitedCall, more3GB));
            Assert.AreEqual(0, testUser.CurrentPlan);
        }

        [Test]
        [TestCase("Charan", 32, "+918765487645", "idea", 199, true, false)]
        public void expectException(string name, int age, string number, string brand, int plan, bool more3GB, bool unlimitedCall)
        {
            try 
            {
                testUser = new user(name, age, number, brand);
                PlanSelector selector = new PlanSelector(testUser);
                Assert.IsTrue(selector.ChangePlan(plan, unlimitedCall, more3GB));
                Assert.AreEqual(plan, testUser.CurrentPlan);
            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}