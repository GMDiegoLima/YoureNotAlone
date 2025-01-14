using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcGO : MonoBehaviour
{

    public GameObject UIpressToGive;
    public Image UIHearth;
    private float currentLike = 0;
    public Transform SpawnPoint;
    public GameObject ShipPiecePrefab;

    private void Start()
    {
        UIpressToGive.SetActive(false);
        UIHearth.fillAmount = currentLike;
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (GameManager.player.itemInHand!=null && GameManager.player.itemInHand.resType == RessourceType.Wood)
        {
            UIpressToGive.SetActive(true);
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        UIpressToGive.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown("e") && UIpressToGive.activeInHierarchy )
        {
            GameManager.player.ItemIsGiven();
            currentLike += 0.33f;
            UIHearth.fillAmount = currentLike;
            UIpressToGive.SetActive(false);
            Instantiate(ShipPiecePrefab, SpawnPoint);
        }

      
    }
}
