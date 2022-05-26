using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LP.SpawnObjectsNewInputTutorial
{

    public class SpawnCube : MonoBehaviour
    {
        [SerializeField] GameObject cubePrefab = null;
        private Camera cam = null;

        private void Start()
        {
            cam = Camera.main;
        }

        private void Update()
        {
            SpawnAtMousePos();
        }

        private void SpawnAtMousePos()
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Instantiate(cubePrefab, new Vector3(hit.point.x, hit.point.y + cubePrefab.transform.position.y, hit.point.z), Quaternion.identity);
                } 
            }
        }        
    }

}