# TweenAssistance

[日本語](README.md) / English

![](https://img.shields.io/badge/Unity-2018.4-red.svg)
![](https://img.shields.io/badge/.NET-4.x-yellow.svg)
[![](https://img.shields.io/badge/License-MIT-green)](https://github.com/usam1111/TweenAssistance/blob/master/LICENSE)

<!-- 
## UnityPackage
- path
-->

## Overview of TweenAssistance
- It is a tool to reduce the amount of code for animation.
- Set the start value (0) and end value (1) of the tween in the inspector, and specify 0 to 1 in the code. (A value outside the range of 0 to 1 is also possible)
- The following tweens are supported.
  - maskableGraphic.color
  - maskableGraphic.color.a
  - transform.localScale
  - transform.localPosition
  - transform.localEulerAngles
- At the beginning of the tween, SetActive (true) is called, and at the end of the tween, if the value is the start value (0), SetActive (false) is called.
- Since tween is executed using DOTween, DOTween must be imported separately.

## How to use

### Inspector

Add a TweenAssistance component to the object you want to move and set it in the inspector.

![](https://raw.githubusercontent.com/usam1111/TweenAssistance/master/Screenshots/sample1.gif)

- inactiveOnAwake : Whether to turn off active state at startup
- useColor
  - ColorType.None : Don't tween colors
  - ColorType.Alpha : Tween only alpha values
    - startAlpha : maskableGraphic.color.a
    - endAlpha : maskableGraphic.color.a
  - ColorType.Color : Tween colors
    - startColor : maskableGraphic.color
    - endColor : maskableGraphic.color
- useScale : Whether to tween the scale
  - startScale : transform.localScale
  - endScale : transform.localScale
- usePosition : Whether to tween the position
  - startPosition : transform.localPosition
  - endPosition : transform.localPosition
- useRotation : Whether to tween the rotation
  - startEulerAngles :transform.localEulerAngles
  - endEulerAngles : transform.localEulerAngles

### code

using
```cs
using Itach.TweenAssistance;
```

Use the Inspector to register a reference to the TweenAssistance component of the object you want to move.
```cs
[SerializeField] private TweenAssistance imageObj = default;
```

Execute the registered tween
```cs
imageObj.Animate(endValue: 1f, duration: 0.5f, ease: Ease.OutQuart);
```
Animate function arguments
| Argument name | Required | Type | Description |
| :-- | :-- | :-- | :-- |
| startValue |  | float | The value at which the tween starts when the start value registered in the inspector is 0 and the end value is 1.  | 
| endValue | Required | float | The value at which the tween ends when the start value registered in the inspector is 0 and the end value is 1.  | 
| duration | Required | float | Tween seconds  | 
| ease |  | DG.Tweening.Ease | Types of easing  | 
| delay |  | float | Number of seconds to delay (note that GameObject's active state is turned on when the Animete function is used)  | 
| flag |  | TweenFlag | Bit flag that combines Color, Scale, Position, and Rotation (which tween) | 

Tween color only
```cs
imageObj.AnimateColor(1f, 0.5f);
```

Tween scale only
```cs
imageObj.AnimateScale(1f, 0.5f);
```

Tween only position
```cs
imageObj.AnimatePosition(1f, 0.5f);
```

Tween only rotation
```cs
imageObj.AnimateRotation(1f, 0.5f);
```

When the tween ends, the active state is not automatically turned off even if the endValue of the Animate function is 0.<br />Default is autoInactiveOnComplete = true
```cs
imageObj.autoInactiveOnComplete = false;
```