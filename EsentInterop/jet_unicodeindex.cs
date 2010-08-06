﻿//-----------------------------------------------------------------------
// <copyright file="jet_unicodeindex.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.Isam.Esent.Interop
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The native version of the JET_UNICODEINDEX structure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.NamingRules",
        "SA1307:AccessibleFieldsMustBeginWithUpperCaseLetter",
        Justification = "This should match the unmanaged API, which isn't capitalized.")]
    internal struct NATIVE_UNICODEINDEX
    {
        /// <summary>
        /// The LCID to be used when normalizing unicode data.
        /// </summary>
        public uint lcid;

        /// <summary>
        /// The flags for LCMapString.
        /// </summary>
        public uint dwMapFlags;
    }

    /// <summary>
    /// Customizes how Unicode data gets normalized when an index is created over a Unicode column.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.NamingRules",
        "SA1300:ElementMustBeginWithUpperCaseLetter",
        Justification = "This should match the unmanaged API, which isn't capitalized.")]
    [Serializable]
    public class JET_UNICODEINDEX : IEquatable<JET_UNICODEINDEX>
    {
        /// <summary>
        /// The LCID to be used when normalizing unicode data.
        /// </summary>
        private int localeId;

        /// <summary>
        /// Sets the flags to be used with LCMapString when normalizing unicode data.
        /// </summary>
        private uint mapStringFlags;

        /// <summary>
        /// Gets or sets the LCID to be used when normalizing unicode data.
        /// </summary>
        public int lcid
        {
            [DebuggerStepThrough]
            get { return this.localeId; }
            set { this.localeId = value; }
        }

        /// <summary>
        /// Gets or sets the flags to be used with LCMapString when normalizing unicode data.
        /// </summary>
        [CLSCompliant(false)]
        public uint dwMapFlags
        {
            [DebuggerStepThrough]
            get { return this.mapStringFlags; }
            set { this.mapStringFlags = value; }
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal
        /// to another instance.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>True if the two instances are equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return this.Equals((JET_UNICODEINDEX)obj);
        }

        /// <summary>
        /// Generate a string representation of the instance.
        /// </summary>
        /// <returns>The structure as a string.</returns>
        public override string ToString()
        {
            return String.Format(
                CultureInfo.InvariantCulture,
                "JET_UNICODEINDEX({0}:0x{1:X})",
                this.localeId,
                this.mapStringFlags);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>The hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return (this.localeId * 31) ^ unchecked((int)this.mapStringFlags);
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal
        /// to another instance.
        /// </summary>
        /// <param name="other">An instance to compare with this instance.</param>
        /// <returns>True if the two instances are equal.</returns>
        public bool Equals(JET_UNICODEINDEX other)
        {
            if (null == other)
            {
                return false;
            }

            return this.localeId == other.localeId && this.mapStringFlags == other.mapStringFlags;
        }

        /// <summary>
        /// Gets the native version of this object.
        /// </summary>
        /// <returns>The native version of this object.</returns>
        internal NATIVE_UNICODEINDEX GetNativeUnicodeIndex()
        {
            var native = new NATIVE_UNICODEINDEX
            {
                lcid = (uint) this.lcid,
                dwMapFlags = (uint) this.dwMapFlags,
            };
            return native;
        }        
    }
}
