// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: antimw.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Antimwpb {

  /// <summary>Holder for reflection information generated from antimw.proto</summary>
  public static partial class AntimwReflection {

    #region Descriptor
    /// <summary>File descriptor for antimw.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static AntimwReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CgxhbnRpbXcucHJvdG8SCGFudGltd3BiGh9nb29nbGUvcHJvdG9idWYvdGlt",
            "ZXN0YW1wLnByb3RvInoKDlRocmVhdEV2ZW50RHRvEhEKCWV2ZW50VHlwZRgB",
            "IAEoCRItCgl0aW1lc3RhbXAYAiABKAsyGi5nb29nbGUucHJvdG9idWYuVGlt",
            "ZXN0YW1wEhIKCnRocmVhdFBhdGgYAyABKAkSEgoKdGhyZWF0TmFtZRgEIAEo",
            "CWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Antimwpb.ThreatEventDto), global::Antimwpb.ThreatEventDto.Parser, new[]{ "EventType", "Timestamp", "ThreatPath", "ThreatName" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class ThreatEventDto : pb::IMessage<ThreatEventDto> {
    private static readonly pb::MessageParser<ThreatEventDto> _parser = new pb::MessageParser<ThreatEventDto>(() => new ThreatEventDto());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ThreatEventDto> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Antimwpb.AntimwReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ThreatEventDto() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ThreatEventDto(ThreatEventDto other) : this() {
      eventType_ = other.eventType_;
      Timestamp = other.timestamp_ != null ? other.Timestamp.Clone() : null;
      threatPath_ = other.threatPath_;
      threatName_ = other.threatName_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ThreatEventDto Clone() {
      return new ThreatEventDto(this);
    }

    /// <summary>Field number for the "eventType" field.</summary>
    public const int EventTypeFieldNumber = 1;
    private string eventType_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string EventType {
      get { return eventType_; }
      set {
        eventType_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "timestamp" field.</summary>
    public const int TimestampFieldNumber = 2;
    private global::Google.Protobuf.WellKnownTypes.Timestamp timestamp_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp Timestamp {
      get { return timestamp_; }
      set {
        timestamp_ = value;
      }
    }

    /// <summary>Field number for the "threatPath" field.</summary>
    public const int ThreatPathFieldNumber = 3;
    private string threatPath_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ThreatPath {
      get { return threatPath_; }
      set {
        threatPath_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "threatName" field.</summary>
    public const int ThreatNameFieldNumber = 4;
    private string threatName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ThreatName {
      get { return threatName_; }
      set {
        threatName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ThreatEventDto);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ThreatEventDto other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (EventType != other.EventType) return false;
      if (!object.Equals(Timestamp, other.Timestamp)) return false;
      if (ThreatPath != other.ThreatPath) return false;
      if (ThreatName != other.ThreatName) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (EventType.Length != 0) hash ^= EventType.GetHashCode();
      if (timestamp_ != null) hash ^= Timestamp.GetHashCode();
      if (ThreatPath.Length != 0) hash ^= ThreatPath.GetHashCode();
      if (ThreatName.Length != 0) hash ^= ThreatName.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (EventType.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(EventType);
      }
      if (timestamp_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Timestamp);
      }
      if (ThreatPath.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(ThreatPath);
      }
      if (ThreatName.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(ThreatName);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (EventType.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(EventType);
      }
      if (timestamp_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Timestamp);
      }
      if (ThreatPath.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ThreatPath);
      }
      if (ThreatName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ThreatName);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ThreatEventDto other) {
      if (other == null) {
        return;
      }
      if (other.EventType.Length != 0) {
        EventType = other.EventType;
      }
      if (other.timestamp_ != null) {
        if (timestamp_ == null) {
          timestamp_ = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        Timestamp.MergeFrom(other.Timestamp);
      }
      if (other.ThreatPath.Length != 0) {
        ThreatPath = other.ThreatPath;
      }
      if (other.ThreatName.Length != 0) {
        ThreatName = other.ThreatName;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            EventType = input.ReadString();
            break;
          }
          case 18: {
            if (timestamp_ == null) {
              timestamp_ = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(timestamp_);
            break;
          }
          case 26: {
            ThreatPath = input.ReadString();
            break;
          }
          case 34: {
            ThreatName = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code