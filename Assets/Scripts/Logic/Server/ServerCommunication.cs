using System;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace ShelfDisplay
{
    /// <summary>
    /// This class is responsiable to communicate with server and get data from it.
    /// </summary>
    public class ServerCommunication : MonoBehaviour
    {
        private static ServerCommunication m_SharedInstance;

        public static ServerCommunication SharedInstance
        {
            get
            {
                return m_SharedInstance;
            }
        }
        
        private const string URL_ADDRESS = "https://homework.mocart.io/api/products";
        private ProductsDataStorage m_Products;
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

        public async Task<ProductsDataStorage> GetProducts()
        {
            UnityWebRequest webRequest = UnityWebRequest.Get(URL_ADDRESS);
            UnityWebRequestAsyncOperation operation = webRequest.SendWebRequest();

            while (!operation.isDone)
            {
                await Task.Yield();
            }
            
            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError || webRequest.result == UnityWebRequest.Result.DataProcessingError)
            {
                Debug.LogError("WebRequest retruned this error: " + webRequest.error);
                return null;
            }
            else
            {
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