using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace AllFormsDesign
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        //StudentLoginForm be 1
        //StudentCreateAccountForm be 2
        //AdminLoginForm be 3
        //AdminCreateAccountForm be 4
        //Form number(s) if opened and needed to be closed
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            int a = 0;
            //GlobalVariable.GlobalClosingInput(a);

            //Application.Run(new AdminLoginForm());

            Application.Run(new ChooseIdentity());
            do {
                AutomatedFormOpen.StartIt();
                a = AutomatedFormOpen.ReturnOpeningStatus();
            } while (a!=0) ;

            /*StudentLoginForm LoginForm = new StudentLoginForm();
            //List.Add(LoginForm);
            StudentCreateAccountForm StudentCreate = new StudentCreateAccountForm();

            Application.Run(LoginForm);            

            a = GlobalVariable.GlobalOpeningOutput();
            FormOpen.OpenIt(a); */
          
            //Application.Run(new StudentCreateAccountForm());
        }
        public static void RunStudentLoginForm()
        {
            Console.Write("RunStudentLoginForm function is called.");
            GlobalVariable.GlobalOpeningInput(1); //2 means Open StudentCreateAccountForm according to previous description
        }
        public static void RunStudentCreateAccountForm()
        {
            Console.Write("RunStudentCreateAccountForm function is called.");
            GlobalVariable.GlobalOpeningInput(2); //2 means Open StudentCreateAccountForm according to previous description
        }

        public static void RunAdminLoginForm()
        {
            Console.Write("RunAdminLoginForm function is called.");
            GlobalVariable.GlobalOpeningInput(3); //2 means Open StudentCreateAccountForm according to previous description
        }
        public static void RunAdminCreateAccountForm()
        {
            Console.Write("RunAdminCreateAccountForm function is called.");
            GlobalVariable.GlobalOpeningInput(4);
        }
    }

    public class GlobalVariable
    {
        protected static int OpeningStatus = 0; //This is mainly for Main() function
        public static void GlobalOpeningInput(int a)
        {
            OpeningStatus = a;
        }
        public static int GlobalOpeningOutput() //For throwing in Main
        {
            return OpeningStatus;
        }
    }

    public class AutomatedFormOpen: GlobalVariable
    {
        public static void StartIt ()
        {
            int a = OpeningStatus;
            OpeningStatus = 0;
            FormOpen.OpenIt(a);
        }
        public static int ReturnOpeningStatus()
        {
            return OpeningStatus;
        }
    }
    public class FormOpen
    {
        public static void OpenIt(int a)
        {
            if (a == 1)
            {
                Application.Run(new StudentLoginForm());
            }
            else if (a == 2)
            {
                Application.Run(new StudentCreateAccountForm());
            }
            else if (a == 3)
            {
                Application.Run(new AdminLoginForm());
            }
            else if (a == 4)
            {
                Application.Run(new AdminCreateAccountForm());
            }
        }
    }
    

}
