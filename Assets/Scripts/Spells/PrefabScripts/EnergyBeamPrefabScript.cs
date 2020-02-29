using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBeamPrefabScript : MonoBehaviour
{
    GameObject Player;
    GameObject ImpactObject;
    LineRenderer lr;

    float StartWidth = 0.02f;
    float EndWidth = 0.1f;
    float maxDistance = 1.5f;
    float distance = 0f;

    Color StartColor = Color.magenta;
    Color EndColor = Color.magenta;

    public void CastSpell(GameObject player)
    {
        this.Player = player;
        this.lr = this.GetComponent<LineRenderer>();

        this.lr.startWidth = StartWidth;
        this.lr.endWidth = EndWidth;
        this.lr.startColor = StartColor;
        this.lr.endColor = EndColor;
        this.lr.positionCount = 2;

        this.ImpactObject = this.transform.GetChild(0).gameObject;
        this.ImpactObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void EndCast()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if (this.distance < this.maxDistance)
        {
            this.distance += 0.05f;
        }

        Vector3 mousePos3d = this.Player.GetComponent<Player>().MainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerPos3d = this.Player.transform.position;

        Vector2 mousePos2d = new Vector2(mousePos3d.x, mousePos3d.y);
        Vector2 playerPos2d = new Vector2(playerPos3d.x, playerPos3d.y);

        RaycastHit2D hit = Physics2D.Raycast(playerPos2d, mousePos2d - playerPos2d, this.distance);

        this.lr.SetPosition(0, new Vector2(playerPos2d.x, playerPos2d.y));

        if (hit.collider != null)
        {
            this.lr.SetPosition(1, hit.point);
            this.ImpactObject.GetComponent<Transform>().position = hit.point;
            this.distance = (hit.point - playerPos2d).magnitude;
        }
        else
        {
            this.lr.SetPosition(1, playerPos2d + (mousePos2d - playerPos2d).normalized * this.distance);
            this.ImpactObject.GetComponent<Transform>().position = playerPos2d + (mousePos2d - playerPos2d).normalized * this.distance;
        }
    }
}
