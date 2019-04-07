using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{

    #region Static Variables

    #endregion

    #region Public Variables
	public PlayerActions actionRef;
    public KeyCode rightButton;
    public KeyCode leftButton;
    public KeyCode forwardButton;
    public KeyCode backButton;
    public KeyCode selectButton;
    #endregion

    #region Private Variables
    private Rigidbody _rbPlayer;
    [SerializeField]
    private float _playerSpeed;
    #endregion

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(rightButton))
        {
            transform.Translate(Vector3.right * _playerSpeed * Time.deltaTime);
        }

        if (Input.GetKey(leftButton))
        {
            transform.Translate(Vector3.left * _playerSpeed * Time.deltaTime);
        }

        if (Input.GetKey(forwardButton))
        {
            transform.Translate(Vector3.forward * _playerSpeed * Time.deltaTime);
        }

        if (Input.GetKey(backButton))
        {
            transform.Translate(Vector3.back * _playerSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(selectButton))
        {
            if (other.tag == "Vegetable")
            {
				actionRef.AddVegetable(other.gameObject.GetComponent<Vegetables>().vegId);
            }
        }
    }
}
