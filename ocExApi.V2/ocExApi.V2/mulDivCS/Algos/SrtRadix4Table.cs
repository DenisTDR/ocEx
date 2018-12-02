// Decompiled with JetBrains decompiler
// Type: muldivCS.Algos.SrtRadix4Table
// Assembly: ocExApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B9C70936-1B7B-4F0B-8906-7F2727162273
// Assembly location: C:\Users\NM\Projects\UPT\OC\ocExApi.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace muldivCS.Algos
{
  public class SrtRadix4Table
  {
    private static List<SrtRadix4Entry> _entries = SrtRadix4Table.Build();

    public static int GetQ(int b, int p)
    {
      SrtRadix4Entry srtRadix4Entry = SrtRadix4Table._entries.FirstOrDefault<SrtRadix4Entry>((Func<SrtRadix4Entry, bool>) (entry =>
      {
        if (entry.B == b && entry.P1 <= p)
          return entry.P2 >= p;
        return false;
      }));
      if (srtRadix4Entry == null)
        return -1000;
      return srtRadix4Entry.Q;
    }

    private static List<SrtRadix4Entry> Build()
    {
      return new List<SrtRadix4Entry>((IEnumerable<SrtRadix4Entry>) new SrtRadix4Entry[40]
      {
        new SrtRadix4Entry(8, -12, -7, -2),
        new SrtRadix4Entry(8, -6, -3, -1),
        new SrtRadix4Entry(8, -2, 1, 0),
        new SrtRadix4Entry(8, 2, 5, 1),
        new SrtRadix4Entry(8, 6, 11, 2),
        new SrtRadix4Entry(9, -14, -8, -2),
        new SrtRadix4Entry(9, -7, -3, -1),
        new SrtRadix4Entry(9, -3, 2, 0),
        new SrtRadix4Entry(9, 2, 6, 1),
        new SrtRadix4Entry(9, 7, 13, 2),
        new SrtRadix4Entry(10, -15, -9, -2),
        new SrtRadix4Entry(10, -8, -3, -1),
        new SrtRadix4Entry(10, -3, 2, 0),
        new SrtRadix4Entry(10, 2, 7, 1),
        new SrtRadix4Entry(10, 8, 14, 2),
        new SrtRadix4Entry(11, -16, -9, -2),
        new SrtRadix4Entry(11, -9, -3, -1),
        new SrtRadix4Entry(11, -3, 2, 0),
        new SrtRadix4Entry(11, 2, 8, 1),
        new SrtRadix4Entry(11, 8, 15, 2),
        new SrtRadix4Entry(12, -18, -10, -2),
        new SrtRadix4Entry(12, -10, -4, -1),
        new SrtRadix4Entry(12, -4, 3, 0),
        new SrtRadix4Entry(12, 3, 9, 1),
        new SrtRadix4Entry(12, 9, 17, 2),
        new SrtRadix4Entry(13, -19, -11, -2),
        new SrtRadix4Entry(13, -10, -4, -1),
        new SrtRadix4Entry(13, -4, 3, 0),
        new SrtRadix4Entry(13, 3, 9, 1),
        new SrtRadix4Entry(13, 10, 18, 2),
        new SrtRadix4Entry(14, -20, -11, -2),
        new SrtRadix4Entry(14, -11, -4, -1),
        new SrtRadix4Entry(14, -4, 3, 0),
        new SrtRadix4Entry(14, 3, 10, 1),
        new SrtRadix4Entry(14, 10, 19, 2),
        new SrtRadix4Entry(15, -22, -12, -2),
        new SrtRadix4Entry(15, -12, -3, -1),
        new SrtRadix4Entry(15, -5, 4, 0),
        new SrtRadix4Entry(15, 3, 11, 1),
        new SrtRadix4Entry(15, 11, 21, 2)
      });
    }
  }
}
