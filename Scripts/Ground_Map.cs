using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ground_Map : MonoBehaviour {
    //public GameObject MainStone;
    [SerializeField]
    public Vector2 WhereAmI;
    // you cna find at any moment the coordinate of were you are the folowing way:
    //whereAmICoord = buildableGroundMark[Mathf.RoundToInt(WhereAmI.x), Mathf.RoundToInt(WhereAmI.y)].transform.position;
    //or using the start position :whereAmICoord=startPosition + new Vector3(BlockSize*i, 0, BlockSize*j);
    //ps all gameObject has WhereAmI on them.
    public bool buildactive=false;
    [SerializeField]
    public GameObject ConstructionBlock;
    [SerializeField]
    public int ConstructionBlockID;
    [SerializeField]
    public GameObject InstantiatMark;
    [SerializeField]
    public GameObject purtchaseAnim;
    [SerializeField]
    public GameObject functionsUI;

    [SerializeField]
    public GameObject PlayerInventoryGBJ;//player inventory
    [SerializeField]
    public int buyprice = 10;//cost of buildblock
    [SerializeField]
    public int workprice = 5;//cost for building a block worker wise

    [SerializeField]
    Vector3 startPosition;
    [SerializeField]
    int row;
    [SerializeField]
    int column;
    [SerializeField]
    int BlockSize = 8;
    [SerializeField]
    int[,] MapIDs;
    [SerializeField]
    GameObject[,] MapObject; //all lands object
    [SerializeField]
    GameObject[,] buildableGroundMark; // all lands posible position
    [SerializeField]
    public GameObject[] SelectionBlock; //user Interface Selection
    [SerializeField]
    Transform selectionTrans;
    [SerializeField]
    public string BlockName = "Null";

    // Use this for initialization
    void Start() {
        MapIDs = Bullet.FarmMaster.Instance.MapIDs;
        row = Bullet.FarmMaster.Instance.row;
        column = Bullet.FarmMaster.Instance.column;
        WhereAmI = new Vector2(0, 0);//numeric simplification of were object is startPosition + Vector3(BlockSize*Mathf.RoundToInt(WhereAmI.x), 0, BlockSize*Mathf.RoundToInt(WhereAmI.y))=transform.position
        startPosition = transform.position;//Starting Stone
        GameObject tempgameobjectforselectionblock = new GameObject();
        tempgameobjectforselectionblock.transform.position = startPosition;
        tempgameobjectforselectionblock.name = "temporary GameObj for Selection Block";
        //MapIDs = new int[row, column];
        MapObject = new GameObject[row, column];
        Debug.Log("AAAAAAAAAAAAAAA-->" + Bullet.FarmMaster.Instance.MapObject[0, 0]);
        // Bullet.FarmMaster.Instance.MapObject;

        //Grid
        buildableGroundMark = new GameObject[row, column];
        //instantiates buildable positions Grid
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                if (MapIDs[i, j] == -1)
                {
                    buildableGroundMark[i, j] = Instantiate(InstantiatMark, startPosition + new Vector3(BlockSize * i, 0, BlockSize * j), transform.rotation);
                }
                else{
                    InstantiateFarmBlocks(i, j, MapIDs[i, j]);
                }


            }
        }

        if (SelectionBlock[0] == null)
        {
            SelectionBlock[0] = tempgameobjectforselectionblock;
            SelectionBlock[1] = SelectionBlock[0];
        }
        if (!buildactive)
        {
            SelectionBlock[0].SetActive(false);
        }
    }

    void Update()
    {
        if (buildactive == true && ConstructionBlock != null)
        {
            //if null
            if(SelectionBlock[0] == null && SelectionBlock[1] !=null)
            {
                SelectionBlock[0] = Instantiate(SelectionBlock[1], selectionTrans.transform.position, selectionTrans.transform.rotation);
                SelectionBlock[1] = SelectionBlock[0];
            }
            //createSelection block if diferent
            if (SelectionBlock[0] != SelectionBlock[1])
            {
                selectionTrans = SelectionBlock[0].transform;
                Destroy(SelectionBlock[0]);
                SelectionBlock[0] = Instantiate(SelectionBlock[1], selectionTrans.transform.position, selectionTrans.transform.rotation);
                SelectionBlock[1] = SelectionBlock[0];
            }
            SelectionBlock[0].SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                
                if (MapIDs[Mathf.RoundToInt(WhereAmI.x), Mathf.RoundToInt(WhereAmI.y)] == -1)
                {
                    if (!functionsUI.GetComponent<UIfunctions>().NoMoneyUI(buyprice) && !functionsUI.GetComponent<UIfunctions>().NoWorkerUI(workprice))
                    {
                        //Instantiate LAND in empty spot
                        MapObject[Mathf.RoundToInt(WhereAmI.x), Mathf.RoundToInt(WhereAmI.y)] = Instantiate(ConstructionBlock, SelectionBlock[0].transform.position, transform.rotation);
                        //matrix with all positions with land
                        MapIDs[Mathf.RoundToInt(WhereAmI.x), Mathf.RoundToInt(WhereAmI.y)] = ConstructionBlockID;
                        //DontDestroyOn Load
                        //DontDestroyOnLoad(MapObject[Mathf.RoundToInt(WhereAmI.x), Mathf.RoundToInt(WhereAmI.y)]);
                        Bullet.FarmMaster.Instance.MapObject[Mathf.RoundToInt(WhereAmI.x), Mathf.RoundToInt(WhereAmI.y)]=MapObject[Mathf.RoundToInt(WhereAmI.x), Mathf.RoundToInt(WhereAmI.y)];
                        Debug.Log("AAAAAAAAAAAAAAA-->" + Mathf.RoundToInt(WhereAmI.x) + " "+Mathf.RoundToInt(WhereAmI.y));
                       Debug.Log("AAAAAAAAAAAAAAA-->" + MapObject[Mathf.RoundToInt(WhereAmI.x), Mathf.RoundToInt(WhereAmI.y)]);
                        //count reduce money
                        //                     StartCoroutine(functionsUI.GetComponent<UIfunctions>().SubtractmoneySlow(buyprice, 300, 0.02f));
                        functionsUI.GetComponent<UIfunctions>().RemoveMoney(buyprice);
                        //count reduce worker
                        functionsUI.GetComponent<UIfunctions>().RemoveWorker(workprice);
                        //Coin self destroy Animation
                        Instantiate(purtchaseAnim, SelectionBlock[0].transform.position + new Vector3(0, 4, 0), transform.rotation);
                        //Destroy aux map;
                        Destroy(buildableGroundMark[Mathf.RoundToInt(WhereAmI.x), Mathf.RoundToInt(WhereAmI.y)]);
                        //name the instantiated tyle
                        MapObject[Mathf.RoundToInt(WhereAmI.x), Mathf.RoundToInt(WhereAmI.y)].name = BlockName;
                        // Initialize Instnatiaded Object position in matrix
                        MapObject[Mathf.RoundToInt(WhereAmI.x), Mathf.RoundToInt(WhereAmI.y)].GetComponent<LandStarter>().WhereAmI = WhereAmI;
                        MapObject[Mathf.RoundToInt(WhereAmI.x), Mathf.RoundToInt(WhereAmI.y)].GetComponent<LandStarter>().ID= ConstructionBlockID;
                        MapObject[Mathf.RoundToInt(WhereAmI.x), Mathf.RoundToInt(WhereAmI.y)].GetComponent<LandStarter>().LandName = BlockName;
                        MapObject[Mathf.RoundToInt(WhereAmI.x), Mathf.RoundToInt(WhereAmI.y)].GetComponent<LandStarter>().CreationPrefab = ConstructionBlock;
                        functionsUI.GetComponent<UIfunctions>().SaveGrounds();
                        //savedata
                        PlayerInventoryGBJ.GetComponent<PlayerInventory>().save();
                    }
                }

            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (WhereAmI.y < column - 1)
                {
                    WhereAmI = WhereAmI + new Vector2(0, 1);
                    SelectionBlock[0].transform.Translate(0, 0, BlockSize);

                }

            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (WhereAmI.y > 0)
                {
                    WhereAmI = WhereAmI + new Vector2(0, -1);
                    SelectionBlock[0].transform.Translate(0, 0, -BlockSize);
                }

            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (WhereAmI.x < row - 1)
                {
                    WhereAmI = WhereAmI + new Vector2(1, 0);
                    SelectionBlock[0].transform.Translate(BlockSize, 0, 0);
                }

            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (WhereAmI.x > 0)
                {
                    WhereAmI = WhereAmI + new Vector2(-1, 0);
                    SelectionBlock[0].transform.Translate(-BlockSize, 0, 0);
                }

            }
        }
        if (SelectionBlock[0].activeInHierarchy && buildactive != true) {
            SelectionBlock[0].SetActive(false);
        }
    }

    public void BuildTrue(){
        buildactive = true;
    }
    public void BuildFalse()
    {
        buildactive = false;
    }
    public int[,] GetMapIDs()
    {
        return MapIDs;
    }


   private void InstantiateFarmBlocks(int x,int y,int ID)
    {
        
        MapObject[x, y] = Instantiate(Bullet.FarmMaster.Instance.BlocksInGame[ID].get_BuildableBlocks(), startPosition + new Vector3(BlockSize * x, 0, BlockSize * y), transform.rotation);
        //old
        //MapObject[x, y] = Instantiate(Bullet.FarmMaster.Instance.BuildableBlocks[ID], startPosition + new Vector3(BlockSize * x, 0, BlockSize * y), transform.rotation);
        MapObject[x, y].name = Bullet.FarmMaster.Instance.BlocksInGame[ID].get_BuildableBlocksName();
        //MapObject[x, y].GetComponent<LandStarter>().LandName= functionsUI.GetComponent<UIfunctions>().BuildableBlocksName[ID];
        MapObject[x, y].GetComponent<LandStarter>().ID = ID;
        MapObject[x, y].GetComponent<LandStarter>().WhereAmI = new Vector2(x, y);
        MapObject[x, y].GetComponent<LandStarter>().CreationPrefab = Bullet.FarmMaster.Instance.BlocksInGame[ID].get_BuildableBlocks();


    }
}

