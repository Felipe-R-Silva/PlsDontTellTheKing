using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bullet
{
    [System.Serializable]
    public class PlayerMaster : MonoBehaviour
    {
        //public Item[] itemsUnlocked = new Item[5];
        public int Money;
        public int Lifes;
        public int MaxLifes;
        int MAXvalueSlider = 999;
        public int Workers;
        public int Totalworkers;



        //this is initialized on button start game
        [SerializeField]
        GameObject[,] MapObject; //all lands object
        [SerializeField]
        public List<Resource> Inventory = new List<Resource>();
        [SerializeField]
        public List<Land> FarmDataSave = new List<Land>();
        
        static public PlayerMaster Instance { get { return _instance; } }
        static protected PlayerMaster _instance;

        public bool isMouseMovement = false;

        public void Awake()
        {
            if (_instance != null)
            {
                Debug.LogWarning("PlayerMaster is already in play. Deleting new!", gameObject);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Instantiating new", gameObject);
                _instance = this; }
        }

        void Start()
        {
        }
        public void save_Workers(int value)
        {
            Workers = value;
        }
        public void save_Totalworkers(int value)
        {
            Totalworkers = value;
        }
    }
}


