using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackScript : MonoBehaviour
{
    //  [SerializeField] Physics2D BackpackOBJ;
    [SerializeField] Collider2D backpackOBJ;
    [SerializeField] GameObject BackpackGO;
    //[SerializeField] Physics backpack;
    public List<Items> BackpackItems = new List<Items>();


    public void AddItem(Items item)
    {
        BackpackItems.Add(item);
    }


    void Start()
    {
       // BackpackOBJ = GetComponent<Physics2D>();
        BackpackGO = GetComponent<GameObject>();
        backpackOBJ = GetComponent<Collider2D>();
      //  backpack = GetComponent<Physics>();
    }

    void Update()
    {
        
    }
}
