using Microsoft.Azure.Cosmos;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using System.Diagnostics;

namespace MusicMerge
{
    public static class DataService
    {
        private static CosmosClient cosmosClient;
        private static async Task InitDBConnection()
        {
            var secretUri = "5bbb4c7d5cce4036afdc2cc4c7db0066";
            var keyVaultTokenProvider = new AzureServiceTokenProvider().KeyVaultTokenCallback;
            var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(keyVaultTokenProvider));

            var mySecret = await keyVaultClient.GetSecretAsync(secretUri);
            cosmosClient = new CosmosClient(mySecret.Value);
        }

        public static async Task<List<T>> Get<T>(string Query = "")
        {
            try
            {
                var allItems = new List<T>();

                if (cosmosClient is null)
                {
                    await InitDBConnection();
                }

                QueryRequestOptions options = new QueryRequestOptions() { MaxBufferedItemCount = 100 };

                var database = cosmosClient.GetDatabase("MusicMerge");
                var container = database.GetContainer("Users");
                var queryText = $"SELECT * FROM c";
                if (!string.IsNullOrEmpty(Query))
                {

                    queryText += Query;
                }

                return allItems;

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR – { ex.Message}");
                return null;
            }
        }
    }
}
