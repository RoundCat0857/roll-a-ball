[初めてのUnity](https://unity3d.com/jp/learn/tutorials/projects/hajiuni-jp)  

1. [プロジェクトの作成](https://unity3d.com/jp/learn/tutorials/projects/hajiuni/creating-a-project?playlist=45986)  

2. [ステージを作成](https://unity3d.com/jp/learn/tutorials/projects/hajiuni/creating-the-level?playlist=45986)  
  - **全てのObjectに共通  
    Hieratchy: Create→3DObject**  
  - 地面、壁の作成: Plane、Cubeをここでは使用  
  - Materialファイル: Objectの色などを決定  
  - Objectの回転  
  - **StaticなObjectとして登録**  


3. [プレイヤーの移動](https://unity3d.com/jp/learn/tutorials/projects/hajiuni/moving-the-player?playlist=45986)  
  - Playerの追加: Sphereをここでは使用  
  - コンポーネント  
  Playerの部品。当たり判定や物理演算をPlayerに設定している。  
  **C#で書かれた(実装する)Scriptによって制御するコンポーネントでも制御できる。**  
  - Script  
    - `void Update () {}`  
      フレームごとに処理  
    - `void FixedUpdate () {}`  
      物理演算のたびに処理  
    - public変数  
      直接Unityから変数の値を編集できる  


4. [カメラを動かす](https://unity3d.com/jp/learn/tutorials/projects/hajiuni/moving-the-camera?playlist=45986)  
  - プレイヤーの追跡  
    Asset->Scene->SceneName->Main Camera にScript Compornent を追加  
    追跡したいObjectを`public変数`で指定  
  - 相対距離の指定  
    1. Main Camera Incpection->Transform より相対座標を指定  
    2. 上記のCompornentを編集  
      - `void Start()`  
        起動時に１度だけ呼び出される  
        ここでOffsetを指定する  


5. [アイテム回収の追加](https://unity3d.com/jp/learn/tutorials/projects/hajiuni/creating-collectible-objects?playlist=45986)  
  - Item Objectの追加  
    Hierarchy: Create -> Capsule  
  - 量産するために  
    - Item Object を Prefab フォルダに保存  
    - Scene View に Drag & Drop  
  - 接触判定  
    - `OnTriggerEnter(Collider)`  
      Enter(接触)によってTrigger(発生)されるイベント  
    - `OnCollisionEnter(Collision)`  
      衝突判定をもつObjectとの接触によって発生するイベント  
      > [Collider](https://docs.unity3d.com/ja/current/ScriptReference/Collider.html), [Collision](https://docs.unity3d.com/ja/current/ScriptReference/Collision.html) 共にUnityEngine の Class

  - Itemの接触判定を変更  
    Item->Inspector より Is Trigger にチェック  
  - 対象を設定  
    ```
      void OnTriggerEnter (Collider hit) {
        if (hit.CompareTag ("Player")) {
          // 何らかの処理
        }
      }
    ```  
    引数のhitに接触対象の情報、上記コードではTagがPlayerなら処理  
    > タグの設定方法  
    > 対象とするObjectのInspectorよりTagを変更

  - 接触時に削除する  
    `Destroy(gameObject)`  


6. [ゲームのUIを追加](https://unity3d.com/jp/learn/tutorials/projects/hajiuni/creating-the-game-ui?playlist=45986)
  - **全てのUIに共通  
    Hierarchy: Create -> UI**  
  - Canvas設定  
    Hierarchy: Create -> UI -> Canvas  
    CanvasScaler -> UI Scale Mode を Scale With Screen Size  
  - Text設定  
    Canvas の直下に作られる  
    Hierarchy: Create -> UI -> Text  
    ReactTransform, Text Component をゲームに合うように設定  
  - GameController の作成  
    Create Empty   
    ```
      public class GameController : MonoBehaviour {
        // GameController Inspecter から public変数 scoreLabel を指定
        public UnityEngine.UI.Text scoreLabel;
        public void Update () {
          int count = GameObject.FindGameObjectsWithTag("Item").Length;
          // 指定された scoreLabel の Text に count を格納
          scoreLabel.text = count.ToString ();
        }
      }
    ```
    ここでは `scoreLabel` をUnity側で Canvas -> scoreLabel(上で準備したText) に設定  
  > Tagの追加  
  > Menu Bar -> ProjectSettings -> Tag And Layers より設定  
  > これ以降 Inspecter にそのタグが出現、選択可能に

7. [ゲームのクリアを追加](https://unity3d.com/jp/learn/tutorials/projects/hajiuni/ending-the-game?playlist=45986)
  Text `YOU WIN` を Item が0になったら表示
8. [障害物とリスタート](https://unity3d.com/jp/learn/tutorials/projects/hajiuni/adding-obstacles-and-restart?playlist=45986)
  壁同様に Material, Cube を生成  
  Emission: 物体を発光させる  
  `Emission 1.3 は Emission -> Color -> Intensity`  
  Static Object  
  Prefab  
  - DangerWall.cs
    ```
    void OnCollisionEnter (Collision hit) {
      // 接触対象はPlayerタグですか？
      if (hit.gameObject.CompareTag ("Player")) {
        // 現在のシーン番号を取得
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        // 現在のシーンを再読込する
        SceneManager.LoadScene(sceneIndex);
      }
    }
    ```
    
***  
links  
[Documentation](https://docs.unity3d.com/ja/current/Manual/index.html)  
[Script Reference](https://docs.unity3d.com/ja/current/ScriptReference/index.html)  
