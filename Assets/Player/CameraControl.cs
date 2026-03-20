
using Unity.VisualScripting;
using UnityEngine;
public class CameraControl : MonoBehaviour
{
    private Transform player_position;
    private Transform this_component;
    private Vector3 offset;

    void Start()
    {
        player_position = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        this_component = GetComponent<Transform>();
        offset = this_component.position - player_position.position;

    }

    // Update is called once per frame
    void Update()
    {
        this_component.position = player_position.position + offset;
    }
}
