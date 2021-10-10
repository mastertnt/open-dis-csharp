// Copyright (c) 1995-2009 held by the author(s).  All rights reserved.
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions
// are met:
// * Redistributions of source code must retain the above copyright
//    notice, this list of conditions and the following disclaimer.
// * Redistributions in binary form must reproduce the above copyright
//   notice, this list of conditions and the following disclaimer
//   in the documentation and/or other materials provided with the
//   distribution.
// * Neither the names of the Naval Postgraduate School (NPS)
//   Modeling Virtual Environments and Simulation (MOVES) Institute
//   (http://www.nps.edu and http://www.MovesInstitute.org)
//   nor the names of its contributors may be used to endorse or
//   promote products derived from this software without specific
//   prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// AS IS AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
// COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
// LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
// POSSIBILITY OF SUCH DAMAGE.
//
// Copyright (c) 2008, MOVES Institute, Naval Postgraduate School. All 
// rights reserved. This work is licensed under the BSD open source license,
// available at https://www.movesinstitute.org/licenses/bsd.html
//
// Author: DMcG
// Modified for use with C#:
//  - Peter Smith (Naval Air Warfare Center - Training Systems Division)
//  - Zvonko Bostjancic (Blubit d.o.o. - zvonko.bostjancic@blubit.si)

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml.Serialization;
using DISnet.DataStreamUtilities;

namespace DISnet
{
    /// <summary>
    /// For each type or location of Storage Fuel, this record shall specify the type, location, fuel measure- ment units, reload quantity and maximum quantity for storage fuel either for the whole entity or a specific storage fuel location (tank). Section 6.2.84.
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class StorageFuelReload
    {
        /// <summary>
        ///  the standard quantity of this fuel type normally loaded at this station/launcher if a station/launcher is specified. If the Station/Launcher field is set to zero, then this is the total quantity of this fuel type that would be present in a standard reload of all appli- cable stations/launchers associated with this entity.
        /// </summary>
        private uint _standardQuantity;

        /// <summary>
        /// the maximum quantity of this fuel type that this sta- tion/launcher is capable of holding when a station/launcher is specified. This would be the value used when a maximum reload was desired to be set for this station/launcher. If the Station/launcher field is set to zero, then this is the maximum quantity of this fuel type that would be present on this entity at all stations/launchers that can accept this fuel type.
        /// </summary>
        private uint _maximumQuantity;

        /// <summary>
        /// the seconds normally required to reload the standard quantity of this fuel type at this specific station/launcher. When the Station/Launcher field is set to zero, this shall be the time it takes to perform a standard quantity reload of this fuel type at all applicable stations/launchers for this entity.
        /// </summary>
        private byte _standardQuantityReloadTime;

        /// <summary>
        /// the seconds normally required to reload the maximum possible quantity of this fuel type at this station/launcher. When the Station/Launcher field is set to zero, this shall be the time it takes to perform a maximum quantity load/reload of this fuel type at all applicable stations/launchers for this entity.
        /// </summary>
        private byte _maximumQuantityReloadTime;

        /// <summary>
        /// the fuel measurement units. Enumeration
        /// </summary>
        private byte _fuelMeasurementUnits;

        /// <summary>
        /// Fuel type. Enumeration
        /// </summary>
        private byte _fuelType;

        /// <summary>
        /// Location of fuel as related to entity. See section 14 of EBV document
        /// </summary>
        private byte _fuelLocation;

        /// <summary>
        /// padding
        /// </summary>
        private byte _padding;

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageFuelReload"/> class.
        /// </summary>
        public StorageFuelReload()
        {
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(StorageFuelReload left, StorageFuelReload right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(StorageFuelReload left, StorageFuelReload right)
        {
            if (object.ReferenceEquals(left, right))
            {
                return true;
            }

            if (((object)left == null) || ((object)right == null))
            {
                return false;
            }

            return left.Equals(right);
        }

        public virtual int GetMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize += 4;  // this._standardQuantity
            marshalSize += 4;  // this._maximumQuantity
            marshalSize += 1;  // this._standardQuantityReloadTime
            marshalSize += 1;  // this._maximumQuantityReloadTime
            marshalSize += 1;  // this._fuelMeasurementUnits
            marshalSize += 1;  // this._fuelType
            marshalSize += 1;  // this._fuelLocation
            marshalSize += 1;  // this._padding
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the  the standard quantity of this fuel type normally loaded at this station/launcher if a station/launcher is specified. If the Station/Launcher field is set to zero, then this is the total quantity of this fuel type that would be present in a standard reload of all appli- cable stations/launchers associated with this entity.
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "standardQuantity")]
        public uint StandardQuantity
        {
            get
            {
                return this._standardQuantity;
            }

            set
            {
                this._standardQuantity = value;
            }
        }

        /// <summary>
        /// Gets or sets the the maximum quantity of this fuel type that this sta- tion/launcher is capable of holding when a station/launcher is specified. This would be the value used when a maximum reload was desired to be set for this station/launcher. If the Station/launcher field is set to zero, then this is the maximum quantity of this fuel type that would be present on this entity at all stations/launchers that can accept this fuel type.
        /// </summary>
        [XmlElement(Type = typeof(uint), ElementName = "maximumQuantity")]
        public uint MaximumQuantity
        {
            get
            {
                return this._maximumQuantity;
            }

            set
            {
                this._maximumQuantity = value;
            }
        }

        /// <summary>
        /// Gets or sets the the seconds normally required to reload the standard quantity of this fuel type at this specific station/launcher. When the Station/Launcher field is set to zero, this shall be the time it takes to perform a standard quantity reload of this fuel type at all applicable stations/launchers for this entity.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "standardQuantityReloadTime")]
        public byte StandardQuantityReloadTime
        {
            get
            {
                return this._standardQuantityReloadTime;
            }

            set
            {
                this._standardQuantityReloadTime = value;
            }
        }

        /// <summary>
        /// Gets or sets the the seconds normally required to reload the maximum possible quantity of this fuel type at this station/launcher. When the Station/Launcher field is set to zero, this shall be the time it takes to perform a maximum quantity load/reload of this fuel type at all applicable stations/launchers for this entity.
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "maximumQuantityReloadTime")]
        public byte MaximumQuantityReloadTime
        {
            get
            {
                return this._maximumQuantityReloadTime;
            }

            set
            {
                this._maximumQuantityReloadTime = value;
            }
        }

        /// <summary>
        /// Gets or sets the the fuel measurement units. Enumeration
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "fuelMeasurementUnits")]
        public byte FuelMeasurementUnits
        {
            get
            {
                return this._fuelMeasurementUnits;
            }

            set
            {
                this._fuelMeasurementUnits = value;
            }
        }

        /// <summary>
        /// Gets or sets the Fuel type. Enumeration
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "fuelType")]
        public byte FuelType
        {
            get
            {
                return this._fuelType;
            }

            set
            {
                this._fuelType = value;
            }
        }

        /// <summary>
        /// Gets or sets the Location of fuel as related to entity. See section 14 of EBV document
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "fuelLocation")]
        public byte FuelLocation
        {
            get
            {
                return this._fuelLocation;
            }

            set
            {
                this._fuelLocation = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "padding")]
        public byte Padding
        {
            get
            {
                return this._padding;
            }

            set
            {
                this._padding = value;
            }
        }

        /// <summary>
        /// Occurs when exception when processing PDU is caught.
        /// </summary>
        public event Action<Exception> Exception;

        /// <summary>
        /// Called when exception occurs (raises the <see cref="Exception"/> event).
        /// </summary>
        /// <param name="e">The exception.</param>
        protected void OnException(Exception e)
        {
            if (this.Exception != null)
            {
                this.Exception(e);
            }
        }

        /// <summary>
        /// Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        /// </summary>
        /// <param name="dos">The DataOutputStream instance to which the PDU is marshaled.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Marshal(DataOutputStream dos)
        {
            if (dos != null)
            {
                try
                {
                    dos.WriteUnsignedInt((uint)this._standardQuantity);
                    dos.WriteUnsignedInt((uint)this._maximumQuantity);
                    dos.WriteUnsignedByte((byte)this._standardQuantityReloadTime);
                    dos.WriteUnsignedByte((byte)this._maximumQuantityReloadTime);
                    dos.WriteUnsignedByte((byte)this._fuelMeasurementUnits);
                    dos.WriteUnsignedByte((byte)this._fuelType);
                    dos.WriteUnsignedByte((byte)this._fuelLocation);
                    dos.WriteUnsignedByte((byte)this._padding);
                }
                catch (Exception e)
                {
#if DEBUG
                    Trace.WriteLine(e);
                    Trace.Flush();
#endif
                    this.OnException(e);
                }
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Unmarshal(DataInputStream dis)
        {
            if (dis != null)
            {
                try
                {
                    this._standardQuantity = dis.ReadUnsignedInt();
                    this._maximumQuantity = dis.ReadUnsignedInt();
                    this._standardQuantityReloadTime = dis.ReadUnsignedByte();
                    this._maximumQuantityReloadTime = dis.ReadUnsignedByte();
                    this._fuelMeasurementUnits = dis.ReadUnsignedByte();
                    this._fuelType = dis.ReadUnsignedByte();
                    this._fuelLocation = dis.ReadUnsignedByte();
                    this._padding = dis.ReadUnsignedByte();
                }
                catch (Exception e)
                {
#if DEBUG
                    Trace.WriteLine(e);
                    Trace.Flush();
#endif
                    this.OnException(e);
                }
            }
        }

        /// <summary>
        /// This allows for a quick display of PDU data.  The current format is unacceptable and only used for debugging.
        /// This will be modified in the future to provide a better display.  Usage: 
        /// pdu.GetType().InvokeMember("Reflection", System.Reflection.BindingFlags.InvokeMethod, null, pdu, new object[] { sb });
        /// where pdu is an object representing a single pdu and sb is a StringBuilder.
        /// Note: The supplied Utilities folder contains a method called 'DecodePDU' in the PDUProcessor Class that provides this functionality
        /// </summary>
        /// <param name="sb">The StringBuilder instance to which the PDU is written to.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<StorageFuelReload>");
            try
            {
                sb.AppendLine("<standardQuantity type=\"uint\">" + this._standardQuantity.ToString(CultureInfo.InvariantCulture) + "</standardQuantity>");
                sb.AppendLine("<maximumQuantity type=\"uint\">" + this._maximumQuantity.ToString(CultureInfo.InvariantCulture) + "</maximumQuantity>");
                sb.AppendLine("<standardQuantityReloadTime type=\"byte\">" + this._standardQuantityReloadTime.ToString(CultureInfo.InvariantCulture) + "</standardQuantityReloadTime>");
                sb.AppendLine("<maximumQuantityReloadTime type=\"byte\">" + this._maximumQuantityReloadTime.ToString(CultureInfo.InvariantCulture) + "</maximumQuantityReloadTime>");
                sb.AppendLine("<fuelMeasurementUnits type=\"byte\">" + this._fuelMeasurementUnits.ToString(CultureInfo.InvariantCulture) + "</fuelMeasurementUnits>");
                sb.AppendLine("<fuelType type=\"byte\">" + this._fuelType.ToString(CultureInfo.InvariantCulture) + "</fuelType>");
                sb.AppendLine("<fuelLocation type=\"byte\">" + this._fuelLocation.ToString(CultureInfo.InvariantCulture) + "</fuelLocation>");
                sb.AppendLine("<padding type=\"byte\">" + this._padding.ToString(CultureInfo.InvariantCulture) + "</padding>");
                sb.AppendLine("</StorageFuelReload>");
            }
            catch (Exception e)
            {
#if DEBUG
                    Trace.WriteLine(e);
                    Trace.Flush();
#endif
                    this.OnException(e);
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return this == obj as StorageFuelReload;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(StorageFuelReload obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._standardQuantity != obj._standardQuantity)
            {
                ivarsEqual = false;
            }

            if (this._maximumQuantity != obj._maximumQuantity)
            {
                ivarsEqual = false;
            }

            if (this._standardQuantityReloadTime != obj._standardQuantityReloadTime)
            {
                ivarsEqual = false;
            }

            if (this._maximumQuantityReloadTime != obj._maximumQuantityReloadTime)
            {
                ivarsEqual = false;
            }

            if (this._fuelMeasurementUnits != obj._fuelMeasurementUnits)
            {
                ivarsEqual = false;
            }

            if (this._fuelType != obj._fuelType)
            {
                ivarsEqual = false;
            }

            if (this._fuelLocation != obj._fuelLocation)
            {
                ivarsEqual = false;
            }

            if (this._padding != obj._padding)
            {
                ivarsEqual = false;
            }

            return ivarsEqual;
        }

        /// <summary>
        /// HashCode Helper
        /// </summary>
        /// <param name="hash">The hash value.</param>
        /// <returns>The new hash value.</returns>
        private static int GenerateHash(int hash)
        {
            hash = hash << (5 + hash);
            return hash;
        }

        /// <summary>
        /// Gets the hash code.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            int result = 0;

            result = GenerateHash(result) ^ this._standardQuantity.GetHashCode();
            result = GenerateHash(result) ^ this._maximumQuantity.GetHashCode();
            result = GenerateHash(result) ^ this._standardQuantityReloadTime.GetHashCode();
            result = GenerateHash(result) ^ this._maximumQuantityReloadTime.GetHashCode();
            result = GenerateHash(result) ^ this._fuelMeasurementUnits.GetHashCode();
            result = GenerateHash(result) ^ this._fuelType.GetHashCode();
            result = GenerateHash(result) ^ this._fuelLocation.GetHashCode();
            result = GenerateHash(result) ^ this._padding.GetHashCode();

            return result;
        }
    }
}
