using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnStart : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject[] Levers;
    [SerializeField] GameObject[] StoneDoors;
    [SerializeField] GameObject[] StonePlatforms;
    [SerializeField] GameObject[] StoneTurrets;

    IEnumerator Wait(){
        while(true){
            if(Input.anyKey){
                foreach(GameObject obj in Levers)
                    obj.GetComponent<Lever>().Active();
                foreach(GameObject obj in StoneDoors)
                    obj.GetComponent<StoneDoor>().Active(true);
                foreach(GameObject obj in StonePlatforms)
                    obj.GetComponent<StonePlatform>().Active(true);
                foreach(GameObject obj in StoneTurrets)
                    obj.GetComponent<StoneTurret>().Active(true);
                break;
            }
            yield return null;
        }
        Destroy(gameObject);
    }

    void Start()
    {
        StartCoroutine("Wait");
    }
}