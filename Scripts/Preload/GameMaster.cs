﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//
namespace Bullet
{
    public class GameMaster : MonoBehaviour
    {



        static public GameMaster Instance { get { return _instance; } }
        static protected GameMaster _instance;

        public bool isMouseMovement = false;

        public void Awake()
        {
            if (_instance != null)
            {
                Debug.LogWarning("Game Manager is already in play. Deleting new!", gameObject);
                Destroy(gameObject);
            }
            else
            { _instance = this; }
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.Delete))
            {
                Application.Quit();
            }
            if (Input.GetKey(KeyCode.R))
            {
                Reload();
            }
            if (Input.GetKey(KeyCode.Alpha4))
            {
                SceneManager.LoadScene(2);
            }

            if (Input.GetKey(KeyCode.Alpha1)) {
                Debug.Log(Bullet.PlayerMaster.Instance.Money);
            }

            if (Input.GetKey(KeyCode.Alpha2)) { }
                
        }

        public void Reload()
        {
            SceneManager.LoadScene(0);
        }
    }
}