using System;
using System.Collections.Generic;
using System.Text;
using Azure.Security.KeyVault.Secrets;
using Azure.Identity;

namespace CognitiveServices.Key
{  
    /*
     Esta clase se conecta al servicio de KeyVault a través de AAD 
    Información necesaria: 
    - 1. CLIENT_ID
    - 2. TENANT_ID
    - 3. SECRET_CLIENT
    - 4. VAULT_URI
     */
    class KeyClient
    {
        private static readonly string CLIENT_ID = "637a0b2d-4fc5-4951-b7c6-77a8ba53f50c";
        private static readonly string TENANT_ID = "eff40c30-e867-4a9e-a4b1-f909a8cc1b8f";
        private static readonly string SECRET_CLIENT = "QP61iRFY-BtIbsEA_Gu_k4vYL-3ohM.TQU";
        private static readonly string VAULT_URI = "https://keyleao.vault.azure.net/";

        /* Atributo utilizado para obtener los secretos en cualquier parte del codigo.
         */
        public static SecretClient Secret { get; private set; }
        /*Constructor*/
        static KeyClient() { InitKeyVault(); }

        private static void InitKeyVault(){
            if (Secret == null) {
                var credential = new ClientSecretCredential(TENANT_ID, CLIENT_ID, SECRET_CLIENT);
                Secret = new SecretClient(new Uri(VAULT_URI), credential);
            }
        }
    }
}
