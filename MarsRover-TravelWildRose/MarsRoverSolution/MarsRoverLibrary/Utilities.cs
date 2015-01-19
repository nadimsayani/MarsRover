using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MarsRover.Library
{
    static class Utils
    {
        public class StringValueAttribute : Attribute
        {

            #region Properties

            public string StringValue { get; protected set; }

            #endregion

            #region Constructor

            public StringValueAttribute(string value)
            {
                this.StringValue = value;
            }

            #endregion

        }

        /// <summary>
        /// utilities to convert enumeration to string value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetStringValue(this Enum value)
        {
            Type type = value.GetType();

            FieldInfo fieldInfo = type.GetField(value.ToString());

            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }
    }
}
