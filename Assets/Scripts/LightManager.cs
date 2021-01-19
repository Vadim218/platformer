using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LightManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject grid;
    [SerializeField] GameObject BG;
    [SerializeField] GameObject[] spikes;
    [SerializeField] GameObject[] levers;
    [SerializeField] GameObject[] stoneDoors;
    [SerializeField] GameObject[] stonePlatforms;
    [SerializeField] GameObject[] stoneTurrets;
    [SerializeField] GameObject[] stoneAutoTurrets;
    [Header("Materials")]
    [SerializeField] Material defaultMaterial;
    [Space(10)]
    [SerializeField] Material gridMaterial;
    [SerializeField] Material BGMaterial;
    [SerializeField] Material spikeMaterial;
    [SerializeField] Material[] leverMaterial;
    [SerializeField] Material[] stoneDoorMaterial;
    [SerializeField] Material[] stonePlatformMaterial;
    [SerializeField] Material stoneTurretMaterial;
    [SerializeField] Material[] stoneAutoTurretMaterial;

    public void Active(bool active)
    {
    	if(active)
    	{
    		grid.GetComponent<TilemapRenderer>().material = gridMaterial;
    		BG.GetComponent<TilemapRenderer>().material = BGMaterial;

    		foreach(GameObject obj in spikes)
    			obj.GetComponent<SpriteRenderer>().material = spikeMaterial;

    		foreach(GameObject obj in levers){
    			obj.GetComponent<SpriteRenderer>().material = leverMaterial[0];
    			obj.transform.GetChild(0).GetComponent<SpriteRenderer>().material = leverMaterial[1];
    			obj.transform.GetChild(1).GetComponent<SpriteRenderer>().material = leverMaterial[2];
    		}

    		foreach(GameObject obj in stoneDoors)
    		{
    			obj.GetComponent<SpriteRenderer>().material = stoneDoorMaterial[0];
    			obj.transform.GetChild(0).GetComponent<SpriteRenderer>().material = stoneDoorMaterial[1];
    			obj.transform.GetChild(1).GetComponent<SpriteRenderer>().material = stoneDoorMaterial[2];
    		}

    		foreach(GameObject obj in stonePlatforms)
    		{
    			obj.transform.GetChild(0).GetComponent<SpriteRenderer>().material = stonePlatformMaterial[0];
    			obj.transform.GetChild(1).GetComponent<SpriteRenderer>().material = stonePlatformMaterial[1];
    			obj.transform.GetChild(3).GetComponent<SpriteRenderer>().material = stonePlatformMaterial[3];
    			foreach(SpriteRenderer srt in obj.transform.GetChild(2).GetComponentsInChildren<SpriteRenderer>())
    				srt.material = stonePlatformMaterial[2];
    		}

    		foreach(GameObject obj in stoneTurrets)
    			obj.GetComponent<SpriteRenderer>().material = stoneTurretMaterial;

    		foreach(GameObject obj in stoneAutoTurrets)
    		{
    			obj.transform.GetChild(0).GetComponent<SpriteRenderer>().material = stoneAutoTurretMaterial[0];
    			obj.transform.GetChild(1).GetComponent<SpriteRenderer>().material = stoneAutoTurretMaterial[1];
    		}
    	}
    	else
    	{
    		grid.GetComponent<TilemapRenderer>().material = defaultMaterial;
    		BG.GetComponent<TilemapRenderer>().material = defaultMaterial;

    		foreach(GameObject obj in spikes)
    			obj.GetComponent<SpriteRenderer>().material = defaultMaterial;

    		foreach(GameObject obj in levers){
    			obj.GetComponent<SpriteRenderer>().material = defaultMaterial;
    			obj.transform.GetChild(0).GetComponent<SpriteRenderer>().material = defaultMaterial;
    			obj.transform.GetChild(1).GetComponent<SpriteRenderer>().material = defaultMaterial;
    		}

    		foreach(GameObject obj in stoneDoors)
    		{
    			obj.GetComponent<SpriteRenderer>().material = defaultMaterial;
    			obj.transform.GetChild(0).GetComponent<SpriteRenderer>().material = defaultMaterial;
    			obj.transform.GetChild(1).GetComponent<SpriteRenderer>().material = defaultMaterial;
    		}

    		foreach(GameObject obj in stonePlatforms)
    		{
    			obj.transform.GetChild(0).GetComponent<SpriteRenderer>().material = defaultMaterial;
    			obj.transform.GetChild(1).GetComponent<SpriteRenderer>().material = defaultMaterial;
    			obj.transform.GetChild(3).GetComponent<SpriteRenderer>().material = defaultMaterial;
    			foreach(SpriteRenderer srt in obj.transform.GetChild(2).GetComponentsInChildren<SpriteRenderer>())
    				srt.material = defaultMaterial;
    		}

    		foreach(GameObject obj in stoneTurrets)
    			obj.GetComponent<SpriteRenderer>().material = defaultMaterial;

    		foreach(GameObject obj in stoneAutoTurrets)
    		{
    			obj.transform.GetChild(0).GetComponent<SpriteRenderer>().material = defaultMaterial;
    			obj.transform.GetChild(1).GetComponent<SpriteRenderer>().material = defaultMaterial;
    		}
    	}
    }
}
