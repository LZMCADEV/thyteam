using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    //public TextMeshProUGUI uiText;

    public void Awake (){
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
        
        
    }

    public void SetInventory(Inventory inventory){
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        
        RefreshInventoryItems();


    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e){
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems(){

        foreach (Transform child in itemSlotContainer) {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        float x = 0f;
        float y = 0f;
        int ylvl = 0;
        float itemSlotCellSize = 30f;
        foreach (Item item in inventory.GetItemlist()){
            
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            Debug.Log((item.itemType.ToString(), item.amount.ToString()));
            TextMeshProUGUI uiText = itemSlotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1){
                uiText.SetText(item.amount.ToString());
            } else {
                uiText.SetText("");
            }
            

            x = x + 2.270f;
            if (x > 9.0) {
                x = 0.0f;
                if (ylvl == 0) {
                    y = y - 2.01f;
                    ylvl = ylvl - 1;
                } else if (ylvl == -1){
                    y = y - 2.1f;
                    ylvl = ylvl - 1;
                } else if (ylvl == -2){
                    y = y - 2.1f;
                    ylvl = ylvl - 1;
                } else {
                    y = y - 2.1f;
                    ylvl = ylvl - 1;
                }
                

            }



        
        }
    }

}
