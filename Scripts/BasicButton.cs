using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BasicButton : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        //do your stuff when highlighted
        this.transform.root.GetComponent<UIfunctions>().upgradeMeID = this.transform.parent.parent.GetComponent<buttonID_Upgrade>().Upgrade;
    }
    public void OnSelect(BaseEventData eventData)
    {
        //do your stuff when selected
        this.transform.root.GetComponent<UIfunctions>().upgradeMeID = this.transform.parent.parent.GetComponent<buttonID_Upgrade>().Upgrade;
    }
}
