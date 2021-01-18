using UnityEngine;
using UnityEngine.UI;

public class GetRndWeapon : MonoBehaviour
{
    weapon w;

    public WeaponDisplay weaponDisplay;
    public GameObject card;
    public Collection col;



    public GameObject OpenChestUI, ResultChestUI;

   public  void glowbgAnimation()
    {
        OpenChestUI.SetActive(false);
        ResultChestUI.SetActive(true);
    }

    public void SetVisibleCard()
    {    
        card.SetActive(true);
        SetResourcesImage();
        AddToMemory();
    }
    int itemIndex;
    private void SetResourcesImage()
    {
        Random.seed = System.DateTime.Now.Millisecond;
        var dice = Random.Range(0, 100);      

        if (dice >= 0) { itemIndex = Random.Range(0, 50); }
        if (dice >= 50) { itemIndex = Random.Range(51,60); }
        if (dice >= 90) { itemIndex = Random.Range(61, 65); }
        w = col.weapon[itemIndex];
            
        weaponDisplay.weapon = w;
        weaponDisplay.nameText.text = w.name;
        weaponDisplay.attackText.text = w.attack.ToString();
        weaponDisplay.art.sprite = w.art;

        col = GameObject.Find("Collection").GetComponent<Collection>();
        col.listweap.Add(w);

        archiveItems a = GameObject.Find("Archive").GetComponent<archiveItems>(); ;
        a.ChangeStateItem(itemIndex);
    }
    public Text ticketsText;
    public void AddToMemory()
    {
        GameObject.Find("Collection").GetComponent<Collection>().tickets--;

        ticketsText = GameObject.Find("TextTickets1").GetComponent<Text>();
        ticketsText.text = GameObject.Find("Collection").GetComponent<Collection>().tickets.ToString();


    }

    private void Wood()
    {

    }
    private void Silver()
    {

    }
    private void Gold()
    {

    }
}
