[初めてのUnity](https://unity3d.com/jp/learn/tutorials/projects/hajiuni-jp)

1. [プロジェクトの作成](https://unity3d.com/jp/learn/tutorials/projects/hajiuni/creating-a-project?playlist=45986)

2. [ステージを作成](https://unity3d.com/jp/learn/tutorials/projects/hajiuni/creating-the-level?playlist=45986)
  - **全てのObjectに共通
    Hieratchy: Create→3DObject**
  - 地面、壁の作成: Plane、Cubeをここでは使用
  - Materialファイル: Objectの色などを決定
  - Objectの回転
  - StaticなObjectとして登録


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
    Capsuleを選択
  - 量産するために
    - Item Object を Prefab フォルダに保存
    - Scene View に Drag & Drop
***
links
[Documentation](https://docs.unity3d.com/ja/current/Manual/index.html)
[Script Reference](https://docs.unity3d.com/ja/current/ScriptReference/index.html)
