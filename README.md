# TweenAssistance

日本語 / [English](README_en.md)

![](https://img.shields.io/badge/Unity-2018.4-red.svg)
![](https://img.shields.io/badge/.NET-4.x-yellow.svg)
[![](https://img.shields.io/badge/License-MIT-green)](https://github.com/usam1111/TweenAssistance/blob/master/LICENSE)

## UnityPackage
- [TweenAssistance_v1.0.0.unitypackage](https://github.com/usam1111/TweenAssistance/blob/master/TweenAssistance_v1.0.0.unitypackage)
  - 別途 [DOTween](http://dotween.demigiant.com/documentation.php) のインポートが必要です。

## TweenAssistance の概要
- アニメーションさせる際のコード量を減らすツールです。
- トゥイーンの開始値と終了値をインスペクタで設定しておいて、コードで開始値を0、終了値を1とした場合の0～1を指定します。（0～1の範囲外の数値も可能）
- 下記のトゥイーンに対応しています。
  - maskableGraphic.color
  - maskableGraphic.color.a
  - transform.localScale
  - transform.localPosition
  - transform.localEulerAngles
- トゥイーン開始時は SetActive(true) が呼ばれ、トゥイーン終了時に値が開始値（0）の場合は SetActive(false) が呼ばれます。
- DOTween を使ってトゥイーンさせているので、別途DOTweenのインポートが必要です。

## 使用のメリット・デメリット

### メリット

- アクティブ状態のオン・オフの切り替えは、トゥイーンの開始時と終了時に自動で行われる。
- 位置をトゥイーンさせる際、開始位置や終了位置を変数で持たせるひと手間をインスペクタに入力して済ませられる。

### デメリット

- インスペクタで指定した開始値と終了値を繋ぐ値以外へトゥイーンさせることはできない。
  - 特にカラーの場合、開始カラーを白、終了カラーを赤にした場合、青へトゥイーンさせることはできない等、自由度が低くなる。
- パフォーマンスはDOTweenを直接使うよりも少しだけ重い。

## 使い方

### インスペクタ

動かしたいオブジェクトにTweenAssistanceコンポーネントを追加し、インスペクタで設定します。

![](https://raw.githubusercontent.com/usam1111/TweenAssistance/master/Screenshots/sample1.gif)

- inactiveOnAwake : 起動時にアクティブ状態をオフにするか
- useColor
  - ColorType.None : 色をトゥイーンさせない
  - ColorType.Alpha : アルファ値のみトゥイーンさせる
    - startAlpha : 開始アルファ（maskableGraphic.color.a）
    - endAlpha : 終了アルファ（maskableGraphic.color.a）
  - ColorType.Color : 色をトゥイーンさせる
    - startColor : 開始カラー（maskableGraphic.color）
    - endColor : 終了カラー（maskableGraphic.color）
- useScale : スケールをトゥイーンさせるか
  - startScale : 開始スケール（transform.localScale）
  - endScale : 終了スケール（transform.localScale）
- usePosition : 位置をトゥイーンさせるか
  - startPosition : 開始位置（transform.localPosition）
  - endPosition : 終了位置（transform.localPosition）
- useRotation : 角度をトゥイーンさせるか
  - startEulerAngles : 開始角度（transform.localEulerAngles）
  - endEulerAngles : 終了角度（transform.localEulerAngles）

### コード

using
```cs
using Itach.TweenAssistance;
```

インスペクタを使い、動かしたいオブジェクトのTweenAssistanceコンポーネントの参照を登録しておきます。
```cs
[SerializeField] private TweenAssistance imageObj = default;
```

登録したトゥイーンを実行する
```cs
imageObj.Animate(endValue: 1f, duration: 0.5f, ease: Ease.OutQuart);
```
Animate関数の引数
| 引数名 | 必須か | 型 | 説明 |
| :-- | :-- | :-- | :-- |
| startValue |  | float | インスペクタで登録した開始値を0、終了値を1とした場合のトゥイーンが始まる値  | 
| endValue | 必須 | float | インスペクタで登録した開始値を0、終了値を1とした場合のトゥイーンが終わる値  | 
| duration | 必須 | float | トゥイーンの秒数  | 
| ease |  | DG.Tweening.Ease | イージングの種類  | 
| delay |  | float | 遅延させる秒数（Animete関数を使った時点でGameObjectのアクティブ状態がオンになる点に注意）  | 
| flag |  | TweenFlag | Color, Scale, Position, Rotation を組み合わせるビットフラグ（どれをトゥイーンさせるか） | 

カラーのみトゥイーンさせる
```cs
imageObj.AnimateColor(1f, 0.5f);
```

スケールのみトゥイーンさせる
```cs
imageObj.AnimateScale(1f, 0.5f);
```

位置のみトゥイーンさせる
```cs
imageObj.AnimatePosition(1f, 0.5f);
```

角度のみトゥイーンさせる
```cs
imageObj.AnimateRotation(1f, 0.5f);
```

トゥイーン終了時に、Animate関数の引数endValueが0の場合でも自動でアクティブ状態をオフにしない<br />デフォルトは autoInactiveOnComplete = true
```cs
imageObj.autoInactiveOnComplete = false;
```