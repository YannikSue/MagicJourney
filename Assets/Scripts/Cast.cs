using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cast : MonoBehaviour
{
    Vector3 mousePos;
    public float spellSpeed = 4f;
    public float spellDuration = 1f;

    public void CastSpell(Vector3 casterPos) {
        mousePos = this.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = -new Vector3(mousePos.x, mousePos.y, this.transform.position.z).normalized;
        
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1);

        Destroy(gameObject, spellDuration);
    }

    void Update() {
        this.transform.Translate(mousePos * Time.deltaTime * spellSpeed, Space.World);
    }
}