using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceToDoList
{    
    [DataContract]
    public class ToDo
    {
        private int _id;
        private string _title;
        private string _description;
        private DateTime _endDate;
        private string _userid;

        [DataMember(IsRequired =false)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        [DataMember]
        public string Title
        {
            get { return _title; } 
            set { _title = value; }
        }
        [DataMember]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        [DataMember]
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }
        [DataMember]
        public string UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }
    }
}
