using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class APIClient : MonoBehaviour
{
    private const string baseUrl = "http://localhost:54583/API";

	void Start ()
    {
		
	}

    IEnumerator GetItensAPISync()
    {
        UnityWebRequest request = UnityWebRequest.Get(baseUrl + "/Itens");

        yield return request.Send();

        if(request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            string response = request.downloadHandler.text;
            Debug.Log(response);
        }
    }
}
