using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTurret : MonoBehaviour
{
    public float turretRotationSpeed = 150;

    public List<Sprite> nSprites;
    public List<Sprite> neSprites;
    public List<Sprite> eSprites;
    public List<Sprite> seSprites;
    public List<Sprite> sSprites;

    public SpriteRenderer spriteRenderer;
    Vector2 direction;


    public void Aim(Vector2 inputPointerPosition)
    {
        var turretDirection = (Vector3)inputPointerPosition - transform.position;
        var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;
        var rotationStep = turretRotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation,
            Quaternion.Euler(0, 0, desiredAngle - 90), rotationStep);

        //spriteRenderer = GetComponent<SpriteRenderer>();
        //Debug.Log(transform.rotation.z);

        //direction = new Vector2(Input.mousePosition.y, Input.mousePosition.x).normalized;

        //List<Sprite> selectedSprite = HandleSpriteFlip(transform.rotation);

        //if (selectedSprite != null)
        //{
        //    spriteRenderer.sprite = selectedSprite[0];
        //}




    }
    List<Sprite> HandleSpriteFlip(Quaternion direction)
    {
        List<Sprite> selected = nSprites;

        if (Mathf.Abs(direction.z) < 1 && Mathf.Abs(direction.z) > 0.71)
        {
            spriteRenderer.flipY = true;
        }



        return selected;
    }

}

