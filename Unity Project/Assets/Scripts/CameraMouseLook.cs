using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseLook : MonoBehaviour {
    public float m_sensitivity = 5.0f;
    public float m_smoothing = 2.0f;

    Vector2 m_mouseLook;
    Vector2 m_smoothVector;

    GameObject m_playerCharacter;

	// Use this for initialization
	void Start () {
        m_playerCharacter = this.transform.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(m_sensitivity * m_smoothing, m_sensitivity * m_smoothing));
        m_smoothVector.x = Mathf.Lerp(m_smoothVector.x, mouseDelta.x, 1.0f / m_smoothing);
        m_smoothVector.y = Mathf.Lerp(m_smoothVector.y, mouseDelta.y, 1.0f / m_smoothing);
        m_mouseLook += m_smoothVector;

        m_mouseLook.y = Mathf.Clamp(m_mouseLook.y, -90.0f, 90.0f);

        transform.localRotation = Quaternion.AngleAxis(-m_mouseLook.y, Vector3.right);
        m_playerCharacter.transform.localRotation = Quaternion.AngleAxis(m_mouseLook.x, m_playerCharacter.transform.up);
    }
}
