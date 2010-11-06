﻿using System;
namespace AW
{
    /// <summary>
    /// Used to handle events sent to the <see cref="AW.IInstance" />.
    /// </summary>
    /// <param name="sender">The instance that the event is associated with.</param>
    public delegate void InstanceEventDelegate(IInstance sender);

    /// <summary>
    /// Used to handle callbacks sent to the <see cref="AW.IInstance" />.
    /// </summary>
    /// <param name="sender">The instance that the event is associated with.</param>
    /// <param name="error">The error code associated with the callback.  Check this to ensure the callback was successful.</param>
    public delegate void InstanceCallbackDelegate(IInstance sender, int error);

    public interface IInstance : IDisposable
    {
        IAttributeProvider Attributes { get; }

        int Address(int session);
        int AvatarClick(int session);
        int AvatarLocation(int citizen, int sessionId, string name);
        int AvatarReload(int citizen, int session);
        int AvatarSet(int session);
        int BotgramSend();
        int BotmenuSend();
        event InstanceCallbackDelegate CallbackAddress;
        event InstanceCallbackDelegate CallbackAdmin;
        event InstanceCallbackDelegate CallbackAdminWorldList;
        event InstanceCallbackDelegate CallbackAdminWorldResult;
        event InstanceCallbackDelegate CallbackAttributesResetResult;
        event InstanceCallbackDelegate CallbackAvatarLocation;
        event InstanceCallbackDelegate CallbackBotgramResult;
        event InstanceCallbackDelegate CallbackBotmenuResult;
        event InstanceCallbackDelegate CallbackCav;
        event InstanceCallbackDelegate CallbackCavResult;
        event InstanceCallbackDelegate CallbackCellResult;
        event InstanceCallbackDelegate CallbackCitizenAttributes;
        event InstanceCallbackDelegate CallbackCitizenResult;
        event InstanceCallbackDelegate CallbackDeleteAllObjectsResult;
        event InstanceCallbackDelegate CallbackEnter;
        event InstanceCallbackDelegate CallbackHudResult;
        event InstanceCallbackDelegate CallbackLicenseAttributes;
        event InstanceCallbackDelegate CallbackLicenseResult;
        event InstanceCallbackDelegate CallbackLogin;
        event InstanceCallbackDelegate CallbackObjectQuery;
        event InstanceCallbackDelegate CallbackObjectResult;
        event InstanceCallbackDelegate CallbackQuery;
        event InstanceCallbackDelegate CallbackReloadRegistry;
        event InstanceCallbackDelegate CallbackTerrainDeleteAllResult;
        event InstanceCallbackDelegate CallbackTerrainLoadNodeResult;
        event InstanceCallbackDelegate CallbackTerrainNextResult;
        event InstanceCallbackDelegate CallbackTerrainSetResult;
        event InstanceCallbackDelegate CallbackUniverseEjection;
        event InstanceCallbackDelegate CallbackUniverseEjectionResult;
        event InstanceCallbackDelegate CallbackUserList;
        event InstanceCallbackDelegate CallbackWorldCav;
        event InstanceCallbackDelegate CallbackWorldCavResult;
        event InstanceCallbackDelegate CallbackWorldEjection;
        event InstanceCallbackDelegate CallbackWorldEjectionResult;
        event InstanceCallbackDelegate CallbackWorldInstance;
        int CameraSet(int session);
        int CavChange();
        int CavDelete();
        int CavRequest(int citizen, int session);
        int CellNext();
        bool CheckRight(int citizen, string rightString);
        bool CheckRightAll(string rightString);
        int CitizenAdd();
        int CitizenAttributesByName(string name);
        int CitizenAttributesByNumber(int citizen);
        int CitizenChange();
        int CitizenDelete(int citizen);
        int CitizenNext();
        int CitizenPrevious();
        int ConsoleMessage(int session);
        int DeleteAllObjects();
        int Enter(string world);
        event InstanceEventDelegate Disposing;
        event InstanceEventDelegate EventAdminWorldDelete;
        event InstanceEventDelegate EventAdminWorldInfo;
        event InstanceEventDelegate EventAvatarAdd;
        event InstanceEventDelegate EventAvatarChange;
        event InstanceEventDelegate EventAvatarClick;
        event InstanceEventDelegate EventAvatarDelete;
        event InstanceEventDelegate EventAvatarReload;
        event InstanceEventDelegate EventBotgram;
        event InstanceEventDelegate EventBotmenu;
        event InstanceEventDelegate EventCavDefinitionChange;
        event InstanceEventDelegate EventCellBegin;
        event InstanceEventDelegate EventCellEnd;
        event InstanceEventDelegate EventCellObject;
        event InstanceEventDelegate EventChat;
        event InstanceEventDelegate EventConsoleMessage;
        event InstanceEventDelegate EventEntityAdd;
        event InstanceEventDelegate EventEntityChange;
        event InstanceEventDelegate EventEntityDelete;
        event InstanceEventDelegate EventEntityLinks;
        event InstanceEventDelegate EventEntityRiderAdd;
        event InstanceEventDelegate EventEntityRiderChange;
        event InstanceEventDelegate EventEntityRiderDelete;
        event InstanceEventDelegate EventHudClick;
        event InstanceEventDelegate EventLaserBeam;
        event InstanceEventDelegate EventNoise;
        event InstanceEventDelegate EventObjectAdd;
        event InstanceEventDelegate EventObjectBump;
        event InstanceEventDelegate EventObjectClick;
        event InstanceEventDelegate EventObjectDelete;
        event InstanceEventDelegate EventObjectSelect;
        event InstanceEventDelegate EventTeleport;
        event InstanceEventDelegate EventTerrainBegin;
        event InstanceEventDelegate EventTerrainChanged;
        event InstanceEventDelegate EventTerrainData;
        event InstanceEventDelegate EventTerrainEnd;
        event InstanceEventDelegate EventToolbarClick;
        event InstanceEventDelegate EventUniverseAttributes;
        event InstanceEventDelegate EventUniverseDisconnect;
        event InstanceEventDelegate EventUrl;
        event InstanceEventDelegate EventUrlClick;
        event InstanceEventDelegate EventUserInfo;
        event InstanceEventDelegate EventWorldAttributes;
        event InstanceEventDelegate EventWorldCavDefinitionChange;
        event InstanceEventDelegate EventWorldDisconnect;
        event InstanceEventDelegate EventWorldInfo;
        int Exit();
        bool GetBool(Attributes attribute);
        string GetCAVData();
        byte[] GetData(Attributes attribute);
        float GetFloat(Attributes attribute);
        int GetInt(Attributes attribute);
        string GetString(Attributes attribute);
        void GetV4Object<TV4Object>(out TV4Object v4Object) where TV4Object : V4Object, new();
        bool HasWorldRight(int citizen, Attributes right);
        bool HasWorldRightAll(Attributes right);
        int HudClear(int session);
        int HudClick();
        int HudCreate();
        int HudDestroy(int session, int id);
        bool IsDisposed { get; }
        int LaserBeam();
        int LicenseAdd();
        int LicenseAttributes(string name);
        int LicenseChange();
        int LicenseDelete(string name);
        int LicenseNext();
        int LicensePrevious();
        int Login();
        int MoverLinks(int id);
        int MoverRiderAdd(int id, int session, int dist, int angle, int yDelta, int yawDelta, int pitchDelta);
        int MoverRiderChange(int id, int session, int dist, int angle, int yDelta, int yawDelta, int pitchDelta);
        int MoverRiderDelete(int id, int session);
        int MoverSetPosition(int id, int x, int y, int z, int yaw, int pitch, int roll);
        int MoverSetState(int id, int state, int modelNum);
        int Noise(int session);
        int ObjectAdd();
        int ObjectBump();
        int ObjectChange();
        int ObjectClick();
        int ObjectDelete();
        int ObjectLoad();
        int ObjectQuery();
        int ObjectSelect();
        int Query(int xSector, int zSector, int[,] sequence);
        int Query5x5(int xSector, int zSector, int[,] sequence);
        int Say(string message);
        int Say(string message, params object[] args);
        int Say(string message, object arg0);
        int Say(string message, object arg0, object arg1);
        int Say(string message, object arg0, object arg1, object arg2);
        int ServerWorldAdd();
        int ServerWorldChange(int id);
        int ServerWorldDelete(int id);
        int ServerWorldInstanceAdd(int id, int instanceId);
        int ServerWorldInstanceDelete(int id, int instanceId);
        int ServerWorldInstanceSet(int id);
        int ServerWorldList();
        int ServerWorldSet(int id);
        int ServerWorldStart(int id);
        int ServerWorldStop(int id);
        int Session { get; }
        int SetBool(Attributes attribute, bool value);
        int SetCAVData(string cavContents);
        int SetData(Attributes attribute, byte[] value);
        int SetFloat(Attributes attribute, float value);
        int SetInt(Attributes attribute, int value);
        int SetString(Attributes attribute, string value);
        int SetV4Object<TV4Object>(TV4Object v4Object) where TV4Object : V4Object;
        int StateChange();
        int Teleport(int session);
        int TerrainDeleteAll();
        int TerrainLoadNode();
        int TerrainNext();
        int TerrainQuery(int pageX, int pageZ, long sequence);
        int TerrainSet(int x, int z, int texture, int[] heights);
        int ToolbarClick();
        int TrafficCount(out int inTraffic, out int outTraffic);
        int UniverseAttributesChange();
        int UniverseEjectionAdd();
        int UniverseEjectionDelete(int address);
        int UniverseEjectionLookup();
        int UniverseEjectionNext();
        int UniverseEjectionPrevious();
        int UrlClick(string url);
        int UrlSend(int session, string url, string target);
        object UserData { get; set; }
        int UserList();
        int Whisper(int session, string message);
        int Whisper(int session, string message, params object[] args);
        int Whisper(int session, string message, object arg0);
        int Whisper(int session, string message, object arg0, object arg1);
        int Whisper(int session, string message, object arg0, object arg1, object arg2);
        int WorldAttributeGet(int attribute, out bool readOnly, string value);
        int WorldAttributesChange();
        int WorldAttributeSet(int attribute, string value);
        int WorldAttributesReset();
        int WorldAttributesSend(int session);
        int WorldCavChange();
        int WorldCavDelete();
        int WorldCavRequest(int citizen, int session);
        int WorldEject();
        int WorldEjectionAdd();
        int WorldEjectionDelete();
        int WorldEjectionLookup();
        int WorldEjectionNext();
        int WorldEjectionPrevious();
        int WorldInstanceGet(int citizen);
        int WorldInstanceSet(int citizen, int worldInstance);
        int WorldList();
        int WorldReloadRegistry();
    }
}