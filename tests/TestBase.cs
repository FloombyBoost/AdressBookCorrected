using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace AdressBook_web_test
{
   
    public class TestBase
    {
      
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
           
            app = ApplicationManager.GetInstanse();


            app.Auth.LogOn(new AccountData("admin", "secret"));

        }
        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {
            
            int l =  Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0;i < l;i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
            throw new NotImplementedException();
        }




















    }
}
