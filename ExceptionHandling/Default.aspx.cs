using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace ExceptionHandling
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BaseException();
            DivideByZeroException();
        }


        public  void BaseException()
        {
            try
            {
                string x = null;
                int a = 10;

                Response.Write(int.Parse(x) + a);
            }
            catch (Exception ex)
            {
                ExceptionHandler obj = new ExceptionHandler();
                string errormsg = obj.HandleException(ex);
                Response.Write(errormsg);
            }
        }

        public static void DivideByZeroException()
        {
            try
            {
                int x = 5;
                int y = 0;
                int z = x / y;
            }
            catch (DivideByZeroException ex)
            {
                ExceptionHandler obj = new ExceptionHandler();
                string errormsg = obj.HandleException(ex);
            }
        }

        public static void FileNotFoundException()
        {
            try
            {
                // Read in non-existent file.  
                using (System.IO.StreamReader reader = new System.IO.StreamReader("TextFile1.txt"))
                {
                    reader.ReadToEnd();
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                ExceptionHandler obj = new ExceptionHandler();
                string errormsg = obj.HandleException(ex);
            }
        }
    }
}