using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
        
        //ボールが見える可能性のあるz軸の最大値
        private float visiblePosZ = -6.5f;

        //ゲームオーバを表示するテキスト
        private GameObject gameoverText;

        // ポイント
        private GameObject scoreText;
        private int score = 0;

        // Use this for initialization
        void Start () {
                //シーン中のGameOverTextオブジェクトを取得
                this.gameoverText = GameObject.Find("GameOverText");
                this.scoreText = GameObject.Find("ScoreText");
                this.scoreText.GetComponent<Text> ().text = "Score: " + score;

        }
        
        // Update is called once per frame
        void Update () {
                //ボールが画面外に出た場合
                if (this.transform.position.z < this.visiblePosZ) {
                        //GameoverTextにゲームオーバを表示
                        this.gameoverText.GetComponent<Text> ().text = "Game Over";
                }
        }

        void OnCollisionEnter(Collision other) {
                if (other.gameObject.tag == "SmallStarTag" || other.gameObject.tag == "SmallCloudTag") {
                  score += 10;
                } else if (other.gameObject.tag == "LargeStarTag" || other.gameObject.tag == "LargeCloudTag") {
                  score += 20;
                }
                this.scoreText.GetComponent<Text> ().text = "Score: " + score;
        }
}
