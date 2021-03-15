// // (c) 2007 - 2011 Joshua R. Rodgers under the terms of the Ms-PL license.
using System;

namespace AW
{
    partial class Instance
    {
        #region Instance manage methods
        /// <summary>
        /// Logs the instance into the universe using the Attributes.LoginOwner, Attributes.LoginPrivilegePassword, Attributes.LoginName, and Attributes.LoginApplication that were set earlier.
        /// If CallbackLogin is not set, this is a blocking operation.
        /// </summary>
        public ReasonCode Login()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_login();
        }

        /// <summary>
        /// Causes the instance to enter the specified world.
        /// If CallbackEnter is not set, this is a blocking operation.
        /// </summary>
        /// <param name="world">The name of the world to enter.</param>
        public ReasonCode Enter(string world)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_enter(world);
        }

        ///<summary>
        /// Causes the instance to leave the current world.
        /// It is not necessary to call this method when disconnecting or changing worlds.
        ///</summary>
        public ReasonCode Exit()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_exit();
        }

        /// <summary>
        /// Causes the instance to change state within the world.
        /// </summary>     
        public ReasonCode StateChange()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_state_change();
        }
        #endregion

        #region Event manipulation methods
        public ReasonCode ObjectClick()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_object_click();
        }

        public ReasonCode ObjectSelect()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_object_select();
        }

        public ReasonCode AvatarClick(int session)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_avatar_click(session);
        }

        public ReasonCode UrlSend(int session, string url, string target)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_url_send(session, url, target);
        }

        public ReasonCode UrlClick(string url)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_url_click(url);
        }

        public ReasonCode Teleport(int session)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_teleport(session);
        }

        public ReasonCode AvatarSet(int session)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_avatar_set(session);
        }

        public ReasonCode AvatarReload(int citizen, int session)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_avatar_reload(citizen, session);
        }

        public ReasonCode ToolbarClick()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_toolbar_click();
        }

        public ReasonCode Noise(int session)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_noise(session);
        }

        public ReasonCode CameraSet(int session)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_camera_set(session);
        }

        public ReasonCode BotmenuSend()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_botmenu_send();
        }

        public ReasonCode ObjectBump()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_object_bump();
        }
        #endregion

        #region Information query methods
        public ReasonCode WorldList()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_world_list();
        }

        public ReasonCode Address(int session)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_address(session);
        }

        public ReasonCode UserList()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_user_list();
        }

        public ReasonCode AvatarLocation(int citizen, int sessionId, string name)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_avatar_location(citizen, sessionId, name);
        }
        #endregion

        #region Communication methods
        public ReasonCode Say(string message)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_say(message);
        }

        public ReasonCode Say(string message, object arg0)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_say(string.Format(message, arg0));
        }

        public ReasonCode Say(string message, object arg0, object arg1)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_say(string.Format(message, arg0, arg1));
        }

        public ReasonCode Say(string message, object arg0, object arg1, object arg2)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_say(string.Format(message, arg0, arg1, arg2));
        }

        public ReasonCode Say(string message, params object[] args)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_say(string.Format(message, args));
        }

        public ReasonCode Whisper(int session, string message)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_whisper(session, message);
        }

        public ReasonCode Whisper(int session, string message, object arg0)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_whisper(session, string.Format(message, arg0));
        }

        public ReasonCode Whisper(int session, string message, object arg0, object arg1)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_whisper(session, string.Format(message, arg0, arg1));
        }

        public ReasonCode Whisper(int session, string message, object arg0, object arg1, object arg2)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_whisper(session, string.Format(message, arg0, arg1, arg2));
        }

        public ReasonCode Whisper(int session, string message, params object[] args)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_whisper(session, string.Format(message, args));
        }

        public ReasonCode ConsoleMessage(int session)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_console_message(session);
        }

        public ReasonCode BotgramSend()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_botgram_send();
        }
        #endregion

        #region Property methods
        public ReasonCode Query(int xSector, int zSector, int[,] sequence)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_query(xSector, zSector, sequence);
        }

        public ReasonCode Query5x5(int xSector, int zSector, int[,] sequence)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_query_5x5(xSector, zSector, sequence);
        }

        public ReasonCode ObjectQuery()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_object_query();
        }

        public ReasonCode CellNext()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_cell_next();
        }

        public ReasonCode ObjectAdd()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_object_add();
        }

        public ReasonCode ObjectChange()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_object_change();
        }

        public ReasonCode ObjectDelete()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_object_delete();
        }

        public ReasonCode ObjectLoad()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_object_load();
        }

        public ReasonCode DeleteAllObjects()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_delete_all_objects();
        }
        #endregion

        #region Terrain methods
        public ReasonCode TerrainSet(int x, int z, int texture, int[] heights)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_terrain_set(x, z, heights.Length, texture, heights);
        }

        public ReasonCode TerrainQuery(int pageX, int pageZ, long sequence)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_terrain_query(pageX, pageZ, sequence);
        }

        public ReasonCode TerrainNext()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_terrain_next();
        }

        public ReasonCode TerrainDeleteAll()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_terrain_delete_all();
        }

        public ReasonCode TerrainLoadNode()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_terrain_load_node();
        }
        #endregion

        #region Mover methods
        public ReasonCode MoverSetState(int id, int state, int modelNum)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_mover_set_state(id, state, modelNum);
        }

        public ReasonCode MoverSetPosition(int id, int x, int y, int z, int yaw, int pitch, int roll)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_mover_set_position(id, x, y, z, yaw, pitch, roll);
        }

        public ReasonCode MoverRiderAdd(int id, int session, int dist, int angle, int yDelta, int yawDelta, int pitchDelta)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_mover_rider_add(id, session, dist, angle, yDelta, yawDelta, pitchDelta);
        }

        public ReasonCode MoverRiderChange(int id, int session, int dist, int angle, int yDelta, int yawDelta, int pitchDelta)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_mover_rider_change(id, session, dist, angle, yDelta, yawDelta, pitchDelta);
        }

        public ReasonCode MoverRiderDelete(int id, int session)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_mover_rider_delete(id, session);
        }

        public ReasonCode MoverLinks(int id)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_mover_links(id);
        }
        #endregion

        #region HUD methods
        public ReasonCode HudCreate()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_hud_create();
        }

        public ReasonCode HudClick()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_hud_click();
        }

        public ReasonCode HudDestroy(int session, int id)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_hud_destroy(session, id);
        }

        public ReasonCode HudClear(int session)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_hud_clear(session);
        }

        public ReasonCode TrafficCount(out int inTraffic, out int outTraffic)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_traffic_count(out inTraffic, out outTraffic);
        }
        #endregion

        #region CAV manipulation methods
        public ReasonCode CavRequest(int citizen, int session)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_cav_request(citizen, session);
        }

        public ReasonCode CavChange()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_cav_change();
        }

        public ReasonCode CavDelete()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_cav_delete();
        }

        public ReasonCode WorldCavRequest(int citizen, int session)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_world_cav_request(citizen, session);
        }

        public ReasonCode WorldCavChange()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_world_cav_change();
        }

        public ReasonCode WorldCavDelete()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_world_cav_delete();
        }
        #endregion

        #region Universe related methods
        #region Universe management methods
        public ReasonCode UniverseAttributesChange()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_universe_attributes_change();
        }

        public ReasonCode UniverseEjectionAdd()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_universe_ejection_add();
        }

        public ReasonCode UniverseEjectionDelete(int address)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_universe_ejection_delete(address);
        }

        public ReasonCode UniverseEjectionLookup()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_universe_ejection_lookup();
        }

        public ReasonCode UniverseEjectionNext()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_universe_ejection_next();
        }

        public ReasonCode UniverseEjectionPrevious()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_universe_ejection_previous();
        }
        #endregion

        #region Citizen methods
        public ReasonCode CitizenAttributesByName(string name)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_citizen_attributes_by_name(name);
        }

        public ReasonCode CitizenAttributesByNumber(int citizen)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_citizen_attributes_by_number(citizen);
        }

        public ReasonCode CitizenAdd()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_citizen_add();
        }

        public ReasonCode CitizenChange()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_citizen_change();
        }

        public ReasonCode CitizenDelete(int citizen)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_citizen_delete(citizen);
        }

        public ReasonCode CitizenNext()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_citizen_next();
        }

        public ReasonCode CitizenPrevious()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_citizen_previous();
        }
        #endregion

        #region World license methods
        public ReasonCode LicenseAdd()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_license_add();
        }

        public ReasonCode LicenseAttributes(string name)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_license_attributes(name);
        }

        public ReasonCode LicenseChange()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_license_change();
        }

        public ReasonCode LicenseDelete(string name)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_license_delete(name);
        }

        public ReasonCode LicenseNext()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_license_next();
        }

        public ReasonCode LicensePrevious()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_license_previous();
        }
        #endregion
        #endregion

        #region World related methods
        #region World management methods
        public ReasonCode WorldAttributesChange()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_world_attributes_change();
        }

        public ReasonCode WorldEject()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_world_eject();
        }

        public ReasonCode WorldReloadRegistry()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_world_reload_registry();
        }

        public ReasonCode WorldAttributesReset()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_world_attributes_reset();
        }

        public ReasonCode WorldInstanceSet(int citizen, int worldInstance)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_world_instance_set(citizen, worldInstance);
        }

        public ReasonCode WorldInstanceGet(int citizen)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_world_instance_get(citizen);
        }

        public ReasonCode WorldAttributesSend(int session)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_world_attributes_send(session);
        }

        public ReasonCode WorldEjectionAdd()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_world_ejection_add();
        }

        public ReasonCode WorldEjectionDelete()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_world_ejection_delete();
        }

        public ReasonCode WorldEjectionLookup()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_world_ejection_lookup();
        }

        public ReasonCode WorldEjectionNext()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_world_ejection_next();
        }

        public ReasonCode WorldEjectionPrevious()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_world_ejection_previous();
        }

        public ReasonCode WorldAttributeSet(int attribute, string value)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_world_attribute_set(attribute, value);
        }

        public ReasonCode WorldAttributeGet(int attribute, out bool readOnly, string value)
        {
            SetInstance();
            int ro;
            int ret = NativeMethods.aw_world_attribute_get(attribute, out ro, value);
            readOnly = ro != 0;
            return (ReasonCode)ret;
        }
        #endregion

        #region Rights Checking Methods
        public bool CheckRight(int citizen, string rightString)
        {
            SetInstance();
            return NativeMethods.aw_check_right(citizen, rightString);
        }

        public bool CheckRightAll(string rightString)
        {
            SetInstance();
            return NativeMethods.aw_check_right_all(rightString);
        }

        public bool HasWorldRight(int citizen, Attributes right)
        {
            SetInstance();
            return NativeMethods.aw_has_world_right(citizen, right);
        }

        public bool HasWorldRightAll(Attributes right)
        {
            SetInstance();
            return NativeMethods.aw_has_world_right_all(right);
        }
        #endregion
        #endregion

        #region World server management methods
        public ReasonCode ServerWorldAdd()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_server_world_add();
        }

        public ReasonCode ServerWorldDelete(int id)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_server_world_delete(id);
        }

        public ReasonCode ServerWorldChange(int id)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_server_world_change(id);
        }

        public ReasonCode ServerWorldList()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_server_world_list();
        }

        public ReasonCode ServerWorldStart(int id)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_server_world_start(id);
        }

        public ReasonCode ServerWorldStop(int id)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_server_world_stop(id);
        }

        public ReasonCode ServerWorldSet(int id)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_server_world_set(id);
        }

        public ReasonCode ServerWorldInstanceSet(int id)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_server_world_instance_set(id);
        }

        public ReasonCode ServerWorldInstanceAdd(int id, int instanceId)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_server_world_instance_add(id, instanceId);
        }

        public ReasonCode ServerWorldInstanceDelete(int id, int instanceId)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_server_world_instance_delete(id, instanceId);
        }
        #endregion

        #region Laser Beam methods

        public ReasonCode LaserBeam()
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_laser_beam();
        }

        public ReasonCode Listen(ChatChannels channels)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_listen((int) channels);
        }

        public ReasonCode SayChannel(ChatChannels channel, string message)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_say_channel(string.Format(message), (int)channel);
        }

        public ReasonCode SayChannel(ChatChannels channel, string message, object arg0)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_say_channel(string.Format(message, arg0), (int)channel);
        }

        public ReasonCode SayChannel(ChatChannels channel, string message, object arg0, object arg1)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_say_channel(string.Format(message, arg0, arg1), (int)channel);
        }

        public ReasonCode SayChannel(ChatChannels channel, string message, object arg0, object arg1, object arg2)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_say_channel(string.Format(message, arg0, arg1, arg2), (int)channel);
        }

        public ReasonCode SayChannel(ChatChannels channel, string message, params object[] args)
        {
            SetInstance();
            return (ReasonCode)NativeMethods.aw_say_channel(string.Format(message, args), (int)channel);
        }

        public ReasonCode ObjectAddSession(int session)
        {
            SetInstance();
            return (ReasonCode) NativeMethods.aw_object_add_session(session);
        }

        public ReasonCode ObjectDeleteSession(int session)
        {
            SetInstance();
            return (ReasonCode) NativeMethods.aw_object_delete_session(session);
        }

        public ReasonCode ServerWorldGet()
        {
            SetInstance();
            return (ReasonCode) NativeMethods.aw_server_world_get();
        }

        #endregion
    }
}