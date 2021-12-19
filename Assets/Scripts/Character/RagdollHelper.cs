using System;
using System.Collections.Generic;
using System.Linq;
using Common.Algorithms;
using UnityEngine;

namespace Character
{
    public class RagdollHelper : MonoBehaviour
    {
        [SerializeField] private Transform baseTransform;
        [SerializeField] private Animator _animator;
        [SerializeField] private Collider capsuleColider;

        private Rigidbody[] _rigidbodies;
        private Collider[] _colliders;

        private Action<bool> _enableKinematicToAll;
        private Action<bool> _enableColliders;

        private void Awake()
        {
            if (baseTransform == null)
                return;

            if (capsuleColider == null)
            {
                capsuleColider = GetComponent<UnityEngine.CharacterController>();
            }

            List<Transform> transforms = RecursiveSearch.GetListWithChildren(baseTransform, 
                    (trans) => trans.childCount, 
                    (trans, i) => trans.GetChild(i));

            {
                _rigidbodies = transforms
                    .Select(child => child.GetComponent<Rigidbody>())
                    .Where(rigid => rigid != null).ToArray();

                foreach (var rigid in _rigidbodies)
                    _enableKinematicToAll += value => EnableKinematic(rigid, value);
            }

            // {
            //     _colliders = transforms
            //         .Select(child => child.GetComponent<Collider>())
            //         .Where(coll => coll != null).ToArray();
            //
            //     foreach (var coll in _colliders)
            //         _enableColliders += value => EnableCollider(coll, value);
            //
            //     _enableColliders(false);
            // }
        }

        private void Start()
        {
            _enableKinematicToAll(true);
        }

        private void EnableKinematic(Rigidbody rigid, bool value)
        {
            rigid.isKinematic = value;
        }

        private void EnableCollider(Collider coll, bool value)
        {
            coll.enabled = value;
        }

        public void EnableRagdoll(bool value)
        {
            capsuleColider.enabled = !value;
            _enableKinematicToAll(!value);
            // _enableColliders(value);
        }
        
    }
}