using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bullet
{
    public class FarmMaster : MonoBehaviour
    {
        public GameObject[,] MapObject; //all lands object
        public GameObject[,] buildableGroundMark; // all lands posible position
        public int[,] MapIDs;
        [SerializeField]
        public int row = 8;
        [SerializeField]
        public int column = 8;

        public Construction[] BlocksInGame;
        //[Tooltip("make sure to mach position in the array with functions")]
        //public GameObject[] BuildableBlocks;

        //[Tooltip("make sure to mach position in the array with functions")]
        //public GameObject[] SelectBlocks;

      //  [Tooltip("make sure to mach position in the array with functions")]
       // public int[] BuildableBlocksPrice;
        [SerializeField]
        public List<Block> Inventory = new List<Block>();
        [SerializeField]
        

        static public FarmMaster Instance { get { return _instance; } }
        static protected FarmMaster _instance;

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
                _instance = this;
            }
        }

        void Start()
        {
        }
    }
}
