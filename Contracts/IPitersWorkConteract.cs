using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PitersWorkService.DTO;

namespace PitersWorkService.Contracts
{
    [ServiceContract]
    interface IPitersWorkConteract
    {
        [OperationContract]
        StaticData GetStaticData();

        [OperationContract]
        Work GetWork(string routeCard, string drawingNumber);

        [OperationContract]
        void SaveWork(Work toSave);

        [OperationContract]
        Worker GetWorker(int id);
    }
}
