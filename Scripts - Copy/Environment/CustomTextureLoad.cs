using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomTextureLoad : MonoBehaviour
{
    //Allows the image link from the web to be inserted through the editor.
    public string TextureURL = "";


    void Start()
    {
        //Calls the Coroutine in start, so that the image gets downloaded and placed as a textutre onto an item.
        StartCoroutine(DownloadImage(TextureURL));
    }

    IEnumerator DownloadImage(string ImageLink)
    {
        //web request looks for the image to covert into a texture, Image link is the url that will be used for the texture
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(ImageLink);
        //yields when the request is complete
        yield return request.SendWebRequest();
        //if the request is interruptted by a network error it sends a response to the user that there was an error with the request.
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            //if there is no error then the texture will be rendered onto the selected item.
            this.gameObject.GetComponent<Renderer>().material.mainTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }
}

