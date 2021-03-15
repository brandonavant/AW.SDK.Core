namespace AW.Core.Sample.Models
{
    /// <summary>
    /// Encapsulates configuration properties deserialized from appsettings.json.
    /// </summary>
    public class AwConfig
    {
        /// <summary>
        /// The citizen number with which <see cref="AW.Instance"/> instances are created are created.
        /// </summary>
        public int CitizenNumber { get; set; }

        /// <summary>
        /// The privilege password associated with the <see cref="CitizenNumber"/>.
        /// </summary>
        public string PrivilegePassword { get; set; }

        /// <summary>
        /// The world to enter.
        /// </summary>
        public string EntryWorld { get; set; }
    }
}
