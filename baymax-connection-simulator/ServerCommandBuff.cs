// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: proto/ServerCommandBuff.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from proto/ServerCommandBuff.proto</summary>
[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
public static partial class ServerCommandBuffReflection {

  #region Descriptor
  /// <summary>File descriptor for proto/ServerCommandBuff.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static ServerCommandBuffReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "Ch1wcm90by9TZXJ2ZXJDb21tYW5kQnVmZi5wcm90bxoecHJvdG8vU2V0VmFs",
          "dWVTdWJDb21tYW5kLnByb3RvGiFwcm90by9WYWx1ZVNldHRlZFN1YkNvbW1h",
          "bmQucHJvdG8aIXByb3RvL0dldFJlc291cmNlU3ViQ29tbWFuZC5wcm90byLG",
          "AQoRU2VydmVyQ29tbWFuZEJ1ZmYSMQoSc2V0VmFsdWVTdWJDb21tYW5kGAEg",
          "ASgLMhMuU2V0VmFsdWVTdWJDb21tYW5kSAASNwoVdmFsdWVTZXR0ZWRTdWJD",
          "b21tYW5kGAIgASgLMhYuVmFsdWVTZXR0ZWRTdWJDb21tYW5kSAASNwoVZ2V0",
          "UkVzb3VyY2VTdWJDb21tYW5kGAMgASgLMhYuR2V0UmVzb3VyY2VTdWJDb21t",
          "YW5kSABCDAoKc3ViQ29tbWFuZGIGcHJvdG8z"));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { global::SetValueSubCommandReflection.Descriptor, global::ValueSettedSubCommandReflection.Descriptor, global::GetResourceSubCommandReflection.Descriptor, },
        new pbr::GeneratedCodeInfo(null, new pbr::GeneratedCodeInfo[] {
          new pbr::GeneratedCodeInfo(typeof(global::ServerCommandBuff), global::ServerCommandBuff.Parser, new[]{ "SetValueSubCommand", "ValueSettedSubCommand", "GetREsourceSubCommand" }, new[]{ "SubCommand" }, null, null)
        }));
  }
  #endregion

}
#region Messages
[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
public sealed partial class ServerCommandBuff : pb::IMessage<ServerCommandBuff> {
  private static readonly pb::MessageParser<ServerCommandBuff> _parser = new pb::MessageParser<ServerCommandBuff>(() => new ServerCommandBuff());
  public static pb::MessageParser<ServerCommandBuff> Parser { get { return _parser; } }

  public static pbr::MessageDescriptor Descriptor {
    get { return global::ServerCommandBuffReflection.Descriptor.MessageTypes[0]; }
  }

  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  public ServerCommandBuff() {
    OnConstruction();
  }

  partial void OnConstruction();

  public ServerCommandBuff(ServerCommandBuff other) : this() {
    switch (other.SubCommandCase) {
      case SubCommandOneofCase.SetValueSubCommand:
        SetValueSubCommand = other.SetValueSubCommand.Clone();
        break;
      case SubCommandOneofCase.ValueSettedSubCommand:
        ValueSettedSubCommand = other.ValueSettedSubCommand.Clone();
        break;
      case SubCommandOneofCase.GetREsourceSubCommand:
        GetREsourceSubCommand = other.GetREsourceSubCommand.Clone();
        break;
    }

  }

  public ServerCommandBuff Clone() {
    return new ServerCommandBuff(this);
  }

  /// <summary>Field number for the "setValueSubCommand" field.</summary>
  public const int SetValueSubCommandFieldNumber = 1;
  public global::SetValueSubCommand SetValueSubCommand {
    get { return subCommandCase_ == SubCommandOneofCase.SetValueSubCommand ? (global::SetValueSubCommand) subCommand_ : null; }
    set {
      subCommand_ = value;
      subCommandCase_ = value == null ? SubCommandOneofCase.None : SubCommandOneofCase.SetValueSubCommand;
    }
  }

  /// <summary>Field number for the "valueSettedSubCommand" field.</summary>
  public const int ValueSettedSubCommandFieldNumber = 2;
  public global::ValueSettedSubCommand ValueSettedSubCommand {
    get { return subCommandCase_ == SubCommandOneofCase.ValueSettedSubCommand ? (global::ValueSettedSubCommand) subCommand_ : null; }
    set {
      subCommand_ = value;
      subCommandCase_ = value == null ? SubCommandOneofCase.None : SubCommandOneofCase.ValueSettedSubCommand;
    }
  }

  /// <summary>Field number for the "getREsourceSubCommand" field.</summary>
  public const int GetREsourceSubCommandFieldNumber = 3;
  public global::GetResourceSubCommand GetREsourceSubCommand {
    get { return subCommandCase_ == SubCommandOneofCase.GetREsourceSubCommand ? (global::GetResourceSubCommand) subCommand_ : null; }
    set {
      subCommand_ = value;
      subCommandCase_ = value == null ? SubCommandOneofCase.None : SubCommandOneofCase.GetREsourceSubCommand;
    }
  }

  private object subCommand_;
  /// <summary>Enum of possible cases for the "subCommand" oneof.</summary>
  public enum SubCommandOneofCase {
    None = 0,
    SetValueSubCommand = 1,
    ValueSettedSubCommand = 2,
    GetREsourceSubCommand = 3,
  }
  private SubCommandOneofCase subCommandCase_ = SubCommandOneofCase.None;
  public SubCommandOneofCase SubCommandCase {
    get { return subCommandCase_; }
  }

  public void ClearSubCommand() {
    subCommandCase_ = SubCommandOneofCase.None;
    subCommand_ = null;
  }

  public override bool Equals(object other) {
    return Equals(other as ServerCommandBuff);
  }

  public bool Equals(ServerCommandBuff other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (!object.Equals(SetValueSubCommand, other.SetValueSubCommand)) return false;
    if (!object.Equals(ValueSettedSubCommand, other.ValueSettedSubCommand)) return false;
    if (!object.Equals(GetREsourceSubCommand, other.GetREsourceSubCommand)) return false;
    if (SubCommandCase != other.SubCommandCase) return false;
    return true;
  }

  public override int GetHashCode() {
    int hash = 1;
    if (subCommandCase_ == SubCommandOneofCase.SetValueSubCommand) hash ^= SetValueSubCommand.GetHashCode();
    if (subCommandCase_ == SubCommandOneofCase.ValueSettedSubCommand) hash ^= ValueSettedSubCommand.GetHashCode();
    if (subCommandCase_ == SubCommandOneofCase.GetREsourceSubCommand) hash ^= GetREsourceSubCommand.GetHashCode();
    hash ^= (int) subCommandCase_;
    return hash;
  }

  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  public void WriteTo(pb::CodedOutputStream output) {
    if (subCommandCase_ == SubCommandOneofCase.SetValueSubCommand) {
      output.WriteRawTag(10);
      output.WriteMessage(SetValueSubCommand);
    }
    if (subCommandCase_ == SubCommandOneofCase.ValueSettedSubCommand) {
      output.WriteRawTag(18);
      output.WriteMessage(ValueSettedSubCommand);
    }
    if (subCommandCase_ == SubCommandOneofCase.GetREsourceSubCommand) {
      output.WriteRawTag(26);
      output.WriteMessage(GetREsourceSubCommand);
    }
  }

  public int CalculateSize() {
    int size = 0;
    if (subCommandCase_ == SubCommandOneofCase.SetValueSubCommand) {
      size += 1 + pb::CodedOutputStream.ComputeMessageSize(SetValueSubCommand);
    }
    if (subCommandCase_ == SubCommandOneofCase.ValueSettedSubCommand) {
      size += 1 + pb::CodedOutputStream.ComputeMessageSize(ValueSettedSubCommand);
    }
    if (subCommandCase_ == SubCommandOneofCase.GetREsourceSubCommand) {
      size += 1 + pb::CodedOutputStream.ComputeMessageSize(GetREsourceSubCommand);
    }
    return size;
  }

  public void MergeFrom(ServerCommandBuff other) {
    if (other == null) {
      return;
    }
    switch (other.SubCommandCase) {
      case SubCommandOneofCase.SetValueSubCommand:
        SetValueSubCommand = other.SetValueSubCommand;
        break;
      case SubCommandOneofCase.ValueSettedSubCommand:
        ValueSettedSubCommand = other.ValueSettedSubCommand;
        break;
      case SubCommandOneofCase.GetREsourceSubCommand:
        GetREsourceSubCommand = other.GetREsourceSubCommand;
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
        case 10: {
          global::SetValueSubCommand subBuilder = new global::SetValueSubCommand();
          if (subCommandCase_ == SubCommandOneofCase.SetValueSubCommand) {
            subBuilder.MergeFrom(SetValueSubCommand);
          }
          input.ReadMessage(subBuilder);
          SetValueSubCommand = subBuilder;
          break;
        }
        case 18: {
          global::ValueSettedSubCommand subBuilder = new global::ValueSettedSubCommand();
          if (subCommandCase_ == SubCommandOneofCase.ValueSettedSubCommand) {
            subBuilder.MergeFrom(ValueSettedSubCommand);
          }
          input.ReadMessage(subBuilder);
          ValueSettedSubCommand = subBuilder;
          break;
        }
        case 26: {
          global::GetResourceSubCommand subBuilder = new global::GetResourceSubCommand();
          if (subCommandCase_ == SubCommandOneofCase.GetREsourceSubCommand) {
            subBuilder.MergeFrom(GetREsourceSubCommand);
          }
          input.ReadMessage(subBuilder);
          GetREsourceSubCommand = subBuilder;
          break;
        }
      }
    }
  }

}

#endregion


#endregion Designer generated code