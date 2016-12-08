using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rigidBody;
	private int count;

	void Start(){
		count = 0;
		SetCountText ();
		winText.gameObject.SetActive (false);
		rigidBody = GetComponent<Rigidbody> ();		
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		rigidBody.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		//Destroy(other.gameObject);
		if (other.gameObject.CompareTag("PickUp"))
		{
			count++;
			SetCountText ();
			other.gameObject.SetActive (false);
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 10) 
		{
			winText.gameObject.SetActive (true);
		}
		//if (count >= 10) {
		//	winText.text = "You Win!";
		//}
	}
			
}
