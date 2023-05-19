using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageDownload : MonoBehaviour
{
    public Image image;
    public Slider slider;
    public Text progressText;
    public string imageUrl = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/132.png"; 

    public void Downloader()
    {
        StartCoroutine(ImageDownloader());
    }

    IEnumerator ImageDownloader()
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl);
        //DownloadHandler downloadHandler = request.downloadHandler;

        request.SendWebRequest();
        StartCoroutine(ShowDownloadProgress(request));
;        //int z = 0;
        //float val = 0f;
        /*while(!request.isDone)
        {
            float progress = request.downloadProgress;
            Debug.Log("Progress : " + (progress * 100f) + "%");
            slider.value = progress;

            yield return new WaitForSeconds(.01f);
            //val += request.downloadProgress;
            //Debug.Log(val);
        }*/

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Success");
            DownloadHandlerTexture textureDownloadHandler = (DownloadHandlerTexture)request.downloadHandler;
            Texture2D texture = textureDownloadHandler.texture; 
            image.sprite = Sprite.Create(texture, new Rect(0, 0, 96, 96), Vector2.zero);
            
        }
        else
        {
            Debug.Log("Connection Error");
            yield break;
        }
    }

    public IEnumerator ShowDownloadProgress(UnityWebRequest www)
    {
        while (!www.isDone)
        {
            slider.value = www.downloadProgress*100;
            Debug.Log("Download Progress: " +www.downloadProgress);
            progressText.text = (string.Format("{0:0%}", www.downloadProgress));
            yield return new WaitForSeconds(.01f);
        }
        slider.value = 0;
    }
}
