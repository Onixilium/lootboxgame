using UnityEngine;
using UnityEngine.UI;

public class GetRndWeapon : MonoBehaviour
{
    weapon w;

    public WeaponDisplay weaponDisplay;
    public GameObject card;
    public Collection collection;

    public GameObject OpenChestUI, ResultChestUI;

    SetUiText setUiText;


    public void Start()
    {
        collection = GameObject.Find("Collection").GetComponent<Collection>();
        setUiText = GameObject.Find("SceneManager").GetComponent<SetUiText>();
    } 

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
        w = collection.weapon[itemIndex];
        
        
        weaponDisplay.weapon = w;
        weaponDisplay.nameText.text = w.name;
        weaponDisplay.attackText.text = w.attack.ToString();
        weaponDisplay.art.sprite = w.art;


        collection.listweap.Add(w);

        w.Opened = true;
    }

 
    public  void AddToMemory()
    {
        collection.tickets--;        
        setUiText.SetBronzeKeyText(collection.tickets);
        collection.SavePlayer();
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
