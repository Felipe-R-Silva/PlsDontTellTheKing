using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOnOffScript : MonoBehaviour {
    public GameObject craftBigPicturelistParent;

	public void TargetOnOff(GameObject target)
    {
        print(target.activeSelf);
        if (target.activeSelf)
        {
            target.SetActive(false);
        }
        else
        {
            target.SetActive(true);
        }
    }
    public void TargetOnOffCraft(GameObject target)
    {
        print(target.activeSelf);
        if (target.activeSelf)
        {
            target.SetActive(false);
        }
        else
        {
            foreach (Transform child in craftBigPicturelistParent.transform)
            {
                child.gameObject.SetActive(false);
            }
            target.SetActive(true);
        }
    }
}
