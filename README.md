# RaylibWasm

.Net 8.0 webasssembly starter project using Raylib-cs nuget.

I've followed [DotnetRaylibWasm](https://github.com/disketteman/DotnetRaylibWasm) example project and some official Microsoft documentation.

## Setup

You must have .Net 8.0 installed before start.

Then install wasm toolset:

```
dotnet workload install wasm-tools
```

## Build

You should use publish option for building.

> [!WARNING]
> Do not use Visual Studio publication, it may cause some strange errors!

Just call this command from the root directory of the solution:
```
dotnet publish -c Release
```

## Run

You could use whatever web-server you want to serve published files.

OR

You could also use `dotnet serve` for this purpose:

If it's not installed, you need to install it with this command:
```
dotnet tool install --global dotnet-serve
```

And then just call this command to start web server for your build:
```
dotnet serve --mime .wasm=application/wasm --mime .js=text/javascript --mime .json=application/json --directory RaylibWasm\bin\Release\net8.0\browser-wasm\AppBundle\
```

While server is running you can use publish command to update your files without any need to restart server.

## Notes

This project includes webassembly build of raylib native 4.5 (`raylib.a` file), because it is not included with Raylib-cs nuget.

It seems that Raylib-cs uses some outdated functions, that not present in raylib native builds, so I'd had to use `WasmAllowUndefinedSymbols` flag to compile without errors, so there will be some warnings about it:
```
1>EXEC : warning : undefined symbol: GetSoundsPlaying (referenced by top-level compiled C/C++ code)
1>EXEC : warning : undefined symbol: rlDisableStatePointer (referenced by top-level compiled C/C++ code)
1>EXEC : warning : undefined symbol: rlEnableStatePointer (referenced by top-level compiled C/C++ code)
```

Raylib-cs may still have some webassembly compatibility issues that have been mentioned [here](https://github.com/disketteman/DotnetRaylibWasm/issues/11) and [here](https://github.com/disketteman/DotnetRaylibWasm/issues/4).

This project is not perfect, so I would welcome your suggestions and PR requests.

## Thanks

- to [Ray](https://github.com/raysan5) and all [Raylib](https://github.com/raysan5/raylib) contributors for such a wonderful lib
- to [ChrisDill](https://github.com/ChrisDill) for [Raylib C# bindings](https://github.com/ChrisDill/Raylib-cs)
- to [disketteman](https://github.com/disketteman) for dotnet webassembly [example project](https://github.com/disketteman/DotnetRaylibWasm)