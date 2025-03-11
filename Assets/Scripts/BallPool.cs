using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallPool : MonoBehaviour
{   
    int pool1Size=5;
    [SerializeField] List<GameObject> cannonballs1;
    [SerializeField] List<GameObject> cannonballs2;
    int pool2Size=5;
    public GameObject ball1;
    public GameObject ball2;

    public static BallPool Instance{get;private set;}

    void Awake()
    {
        if(Instance==null)
            {
                Instance=this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
    }

    void Start()
    {
       MakePool1(pool1Size); 
       MakePool2(pool2Size); 
    }

    public void MakePool1(int poo1lSize)
    {
        for (int i = 0; i < poo1lSize; i++)
        {
            GameObject ball;
            ball= Instantiate(ball1);
            ball.SetActive(false);
            cannonballs1.Add(ball);
            ball.transform.parent=transform;
            
        }
    }

    public void MakePool2(int poo2lSize)
    {
        for (int i = 0; i <poo2lSize ; i++)
        {   
            GameObject ball;
            ball=Instantiate(ball2);
            ball.SetActive(false);
            cannonballs2.Add(ball);
            ball.transform.parent=transform;
        }
    }

    public GameObject UseBall1()
        {
            foreach (GameObject ball in cannonballs1)
            {
                if(!ball.activeInHierarchy)
                {
                    return ball;        
                }    
            }
        MakePool1(1);
        return cannonballs1.Last();
        }


    public GameObject Useball2()
    {
        foreach (GameObject ball in cannonballs2)
        {
            if(!ball.activeInHierarchy)
            {
                return ball;
            }            
        }
        MakePool2(1);
        return cannonballs2.Last();
    }


}
