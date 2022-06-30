using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float speedModifier = 0.25f;
    PhotonView view;
    private void Start()
    {
        view = GetComponent<PhotonView>();
        CameraWork _cameraWork = this.gameObject.GetComponent<CameraWork>();


        if (_cameraWork != null)
        {
            if (view.IsMine)
            {
                _cameraWork.OnStartFollowing();
            }
        }
        else
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> CameraWork Component on playerPrefab.", this);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Sand") && (speed >= 4)) 
        {
            speed = speedModifier * speed;
            Debug.Log("sand!");
        }
        if(other.CompareTag("Sand") != true && (speed <= 4)) 
        {
            speed = speed * 1.5f;
            Debug.Log("sand!");
        }
    
    }
    
    //  private void OnTriggerExit2D(Collider2D other)
    // {
    //     //if(other.CompareTag("Sand") && (speed >= 4)) 
    //     //{
    //         speed += 3;
    //         Debug.Log("Enter!");
    //     //}

    // }
    

    private void Update()
    {
        if (view.IsMine)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 moveAmount = moveInput.normalized * speed * Time.deltaTime;
            transform.position += (Vector3)moveAmount;
        }
    }
}
