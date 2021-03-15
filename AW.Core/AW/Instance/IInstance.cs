// // (c) 2007 - 2011 Joshua R. Rodgers under the terms of the Ms-PL license.
using System;

namespace AW
{
    /// <summary>
    /// Delegate used for handling SDK events.
    /// </summary>
    /// <param name="sender"></param>
    public delegate void InstanceEventHandler(IInstance sender);

    /// <summary>
    /// Delegate used for handling SDK callbacks. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="result"></param>
    public delegate void InstanceCallbackHandler(IInstance sender, ReasonCode result);

    /// <summary>
    /// Exposes SDK instance operations for performing bot and world server administration.
    /// </summary>
    public partial interface IInstance : IDisposable
    {
        /// <summary>
        /// Stores data set by the user, associated with the instance.
        /// </summary>
        object Tag { get; set; }

        /// <summary>
        /// Returns the session associated with the instance.  This will change if connection is lost to the universe and re-established.
        /// </summary>
        int Session { get; }

        /// <summary>
        /// Indicates that the referenced <see cref="AW.Instance" /> has been disposed of.
        /// </summary>
        /// <remarks>
        /// If the <see cref="AW.Instance" /> has been disposed (as indicated by this property) do not attempt to call any methods.
        /// You will need to reconstruct the instance.
        /// </remarks>
        bool IsDisposed { get; }

        /// <summary>
        /// Container of attribute properties available to this instance.  Used to set and get the various attributes related to the different SDK operations.
        /// </summary>
        IAttributeProvider Attributes { get; }

        /// <summary>
        /// Sets the attribute Attributes.ObjectData of the instance to the data represented by the V4 object.
        /// </summary>
        /// <typeparam name="TV4Object">The type of the V4 object being used.</typeparam>
        /// <param name="v4Object">The V4 object representing the data to be set.</param>
        void SetV4Object<TV4Object>(TV4Object v4Object)
            where TV4Object : IV4Object, new();

        /// <summary>
        /// Retrieves a V4 object from the Attributes.ObjectData attribute of the instance.
        /// </summary>
        /// <typeparam name="TV4Object">the type of V4 object to be returned.</typeparam>
        /// <returns></returns>
        TV4Object GetV4Object<TV4Object>()
            where TV4Object : IV4Object, new();

        /// <summary>
        /// Logs the instance into the universe using the Attributes.LoginOwner, Attributes.LoginPrivilegePassword, Attributes.LoginName, and Attributes.LoginApplication that were set earlier.
        /// If CallbackLogin is not set, this is a blocking operation.
        /// </summary>
        ReasonCode Login();

        /// <summary>
        /// Causes the instance to enter the specified world.
        /// If CallbackEnter is not set, this is a blocking operation.
        /// </summary>
        /// <param name="world">The name of the world to enter.</param>
        ReasonCode Enter(string world);

        ///<summary>
        /// Causes the instance to leave the current world.
        /// It is not necessary to call this method when disconnecting or changing worlds.
        ///</summary>
        ReasonCode Exit();

        /// <summary>
        /// Causes the instance to change state within the world.
        /// </summary>     
        ReasonCode StateChange();

        ReasonCode ObjectClick();
        ReasonCode ObjectSelect();
        ReasonCode AvatarClick(int session);
        ReasonCode UrlSend(int session, string url, string target);
        ReasonCode UrlClick(string url);
        ReasonCode Teleport(int session);
        ReasonCode AvatarSet(int session);
        ReasonCode AvatarReload(int citizen, int session);
        ReasonCode ToolbarClick();
        ReasonCode Noise(int session);
        ReasonCode CameraSet(int session);
        ReasonCode BotmenuSend();
        ReasonCode ObjectBump();
        ReasonCode WorldList();
        ReasonCode Address(int session);
        ReasonCode UserList();
        ReasonCode AvatarLocation(int citizen, int sessionId, string name);
        ReasonCode Say(string message);
        ReasonCode Say(string message, object arg0);
        ReasonCode Say(string message, object arg0, object arg1);
        ReasonCode Say(string message, object arg0, object arg1, object arg2);
        ReasonCode Say(string message, params object[] args);
        ReasonCode Whisper(int session, string message);
        ReasonCode Whisper(int session, string message, object arg0);
        ReasonCode Whisper(int session, string message, object arg0, object arg1);
        ReasonCode Whisper(int session, string message, object arg0, object arg1, object arg2);
        ReasonCode Whisper(int session, string message, params object[] args);
        ReasonCode ConsoleMessage(int session);
        ReasonCode BotgramSend();
        ReasonCode Query(int xSector, int zSector, int[,] sequence);
        ReasonCode Query5x5(int xSector, int zSector, int[,] sequence);
        ReasonCode ObjectQuery();
        ReasonCode CellNext();
        ReasonCode ObjectAdd();
        ReasonCode ObjectChange();
        ReasonCode ObjectDelete();
        ReasonCode ObjectLoad();
        ReasonCode DeleteAllObjects();
        ReasonCode TerrainSet(int x, int z, int texture, int[] heights);
        ReasonCode TerrainQuery(int pageX, int pageZ, long sequence);
        ReasonCode TerrainNext();
        ReasonCode TerrainDeleteAll();
        ReasonCode TerrainLoadNode();
        ReasonCode MoverSetState(int id, int state, int modelNum);
        ReasonCode MoverSetPosition(int id, int x, int y, int z, int yaw, int pitch, int roll);
        ReasonCode MoverRiderAdd(int id, int session, int dist, int angle, int yDelta, int yawDelta, int pitchDelta);
        ReasonCode MoverRiderChange(int id, int session, int dist, int angle, int yDelta, int yawDelta, int pitchDelta);
        ReasonCode MoverRiderDelete(int id, int session);
        ReasonCode MoverLinks(int id);
        ReasonCode HudCreate();
        ReasonCode HudClick();
        ReasonCode HudDestroy(int session, int id);
        ReasonCode HudClear(int session);
        ReasonCode TrafficCount(out int inTraffic, out int outTraffic);
        ReasonCode CavRequest(int citizen, int session);
        ReasonCode CavChange();
        ReasonCode CavDelete();
        ReasonCode WorldCavRequest(int citizen, int session);
        ReasonCode WorldCavChange();
        ReasonCode WorldCavDelete();
        ReasonCode UniverseAttributesChange();
        ReasonCode UniverseEjectionAdd();
        ReasonCode UniverseEjectionDelete(int address);
        ReasonCode UniverseEjectionLookup();
        ReasonCode UniverseEjectionNext();
        ReasonCode UniverseEjectionPrevious();
        ReasonCode CitizenAttributesByName(string name);
        ReasonCode CitizenAttributesByNumber(int citizen);
        ReasonCode CitizenAdd();
        ReasonCode CitizenChange();
        ReasonCode CitizenDelete(int citizen);
        ReasonCode CitizenNext();
        ReasonCode CitizenPrevious();
        ReasonCode LicenseAdd();
        ReasonCode LicenseAttributes(string name);
        ReasonCode LicenseChange();
        ReasonCode LicenseDelete(string name);
        ReasonCode LicenseNext();
        ReasonCode LicensePrevious();
        ReasonCode WorldAttributesChange();
        ReasonCode WorldEject();
        ReasonCode WorldReloadRegistry();
        ReasonCode WorldAttributesReset();
        ReasonCode WorldInstanceSet(int citizen, int worldInstance);
        ReasonCode WorldInstanceGet(int citizen);
        ReasonCode WorldAttributesSend(int session);
        ReasonCode WorldEjectionAdd();
        ReasonCode WorldEjectionDelete();
        ReasonCode WorldEjectionLookup();
        ReasonCode WorldEjectionNext();
        ReasonCode WorldEjectionPrevious();
        ReasonCode WorldAttributeSet(int attribute, string value);
        ReasonCode WorldAttributeGet(int attribute, out bool readOnly, string value);
        bool CheckRight(int citizen, string rightString);
        bool CheckRightAll(string rightString);
        bool HasWorldRight(int citizen, Attributes right);
        bool HasWorldRightAll(Attributes right);
        ReasonCode ServerWorldAdd();
        ReasonCode ServerWorldDelete(int id);
        ReasonCode ServerWorldChange(int id);
        ReasonCode ServerWorldList();
        ReasonCode ServerWorldStart(int id);
        ReasonCode ServerWorldStop(int id);
        ReasonCode ServerWorldSet(int id);
        ReasonCode ServerWorldInstanceSet(int id);
        ReasonCode ServerWorldInstanceAdd(int id, int instanceId);
        ReasonCode ServerWorldInstanceDelete(int id, int instanceId);
        ReasonCode LaserBeam();
        ReasonCode Listen(ChatChannels channels);
        ReasonCode SayChannel(ChatChannels channel, string message);
        ReasonCode SayChannel(ChatChannels channel, string message, object arg0);
        ReasonCode SayChannel(ChatChannels channel, string message, object arg0, object arg1);
        ReasonCode SayChannel(ChatChannels channel, string message, object arg0, object arg1, object arg2);
        ReasonCode SayChannel(ChatChannels channel, string message, params object[] args);
        ReasonCode ObjectAddSession(int session);
        ReasonCode ObjectDeleteSession(int session);
        ReasonCode ServerWorldGet();

        /// <summary>
        /// Indicates that the instance is in the process of being disposed.
        /// </summary>
        event InstanceEventHandler Disposing;

        /// <summary>
        /// Sets a string attribute for the current instance.
        /// </summary>
        /// <param name="attribute">The attribute to be set.</param>
        /// <param name="value">The value of the attribute being set.</param>
        /// <exception cref="AW.InstanceAttributeException">Thrown when the instance failed to set the attribute.</exception>
        /// <exception cref="AW.InstanceSetFailedException">Thrown when the instance cannot be set properly. 
        /// (i.e. the instance has been destroyed or is not valid).</exception>
        [Obsolete("This method is now obsolete, use the IInstance.Attributes property instead.")]
        void SetString(Attributes attribute, string value);

        /// <summary>
        /// Gets a string attribute for the current instance.
        /// </summary>
        /// <param name="attribute">The attribute to be accessed.</param>
        /// <returns>The value of the attribute being accessed.</returns>
        /// <exception cref="AW.InstanceSetFailedException">Thrown when the instance cannot be set properly. 
        /// (i.e. the instance has been destroyed or is not valid).</exception>
        [Obsolete("This method is now obsolete, use the AW.IInstance.Attributes property instead.")]
        string GetString(Attributes attribute);

        /// <summary>
        /// Sets an integer attribute for the current instance.
        /// </summary>
        /// <param name="attribute">The attribute to be set.</param>
        /// <param name="value">The value of the attribute being set.</param>
        /// <exception cref="AW.InstanceAttributeException">Thrown when the instance failed to set the attribute.</exception>
        /// <exception cref="AW.InstanceSetFailedException">Thrown when the instance cannot be set properly. 
        /// (i.e. the instance has been destroyed or is not valid).</exception>
        [Obsolete("This method is now obsolete, use the AW.IInstance.Attributes property instead.")]
        void SetInt(Attributes attribute, int value);

        /// <summary>
        /// Gets an integer attribute for the current instance.
        /// </summary>
        /// <param name="attribute">The attribute to be accessed.</param>
        /// <returns>The value of the attribute being accessed.</returns>
        /// <exception cref="AW.InstanceSetFailedException">Thrown when the instance cannot be set properly. 
        /// (i.e. the instance has been destroyed or is not valid).</exception>
        [Obsolete("This method is now obsolete, use the AW.IInstance.Attributes property instead.")]
        int GetInt(Attributes attribute);

        /// <summary>
        /// Sets a boolean attribute for the current instance.
        /// </summary>
        /// <param name="attribute">The attribute to be set.</param>
        /// <param name="value">The value of the attribute being set.</param>
        /// <exception cref="AW.InstanceAttributeException">Thrown when the instance failed to set the attribute.</exception>
        /// <exception cref="AW.InstanceSetFailedException">Thrown when the instance cannot be set properly. 
        /// (i.e. the instance has been destroyed or is not valid).</exception>
        [Obsolete("This method is now obsolete, use the AW.IInstance.Attributes property instead.")]
        void SetBool(Attributes attribute, bool value);

        /// <summary>
        /// Gets a boolean attribute for the current instance.
        /// </summary>
        /// <param name="attribute">The attribute to be accessed.</param>
        /// <returns>The value of the attribute being accessed.</returns>
        /// <exception cref="AW.InstanceSetFailedException">Thrown when the instance cannot be set properly. 
        /// (i.e. the instance has been destroyed or is not valid).</exception>
        [Obsolete("This method is now obsolete, use the AW.IInstance.Attributes property instead.")]
        bool GetBool(Attributes attribute);

        /// <summary>
        /// Sets a floating point attribute for the current instance.
        /// </summary>
        /// <param name="attribute">The attribute to be set.</param>
        /// <param name="value">The value of the attribute being set.</param>
        /// <exception cref="AW.InstanceAttributeException">Thrown when the instance failed to set the attribute.</exception>
        /// <exception cref="AW.InstanceSetFailedException">Thrown when the instance cannot be set properly. 
        /// (i.e. the instance has been destroyed or is not valid).</exception>
        [Obsolete("This method is now obsolete, use the IInstance.Attributes property instead.")]
        void SetFloat(Attributes attribute, float value);

        /// <summary>
        /// Gets a floating point attribute for the current instance.
        /// </summary>
        /// <param name="attribute">The attribute to be accessed.</param>
        /// <returns>The value of the attribute being accessed.</returns>
        /// <exception cref="AW.InstanceSetFailedException">Thrown when the instance cannot be set properly. 
        /// (i.e. the instance has been destroyed or is not valid).</exception>
        [Obsolete("This method is now obsolete, use the IInstance.Attributes property instead.")]
        float GetFloat(Attributes attribute);

        /// <summary>
        /// Sets a data (<see cref="System.Array" /> of <see cref="System.Byte" />) attribute for the current instance.
        /// </summary>
        /// <param name="attribute">The attribute to be set.</param>
        /// <param name="value">The value of the attribute being set.</param>
        /// <exception cref="AW.InstanceAttributeException">Thrown when the instance failed to set the attribute.</exception>
        /// <exception cref="AW.InstanceSetFailedException">Thrown when the instance cannot be set properly. 
        /// (i.e. the instance has been destroyed or is not valid).</exception>
        [Obsolete("This method is now obsolete, use the IInstance.Attributes property instead.")]
        void SetData(Attributes attribute, byte[] value);

        /// <summary>
        /// Gets a data (<see cref="System.Array" /> of <see cref="System.Byte" />) attribute for the current instance.
        /// </summary>
        /// <param name="attribute">The attribute to be accessed.</param>
        /// <returns>The value of the attribute being accessed.</returns>
        /// <exception cref="AW.InstanceSetFailedException">Thrown when the instance cannot be set properly. 
        /// (i.e. the instance has been destroyed or is not valid).</exception>
        [Obsolete("This method is now obsolete, use the IInstance.Attributes property instead.")]
        byte[] GetData(Attributes attribute);

        /// <summary>
        /// Takes a string value representing an XML Custom Avatar defition and sets the <see cref="AW.Attributes.CavDefinition" /> attribute accordingly.
        /// </summary>
        /// <param name="cavContents">String representation of the Custom Avatar definition's XML.</param>
        /// <exception cref="AW.InstanceSetFailedException">Thrown when the instance cannot be set properly. 
        /// (i.e. the instance has been destroyed or is not valid).</exception>
        void SetCavData(string cavContents);

        /// <summary>
        /// Reads the <see cref="AW.Attributes.CavDefinition" /> attribute and returns the XML contained as a string.
        /// </summary>
        /// <returns>String representation of the Custom Avatar definition's XML.</returns>
        /// <exception cref="AW.InstanceSetFailedException">Thrown when the instance cannot be set properly. 
        /// (i.e. the instance has been destroyed or is not valid).</exception>
        string GetCavData();
    }
}
