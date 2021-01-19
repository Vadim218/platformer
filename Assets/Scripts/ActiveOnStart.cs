using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnStart : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject[] levers;
    [SerializeField] GameObject[] stoneDoors;
    [SerializeField] GameObject[] stonePlatforms;
    [SerializeField] GameObject[] stoneTurrets;
    [SerializeField] GameObject[] stoneAutoTurrets;

    IEnumerator Wait(){
        while(true){
            if(Input.anyKey){
                foreach(GameObject obj in levers)
                    obj.GetComponent<Lever>().Active();
                foreach(GameObject obj in stoneDoors)
                    obj.GetComponent<StoneDoor>().Active(true);
                foreach(GameObject obj in stonePlatforms)
                    obj.GetComponent<StonePlatform>().Active(true);
                foreach(GameObject obj in stoneTurrets)
                    obj.GetComponent<StoneTurret>().Active(true);
                foreach(GameObject obj in stoneAutoTurrets)
                    obj.GetComponent<StoneAutoTurret>().Active(true);
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