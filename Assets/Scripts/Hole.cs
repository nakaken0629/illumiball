using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {
	// どのボールを吸い寄せるかをタグで指定
	public string activeTag;

	void OnTriggerStay (Collider other) {
		// コライダに触れているオブジェクトのRigidbodyコンポーネントを取得
		Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

		// ボールがどの方向にあるかを計算
		Vector3 direction = transform.position - other.gameObject.transform.position;
		direction.Normalize ();

		// タグに応じてボールに力を加える
		if (other.gameObject.tag == activeTag) {
			// 中心地点でボールを止めるため速度を減速させる
			r.velocity *= 0.9f;
			r.AddForce (direction * r.mass * 20.0f);
		} else {
			r.AddForce (-direction * r.mass * 80.0f);
		}
	}
}
