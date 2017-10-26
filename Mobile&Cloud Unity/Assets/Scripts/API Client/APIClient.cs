using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class APIClient : MonoBehaviour
{
    [HideInInspector] public Item[] itens = null;
    private const string baseUrl = "http://localhost:54853/API";

	void Start ()
    {
        StartCoroutine("GetItensAPISync");
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

            itens = JSonHelper.getJsonArray<Item>(response);

            foreach (Item i in itens)
            {
                ImprimirItem(i);
            }
        }
    }

    private void ImprimirItem(Item i)
    {
        Debug.Log("=========== Dados do Objeto ===========");
        Debug.Log("ID: " + i.ItemID);
        Debug.Log("Nome: " + i.Nome);
        Debug.Log("Descrição: " + i.Descricao);
        Debug.Log("Dano Máximo: " + i.DanoMaximo);
        Debug.Log("Raridade: " + i.Raridade);
        Debug.Log("Tipo Item ID: " + i.Raridade);
    }
}
