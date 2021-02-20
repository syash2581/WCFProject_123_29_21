using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AdvanceToDoList
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        User GetProfile(string userid);

        [OperationContract]
        bool SignUp(User user);

        [OperationContract]
        User UpdateProfile(User user);

        [OperationContract]
        bool DeleteProfile(string userid);
        [OperationContract]
        bool Login(string userid, string password);
    }
}
