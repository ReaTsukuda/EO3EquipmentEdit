using System;

namespace EO3EquipmentEdit.Data
{
  /// <summary>
  /// Represents a bitfield of the classes in EO3.
  /// </summary>
  public class PlayerClasses
  {
    public bool Princess { get; set; }
    public bool Gladiator { get; set; }
    public bool Hoplite { get; set; }
    public bool Buccaneer { get; set; }
    public bool Ninja { get; set; }
    public bool Monk { get; set; }
    public bool Zodiac { get; set; }
    public bool Wildling { get; set; }
    public bool Arbalist { get; set; }
    public bool Farmer { get; set; }
    public bool Shogun { get; set; }
    public bool Yggdroid { get; set; }

    /// <summary>
    /// Gets the bitfield representation of this class list.
    /// </summary>
    public ushort Bitfield
    {
      get
      {
        ushort result = 0;
        if (Princess == true) { result += (ushort)Math.Pow(2, 0); }
        if (Gladiator == true) { result += (ushort)Math.Pow(2, 1); }
        if (Hoplite == true) { result += (ushort)Math.Pow(2, 2); }
        if (Buccaneer == true) { result += (ushort)Math.Pow(2, 3); }
        if (Ninja == true) { result += (ushort)Math.Pow(2, 4); }
        if (Monk == true) { result += (ushort)Math.Pow(2, 5); }
        if (Zodiac == true) { result += (ushort)Math.Pow(2, 6); }
        if (Wildling == true) { result += (ushort)Math.Pow(2, 7); }
        if (Arbalist == true) { result += (ushort)Math.Pow(2, 8); }
        if (Farmer == true) { result += (ushort)Math.Pow(2, 9); }
        if (Shogun == true) { result += (ushort)Math.Pow(2, 10); }
        if (Yggdroid == true) { result += (ushort)Math.Pow(2, 11); }
        return result;
      }
    }
  }
}