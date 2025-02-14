﻿// header.h: 标准系统包含文件的包含文件，
// 或特定于项目的包含文件
//

#pragma once

#ifdef SILVERAROWANACORE_EXPORTS
#define SILVERAROWANACORE_API __declspec(dllexport)
#else
#define SILVERAROWANACORE_API __declspec(dllimport)
#endif

#ifndef INTERNAL_API
#define INTERNAL_API
#endif

#define WIN32_LEAN_AND_MEAN             // 从 Windows 头文件中排除极少使用的内容
// Windows 头文件
#include <windows.h>
#include<shlobj.h>
#include <strsafe.h>
#include<tchar.h>
#include<Shlwapi.h>
#include<shellapi.h>

#include<vector>
#include<string>

#include <Propkey.h> 
#include <atlbase.h>  

#pragma comment(lib,"Shlwapi.lib")

#define SZ_BACKSLASH TEXT("\\")


#define CHAR_BACKSLASH TEXT('\\')
#define CHAR_DOT TEXT('.')

