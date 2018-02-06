using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensorCamera : MonoBehaviour {
    
    Camera droneCamera;

    // Use this for initialization

    void Start () {
        droneCamera = this.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        //RenderTexture rendText = RenderTexture.active;
        //RenderTexture.active = thisOne.targetTexture;

        //thisOne.Render();

        //Texture2D cameraImage = new Texture2D(thisOne.targetTexture.width, thisOne.targetTexture.height, TextureFormat.RGB24, false);
        //cameraImage.ReadPixels(new Rect(0, 0, thisOne.targetTexture.width, thisOne.targetTexture.height), 0, 0);
        //cameraImage.Apply();
        //RenderTexture.active = rendText;

        //// store the texture into a .PNG file
        //byte[] bytes = cameraImage.EncodeToPNG();

        //// save the encoded image to a file
        System.IO.File.WriteAllBytes(Application.persistentDataPath + "/camera_image.png", bytes);
        Texture2D text = GetRTPixels(droneCamera.targetTexture);

        byte[] bytes = text.EncodeToPNG();
        print("sera que vou escrever no ficheiro");

        System.IO.File.WriteAllBytes("C:/Users/luisr/Desktop/cheiodeMerda", bytes);
        
    }

    static public Texture2D GetRTPixels(RenderTexture rt)
    {
        // Remember currently active render texture
        RenderTexture currentActiveRT = RenderTexture.active;

        // Set the supplied RenderTexture as the active one
        RenderTexture.active = rt;

        // Create a new Texture2D and read the RenderTexture image into it
        Texture2D tex = new Texture2D(rt.width, rt.height);
        tex.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);

        // Restorie previously active render texture
        RenderTexture.active = currentActiveRT;
        return tex;
    }


}
