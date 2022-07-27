#pragma once

#include"framework.h"
#include <Shldisp.h>
#include<shobjidl_core.h>
#include<thumbcache.h>


#include"RegTool.h"

#define WM_SPAWN_WORKER 0x052C

#define RESET_TASKBARTHUMB -1

//refrence https://github.com/TranslucentTB/TranslucentT
enum ACCENT_STATE :INT
{
	ACCENT_DISABLED = 0,
	ACCENT_ENABLE_GRADIENT = 1,
	ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
	ACCENT_ENABLE_BLURBEHIND =3,
	ACCENT_ENABLE_ACRYLICBLURBEHIND = 4
};

struct ACCENT_POLICY
{
	ACCENT_STATE AcentState;
	UINT AccentFlags;
	COLORREF GradientColor;
	LONG AnimationId;
};

enum WINDOWCOMPOSITIONATTRIB : INT
{
	WCA_ACCENT_POLICY = 0x13
};

struct WINDOWCOMPOSITIONATTRIBDATA
{
	WINDOWCOMPOSITIONATTRIB Attrib;
	LPVOID pvData;
	UINT cbData;
};

typedef struct tagTASKBARINFO
{
	int nTaskBarWidth;
	int nTaskBarHeight;
	int nTaskListWidth;
	int nStartMenuWidth;
	bool bDoubleTaskBar;
}TASKBARINFO, * PTASKBARINFO;

enum class DESKTOPICONS : INT
{
	ICON_COMPUTER,
	ICON_USER,
	ICON_RECYCLE,
	ICON_CONTROL_PANEL,
	ICON_NETWORK
};

typedef BOOL(WINAPI* PFN_SET_WINDOW_COMPOSITION_ATTRIBUTE)(HWND, const WINDOWCOMPOSITIONATTRIBDATA*);

SILVERAROWANACORE_API BOOL SetBackground(LPTSTR lpImagePath);
SILVERAROWANACORE_API BOOL SetBackgroundPosition(DESKTOP_WALLPAPER_POSITION pos);
SILVERAROWANACORE_API BOOL GetBackground(LPTSTR lpImagePath);
SILVERAROWANACORE_API BOOL GetBackgroundPosition(DESKTOP_WALLPAPER_POSITION* pos);
SILVERAROWANACORE_API BOOL GetRecentBackground(LPTSTR lpRecentPath);
SILVERAROWANACORE_API VOID SwitchToDesktop();
SILVERAROWANACORE_API VOID SwitchToWindow(HWND hwnd);
SILVERAROWANACORE_API BOOL CloseEmbedWindow();
BOOL CALLBACK EnumWindowProc(HWND hwnd, LPARAM lParam);
SILVERAROWANACORE_API HBITMAP GetFileThumbnail(PCWSTR path);
SILVERAROWANACORE_API BOOL CenterStartMenu(BOOL enable);
SILVERAROWANACORE_API BOOL CenterTaskListIcon(BOOL enable);
SILVERAROWANACORE_API BOOL BlurTaskbar(ACCENT_POLICY);
SILVERAROWANACORE_API VOID SetDesktopIcon(DESKTOPICONS, BOOL);
SILVERAROWANACORE_API BOOL GetDesktopIconState(DESKTOPICONS);
SILVERAROWANACORE_API VOID RefreshDesktop();
SILVERAROWANACORE_API BOOL CreateLink(LPCWSTR lpszPathObj,LPCTSTR lpszPathLink, LPCTSTR lpszArgs, LPCWSTR lpszDesc);
SILVERAROWANACORE_API BOOL GetGodModeShortCutState();
SILVERAROWANACORE_API BOOL CreateGodModeShortCut();
SILVERAROWANACORE_API BOOL RemoveGodModeShortCut();
SILVERAROWANACORE_API BOOL GetShortcutArrowState();
SILVERAROWANACORE_API BOOL RemoveShortcutArrow();  //TODO redundant code
SILVERAROWANACORE_API BOOL RestoreShortcutArrow();
SILVERAROWANACORE_API BOOL GetWindowsPhotoViewerState();
SILVERAROWANACORE_API VOID RegisterWindowsPhotoViewerFormat();
SILVERAROWANACORE_API VOID UnregisterWindowsPhotoViewerFormat();
SILVERAROWANACORE_API BOOL GetPaintVersionState();
SILVERAROWANACORE_API BOOL PaintVersionInfo(BOOL enable);
SILVERAROWANACORE_API BOOL GetTaskbarThumbnailSize(DWORD*);
SILVERAROWANACORE_API BOOL SetTaskbarThumbnailSize(DWORD,BOOL);


SILVERAROWANACORE_API BOOL EmbedWindowToDesktop(LPCTSTR lpWindowName);
VOID RestartExplorer();
