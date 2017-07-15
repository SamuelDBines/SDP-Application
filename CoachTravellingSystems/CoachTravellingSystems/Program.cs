using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoachTravellingSystems
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        private static string connetionString = "Server=(localdb)\\MSSQLLocalDB;database= websiteSDP;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static SqlConnection cnn =  new SqlConnection(connetionString);
        public static MemeberController member = new MemeberController();
        public static TripController trip = new TripController();
        public static int ticketCount;
        public static CoachTravellingData.CustomersDataTable customerDatabase = new CoachTravellingData.CustomersDataTable();
        public static CoachTravellingData.TripsDataTable tripDatabase = new CoachTravellingData.TripsDataTable();
        [STAThread]
        static void Main()
        {
            
        Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainScreen());
        }
    }
}
