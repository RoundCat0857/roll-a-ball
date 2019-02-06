using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
  public float speed = 10;
  void FixedUpdate() {
    // 入力を変数に格納
    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");
    // Rigidbodyコンポーネントの取得
    Rigidbody rigidbody = GetComponent<Rigidbody>();
    // 入力をrigidbodyに反映
    rigidbody.AddForce(x, 0, z);
  }
}
