using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qazbot.UserSystem;

namespace Qazbot.PointSystem
{
    class PointManager
    {

        public List<User> onlineUsers { get; set; }
        public int pointsPerMinute { get; set; } = 1;
        public int chatMultiplierMinutes { get; set; } = 10;
        public int chatMultiplier { get; set; } = 2;

        /// <summary>
        /// Adds a raw number of points
        /// No multipliers are applied
        /// </summary>
        /// <param name="points"></param>
        public void AddPoints(int points) {
            for (int i = 0; i < onlineUsers.Count; i++) {
                onlineUsers[i].points += points;
            }
        }

        public void AddPoints(string username, int points) {
            
        }

        /// <summary>
        /// Adds points based on watch time and last time chatting
        /// </summary>
        public void AddWeightedPoints() {
            for (int i = 0; i < onlineUsers.Count; i++) {
                User user = onlineUsers[i];
                double watchTimeMultiplier = Math.Log10(user.totalWatchTime + 10);
                double currentTime = (DateTime.Now - new DateTime(1, 1, 1, 1, 1, 1)).TotalSeconds;
                int chatMultiplier = (currentTime - user.lastMessageTime) < chatMultiplierMinutes * 60 ? this.chatMultiplier : 1;

                double addedPoints = pointsPerMinute * watchTimeMultiplier * chatMultiplier;
                user.points += addedPoints;
            }
        }

    }
}
