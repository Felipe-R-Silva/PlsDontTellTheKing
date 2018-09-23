using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {
    Image myImage;


    void Start()
    {

        //var tempColor = myImage.color;
        //tempColor.a = 0.5f;
        //myImage.color = tempColor;

        //this.GetComponent<Image>().color = new Color32(0, 255, 0, 125);

    }

    void OnEnable()
    {
        myImage = this.GetComponent<Image>();
        //me.GetComponent<Image>().color = new Color32(0, 255, 0, 125);
        StartCoroutine(fade(myImage, 0.1f,0.01f,1f));
    }

    IEnumerator fade(Image myImage, float Increment,float delay,float lifetime)
    {
        Debug.Log("runing Coorutine");
        float alphavalue=0;
        //Increment = Increment % 1;
        while (true)
        {
            var tempColor1 = myImage.color;
            tempColor1.a = alphavalue;
            myImage.color = tempColor1;
            alphavalue += Increment;

            yield return new WaitForSeconds(delay);
            if (alphavalue >= 0.9)
            {
                break;
            }
        }
        yield return new WaitForSeconds(lifetime);
        var tempColor = myImage.color;
        tempColor.a = 0;
        myImage.color = tempColor;
        this.gameObject.SetActive(false);

    }
}
