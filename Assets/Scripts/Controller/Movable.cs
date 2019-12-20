using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Controller {
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movable : MonoBehaviour {
        public const float MoveScale = 5;
        public float speed;
        public Vector2 direction;
        private float _moveConstrainX;
        private float _moveConstrainY;
        private Rigidbody2D _body;

        private void Start() {
            _moveConstrainY = GameController.instance.moveConstrain.y;
            _moveConstrainX = GameController.instance.moveConstrain.x;
            _body = GetComponent<Rigidbody2D>();
        }

//        private void Update() {
//            if (direction == Vector2.zero) return;
//            var distance = direction.normalized;
//            if (1 > direction.magnitude) distance = direction;
//            var newPos = transform.position + new Vector3(
//                distance.x * speed * Time.deltaTime * MoveScale,
//                distance.y * speed * Time.deltaTime * MoveScale, 
//                0);
//            newPos.y = Math.Max(newPos.y, _moveConstrainX);
//            newPos.y = Math.Min(newPos.y, _moveConstrainY);
//
//            transform.position = newPos;
//        }

//        private void Update() {
//            var transform1 = transform;
//            var position = transform1.position;
//            position.z = position.y;
//            transform1.position = position;
//        }

        private void FixedUpdate() {
            if (direction == Vector2.zero) {
                _body.velocity = direction;
            } else {
                _body.velocity = MoveScale * speed * direction.normalized;
            }
        }
    }
}