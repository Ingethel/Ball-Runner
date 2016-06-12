using UnityEngine;
using System.Collections;

public class FixPanelCollider : MonoBehaviour {

	BoxCollider2D _collider;
	RectTransform _transform;
	Vector2 size;

	void Start () {
		_collider = GetComponent<BoxCollider2D> ();
		_transform = GetComponent<RectTransform> ();
		setColliderSize (
			new Vector2 (_transform.rect.width, _transform.rect.height)
			);
	}

	void Update () {
		setColliderSize (
			new Vector2 (_transform.rect.width, _transform.rect.height)
			);
	}

	void setColliderSize(Vector2 size){
		if (size != _collider.size) {
			_collider.size = size;
		}
	}

}
