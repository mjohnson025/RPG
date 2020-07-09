using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.Core{
    public class CameraFollow : MonoBehaviour
{
    public bool gameOver = false;
    public GameObject player;
    Vector3 offset;
    [SerializeField]
    private float lerpRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        offset = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver){
            Follow();
        }
    }

    void Follow(){
        Vector3 pos = transform.position;
        Vector3 target = player.transform.position - offset;
        pos = Vector3.Lerp(pos, target, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
}
