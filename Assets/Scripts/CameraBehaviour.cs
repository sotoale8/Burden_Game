using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    void Start()
    {
        playerTransform= GameObject.Find("Captain").GetComponent<Transform>();
    }

  
    void LateUpdate()
    {
        transform.position=new Vector3(playerTransform.position.x,playerTransform.position.y,-10f);
    }
}
