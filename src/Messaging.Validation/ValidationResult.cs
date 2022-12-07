using Autabee.Utility.Messaging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Autabee.Utility
{
#if(NET6_0_OR_GREATER)   
    public record ValidationResult
#else
    public class ValidationResult
#endif
    {
        public ValidationResult(bool success = true, string unSuccessfulText = "", params object[] formatObjects)
        {
            this.Success = success;
            FailInfo = new List<Message>();
            if (!string.IsNullOrWhiteSpace(unSuccessfulText))
            {
                FailInfo.Add(new Message(0,unSuccessfulText, formatObjects));
            }
        }
        public ValidationResult(bool success = true, List<Message> failInfo = default)
        {
            this.Success = success;
            this.FailInfo = failInfo ?? new List<Message>();
        }

        public void AddResult(ValidationResult validationResult)
        {
            if (validationResult.Success == false)
            {
                Success = false;
                FailInfo.AddRange(validationResult.FailInfo);
            }
        }
        public void AddResult(bool succes, string failText, params object[] formatObjects)
        {
            Success &= succes;
            if (!string.IsNullOrWhiteSpace(failText))
            {
                FailInfo.Add(new Message(0,failText, formatObjects));
            }
        }
        public override string ToString()
        {
            string failString = FailInfo.Aggregate("", (accumulator, fail) => accumulator += fail.ToString() + Environment.NewLine);
            return failString;
        }

        public List<Message> FailInfo { get; }

        public bool Success { get; private set; }
    }
}