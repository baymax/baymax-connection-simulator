// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: proto/ValueSettedSubCommand.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from proto/ValueSettedSubCommand.proto</summary>
[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
public static partial class ValueSettedSubCommandReflection {

  #region Descriptor
  /// <summary>File descriptor for proto/ValueSettedSubCommand.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static ValueSettedSubCommandReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "CiFwcm90by9WYWx1ZVNldHRlZFN1YkNvbW1hbmQucHJvdG8ipAEKFVZhbHVl",
          "U2V0dGVkU3ViQ29tbWFuZBIKCgJpZBgBIAEoDRIUCgpvdGhlclZhbHVlGAIg",
          "ASgNSAASFgoMY3VycmVudFZhbHVlGAMgASgNSAASFgoMdm9sdGFnZVZhbHVl",
          "GAQgASgNSAASGgoQdGVtcGVyYXR1cmVWYWx1ZRgFIAEoAkgAEhMKC2RhdGVT",
          "ZWNvbmRzGAYgASgEQggKBnZhbHVlc2IGcHJvdG8z"));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { },
        new pbr::GeneratedCodeInfo(null, new pbr::GeneratedCodeInfo[] {
          new pbr::GeneratedCodeInfo(typeof(global::ValueSettedSubCommand), global::ValueSettedSubCommand.Parser, new[]{ "Id", "OtherValue", "CurrentValue", "VoltageValue", "TemperatureValue", "DateSeconds" }, new[]{ "Values" }, null, null)
        }));
  }
  #endregion

}
#region Messages
[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
public sealed partial class ValueSettedSubCommand : pb::IMessage<ValueSettedSubCommand> {
  private static readonly pb::MessageParser<ValueSettedSubCommand> _parser = new pb::MessageParser<ValueSettedSubCommand>(() => new ValueSettedSubCommand());
  public static pb::MessageParser<ValueSettedSubCommand> Parser { get { return _parser; } }

  public static pbr::MessageDescriptor Descriptor {
    get { return global::ValueSettedSubCommandReflection.Descriptor.MessageTypes[0]; }
  }

  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  public ValueSettedSubCommand() {
    OnConstruction();
  }

  partial void OnConstruction();

  public ValueSettedSubCommand(ValueSettedSubCommand other) : this() {
    id_ = other.id_;
    dateSeconds_ = other.dateSeconds_;
    switch (other.ValuesCase) {
      case ValuesOneofCase.OtherValue:
        OtherValue = other.OtherValue;
        break;
      case ValuesOneofCase.CurrentValue:
        CurrentValue = other.CurrentValue;
        break;
      case ValuesOneofCase.VoltageValue:
        VoltageValue = other.VoltageValue;
        break;
      case ValuesOneofCase.TemperatureValue:
        TemperatureValue = other.TemperatureValue;
        break;
    }

  }

  public ValueSettedSubCommand Clone() {
    return new ValueSettedSubCommand(this);
  }

  /// <summary>Field number for the "id" field.</summary>
  public const int IdFieldNumber = 1;
  private uint id_;
  public uint Id {
    get { return id_; }
    set {
      id_ = value;
    }
  }

  /// <summary>Field number for the "otherValue" field.</summary>
  public const int OtherValueFieldNumber = 2;
  public uint OtherValue {
    get { return valuesCase_ == ValuesOneofCase.OtherValue ? (uint) values_ : 0; }
    set {
      values_ = value;
      valuesCase_ = ValuesOneofCase.OtherValue;
    }
  }

  /// <summary>Field number for the "currentValue" field.</summary>
  public const int CurrentValueFieldNumber = 3;
  public uint CurrentValue {
    get { return valuesCase_ == ValuesOneofCase.CurrentValue ? (uint) values_ : 0; }
    set {
      values_ = value;
      valuesCase_ = ValuesOneofCase.CurrentValue;
    }
  }

  /// <summary>Field number for the "voltageValue" field.</summary>
  public const int VoltageValueFieldNumber = 4;
  public uint VoltageValue {
    get { return valuesCase_ == ValuesOneofCase.VoltageValue ? (uint) values_ : 0; }
    set {
      values_ = value;
      valuesCase_ = ValuesOneofCase.VoltageValue;
    }
  }

  /// <summary>Field number for the "temperatureValue" field.</summary>
  public const int TemperatureValueFieldNumber = 5;
  public float TemperatureValue {
    get { return valuesCase_ == ValuesOneofCase.TemperatureValue ? (float) values_ : 0F; }
    set {
      values_ = value;
      valuesCase_ = ValuesOneofCase.TemperatureValue;
    }
  }

  /// <summary>Field number for the "dateSeconds" field.</summary>
  public const int DateSecondsFieldNumber = 6;
  private ulong dateSeconds_;
  public ulong DateSeconds {
    get { return dateSeconds_; }
    set {
      dateSeconds_ = value;
    }
  }

  private object values_;
  /// <summary>Enum of possible cases for the "values" oneof.</summary>
  public enum ValuesOneofCase {
    None = 0,
    OtherValue = 2,
    CurrentValue = 3,
    VoltageValue = 4,
    TemperatureValue = 5,
  }
  private ValuesOneofCase valuesCase_ = ValuesOneofCase.None;
  public ValuesOneofCase ValuesCase {
    get { return valuesCase_; }
  }

  public void ClearValues() {
    valuesCase_ = ValuesOneofCase.None;
    values_ = null;
  }

  public override bool Equals(object other) {
    return Equals(other as ValueSettedSubCommand);
  }

  public bool Equals(ValueSettedSubCommand other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Id != other.Id) return false;
    if (OtherValue != other.OtherValue) return false;
    if (CurrentValue != other.CurrentValue) return false;
    if (VoltageValue != other.VoltageValue) return false;
    if (TemperatureValue != other.TemperatureValue) return false;
    if (DateSeconds != other.DateSeconds) return false;
    if (ValuesCase != other.ValuesCase) return false;
    return true;
  }

  public override int GetHashCode() {
    int hash = 1;
    if (Id != 0) hash ^= Id.GetHashCode();
    if (valuesCase_ == ValuesOneofCase.OtherValue) hash ^= OtherValue.GetHashCode();
    if (valuesCase_ == ValuesOneofCase.CurrentValue) hash ^= CurrentValue.GetHashCode();
    if (valuesCase_ == ValuesOneofCase.VoltageValue) hash ^= VoltageValue.GetHashCode();
    if (valuesCase_ == ValuesOneofCase.TemperatureValue) hash ^= TemperatureValue.GetHashCode();
    if (DateSeconds != 0UL) hash ^= DateSeconds.GetHashCode();
    hash ^= (int) valuesCase_;
    return hash;
  }

  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  public void WriteTo(pb::CodedOutputStream output) {
    if (Id != 0) {
      output.WriteRawTag(8);
      output.WriteUInt32(Id);
    }
    if (valuesCase_ == ValuesOneofCase.OtherValue) {
      output.WriteRawTag(16);
      output.WriteUInt32(OtherValue);
    }
    if (valuesCase_ == ValuesOneofCase.CurrentValue) {
      output.WriteRawTag(24);
      output.WriteUInt32(CurrentValue);
    }
    if (valuesCase_ == ValuesOneofCase.VoltageValue) {
      output.WriteRawTag(32);
      output.WriteUInt32(VoltageValue);
    }
    if (valuesCase_ == ValuesOneofCase.TemperatureValue) {
      output.WriteRawTag(45);
      output.WriteFloat(TemperatureValue);
    }
    if (DateSeconds != 0UL) {
      output.WriteRawTag(48);
      output.WriteUInt64(DateSeconds);
    }
  }

  public int CalculateSize() {
    int size = 0;
    if (Id != 0) {
      size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Id);
    }
    if (valuesCase_ == ValuesOneofCase.OtherValue) {
      size += 1 + pb::CodedOutputStream.ComputeUInt32Size(OtherValue);
    }
    if (valuesCase_ == ValuesOneofCase.CurrentValue) {
      size += 1 + pb::CodedOutputStream.ComputeUInt32Size(CurrentValue);
    }
    if (valuesCase_ == ValuesOneofCase.VoltageValue) {
      size += 1 + pb::CodedOutputStream.ComputeUInt32Size(VoltageValue);
    }
    if (valuesCase_ == ValuesOneofCase.TemperatureValue) {
      size += 1 + 4;
    }
    if (DateSeconds != 0UL) {
      size += 1 + pb::CodedOutputStream.ComputeUInt64Size(DateSeconds);
    }
    return size;
  }

  public void MergeFrom(ValueSettedSubCommand other) {
    if (other == null) {
      return;
    }
    if (other.Id != 0) {
      Id = other.Id;
    }
    if (other.DateSeconds != 0UL) {
      DateSeconds = other.DateSeconds;
    }
    switch (other.ValuesCase) {
      case ValuesOneofCase.OtherValue:
        OtherValue = other.OtherValue;
        break;
      case ValuesOneofCase.CurrentValue:
        CurrentValue = other.CurrentValue;
        break;
      case ValuesOneofCase.VoltageValue:
        VoltageValue = other.VoltageValue;
        break;
      case ValuesOneofCase.TemperatureValue:
        TemperatureValue = other.TemperatureValue;
        break;
    }

  }

  public void MergeFrom(pb::CodedInputStream input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          input.SkipLastField();
          break;
        case 8: {
          Id = input.ReadUInt32();
          break;
        }
        case 16: {
          OtherValue = input.ReadUInt32();
          break;
        }
        case 24: {
          CurrentValue = input.ReadUInt32();
          break;
        }
        case 32: {
          VoltageValue = input.ReadUInt32();
          break;
        }
        case 45: {
          TemperatureValue = input.ReadFloat();
          break;
        }
        case 48: {
          DateSeconds = input.ReadUInt64();
          break;
        }
      }
    }
  }

}

#endregion


#endregion Designer generated code
