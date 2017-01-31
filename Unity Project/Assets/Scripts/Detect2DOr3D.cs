using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Detect2DOr3D : MonoBehaviour {
    public GameObject m_caveMesh;
    public GameObject m_mainCamera;
    public GameObject m_fpsCamera;

    public GameObject m_playerController;

    // Use this for initialization
    void Start () {
        DetectOrientation();
    }

    void DetectOrientation () {
        if (m_caveMesh.GetComponent<MeshGenerator>().is2D == true) {
            m_fpsCamera.SetActive(false);
            m_mainCamera.SetActive(true);

            m_playerController.AddComponent<BoxCollider2D>();
            m_playerController.AddComponent<Rigidbody2D>();
            m_playerController.GetComponent<Rigidbody2D>().gravityScale = 0;  // This prevents the player character from sliding down, since the map is tilted 270 degrees or -90 degrees.
            m_playerController.AddComponent<Player2D>();
        } else if (m_caveMesh.transform.rotation.eulerAngles.x == 0) {
            m_fpsCamera.SetActive(true);
            m_mainCamera.SetActive(false);

            m_playerController.AddComponent<BoxCollider>();
            m_playerController.AddComponent<Rigidbody>();
            m_playerController.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            m_playerController.AddComponent<Player>();
        }
    }
}
