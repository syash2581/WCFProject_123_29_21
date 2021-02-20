using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceToDoList
{
    [DataContract]
    public class User
    {
        private int _id;
        private string _userid;
        private string _name;
        private DateTime _dob;
        private string _email;
        private string _contact;
        private string _password;

        [DataMember(IsRequired =false)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        [DataMember]
        public string UserId
        {
            get { return _userid; }
            set { _userid = value; }
        }
        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        [DataMember]
        public DateTime DOB
        {
            get { return _dob; }
            set { _dob = value; }
        }
        [DataMember]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        [DataMember]
        public string Contact
        {
            get { return _contact; }
            set { _contact = value; }

        }
        [DataMember]
        public string Password
        {
            get { return _password; }
            set { _password = value; }

        }
    }
}
