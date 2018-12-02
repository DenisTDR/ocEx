// Decompiled with JetBrains decompiler
// Type: muldivCS.Algos.Extensions
// Assembly: ocExApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B9C70936-1B7B-4F0B-8906-7F2727162273
// Assembly location: C:\Users\NM\Projects\UPT\OC\ocExApi.dll

namespace muldivCS.Algos
{
  public static class Extensions
  {
    public static int ToInt(this char c)
    {
      return (int) c != 49 ? 0 : 1;
    }
  }
}
