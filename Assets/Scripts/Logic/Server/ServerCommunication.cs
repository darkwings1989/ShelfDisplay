using System;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace ShelfDisplay
{
    /// <summary>
    /// This class is responsible to handle communication with the server and get products data.
    /// This class is acting like a Singleton, to be able to access from any place in this app.
    /// </summary>
    public class ServerCommunication : MonoBehaviour
    {
        // With this instance any place in the app will access the Server methods.
        private static ServerCommunication m_SharedInstance;

        public static ServerCommunication SharedInstance
        {
            get
            {
                return m_SharedInstance;
            }
        }
        
        // API address.
        private const string URL_ADDRESS = "https://homework.mocart.io/api/products";
        
        // This will store the products data that fetch form the server.
        private ProductsDataStorage m_Products;
        
        // Indication to know if the products data was downloaded from the sever.
        private bool isProductsDataReady = false;
        
        private void Awake()
        {
            // Make sure I using the same instance of ServerCommunication across the app.
            if (m_SharedInstance != null && m_SharedInstance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                m_SharedInstance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        
        /// <summary>
        /// This method uses a WebRequest to get products data from the server and storing it in a list.
        /// </summary>
        /// <returns></returns>
        public async Task<ProductsDataStorage> GetProducts()
        {
            UnityWebRequest webRequest = UnityWebRequest.Get(URL_ADDRESS);
            UnityWebRequestAsyncOperation operation = webRequest.SendWebRequest();
            
            // Waiting for the WebRequest operation to be finish.
            while (!operation.isDone)
            {
                await Task.Yield();
            }
            
            // If there was an error, that retun null and print error log with the error message.
            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError || webRequest.result == UnityWebRequest.Result.DataProcessingError)
            {
                Debug.LogError("WebRequest retruned this error: " + webRequest.error);
                return null;
            }
            else
            {
                // Trying to parse the JSON that returned from the server to ProductData list.
                try
                {
                    m_Products = JsonUtility.FromJson<ProductsDataStorage>(webRequest.downloadHandler.text);
                    return m_Products;
                }
                catch (Exception exp)
                {
                    Debug.LogError("Error occurred while parsing JSON from the server, error description: " + exp.Message);
                    return null;
                }
            }
        }
    }
}