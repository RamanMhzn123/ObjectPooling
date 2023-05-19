using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WebRequestExample : MonoBehaviour
{
    public Text progressText;

    private void Start()
    {
        // Send the web request
        StartCoroutine(SendWebRequester());
    }

    private IEnumerator SendWebRequester()
    {
        UnityWebRequest request = UnityWebRequest.Get("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/132.png"); // Replace with your own URL

        request.SendWebRequest();

        while (!request.isDone)
        {
            // Update the UI text with the progress value
            progressText.text = (request.downloadProgress * 100f).ToString("F0") + "%";

            yield return null;
        }

        if (request.result == UnityWebRequest.Result.Success)
        {
            // Handle the successful response
            Debug.Log("Request successful");
            Debug.Log("Response: " + request.downloadHandler.text);
        }
        else
        {
            // Handle the error response
            Debug.Log("Request failed");
            Debug.Log("Error: " + request.error);
        }
    }
}
