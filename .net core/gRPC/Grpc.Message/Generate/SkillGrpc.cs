// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/skill.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Grpc.Message {
  public static partial class SkillService
  {
    static readonly string __ServiceName = "UserInfo.SkillService";

    static readonly grpc::Marshaller<global::Grpc.Message.SkillInfo> __Marshaller_UserInfo_SkillInfo = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Grpc.Message.SkillInfo.Parser.ParseFrom);

    static readonly grpc::Method<global::Grpc.Message.SkillInfo, global::Grpc.Message.SkillInfo> __Method_Query = new grpc::Method<global::Grpc.Message.SkillInfo, global::Grpc.Message.SkillInfo>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Query",
        __Marshaller_UserInfo_SkillInfo,
        __Marshaller_UserInfo_SkillInfo);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Grpc.Message.SkillReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of SkillService</summary>
    [grpc::BindServiceMethod(typeof(SkillService), "BindService")]
    public abstract partial class SkillServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Grpc.Message.SkillInfo> Query(global::Grpc.Message.SkillInfo request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for SkillService</summary>
    public partial class SkillServiceClient : grpc::ClientBase<SkillServiceClient>
    {
      /// <summary>Creates a new client for SkillService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public SkillServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for SkillService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public SkillServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected SkillServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected SkillServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Grpc.Message.SkillInfo Query(global::Grpc.Message.SkillInfo request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Query(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Grpc.Message.SkillInfo Query(global::Grpc.Message.SkillInfo request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Query, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Grpc.Message.SkillInfo> QueryAsync(global::Grpc.Message.SkillInfo request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return QueryAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Grpc.Message.SkillInfo> QueryAsync(global::Grpc.Message.SkillInfo request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Query, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override SkillServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new SkillServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(SkillServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Query, serviceImpl.Query).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, SkillServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Query, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Grpc.Message.SkillInfo, global::Grpc.Message.SkillInfo>(serviceImpl.Query));
    }

  }
}
#endregion