using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// ABCDEFGHIJKLMNOPQRSTUVWYXZ
public class LightManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject grid;
    [SerializeField] GameObject BG;
    [Space(2)]
    [SerializeField] GameObject[] boxes;
    [SerializeField] GameObject[] buttons;
    [SerializeField] GameObject[] levers;
    [SerializeField] GameObject[] spikes;
    [SerializeField] GameObject[] stairs;
    [SerializeField] GameObject[] stoneAutoTurrets;
    [SerializeField] GameObject[] stoneDoors;
    [SerializeField] GameObject[] stonePlatforms;
    [SerializeField] GameObject[] stoneTurrets;
    [Header("Materials")]
    [SerializeField] Material defaultMaterial;
    [Space(10)]
    [SerializeField] Material matGrid;
    [SerializeField] Material matBG;
    [Space(2)]
    [SerializeField] Material   matBox;
    [SerializeField] Material[] matButton;
    [SerializeField] Material[] matLever;
    [SerializeField] Material   matSpike;
    [SerializeField] Material[] matStair;
    [SerializeField] Material[] matStoneAutoTurret;
    [SerializeField] Material[] matStoneDoor;
    [SerializeField] Material[] matStonePlatform;
    [SerializeField] Material   matStoneTurret;

    public void Active(bool active)
    {
        Settings.light = active;
        
        if(active)
        {
            grid.GetComponentInChildren<TilemapRenderer>().material = matGrid;
            BG.GetComponentInChildren<TilemapRenderer>().material = matBG;

            foreach(GameObject obj in boxes)
                obj.GetComponent<SpriteRenderer>().material = matBox;

            foreach(GameObject obj in buttons){
                obj.GetComponent<SpriteRenderer>().material = matButton[0];
                obj.transform.GetChild(1).GetComponent<SpriteRenderer>().material = matButton[1];
            }

            foreach(GameObject obj in levers){
                obj.GetComponent<SpriteRenderer>().material = matLever[0];
                obj.transform.GetChild(0).GetComponent<SpriteRenderer>().material = matLever[1];
                obj.transform.GetChild(1).GetComponent<SpriteRenderer>().material = matLever[2];
            }

            foreach(GameObject obj in spikes)
                obj.GetComponent<SpriteRenderer>().material = matSpike;

            foreach(GameObject obj in stairs)
            {
                obj.transform.GetChild(0).GetComponent<SpriteRenderer>().material = matStair[0];
                foreach(SpriteRenderer spr in obj.transform.GetChild(1).GetComponentsInChildren<SpriteRenderer>())
                    spr.material = matStair[1];
            }

            foreach(GameObject obj in stoneAutoTurrets)
            {
                obj.transform.GetChild(0).GetComponent<SpriteRenderer>().material = matStoneAutoTurret[0];
                obj.transform.GetChild(1).GetComponent<SpriteRenderer>().material = matStoneAutoTurret[1];
            }

            foreach(GameObject obj in stoneDoors)
            {
                obj.GetComponent<SpriteRenderer>().material = matStoneDoor[0];
                obj.transform.GetChild(0).GetComponent<SpriteRenderer>().material = matStoneDoor[1];
                obj.transform.GetChild(1).GetComponent<SpriteRenderer>().material = matStoneDoor[2];
            }

            foreach(GameObject obj in stonePlatforms)
            {
                obj.transform.GetChild(0).GetComponent<SpriteRenderer>().material = matStonePlatform[0];
                obj.transform.GetChild(1).GetComponent<SpriteRenderer>().material = matStonePlatform[1];
                obj.transform.GetChild(3).GetComponent<SpriteRenderer>().material = matStonePlatform[3];
                foreach(SpriteRenderer srt in obj.transform.GetChild(2).GetComponentsInChildren<SpriteRenderer>())
                    srt.material = matStonePlatform[2];
            }

            foreach(GameObject obj in stoneTurrets)
                obj.GetComponent<SpriteRenderer>().material = matStoneTurret;
        }
        else
        {
            grid.GetComponentInChildren<TilemapRenderer>().material = defaultMaterial;
            BG.GetComponentInChildren<TilemapRenderer>().material = defaultMaterial;

            foreach(GameObject obj in boxes)
                obj.GetComponent<SpriteRenderer>().material = defaultMaterial;

            foreach(GameObject obj in buttons){
                obj.GetComponent<SpriteRenderer>().material = defaultMaterial;
                obj.transform.GetChild(1).GetComponent<SpriteRenderer>().material = defaultMaterial;
            }

            foreach(GameObject obj in levers){
                obj.GetComponent<SpriteRenderer>().material = defaultMaterial;
                obj.transform.GetChild(0).GetComponent<SpriteRenderer>().material = defaultMaterial;
                obj.transform.GetChild(1).GetComponent<SpriteRenderer>().material = defaultMaterial;
            }

            foreach(GameObject obj in spikes)
                obj.GetComponent<SpriteRenderer>().material = defaultMaterial;

            foreach(GameObject obj in stairs)
            {
                obj.transform.GetChild(0).GetComponent<SpriteRenderer>().material = defaultMaterial;
                foreach(SpriteRenderer spr in obj.transform.GetChild(1).GetComponentsInChildren<SpriteRenderer>())
                    spr.material = defaultMaterial;
            }

            foreach(GameObject obj in stoneAutoTurrets)
            {
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
        }
    }

    void Start()
    {
        Active(Settings.light);
    }
}