--Object基类
require("Object");
--Mono基类
require("Mono");
require("PanelBase");
--面板脚本
require("StartHome");
require("StartLogin");
require("GameHome");

--GameObject
GameObject = CS.UnityEngine.GameObject;
--Vector3
Vector3 = CS.UnityEngine.Vector3;
--Input
Input = CS.UnityEngine.Input;
--EventTriggerType
EventTriggerType = CS.UnityEngine.EventSystems.EventTriggerType;
--UI管理器
UIManager = CS.GameEngin.UI.CUIMgr;
--UI基类
UIBase = CS.GameEngin.UI.CUIBase;
--公共Mono管理器
MonoManager = CS.GameEngin.MonoTool.CGlobalMonoMgr;
--音效管理器
MusicManager = CS.GameEngin.Music.CMusicMgr;
--资源加载管理器
ResManager = CS.GameEngin.Res.CResLoadMgr;
--数据库管理器
MySQLManager = CS.GameEngin.MySQL.CMySqlMgr;
PlayerInfoMgr = CS.CPlayerInfoMgr;