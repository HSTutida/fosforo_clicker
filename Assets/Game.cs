using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //added to make this communicate with UI parts

public class Game : MonoBehaviour
{
    public Text ui; // public to make this editable in editor
    public Text uiCloud;
    public Text uiCow;
    public Text uiPoop;
    public Text uiSkull;
    public Text uiPoint;
    public Text uiLevel;
    [SerializeField] public GameObject cowPrefab;
    static float cowCount;
    public GameObject cowInstant;
    public List<GameObject> cowList;

    public void Increment(int num) // will atach this to the sprite to increment 
                                   // num will determine which sprite is clicked
    {
        if (num == 1 && GameManager.cloud >1) //num == 1 for tree click
        {
            GameManager.tree += GameManager.multiplier;
            GameManager.cloud -= GameManager.multiplier;
            if(GameManager.cloud < 0)
            {
                GameManager.cloud = 0;
            }
        }
        if (num == 2) 
        {
            GameManager.cloud += GameManager.multiplier;
        }
        if(num == 3 && GameManager.tree >1 && GameManager.tree > GameManager.multiplier)
        {
            GameManager.cow += GameManager.multiplier;
            GameManager.tree -= GameManager.multiplier;
        }
        if (num == 4 && GameManager.tree>GameManager.multiplier && GameManager.cow > GameManager.multiplier)
        {
            GameManager.poop += GameManager.multiplier;
            GameManager.tree -= GameManager.multiplier;
        }
        if (num == 5 && GameManager.cow >GameManager.multiplier)
        {
            GameManager.skull += GameManager.multiplier;
            GameManager.cow -= GameManager.multiplier;
        }

    } 

    public void Buy(int num) // function that increases the multipliers using the tree
                             // int num is used to choose which button is pressed
    {
        if (num == 1 && GameManager.poop >= 25 && GameManager.skull >=10)
        {
            GameManager.multiplier += 1;
            GameManager.poop -= 25;
            GameManager.skull -= 10;
        }
        if (num == 2 && GameManager.poop >= 125 && GameManager.skull >= 50)
        {
            GameManager.multiplier += 10;
            GameManager.poop -= 125;
            GameManager.skull -= 50;
        }
        if (num == 3 && GameManager.poop >= 1000 && GameManager.skull >= 400)
        {
            GameManager.multiplier += 100;
            GameManager.poop -= 1000;
            GameManager.skull -= 400;
        }
    }

    public void Update() // responsible to upgrade the text tree on top of screen
    {
        GameManager.cloud += Time.deltaTime;
        GameManager.cloudTime += Time.deltaTime;
        GameManager.plantTime += Time.deltaTime;
        GameManager.skullTime += Time.deltaTime;
        GameManager.poopTime += Time.deltaTime;

        if (GameManager.cloudTime > 2 && GameManager.cloud > 2) // for each 20 cloud, one plant is made 
        {
            //GameManager.tree += 2;
            //GameManager.tree = Mathf.Floor(GameManager.tree * 10f) / 10f;
            GameManager.cloud -= 2;
            GameManager.cloudTime = 0;
        }


        /*if (GameManager.plantTime > 3 && GameManager.tree > 10) // each 3 seconds each newborn cow each one plant
        {
            GameManager.cow += 10;
            GameManager.tree -= 10;
            GameManager.plantTime = 0;
        }*/

        if (GameManager.skullTime > 2 && GameManager.cow > 1) //ten percent of cows dies each 3 seconds
        {
            GameManager.skull += Mathf.Floor((GameManager.cow * 0.10f)*10f)/10f;
            GameManager.cow = Mathf.Floor((GameManager.cow * 0.90f) * 10f) / 10f;
            
            GameManager.skullTime = 0;
        }

        if (GameManager.poopTime > 2 && GameManager.tree > GameManager.cow/2 && GameManager.cow>1) // each 2 seconds poop increases the amount of
                                                                                                  // half cow, tree is consumed
        {
            GameManager.tree -= Mathf.Floor(GameManager.cow/2);
           
            GameManager.poop += Mathf.Floor(GameManager.cow/2);
            GameManager.poopTime = 0;
        }
        /*if (GameManager.cow > 8 && cowCount == 0) // instantiate a cow for 20
        {
            
            cowInstant = Instantiate(cowPrefab, new Vector3(1,1,0),Quaternion.identity);
            cowList.Add(cowInstant);
            cowInstant = Instantiate(cowPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            cowList.Add(cowInstant);
            cowCount += 1;
        }*/
        if(GameManager.cow > 20)
        {
           // cowFind = GameObject.FindGameObjectsWithTag("1");
            //print(cowFind[0]);
        }

        ui.text = "Planta: " + GameManager.tree;
        uiCloud.text = "Solo: " + GameManager.cloud;
        uiCow.text = "Animal: " + GameManager.cow;
        uiPoop.text = "Dejeto: " + GameManager.poop;
        uiSkull.text = "Cadáver: " + GameManager.skull;
        uiPoint.text = "Pontos: " + ((GameManager.cow + GameManager.tree)*GameManager.multiplier);
        uiLevel.text = "Nível: +" + GameManager.multiplier + " por click";
    }

    IEnumerator Test() //to test the wait function 
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(5);
        print(Time.time);
    }

    void Start()
    {
        cowList = new List<GameObject>();
        StartCoroutine(Test());
        cowCount = 0;
    }

 


}
