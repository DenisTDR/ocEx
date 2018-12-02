// Decompiled with JetBrains decompiler
// Type: muldivCS.Algos.Registry
// Assembly: ocExApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B9C70936-1B7B-4F0B-8906-7F2727162273
// Assembly location: C:\Users\NM\Projects\UPT\OC\ocExApi.dll

using System;
using System.Collections.Generic;

namespace muldivCS.Algos
{
  public class Registry
  {
    public List<int> Radix4Bits = new List<int>();
    private int _value;
    public List<bool> NegativeBits;
    private int _length;

    public bool SafeSetValue { get; set; }

    public int Value
    {
      get
      {
        return this._value;
      }
      set
      {
        this._value = value & (1 << this.Length) - 1;
        if (!this.SafeSetValue || (this._value & 1 << this.Length - 1) <= 0 || this._value <= 0)
          return;
        this._value = -1 & -(1 << this.Length) | this._value;
      }
    }

    public int Length
    {
      get
      {
        return this._length;
      }
      set
      {
        this._length = value;
        this.Value = this.Value;
      }
    }

    public int Offset { get; set; }

    public bool IsRadix4 { get; set; }

    public Registry()
    {
      this.Length = 0;
      this.Value = 0;
      this.Offset = 0;
    }

    public Registry(int length, int offset = 0)
    {
      this.Length = length;
      this.Offset = offset;
    }

    public override string ToString()
    {
      return this._value.ToString();
    }

    public int FirstNBits(int n)
    {
      return this._value >> this.Length - n & (1 << n) - 1;
    }

    public int LastNBits(int n)
    {
      return this._value & (1 << n) - 1;
    }

    public void SetFirstNBits(int n, int val)
    {
      val <<= this.Length - n;
      this.Value = this.Value | val;
    }

    public void DisableFirstBit()
    {
      if ((this._value & 1 << this.Length - 1) <= 0)
        return;
      this.Value = this.Value ^ 1 << this.Length - 1;
    }

    public void SetLastBit(int val)
    {
      if (val == -1)
      {
        this.SetLastBitNegative(true);
      }
      else
      {
        this.SetLastBitNegative(false);
        if ((this._value & 1) == (val & 1))
          return;
        this._value = this._value ^ 1;
      }
    }

    public void SetRadix4Bit(int bit)
    {
      this.Radix4Bits.Add(bit);
    }

    public void FromBinary(string str, int len = -1)
    {
      if (len == -1)
      {
        len = 0;
        foreach (int num in str)
        {
          if (num != 32)
            ++len;
        }
        this.Length = len;
      }
      int num1 = 0;
      for (int index = 0; index < len; ++index)
      {
        if ((int) str[index] == 32)
          ++len;
        else
          num1 = (num1 | str[index].ToInt()) << 1;
      }
      this.Value = num1 >> 1;
    }

    public void FromNumber(int nr, int len = -1)
    {
      if (len == -1)
        len = this.Length;
      else
        this.Length = len;
      this.FromBinary(Registry.ToBinaryS(nr, len, 4, 0, (List<bool>) null), -1);
    }

    public string ToBinary(int groups = 4, int offset = -1)
    {
      if (offset == -1)
        offset = this.Offset;
      return Registry.ToBinaryS(this._value, this.Length, groups, offset, this.NegativeBits);
    }

    public string ToBinaryR4(int groups = 4, int offset = -1)
    {
      List<int> intList = new List<int>((IEnumerable<int>) this.Radix4Bits.ToArray());
      string str = "";
      int nr = this._value;
      while (intList.Count > 0)
      {
        str = str + " " + (object) intList[0];
        intList.RemoveAt(0);
        nr >>= 2;
      }
      if (offset == -1)
        offset = this.Offset;
      return Registry.ToBinaryS(nr, this.Length - this.Radix4Bits.Count * 2, groups, offset, (List<bool>) null) + " " + str;
    }

    public static string ToBinaryS(int nr, int len, int groups = 4, int offset = 0, List<bool> negativeBits = null)
    {
      string str = "";
      int index = 0;
      while (len-- > 0)
      {
        if (index % groups == offset)
          str = " " + str;
        str = negativeBits == null || !negativeBits[index] ? ((nr & 1) == 1 ? "1" : "0") + str : "-" + str;
        nr >>= 1;
        ++index;
      }
      return str;
    }

    public void SetLastBitNegative(bool negative = true)
    {
      if (this.NegativeBits == null || this.NegativeBits.Count != this.Length)
        this.NegativeBits = new List<bool>((IEnumerable<bool>) new bool[this.Length]);
      this.NegativeBits[0] = negative;
    }

    public void LeftShift(int cnt)
    {
      this.Value = this.Value << cnt;
      if (this.NegativeBits == null || this.NegativeBits.Count != this.Length)
        return;
      for (int index = this.Length - 1; index >= cnt; --index)
      {
        this.NegativeBits[index] = this.NegativeBits[index - cnt];
        this.NegativeBits[index - cnt] = false;
      }
    }

    public void RightShift(int cnt)
    {
      this.Value = this.Value >> cnt;
      if (this.NegativeBits == null || this.NegativeBits.Count != this.Length)
        return;
      for (int index = 0; index < this.Length - cnt; ++index)
      {
        this.NegativeBits[index] = this.NegativeBits[index + cnt];
        this.NegativeBits[index + cnt] = false;
      }
    }

    public Registry BuildRegistry()
    {
      Registry registry = new Registry(this.Length, 0);
      registry.FromNumber(this.Value, -1);
      if (this.NegativeBits != null)
        registry.NegativeBits = new List<bool>((IEnumerable<bool>) this.NegativeBits.ToArray());
      return registry;
    }

    public Registry Multiplty(int nr)
    {
      this.Value = this.Value * nr;
      return this;
    }

    public int DiffFromNegativeBits()
    {
      int num = 0;
      if (this.NegativeBits == null || this.NegativeBits.Count != this.Length)
        return 0;
      this.NegativeBits.Reverse();
      foreach (bool negativeBit in this.NegativeBits)
      {
        if (negativeBit)
          num |= 1;
        num <<= 1;
      }
      this.NegativeBits.Reverse();
      return num >> 1;
    }

    public string CalcRadix4()
    {
      string str = "";
      int num1 = 0;
      int num2 = 0;
      foreach (int radix4Bit in this.Radix4Bits)
      {
        str = str + "  " + (radix4Bit >= 0 ? "+" : "") + (object) radix4Bit + "*4^" + (object) (this.Length / 2 - num1 - 1);
        num2 += radix4Bit * (int) Math.Pow(4.0, (double) (this.Length / 2 - num1 - 1));
        ++num1;
      }
      if (this._value != 0)
      {
        str += "  -1";
        --num2;
      }
      return str + "  = " + (object) num2;
    }

    public void SetFakeValue(int nr)
    {
      this._value = nr & (1 << this.Length) - 1;
    }
  }
}
