using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCamera : MonoBehaviour {

    [SerializeField] RawImage rawImage;
    [SerializeField] int devicesIndex = 0;
    int width = 1920;
    int height = 1080;
    int fps = 60;
    WebCamTexture webcamTexture;
    

    void Start () {
        WebCamDevice[] devices = WebCamTexture.devices;
        webcamTexture = new WebCamTexture(devices[devicesIndex].name, this.width, this.height, this.fps);
        rawImage.texture = webcamTexture;
        webcamTexture.Play();
    }
}