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
        Work GetWorkByRouteCard(string routeCard);

        [OperationContract]
        Work GetWorkByDrawingNumber(string drawingNumber);

        [OperationContract]
        void SaveWork(Work toSave);
    }
}
