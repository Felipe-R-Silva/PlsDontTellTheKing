using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIfunctionsTown : MonoBehaviour {

    public GameObject TownData;
    
    public int MAX_WorkersvalueSlider =999;
    public int MAX_moneyvalueSlider =999;

    public void ChangeScene(int sceneNumber)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNumber);
    }
    public void AddWorker(int value)
    {
        // UIfunct.workersText, UIfunct.workersBar, UIfunct.PlayerInventoryGBJ
        townManager townManager;
        townManager = TownData.GetComponent<townManager>();
        //PlayerItems myItems = PlayerInventoryGBJ.GetComponent<townManager>().myItems;

        if ((townManager.curentworker + value < MAX_WorkersvalueSlider))
        {
            townManager.workersBar.fillAmount += (float)value / MAX_WorkersvalueSlider;
            int valueInIntegers = Mathf.RoundToInt(townManager.workersBar.fillAmount * MAX_WorkersvalueSlider);

            //redefine curent MAX workers global data
            if (valueInIntegers > Bullet.PlayerMaster.Instance.Totalworkers)
            {
                Bullet.PlayerMaster.Instance.save_Totalworkers(valueInIntegers);
            }
            //fill the bar UI
            if (valueInIntegers == Bullet.PlayerMaster.Instance.Totalworkers)
            {
                townManager.workersText.text = valueInIntegers.ToString();
            }
            else
            {
                townManager.workersText.text = valueInIntegers.ToString() + "/" + Bullet.PlayerMaster.Instance.Totalworkers.ToString();

            }
            //redefine workers global data
            Bullet.PlayerMaster.Instance.save_Workers(valueInIntegers);
            //redefine workers local scene
            townManager.curentworker = valueInIntegers;
        }

        else
        {
            townManager.workersBar.fillAmount = 1;
            townManager.curentworker = MAX_WorkersvalueSlider;
        }
    }


    public void fillWorkers()
    {
        AddWorker(Bullet.PlayerMaster.Instance.Totalworkers- Bullet.PlayerMaster.Instance.Workers);
    }



}
