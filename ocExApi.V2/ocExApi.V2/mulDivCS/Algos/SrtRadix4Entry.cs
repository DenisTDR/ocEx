// Decompiled with JetBrains decompiler
// Type: muldivCS.Algos.SrtRadix4Entry
// Assembly: ocExApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B9C70936-1B7B-4F0B-8906-7F2727162273
// Assembly location: C:\Users\NM\Projects\UPT\OC\ocExApi.dll

namespace muldivCS.Algos
{
  internal class SrtRadix4Entry
  {
    public int B { get; set; }

    public int P1 { get; set; }

    public int P2 { get; set; }

    public int Q { get; set; }

    public SrtRadix4Entry(int b, int p1, int p2, int q)
    {
      this.B = b;
      this.P1 = p1;
      this.P2 = p2;
      this.Q = q;
    }
  }
}
