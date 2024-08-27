/*
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 * Copyright (c) 2017-2019 Swan & The Quaver Team <support@quavergame.com>.
*/

using System;
using System.Collections.Generic;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Interop;
using Quaver.API.Enums;
using YamlDotNet.Serialization;

namespace Quaver.API.Maps.Structures
{
    /// <summary>
    ///     TimingPoints section of the .qua
    /// </summary>
    [Serializable]
    [MoonSharpUserData]
    public class TimingPointInfo : IStartTime
    {
        /// <summary>
        ///     The time in milliseconds for when this timing point begins
        /// </summary>
        public float StartTime
        {
            get;
            [MoonSharpVisible(false)]
            set;
        }

        /// <summary>
        ///     The BPM during this timing point
        /// </summary>
        public float Bpm
        {
            get;
            [MoonSharpVisible(false)]
            set;
        }

        /// <summary>
        ///     The signature during this timing point
        /// </summary>
        public TimeSignature Signature
        {
            get;
            [MoonSharpVisible(false)]
            set;
        }

        /// <summary>
        ///     Whether timing lines during this timing point should be hidden or not
        /// </summary>
        public bool Hidden
        {
            get;
            [MoonSharpVisible(false)]
            set;
        }

        [YamlIgnore]
        public bool IsEditableInLuaScript
        {
            get;
            [MoonSharpVisible(false)]
            set;
        }

        /// <summary>
        ///     The amount of milliseconds per beat this one takes up.
        /// </summary>
        [YamlIgnore]
        public float MillisecondsPerBeat => 60000 / Bpm;

        /// <summary>
        ///     By-value comparer, auto-generated by Rider.
        /// </summary>
        private sealed class ByValueEqualityComparer : IEqualityComparer<TimingPointInfo>
        {
            public bool Equals(TimingPointInfo x, TimingPointInfo y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;

                return x.StartTime.Equals(y.StartTime) && x.Bpm.Equals(y.Bpm) && x.Signature == y.Signature && x.Hidden == y.Hidden;
            }

            public int GetHashCode(TimingPointInfo obj)
            {
                unchecked
                {
                    var hashCode = obj.StartTime.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.Bpm.GetHashCode();
                    hashCode = (hashCode * 397) ^ (int)obj.Signature;
                    hashCode = (hashCode * 397) ^ (obj.Hidden ? 1 : 0);
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<TimingPointInfo> ByValueComparer { get; } = new ByValueEqualityComparer();
    }
}
