using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class TankDynamicMovement : MonoBehaviour
    {
        private Rigidbody2D rb;
        private float moveH, moveV;
        [SerializeField] private float moveSpeed = 1.0f;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        public void Move(Vector2 movement)
        {
            moveH = movement.y * moveSpeed;
            moveV = movement.x * moveSpeed;
            rb.velocity = new Vector2(moveH, moveV);
        }


    }

    
}
