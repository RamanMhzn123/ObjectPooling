using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;

public class Find : MonoBehaviour
{
    public Slider progressSlider; 
    public Text progressText;

    public RawImage pokeRawImage;
    public Text pokeNameText, pokeNum;

    public readonly string baseUrl = "https://pokeapi.co/api/v2/pokemon/";

    public void GetButton()
    {
        int random = Random.Range(1, 808); 
        pokeNameText.text = "Loading...";
        progressSlider.value = 0;
        pokeNum.text = "#" + random;
        StartCoroutine(GetRequest(random));
    }

    IEnumerator GetRequest(int pokeIndex)
    {
        string pokemonUrl = baseUrl + pokeIndex.ToString(); 

        UnityWebRequest request = UnityWebRequest.Get(pokemonUrl); //create getRequest
        
        yield return request.SendWebRequest(); //send request 

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError("Connection Error");
            yield break;
        }

        JSONNode pokeInfo = JSON.Parse(request.downloadHandler.text); //json file/text into object
        //Debug.Log(pokeInfo);
         
        pokeNameText.text = pokeInfo["name"];
        string pokeSpriteUrl = pokeInfo["sprites"]["front_default"];

        UnityWebRequest pokeSpriteRequest = UnityWebRequestTexture.GetTexture(pokeSpriteUrl);
        pokeSpriteRequest.SendWebRequest();

        while (!pokeSpriteRequest.isDone)
        {
            Debug.Log("Progress: " + (int)(pokeSpriteRequest.downloadProgress * 100f) + "%");
        }

        if (pokeSpriteRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Sprite download failed. Error: " + pokeSpriteRequest.error);
        }
        else
        {
            // Texture download is complete, process the downloaded texture
            Texture2D downloadedTexture = DownloadHandlerTexture.GetContent(pokeSpriteRequest);

            // Use the downloaded texture, e.g., assign it to a material
            if (downloadedTexture != null)
            {
                pokeRawImage.texture = downloadedTexture;
                pokeRawImage.texture.filterMode = FilterMode.Point;
            }
            else
            {
                Debug.LogError("Failed to process downloaded texture.");
            }
        }

        // Clean up the UnityWebRequest object
        pokeSpriteRequest.Dispose();
    }
}
