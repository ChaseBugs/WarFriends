# APK/XAPK를 Unity 프로젝트로 변환하는 방법

이 문서는 APK 또는 XAPK 안에 들어있는 Unity 게임 자료를 꺼내서 Unity 편집기에서 열 수 있는 프로젝트 형태로 복구하는 절차를 설명한다.

중요한 점은 APK/XAPK를 원래 개발자가 가지고 있던 완전한 Unity 원본 프로젝트로 되돌리는 것은 보통 불가능하다는 것이다. 특히 IL2CPP로 빌드된 게임은 C# 코드가 네이티브 코드로 변환되어 있으므로, 원래 C# 함수 내용은 깨끗하게 복구되지 않는다.

## 1. APK와 XAPK를 준비한다

필요한 파일:

```text
game.apk
game.xapk
```

XAPK는 보통 APK와 OBB 자료를 함께 담은 압축 파일이다.

리유:

APK만 보면 Unity 기본 자료 일부만 들어있고, 큰 리소스는 OBB에 따로 들어있는 경우가 많다. 그러므로 APK와 XAPK/OBB를 같이 보아야 빠진 asset을 줄일 수 있다.

## 2. XAPK를 압축 해제한다

PowerShell 예:

```powershell
Rename-Item game.xapk game.zip
Expand-Archive game.zip .\xapk_extract
```

압축을 풀면 보통 이런 구조가 나온다:

```text
*.apk
Android/obb/<package.name>/*.obb
```

리유:

XAPK 자체는 Unity 프로젝트가 아니다. 안에 들어있는 APK와 OBB를 분리해야 Unity Data 폴더를 찾을 수 있다.

## 3. APK를 압축 해제한다

```powershell
New-Item -ItemType Directory -Force .\apk_extract
tar -xf .\game.apk -C .\apk_extract
```

Unity Android 빌드에서는 보통 아래 폴더를 확인한다:

```text
assets/bin/Data
```

리유:

Unity scene, asset, global manager, metadata 같은 핵심 자료가 `assets/bin/Data` 아래에 들어있다.

## 4. Mono인지 IL2CPP인지 확인한다

Mono 빌드라면 보통 다음 파일이 있다:

```text
assets/bin/Data/Managed/Assembly-CSharp.dll
```

IL2CPP 빌드라면 보통 다음 파일들이 있다:

```text
lib/arm64-v8a/libil2cpp.so
assets/bin/Data/Managed/Metadata/global-metadata.dat
```

리유:

Mono는 C# DLL을 디컴파일해서 실제 코드에 가까운 결과를 얻을 가능성이 있다. 반대로 IL2CPP는 C# 코드가 네이티브 코드로 변환되어 있으므로 클래스 이름, 필드, 메소드 이름은 복구되어도 함수 본문은 보통 비어 있거나 dummy가 된다.

## 5. APK와 OBB의 Unity Data를 합친다

예:

```powershell
New-Item -ItemType Directory -Force .\combined\Data
Copy-Item -Recurse -Force .\apk_extract\assets\bin\Data\* .\combined\Data
Copy-Item -Recurse -Force .\xapk_extract\Android\obb\<package.name>\assets\bin\Data\* .\combined\Data
```

리유:

APK Data와 OBB Data가 서로 의존할 수 있다. 따로 불러오면 scene, sharedassets, texture, animation dependency가 누락될 수 있다.

## 6. split 파일을 다시 합친다

Unity Android 빌드에는 이런 파일들이 있을 수 있다:

```text
sharedassets0.assets.split0
sharedassets0.assets.split1
globalgamemanagers.assets.split0
```

이런 파일들은 번호 순서대로 이어붙여야 한다.

리유:

AssetRipper 같은 도구는 완전한 asset 파일을 읽는 것이 더 안정적이다. split 상태 그대로 두면 dependency missing 또는 partial import 문제가 생길 수 있다.

## 7. AssetRipper용 Android root를 만든다

추천 구조:

```text
android-root/
  assets/bin/Data/
  lib/arm64-v8a/libil2cpp.so
```

리유:

AssetRipper는 단순히 `Data` 폴더만 넣었을 때보다 Android 게임 구조를 갖춘 폴더를 넣었을 때 IL2CPP metadata와 Unity asset을 더 잘 연결한다.

## 8. AssetRipper로 Unity 프로젝트를 export한다

AssetRipper에서 `android-root` 폴더를 연다.

정상적인 경우 이런 내용을 확인할 수 있다:

```text
Android game structure has been found
Files use the IL2CPP scripting backend
During Il2Cpp initialization, found Unity version: 2018.4.23f1
```

그 다음 Unity Project로 export한다.

리유:

AssetRipper가 scene, prefab, material, texture, audio, animation, script 구조를 Unity 프로젝트 형식으로 다시 만들어 준다.

## 9. Unity 버전을 맞춰 연다

이 프로젝트는 다음 Unity 버전으로 복구되었다:

```text
2018.4.23f1
```

Unity Hub에서 `Client` 폴더를 열면 된다.

리유:

Unity asset serialization은 버전에 민감하다. 다른 버전으로 열면 자동 upgrade가 일어나고, shader나 prefab 참조가 더 깨질 수 있다.

## 10. IL2CPP 코드 한계를 이해한다

IL2CPP 프로젝트에서 복구된 C# 파일은 보통 이런 형태가 많다:

```csharp
private void SomeMethod()
{
}

private Player GetPlayer()
{
    return null;
}
```

리유:

원래 C# 함수 본문은 APK 안의 `Assembly-CSharp.dll`에 남아 있지 않고, `libil2cpp.so` 네이티브 코드 안으로 변환되어 있다. 그래서 Unity 프로젝트 복구는 가능하지만, 원래 gameplay logic을 그대로 되찾는 것은 별도 native reverse engineering이 필요하다.

## 11. 최종 프로젝트

현재 정리된 최종 Unity 프로젝트 폴더:

```text
Client
```

Unity Hub에서 이 폴더를 열면 된다.

## 12. 주의

이 작업은 본인이 소유했거나 분석 권한이 있는 APK/XAPK에만 해야 한다.

복구 결과는 보통 다음과 같다:

```text
복구 가능: asset, scene, prefab, material, texture, audio, animation, script 구조
부분 복구: shader metadata, IL2CPP class/member 정보
복구 어려움: 원래 C# 함수 본문, 완전한 shader source, 원래 Unity package 설정
```
