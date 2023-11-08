using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wcfPostgreSQL
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetCustomers();

        [OperationContract]
        string GetTest();

        [OperationContract]
        void PostCustInfo(string user, string Company);

        [OperationContract]
        string DeleteCustInfo(string user, string Company);
    }
   
}
