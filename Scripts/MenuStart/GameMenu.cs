using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour {
    public GameObject trigo;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonNewGameF()
    {
        Bullet.FarmMaster.Instance.row = 5;
        Bullet.FarmMaster.Instance.column = 5;
        Bullet.FarmMaster.Instance.MapIDs = new int[Bullet.FarmMaster.Instance.row, Bullet.FarmMaster.Instance.column];

        Bullet.PlayerMaster.Instance.Inventory.Add(new Resource(0, "Mud"));
        Bullet.PlayerMaster.Instance.Inventory.Add(new Resource(1, "Water"));
        Bullet.PlayerMaster.Instance.Inventory.Add(new Resource(2, "Wheat"));
        Bullet.PlayerMaster.Instance.Inventory.Add(new Resource(3, "Wood"));
        Bullet.PlayerMaster.Instance.Inventory.Add(new Resource(4, "brick"));
        Bullet.PlayerMaster.Instance.Inventory.Add(new Resource(5, "rock"));
        Bullet.PlayerMaster.Instance.Inventory.Add(new Resource(6, "fish"));
        Bullet.PlayerMaster.Instance.Inventory.Add(new Resource(7, "ore"));
        Bullet.PlayerMaster.Instance.Inventory.Add(new Resource(8, "bread"));
        Bullet.PlayerMaster.Instance.Inventory.Add(new Resource(9, "Flour"));
        Bullet.PlayerMaster.Instance.Inventory.Add(new Resource(10, "FishStick"));
        Bullet.PlayerMaster.Instance.MaxLifes = 3;
        Bullet.PlayerMaster.Instance.Money = 240;
        Bullet.PlayerMaster.Instance.Lifes = 2;
        Bullet.PlayerMaster.Instance.Workers = 30;
        Bullet.PlayerMaster.Instance.Totalworkers = 30;
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);

        
        for (int i = 0; i < Bullet.FarmMaster.Instance.row; i++)
        {
            for (int j = 0; j < Bullet.FarmMaster.Instance.column; j++)
            {
                Bullet.FarmMaster.Instance.MapIDs[i, j] = -1;

            }
        }
        Bullet.FarmMaster.Instance.MapIDs[0, 0] = 2;
        Bullet.FarmMaster.Instance.MapIDs[0, 2] = 0;
        Bullet.FarmMaster.Instance.MapIDs[1, 2] = 1;
        int BlockSize = 8;
        Bullet.FarmMaster.Instance.MapObject = new GameObject[Bullet.FarmMaster.Instance.row, Bullet.FarmMaster.Instance.column];
        Bullet.FarmMaster.Instance.MapObject[1, 1] = trigo;


    }
}
