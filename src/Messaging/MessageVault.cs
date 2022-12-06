using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Security;
using System.Runtime.CompilerServices;

namespace Autabee.Utility.Messaging
{

    public static class MessageVault
    {
        private static Dictionary<int, Dictionary<CultureInfo, string>> vault = new Dictionary<int, Dictionary<CultureInfo, string>>();

        /// <summary>
        /// Register a message text/string
        /// </summary>
        /// <param name="messageText">the text that is being added</param>
        /// <param name="culture">default=CultureInfo.InvariantCulture</param>
        public static void AddMessage(string messageText, CultureInfo culture = null)
        {
            culture = culture ?? CultureInfo.InvariantCulture;
            vault.Add(messageText.GetHashCode(), new Dictionary<CultureInfo, string>() { { culture, messageText } });
        }

        public static string GetTranslatedMessage(string message, CultureInfo culture)
        {
            if (culture == null) throw new ArgumentNullException(nameof(culture));
            if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));
            return GetMessage(message.GetHashCode(), culture );
        }

        /// <summary>
        /// Get a message string from the Vault
        /// </summary>
        /// <param name="messageCode">hash code of the message text</param>
        /// <param name="culture">translated text</param>
        /// <returns>actual messages that is send as hash code</returns>
        public static string GetMessage(int messageCode, CultureInfo culture =null)
        {
            if (vault.TryGetValue(messageCode, out var value))
            {
                if (culture  != null && value.TryGetValue(culture , out string message)) return message;
                else if (value.TryGetValue(CultureInfo.InvariantCulture, out message)) return message;
                else return string.Empty;
            }
            return string.Empty;
        }
    }

}
