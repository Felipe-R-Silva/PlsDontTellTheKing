using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ArrayLayout {
    [System.Serializable]
    public struct rowData
    {
        public GameObject[] ID;
    }
    public rowData[] rows = new rowData[7];//grid nx3  data.rows[1].ID[0]
}
