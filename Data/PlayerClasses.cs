using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        if (Princess == true) { result += 2 ^ 1; }
        if (Gladiator == true) { result += 2 ^ 2; }
        if (Hoplite == true) { result += 2 ^ 3; }
        if (Buccaneer == true) { result += 2 ^ 4; }
        if (Ninja == true) { result += 2 ^ 5; }
        if (Monk == true) { result += 2 ^ 6; }
        if (Zodiac == true) { result += 2 ^ 7; }
        if (Wildling == true) { result += 2 ^ 8; }
        if (Arbalist == true) { result += 2 ^ 9; }
        if (Farmer == true) { result += 2 ^ 10; }
        if (Shogun == true) { result += 2 ^ 11; }
        if (Yggdroid == true) { result += 2 ^ 12; }
        return result;
      }
    }
  }
}
