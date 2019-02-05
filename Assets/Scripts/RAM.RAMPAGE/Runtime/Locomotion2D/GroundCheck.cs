using System;
using System.Collections.Generic;
using RAM.RAMPAGE.Runtime.Validation;
using UnityEngine;
using UnityEngine.Assertions;

namespace RAM.RAMPAGE.Runtime.Locomotion
{

    public class GroundCheck : MonoBehaviour, IValidatable
    {
        [SerializeField]
        private Settings settings;

        private List<Collider2D> Colliders { get; } = new List<Collider2D>();
        public  bool Grounded => Colliders.Count > 0;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (((1 << other.gameObject.layer) & settings.LayerMask) != 0 && !Colliders.Contains(other))
                Colliders.Add(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (((1 << other.gameObject.layer) & settings.LayerMask) != 0 && Colliders.Contains(other))
                Colliders.Remove(other);
        }

        #if UNITY_EDITOR
        public void OnValidate()
        {
            Assert.IsNotNull(GetComponent<Collider2D>(), "GroundCheck must have a collider component.");
            GetComponent<Collider2D>().isTrigger = true;
        }
        #endif


        [Serializable]
        public class Settings
        {
            [SerializeField]
            private LayerMask _layerMask;
            public LayerMask LayerMask => _layerMask;
        }
        
    }
}
