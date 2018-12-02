// Decompiled with JetBrains decompiler
// Type: muldivCS.Algos.Algorithms
// Assembly: ocExApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B9C70936-1B7B-4F0B-8906-7F2727162273
// Assembly location: C:\Users\NM\Projects\UPT\OC\ocExApi.dll

using System;

namespace muldivCS.Algos
{
  public class Algorithms
  {
    private string str;

    public string BoothRadix4(int x, int y)
    {
      this.str = "";
      Registry registry1 = new Registry(9, 0);
      Registry registry2 = new Registry(9, 1);
      Registry M = new Registry(9, 0);
      registry1.FromBinary("0 0000 0000", -1);
      registry2.FromNumber(x, 9);
      registry2.Value <<= 1;
      M.FromNumber(y, 9);
      this.CWL((object) ("    " + this.AsLine(registry1, registry2, M)));
      for (int index = 0; index < 4; ++index)
      {
        this.CWL((object) "-----------------------------------------");
        string op;
        Registry radix4OpertionValue = this.GetBoothRadix4OpertionValue(registry2.LastNBits(3), M, out op);
        registry1.Value += radix4OpertionValue.Value;
        this.CWL((object) (op + " " + radix4OpertionValue.ToBinary(4, -1)));
        this.CWL((object) (" => " + registry1.ToBinary(4, -1)));
        this.RightShift(2, registry1, registry2);
        registry1.SetFirstNBits(2, (registry1.FirstNBits(4) & 2) > 1 ? 3 : 0);
        this.CWL((object) ("    " + this.AsLine(registry1, registry2)));
      }
      int num1 = registry2.Value / 2;
      int num2 = (registry1.Value << registry2.Length - 1) + num1;
      if ((num2 & 65536) != 0)
        num2 = -65536 | num2;
      this.CWL((object) "");
      this.CWL((object) ("   =>" + (object) num2));
      this.CWL((object) "");
      this.CWL((object) ("calc=" + (object) (x * y)));
      this.CWL(num2 == x * y ? (object) "ok" : (object) "not ok");
      return this.str;
    }

    public string SrtRadix2(int x, int y)
    {
      this.str = "";
      Registry registry1 = new Registry(9, 0);
      Registry registry2 = new Registry(8, 0);
      Registry registry3 = new Registry(8, 0);
      registry1.FromNumber(x >> registry2.Length, -1);
      registry2.FromNumber(x, -1);
      registry3.FromNumber(y, -1);
      int cnt = 0;
      registry3.Length = 9;
      this.CWL((object) ("     " + this.AsLine(registry1, registry2, registry3)));
      registry3.Length = 8;
      while (registry3.FirstNBits(1) == 0)
      {
        this.LeftShift(1, registry1, registry2, registry3);
        ++cnt;
      }
      this.CWL((object) ("k=" + (object) cnt));
      registry3.Length = 9;
      this.CWL((object) ("     " + this.AsLine(registry1, registry2, registry3)));
      for (int index = 0; index <= 7; ++index)
      {
        this.CWL((object) "-----------------------------------------");
        int num = registry1.FirstNBits(3);
        this.LeftShift(1, registry1, registry2);
        this.CWL((object) index);
        if (num == 7 || num == 0)
        {
          registry2.SetLastBit(0);
          this.CWL((object) ("     " + this.AsLine(registry1, registry2)));
        }
        else if (registry1.FirstNBits(1) == 0)
        {
          registry2.SetLastBit(1);
          this.CWL((object) ("     " + this.AsLine(registry1, registry2)));
          registry1.Value -= registry3.Value;
          this.CWL((object) ("-M  +" + registry3.BuildRegistry().Multiplty(-1).ToBinary(4, -1)));
          this.CWL((object) ("    =" + this.AsLine(registry1)));
        }
        else
        {
          registry2.SetLastBit(-1);
          this.CWL((object) ("     " + this.AsLine(registry1, registry2)));
          registry1.Value += registry3.Value;
          this.CWL((object) ("+M  +" + registry3.ToBinary(4, -1)));
          this.CWL((object) ("    =" + this.AsLine(registry1)));
        }
      }
      this.CWL((object) "-----------------------------------------");
      if (registry1.FirstNBits(1) == 1)
      {
        this.CWL((object) ("Cor +" + registry3.ToBinary(4, -1)));
        registry1.Value += registry3.Value;
        this.CWL((object) ("     " + this.AsLine(registry1)));
        --registry2.Value;
      }
      this.CWL((object) "");
      this.RightShift(cnt, registry1);
      this.CWL((object) ("Shift A k=" + (object) cnt + " positions right"));
      this.CWL((object) ("     " + this.AsLine(registry1)));
      this.CWL((object) "");
      object[] objArray = new object[5]
      {
        (object) "     A = ",
        (object) registry1.Value,
        (object) "\tQ = ",
        (object) registry2.Value,
        null
      };
      int index1 = 4;
      string str;
      if (registry2.DiffFromNegativeBits() == 0)
        str = "";
      else
        str = " - " + (object) registry2.DiffFromNegativeBits() + " = " + (object) (registry2.Value - registry2.DiffFromNegativeBits());
      objArray[index1] = (object) str;
      this.CWL((object) string.Concat(objArray));
      this.CWL((object) "");
      int num1 = x;
      int num2 = y;
      int num3 = num1 / num2 * y;
      this.CWL((object) ((num1 - num3).ToString() + "    " + (object) (x / y)));
      return this.str;
    }

    private Registry GetBoothRadix4OpertionValue(int ct, Registry M, out string op)
    {
      Registry registry = new Registry(M.Length, 0);
      switch (ct)
      {
        case 0:
        case 7:
          op = " +0";
          registry.Value = 0;
          break;
        case 1:
        case 2:
          op = " +M";
          registry.Value = M.Value;
          break;
        case 3:
          op = "+2M";
          registry.Value = 2 * M.Value;
          break;
        case 4:
          op = "-2M";
          registry.Value = -2 * M.Value;
          break;
        case 5:
        case 6:
          op = " -M";
          registry.Value = -M.Value;
          break;
        default:
          throw new Exception("WTF");
      }
      return registry;
    }

    public string SrtRadix4(int x, int y)
    {
      this.str = "";
      Registry registry1 = new Registry(9, 0);
      Registry registry2 = new Registry(8, 0);
      Registry registry3 = new Registry(8, 0);
      registry1.FromNumber(x >> registry2.Length, -1);
      registry2.FromNumber(x, -1);
      registry3.FromNumber(y, -1);
      registry2.IsRadix4 = true;
      int cnt = 0;
      registry3.Length = 9;
      this.CWL((object) ("       " + this.AsLine(registry1, registry2, registry3)));
      registry3.Length = 8;
      while (registry3.FirstNBits(1) == 0)
      {
        this.LeftShift(1, registry1, registry2, registry3);
        ++cnt;
      }
      this.CWL((object) ("k=" + (object) cnt));
      registry3.Length = 9;
      registry3.DisableFirstBit();
      this.CWL((object) ("       " + this.AsLine(registry1, registry2, registry3)));
      int b = registry3.FirstNBits(5) & 15;
      Registry registry4 = new Registry(6, 0);
      registry4.SafeSetValue = true;
      for (int index = 0; index < 4; ++index)
      {
        this.CWL((object) "-----------------------------------------");
        registry4.FromNumber(registry1.FirstNBits(6), -1);
        this.LeftShift(2, registry1, registry2);
        int p = registry4.Value;
        int q = SrtRadix4Table.GetQ(b, p);
        this.CWL((object) (index.ToString() + "   q=" + (object) q));
        registry2.SetRadix4Bit(q);
        this.CWL((object) ("       " + this.AsLine(registry1, registry2)));
        if (q != 0)
        {
          registry1.Value += -q * registry3.Value;
          this.CWL((object) ((-q > 0 ? "+" : "") + (object) -q + "M   +" + registry3.BuildRegistry().Multiplty(-q).ToBinary(4, -1)));
          this.CWL((object) ("       " + registry1.ToBinary(4, -1)));
        }
      }
      this.CWL((object) "-----------------------------------------");
      if (registry1.FirstNBits(1) == 1)
      {
        this.CWL((object) ("Cor A= " + registry3.ToBinary(4, -1)));
        this.CWL((object) ("    +M " + registry3.ToBinary(4, -1)));
        registry1.Value += registry3.Value;
        --registry2.Value;
      }
      this.CWL((object) ("       " + this.AsLine(registry1, registry2)));
      this.CWL((object) "");
      this.CWL((object) ("shift A  k=" + (object) cnt + " positions right"));
      registry1.RightShift(cnt);
      this.CWL((object) "");
      this.CWL((object) ("A=  " + registry1.ToBinary(4, -1) + " = " + (object) registry1.Value));
      this.CWL((object) ("Q=" + registry2.CalcRadix4()));
      this.CWL((object) "");
      int num1 = x;
      int num2 = y;
      int num3 = num1 / num2 * y;
      this.CWL((object) ((num1 - num3).ToString() + "    " + (object) (x / y)));
      return this.str;
    }

    public void LeftShift(int cnt, params Registry[] list)
    {
      for (int index = 0; index < list.Length - 1; ++index)
      {
        list[index].LeftShift(cnt);
        list[index].Value |= list[index + 1].FirstNBits(cnt);
      }
      Registry[] registryArray = list;
      int index1 = registryArray.Length - 1;
      registryArray[index1].LeftShift(cnt);
    }

    public void RightShift(int cnt, params Registry[] list)
    {
      for (int index = list.Length - 1; index > 0; --index)
      {
        list[index].RightShift(cnt);
        list[index].SetFirstNBits(cnt, list[index - 1].LastNBits(cnt));
      }
      list[0].RightShift(cnt);
    }

    private void CWL(object o)
    {
      this.str = this.str + o + "\n";
    }

    public string AsLine(params Registry[] list)
    {
      string str = "";
      foreach (Registry registry in list)
        str = str + (registry.IsRadix4 ? registry.ToBinaryR4(4, -1) : registry.ToBinary(4, -1)) + "\t";
      return str;
    }
  }
}
