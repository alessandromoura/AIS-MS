using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CorinthiansBackend
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public bool PurchaseTicket(Ticket ticket)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["backendDb"].ConnectionString))
                {
                    cn.Open();

                    StringBuilder builder = new StringBuilder();
                    builder.Append("INSERT INTO Tickets ");
                    builder.Append("(TeamHome, TeamAway, Stadium, Championship, Year, Place, Quantity, CustomerName, Printed) VALUES ");
                    builder.Append($"('{ticket.TeamHome}', '{ticket.TeamAway}', '{ticket.Stadium}', '{ticket.Championship}', {ticket.Year}, '{ticket.Place}', ");
                    builder.Append($"{ticket.Quantity}, '{ticket.FanName}', 0)");

                    SqlCommand cmd = new SqlCommand(builder.ToString(), cn);

                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
