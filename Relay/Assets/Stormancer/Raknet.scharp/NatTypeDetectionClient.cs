/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.0
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace RakNet {

using System;
using System.Runtime.InteropServices;

public class NatTypeDetectionClient : PluginInterface2 {
  private HandleRef swigCPtr;

  internal NatTypeDetectionClient(IntPtr cPtr, bool cMemoryOwn) : base(RakNetPINVOKE.NatTypeDetectionClient_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(NatTypeDetectionClient obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~NatTypeDetectionClient() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          RakNetPINVOKE.delete_NatTypeDetectionClient(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public static NatTypeDetectionClient GetInstance() {
    IntPtr cPtr = RakNetPINVOKE.NatTypeDetectionClient_GetInstance();
    NatTypeDetectionClient ret = (cPtr == IntPtr.Zero) ? null : new NatTypeDetectionClient(cPtr, false);
    return ret;
  }

  public static void DestroyInstance(NatTypeDetectionClient i) {
    RakNetPINVOKE.NatTypeDetectionClient_DestroyInstance(NatTypeDetectionClient.getCPtr(i));
  }

  public NatTypeDetectionClient() : this(RakNetPINVOKE.new_NatTypeDetectionClient(), true) {
  }

  public void DetectNATType(SystemAddress _serverAddress) {
    RakNetPINVOKE.NatTypeDetectionClient_DetectNATType(swigCPtr, SystemAddress.getCPtr(_serverAddress));
    if (RakNetPINVOKE.SWIGPendingException.Pending) throw RakNetPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void OnRNS2Recv(SWIGTYPE_p_RNS2RecvStruct recvStruct) {
    RakNetPINVOKE.NatTypeDetectionClient_OnRNS2Recv(swigCPtr, SWIGTYPE_p_RNS2RecvStruct.getCPtr(recvStruct));
  }

  public virtual void DeallocRNS2RecvStruct(SWIGTYPE_p_RNS2RecvStruct s, string file, uint line) {
    RakNetPINVOKE.NatTypeDetectionClient_DeallocRNS2RecvStruct(swigCPtr, SWIGTYPE_p_RNS2RecvStruct.getCPtr(s), file, line);
  }

  public virtual SWIGTYPE_p_RNS2RecvStruct AllocRNS2RecvStruct(string file, uint line) {
    IntPtr cPtr = RakNetPINVOKE.NatTypeDetectionClient_AllocRNS2RecvStruct(swigCPtr, file, line);
    SWIGTYPE_p_RNS2RecvStruct ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_RNS2RecvStruct(cPtr, false);
    return ret;
  }

}

}
