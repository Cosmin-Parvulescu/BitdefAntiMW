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
            "ZXN0YW1wLnByb3RvIrMBCgpNZXNzYWdlRHRvEjIKDnRocmVhdEV2ZW50RHRv",
            "GAEgASgLMhguYW50aW13cGIuVGhyZWF0RXZlbnREdG9IABI4ChF0aHJlYXRM",
            "b2dFdmVudER0bxgCIAEoCzIbLmFudGltd3BiLlRocmVhdExvZ0V2ZW50RHRv",
            "SAASLAoLbG9nRXZlbnREdG8YAyABKAsyFS5hbnRpbXdwYi5Mb2dFdmVudER0",
            "b0gAQgkKB21lc3NhZ2UiZwoLTG9nRXZlbnREdG8SLQoJdGltZXN0YW1wGAEg",
            "ASgLMhouZ29vZ2xlLnByb3RvYnVmLlRpbWVzdGFtcBIRCglldmVudFR5cGUY",
            "AiABKAkSFgoOYWRkaXRpb25hbFRleHQYAyABKAkidQoRVGhyZWF0TG9nRXZl",
            "bnREdG8SLQoJdGltZXN0YW1wGAEgASgLMhouZ29vZ2xlLnByb3RvYnVmLlRp",
            "bWVzdGFtcBIxCg90aHJlYXRFdmVudER0b3MYAiADKAsyGC5hbnRpbXdwYi5U",
            "aHJlYXRFdmVudER0byJnCg5UaHJlYXRFdmVudER0bxItCgl0aW1lc3RhbXAY",
            "ASABKAsyGi5nb29nbGUucHJvdG9idWYuVGltZXN0YW1wEhIKCnRocmVhdFBh",
            "dGgYAiABKAkSEgoKdGhyZWF0TmFtZRgDIAEoCWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Antimwpb.MessageDto), global::Antimwpb.MessageDto.Parser, new[]{ "ThreatEventDto", "ThreatLogEventDto", "LogEventDto" }, new[]{ "Message" }, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Antimwpb.LogEventDto), global::Antimwpb.LogEventDto.Parser, new[]{ "Timestamp", "EventType", "AdditionalText" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Antimwpb.ThreatLogEventDto), global::Antimwpb.ThreatLogEventDto.Parser, new[]{ "Timestamp", "ThreatEventDtos" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Antimwpb.ThreatEventDto), global::Antimwpb.ThreatEventDto.Parser, new[]{ "Timestamp", "ThreatPath", "ThreatName" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class MessageDto : pb::IMessage<MessageDto> {
    private static readonly pb::MessageParser<MessageDto> _parser = new pb::MessageParser<MessageDto>(() => new MessageDto());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<MessageDto> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Antimwpb.AntimwReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MessageDto() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MessageDto(MessageDto other) : this() {
      switch (other.MessageCase) {
        case MessageOneofCase.ThreatEventDto:
          ThreatEventDto = other.ThreatEventDto.Clone();
          break;
        case MessageOneofCase.ThreatLogEventDto:
          ThreatLogEventDto = other.ThreatLogEventDto.Clone();
          break;
        case MessageOneofCase.LogEventDto:
          LogEventDto = other.LogEventDto.Clone();
          break;
      }

      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MessageDto Clone() {
      return new MessageDto(this);
    }

    /// <summary>Field number for the "threatEventDto" field.</summary>
    public const int ThreatEventDtoFieldNumber = 1;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Antimwpb.ThreatEventDto ThreatEventDto {
      get { return messageCase_ == MessageOneofCase.ThreatEventDto ? (global::Antimwpb.ThreatEventDto) message_ : null; }
      set {
        message_ = value;
        messageCase_ = value == null ? MessageOneofCase.None : MessageOneofCase.ThreatEventDto;
      }
    }

    /// <summary>Field number for the "threatLogEventDto" field.</summary>
    public const int ThreatLogEventDtoFieldNumber = 2;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Antimwpb.ThreatLogEventDto ThreatLogEventDto {
      get { return messageCase_ == MessageOneofCase.ThreatLogEventDto ? (global::Antimwpb.ThreatLogEventDto) message_ : null; }
      set {
        message_ = value;
        messageCase_ = value == null ? MessageOneofCase.None : MessageOneofCase.ThreatLogEventDto;
      }
    }

    /// <summary>Field number for the "logEventDto" field.</summary>
    public const int LogEventDtoFieldNumber = 3;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Antimwpb.LogEventDto LogEventDto {
      get { return messageCase_ == MessageOneofCase.LogEventDto ? (global::Antimwpb.LogEventDto) message_ : null; }
      set {
        message_ = value;
        messageCase_ = value == null ? MessageOneofCase.None : MessageOneofCase.LogEventDto;
      }
    }

    private object message_;
    /// <summary>Enum of possible cases for the "message" oneof.</summary>
    public enum MessageOneofCase {
      None = 0,
      ThreatEventDto = 1,
      ThreatLogEventDto = 2,
      LogEventDto = 3,
    }
    private MessageOneofCase messageCase_ = MessageOneofCase.None;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public MessageOneofCase MessageCase {
      get { return messageCase_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearMessage() {
      messageCase_ = MessageOneofCase.None;
      message_ = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as MessageDto);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(MessageDto other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(ThreatEventDto, other.ThreatEventDto)) return false;
      if (!object.Equals(ThreatLogEventDto, other.ThreatLogEventDto)) return false;
      if (!object.Equals(LogEventDto, other.LogEventDto)) return false;
      if (MessageCase != other.MessageCase) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (messageCase_ == MessageOneofCase.ThreatEventDto) hash ^= ThreatEventDto.GetHashCode();
      if (messageCase_ == MessageOneofCase.ThreatLogEventDto) hash ^= ThreatLogEventDto.GetHashCode();
      if (messageCase_ == MessageOneofCase.LogEventDto) hash ^= LogEventDto.GetHashCode();
      hash ^= (int) messageCase_;
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
      if (messageCase_ == MessageOneofCase.ThreatEventDto) {
        output.WriteRawTag(10);
        output.WriteMessage(ThreatEventDto);
      }
      if (messageCase_ == MessageOneofCase.ThreatLogEventDto) {
        output.WriteRawTag(18);
        output.WriteMessage(ThreatLogEventDto);
      }
      if (messageCase_ == MessageOneofCase.LogEventDto) {
        output.WriteRawTag(26);
        output.WriteMessage(LogEventDto);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (messageCase_ == MessageOneofCase.ThreatEventDto) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(ThreatEventDto);
      }
      if (messageCase_ == MessageOneofCase.ThreatLogEventDto) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(ThreatLogEventDto);
      }
      if (messageCase_ == MessageOneofCase.LogEventDto) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(LogEventDto);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(MessageDto other) {
      if (other == null) {
        return;
      }
      switch (other.MessageCase) {
        case MessageOneofCase.ThreatEventDto:
          if (ThreatEventDto == null) {
            ThreatEventDto = new global::Antimwpb.ThreatEventDto();
          }
          ThreatEventDto.MergeFrom(other.ThreatEventDto);
          break;
        case MessageOneofCase.ThreatLogEventDto:
          if (ThreatLogEventDto == null) {
            ThreatLogEventDto = new global::Antimwpb.ThreatLogEventDto();
          }
          ThreatLogEventDto.MergeFrom(other.ThreatLogEventDto);
          break;
        case MessageOneofCase.LogEventDto:
          if (LogEventDto == null) {
            LogEventDto = new global::Antimwpb.LogEventDto();
          }
          LogEventDto.MergeFrom(other.LogEventDto);
          break;
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
            global::Antimwpb.ThreatEventDto subBuilder = new global::Antimwpb.ThreatEventDto();
            if (messageCase_ == MessageOneofCase.ThreatEventDto) {
              subBuilder.MergeFrom(ThreatEventDto);
            }
            input.ReadMessage(subBuilder);
            ThreatEventDto = subBuilder;
            break;
          }
          case 18: {
            global::Antimwpb.ThreatLogEventDto subBuilder = new global::Antimwpb.ThreatLogEventDto();
            if (messageCase_ == MessageOneofCase.ThreatLogEventDto) {
              subBuilder.MergeFrom(ThreatLogEventDto);
            }
            input.ReadMessage(subBuilder);
            ThreatLogEventDto = subBuilder;
            break;
          }
          case 26: {
            global::Antimwpb.LogEventDto subBuilder = new global::Antimwpb.LogEventDto();
            if (messageCase_ == MessageOneofCase.LogEventDto) {
              subBuilder.MergeFrom(LogEventDto);
            }
            input.ReadMessage(subBuilder);
            LogEventDto = subBuilder;
            break;
          }
        }
      }
    }

  }

  public sealed partial class LogEventDto : pb::IMessage<LogEventDto> {
    private static readonly pb::MessageParser<LogEventDto> _parser = new pb::MessageParser<LogEventDto>(() => new LogEventDto());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LogEventDto> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Antimwpb.AntimwReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LogEventDto() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LogEventDto(LogEventDto other) : this() {
      Timestamp = other.timestamp_ != null ? other.Timestamp.Clone() : null;
      eventType_ = other.eventType_;
      additionalText_ = other.additionalText_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LogEventDto Clone() {
      return new LogEventDto(this);
    }

    /// <summary>Field number for the "timestamp" field.</summary>
    public const int TimestampFieldNumber = 1;
    private global::Google.Protobuf.WellKnownTypes.Timestamp timestamp_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp Timestamp {
      get { return timestamp_; }
      set {
        timestamp_ = value;
      }
    }

    /// <summary>Field number for the "eventType" field.</summary>
    public const int EventTypeFieldNumber = 2;
    private string eventType_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string EventType {
      get { return eventType_; }
      set {
        eventType_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "additionalText" field.</summary>
    public const int AdditionalTextFieldNumber = 3;
    private string additionalText_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string AdditionalText {
      get { return additionalText_; }
      set {
        additionalText_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LogEventDto);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LogEventDto other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Timestamp, other.Timestamp)) return false;
      if (EventType != other.EventType) return false;
      if (AdditionalText != other.AdditionalText) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (timestamp_ != null) hash ^= Timestamp.GetHashCode();
      if (EventType.Length != 0) hash ^= EventType.GetHashCode();
      if (AdditionalText.Length != 0) hash ^= AdditionalText.GetHashCode();
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
      if (timestamp_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Timestamp);
      }
      if (EventType.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(EventType);
      }
      if (AdditionalText.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(AdditionalText);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (timestamp_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Timestamp);
      }
      if (EventType.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(EventType);
      }
      if (AdditionalText.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(AdditionalText);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LogEventDto other) {
      if (other == null) {
        return;
      }
      if (other.timestamp_ != null) {
        if (timestamp_ == null) {
          timestamp_ = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        Timestamp.MergeFrom(other.Timestamp);
      }
      if (other.EventType.Length != 0) {
        EventType = other.EventType;
      }
      if (other.AdditionalText.Length != 0) {
        AdditionalText = other.AdditionalText;
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
            if (timestamp_ == null) {
              timestamp_ = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(timestamp_);
            break;
          }
          case 18: {
            EventType = input.ReadString();
            break;
          }
          case 26: {
            AdditionalText = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class ThreatLogEventDto : pb::IMessage<ThreatLogEventDto> {
    private static readonly pb::MessageParser<ThreatLogEventDto> _parser = new pb::MessageParser<ThreatLogEventDto>(() => new ThreatLogEventDto());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ThreatLogEventDto> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Antimwpb.AntimwReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ThreatLogEventDto() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ThreatLogEventDto(ThreatLogEventDto other) : this() {
      Timestamp = other.timestamp_ != null ? other.Timestamp.Clone() : null;
      threatEventDtos_ = other.threatEventDtos_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ThreatLogEventDto Clone() {
      return new ThreatLogEventDto(this);
    }

    /// <summary>Field number for the "timestamp" field.</summary>
    public const int TimestampFieldNumber = 1;
    private global::Google.Protobuf.WellKnownTypes.Timestamp timestamp_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp Timestamp {
      get { return timestamp_; }
      set {
        timestamp_ = value;
      }
    }

    /// <summary>Field number for the "threatEventDtos" field.</summary>
    public const int ThreatEventDtosFieldNumber = 2;
    private static readonly pb::FieldCodec<global::Antimwpb.ThreatEventDto> _repeated_threatEventDtos_codec
        = pb::FieldCodec.ForMessage(18, global::Antimwpb.ThreatEventDto.Parser);
    private readonly pbc::RepeatedField<global::Antimwpb.ThreatEventDto> threatEventDtos_ = new pbc::RepeatedField<global::Antimwpb.ThreatEventDto>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Antimwpb.ThreatEventDto> ThreatEventDtos {
      get { return threatEventDtos_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ThreatLogEventDto);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ThreatLogEventDto other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Timestamp, other.Timestamp)) return false;
      if(!threatEventDtos_.Equals(other.threatEventDtos_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (timestamp_ != null) hash ^= Timestamp.GetHashCode();
      hash ^= threatEventDtos_.GetHashCode();
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
      if (timestamp_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Timestamp);
      }
      threatEventDtos_.WriteTo(output, _repeated_threatEventDtos_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (timestamp_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Timestamp);
      }
      size += threatEventDtos_.CalculateSize(_repeated_threatEventDtos_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ThreatLogEventDto other) {
      if (other == null) {
        return;
      }
      if (other.timestamp_ != null) {
        if (timestamp_ == null) {
          timestamp_ = new global::Google.Protobuf.WellKnownTypes.Timestamp();
        }
        Timestamp.MergeFrom(other.Timestamp);
      }
      threatEventDtos_.Add(other.threatEventDtos_);
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
            if (timestamp_ == null) {
              timestamp_ = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(timestamp_);
            break;
          }
          case 18: {
            threatEventDtos_.AddEntriesFrom(input, _repeated_threatEventDtos_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class ThreatEventDto : pb::IMessage<ThreatEventDto> {
    private static readonly pb::MessageParser<ThreatEventDto> _parser = new pb::MessageParser<ThreatEventDto>(() => new ThreatEventDto());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ThreatEventDto> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Antimwpb.AntimwReflection.Descriptor.MessageTypes[3]; }
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
      Timestamp = other.timestamp_ != null ? other.Timestamp.Clone() : null;
      threatPath_ = other.threatPath_;
      threatName_ = other.threatName_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ThreatEventDto Clone() {
      return new ThreatEventDto(this);
    }

    /// <summary>Field number for the "timestamp" field.</summary>
    public const int TimestampFieldNumber = 1;
    private global::Google.Protobuf.WellKnownTypes.Timestamp timestamp_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.WellKnownTypes.Timestamp Timestamp {
      get { return timestamp_; }
      set {
        timestamp_ = value;
      }
    }

    /// <summary>Field number for the "threatPath" field.</summary>
    public const int ThreatPathFieldNumber = 2;
    private string threatPath_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ThreatPath {
      get { return threatPath_; }
      set {
        threatPath_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "threatName" field.</summary>
    public const int ThreatNameFieldNumber = 3;
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
      if (!object.Equals(Timestamp, other.Timestamp)) return false;
      if (ThreatPath != other.ThreatPath) return false;
      if (ThreatName != other.ThreatName) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
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
      if (timestamp_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Timestamp);
      }
      if (ThreatPath.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(ThreatPath);
      }
      if (ThreatName.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(ThreatName);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
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
            if (timestamp_ == null) {
              timestamp_ = new global::Google.Protobuf.WellKnownTypes.Timestamp();
            }
            input.ReadMessage(timestamp_);
            break;
          }
          case 18: {
            ThreatPath = input.ReadString();
            break;
          }
          case 26: {
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