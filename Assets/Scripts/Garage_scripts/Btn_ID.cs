using UnityEngine;
using UnityEngine.UI;


public class Btn_ID : MonoBehaviour
{
    public int ID;
    public string name;  

    [HideInInspector] public Item_Ikonki item;
    [HideInInspector] public Spawn_components spawn_components;
    [HideInInspector] public Button btn;
  
    public Main_Shop1 mainShop;
    public bool activeClose;

    public void Start()
    {       
        item = GetComponentInParent<Item_Ikonki>();
        btn = GetComponent<Button>();

        spawn_components = GetComponentInParent<Spawn_components>();

    }
    public void Update()
    { 
        btn.onClick.AddListener(Btn_Event);     
    }   
    public void Btn_Event()
    {        
        spawn_components.EventBtn_Pricel1(ID, name);
        mainShop.CloseGG(ID, name);
        item.Ikon_pricel(ID);       
    }
    
}
