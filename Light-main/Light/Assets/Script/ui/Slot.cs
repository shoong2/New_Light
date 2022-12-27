using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    public Item item;
    public int itemCount;
    public Image itemImage;

    [SerializeField]
    private Text text_Count;

    // [SerializeField]
    //private GameObject IsActive_Text;

    private void Start()
    {
       
    }


    //이미지 투명도 조절
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    public void AddItem(Item _item, int _count =1)
    {
        item = _item;
        //itemCount = _count;
        //GameManager.instance.saveData.getApple += _count;
        itemImage.sprite = item.itemImage;

        //IsActive_Text.SetActive(true);
        //text_Count.text = itemCount.ToString();
        text_Count.text = GameManager.instance.saveData.getApple.ToString();

        SetColor(1);
    }


    //아이템 갯수 조절
    public void SetSlotCount(int _count)
    {
        //itemCount += _count;
        //GameManager.instance.saveData.getApple += _count;
        //text_Count.text = itemCount.ToString();
        text_Count.text = GameManager.instance.saveData.getApple.ToString();

        //if (itemCount <= 0)
            //ClearSlot();



    }

    //슬롯 초기화

    void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";

    }
}
