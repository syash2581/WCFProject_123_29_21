using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AdvanceToDoList
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IToDoService" in both code and config file together.
    [ServiceContract]
    public interface IToDoService
    {
        [OperationContract]
        ToDo GetToDo(int id);

        [OperationContract]
        void SaveToDo(ToDo toDo);

        [OperationContract]
        ToDo UpdateToDo(ToDo toDo);

        [OperationContract]
        bool DeleteToDo(int id);
        [OperationContract]
        List<ToDo> GetAllToDos(string userid);

        [OperationContract]
        DataSet GetAllToDosGrid(string userid);
    }
}
