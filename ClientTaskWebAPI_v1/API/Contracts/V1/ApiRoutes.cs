using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientTaskWebAPI_v1.API.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;
        public static class Client
        {
            public const string GetAll = Base + "/clients";
            public const string GetClientById = Base + "/clients/{id}";
        }

        public static class ClientTask
        {
            public const string GetAllByClientId = Base + "/clients/{id}/tasks";

            public const string Create = Base + "/clients/{id}/tasks";

            public const string GetTaskById = Base + "/clients/{clientId}/tasks/{taskId}";  

        }
    }
}
