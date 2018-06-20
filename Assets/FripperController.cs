using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour {
        //HingiJointコンポーネントを入れる
        private HingeJoint myHingeJoint;

        //初期の傾き
        private float defaultAngle = 20;
        //弾いた時の傾き
        private float flickAngle = -20;

        // Use this for initialization
        void Start () {
                //HingeJointコンポーネント取得
                this.myHingeJoint = GetComponent<HingeJoint>();

                //フリッパーの傾きを設定
                SetAngle(this.defaultAngle);
        }

        // Update is called once per frame
        void Update () {

                //左矢印キーを押した時左フリッパーを動かす
                if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
                SetAngle (this.flickAngle);
                }
                //右矢印キーを押した時右フリッパーを動かす
                if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag") {
                SetAngle (this.flickAngle);
                }

                //矢印キー離された時フリッパーを元に戻す
                if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
                SetAngle (this.defaultAngle);
                }
                if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag") {
                SetAngle (this.defaultAngle);
                }

                if (Input.touchCount > 0) {
                    Touch touch = Input.GetTouch(0);
                    switch (touch.phase)
                    {
                      case TouchPhase.Began:
                        if (touch.position.x < 0.5 * Screen.width && tag == "LeftFripperTag") {
                          SetAngle (this.flickAngle);
                        } else if (touch.position.x > 0.5 * Screen.width && tag == "RightFripperTag") {
                          SetAngle (this.flickAngle);
                        }
                      break;

                      case TouchPhase.Ended:
                        if (touch.position.x < 0.5 * Screen.width && tag == "LeftFripperTag") {
                          SetAngle (this.defaultAngle);
                        } else if (touch.position.x > 0.5 * Screen.width && tag == "RightFripperTag") {
                          SetAngle (this.defaultAngle);
                        }
                      break;
                    }
                  }
        }

        //フリッパーの傾きを設定
        public void SetAngle (float angle){
                JointSpring jointSpr = this.myHingeJoint.spring;
                jointSpr.targetPosition = angle;
                this.myHingeJoint.spring = jointSpr;
        }

}
