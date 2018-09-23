using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_orderInLayer : MonoBehaviour {
    public int SortLayer = 0;
    public int SortingLayerID = SortingLayer.GetLayerValueFromName("Default");
    // Use this for initialization
    void Start()
    {
        Renderer renderer = this.gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.sortingOrder = SortLayer;
            renderer.sortingLayerID = SortingLayerID;
        }
    }
}
