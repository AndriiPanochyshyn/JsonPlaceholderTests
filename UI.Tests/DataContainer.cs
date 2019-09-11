using System.Collections.Generic;

namespace Tests
{
    internal class DataContainer
    {
        private readonly Dictionary<string, int> _userIds = new Dictionary<string, int>();

        public void AddUserId(string userIdKey, int userIdValue) => _userIds.Add(userIdKey, userIdValue);
        public int GetUserId(string key) => _userIds[key];

        private readonly Dictionary<string, int> _albumIds = new Dictionary<string, int>();

        public void AddAlbumId(string albumIdKey, int albumIdValue) => _albumIds.Add(albumIdKey, albumIdValue);
        public int GetAlbumId(string key) => _albumIds[key];
    }
}
