using Unity.VisualScripting;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public Transform spawn;
    public GameObject ballPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(ballPrefab,spawn.position,spawn.rotation);
        }
    }
}
