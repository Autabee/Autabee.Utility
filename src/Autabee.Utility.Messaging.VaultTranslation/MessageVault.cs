using Autabee.Utility.Messaging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Security;
using System.Runtime.CompilerServices;

namespace Autabee.Utility.TranslationVault
{

    public static class TranslationVault
    {
        static readonly Dictionary<string, string> translations = new Dictionary<string, string>();
        static readonly Dictionary<string, string> backTranslations = new Dictionary<string, string>();

        public static CultureInfo ActiveTranslation { get; } = CultureInfo.CurrentUICulture;
        /// <summary>
        /// Register a message text/string
        /// </summary>
        /// <param name="messageText">the text that is being added</param>
        public static void AddTranslation(string messageText, string translation)
        {
            translations.Add(messageText, translation);
            backTranslations.Add(translation, messageText);
        }

        public static string GetTranslation(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));
            if (translations.TryGetValue(message, out var translation))
            {
                return translation;
            }
            return message;
        }
    }

}
