# ComMutex

A Windows COM library to give limited scripting languages mutex capability.

## Description

ComMutex is a Windows COM (Component Object Model) library designed to provide mutex (mutual exclusion) capabilities to scripting languages that have limited support for such functionality. This library allows scripts to manage synchronization and ensure that critical sections of code are executed by only one thread at a time.

## Features

- Easy integration with various scripting languages.
- Provides mutex capabilities to ensure thread safety.
- Simple and intuitive API.

### Building

1. Clone the repository:
```cmd
git clone https://github.com/kimboslice99/ComMutex.git
cd ComMutex
msbuild ComMutex.sln /p:Configuration=Release
```
2. Place dll in a directory of choice then register with Regasm
```cmd
C:\Windows\Microsoft.NET\Framework\v4.0.30319\Regasm.exe /codebase ComMutex.dll
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\Regasm.exe /codebase ComMutex.dll
```

#### Example in Windows JScript

```javascript
var mutex = CreateObject("ComMutex.ComMutex")

// Aquire mutex
var createMutex = mutex.Create("hMailAuthLogMutex");
if(createMutex === false){
    WScript.Echo('Failed to create mutex')
}
// wait
var wait = mutex.WaitWithTimeout(5000);
if(wait === true){
    WScript.Echo("Aquired mutex")
}

// thread safe section of code

// Release the mutex 
mutex.ReleaseMutex()