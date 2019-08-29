using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CorinthiansBackend
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool PurchaseTicket(Ticket ticket);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Ticket
    {
        [DataMember]
        public string TeamHome { get; set; }
        [DataMember]
        public string TeamAway { get; set; }
        [DataMember]
        public string Stadium { get; set; }
        [DataMember]
        public string Championship { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public string Place { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public string FanName { get; set; }
    }
}
