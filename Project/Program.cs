using static System.Formats.Asn1.AsnWriter;

namespace Project
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        public static ScorTable scoreTable = new ScorTable();
        [STAThread]

        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
        
            ApplicationConfiguration.Initialize();
          
            Application.Run(new Form1());

            
        }
    }
}