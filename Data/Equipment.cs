using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OriginTablets.Types;

namespace EO3EquipmentEdit.Data
{
  /// <summary>
  /// Represents an equippable item in EO3.
  /// </summary>
  class Equipment
  {
    /// <summary>
    /// A pointer to the loaded equipitemnametable.tbl.
    /// </summary>
    private Table EquipmentNames;

    /// <summary>
    /// A pointer to the loaded equipitemexpbattle.mbm.
    /// </summary>
    private MBM EquipmentDescriptions;

    /// <summary>
    /// Where this equipment is in the internal table.
    /// </summary>
    private int Index;

    /// <summary>
    /// This equipment's name.
    /// </summary>
    public string Name => EquipmentNames[Index];

    /// <summary>
    /// This equipment's description.
    /// </summary>
    public string Description => EquipmentDescriptions[Index];

    /// <summary>
    /// What type of equipment this item is.
    /// </summary>
    public EquipmentTypes Type { get; set; }

    /// <summary>
    /// The item's accuracy value.
    /// </summary>
    public int Accuracy { get; set; }

    /// <summary>
    /// The item's damage type. Applies only to weapons.
    /// </summary>
    public DamageType DamageType { get; set; }

    /// <summary>
    /// The item's ATK value.
    /// </summary>
    public int ATK { get; set; }

    /// <summary>
    /// The item's DEF value.
    /// </summary>
    public int DEF { get; set; }

    /// <summary>
    /// The item's MAT value.
    /// </summary>
    public int MAT { get; set; }

    /// <summary>
    /// The item's MDF value.
    /// </summary>
    public int MDF { get; set; }

    /// <summary>
    /// The numeric stat bonuses that the item gives.
    /// </summary>
    public StatBlock StatBonuses { get; }

    /// <summary>
    /// The item's speed modifier.
    /// </summary>
    public int Speed { get; set; }

    /// <summary>
    /// Whether or not the item is a weapon.
    /// This can be checked by seeing if the item is any of the weapon types.
    /// </summary>
    public bool IsWeapon
    { 
      get
      {
        return Type == EquipmentTypes.Sword
          || Type == EquipmentTypes.Katana
          || Type == EquipmentTypes.Dagger
          || Type == EquipmentTypes.Rapier
          || Type == EquipmentTypes.Spear
          || Type == EquipmentTypes.Crossbow
          || Type == EquipmentTypes.Club
          || Type == EquipmentTypes.Fist
          || Type == EquipmentTypes.Book
          || Type == EquipmentTypes.Gun;
      }
    }

    /// <summary>
    /// Which classes can equip this item.
    /// </summary>
    public PlayerClasses ClassesThatCanEquip { get; }

    /// <summary>
    /// The item's special flags.
    /// </summary>
    public EquipmentFlags Flags { get; }

    /// <summary>
    /// The amount of forge slots the item has.
    /// </summary>
    public int ForgeSlots { get; }

    /// <summary>
    /// The forges the item comes with.
    /// </summary>
    public List<ForgeTypes> Forges { get; }

    /// <summary>
    /// How much the item costs to buy.
    /// </summary>
    public int Price { get; }

    /// <summary>
    /// Represents the different equipment types in EO3. 
    /// An entry's value is equal to its numeric type in-game.
    /// </summary>
    public enum EquipmentTypes
    {
      Sword       = 0x1,
      Katana      = 0x2,
      Dagger      = 0x3,
      Rapier      = 0x4,
      Spear       = 0x5,
      Crossbow    = 0x6,
      Club        = 0x7,
      Fist        = 0x8,
      Book        = 0x9,
      Gun         = 0xA,
      HeavyArmor  = 0xB,
      LightArmor  = 0xC,
      ClothArmor  = 0xD,
      Shield      = 0xE,
      Helmet      = 0xF,
      Glove       = 0x10,
      Boot        = 0x11,
      Accessory   = 0x12
    }

    /// <summary>
    /// A lookup table for singular string versions of equipment types.
    /// </summary>
    public static readonly Dictionary<EquipmentTypes, string> EquipmentNamesSingular
      = new Dictionary<EquipmentTypes, string>()
    {
      { EquipmentTypes.Sword, "Sword" },
      { EquipmentTypes.Katana, "Katana" },
      { EquipmentTypes.Dagger, "Dagger" },
      { EquipmentTypes.Rapier, "Rapier" },
      { EquipmentTypes.Crossbow, "Crossbow" },
      { EquipmentTypes.Club, "Club" },
      { EquipmentTypes.Fist, "Fist" },
      { EquipmentTypes.Book, "Book" },
      { EquipmentTypes.Gun, "Gun" },
      { EquipmentTypes.HeavyArmor, "Heavy armor" },
      { EquipmentTypes.LightArmor, "Light armor" },
      { EquipmentTypes.ClothArmor, "Cloth armor" },
      { EquipmentTypes.Shield, "Shield" },
      { EquipmentTypes.Helmet, "Helmet" },
      { EquipmentTypes.Glove, "Glove" },
      { EquipmentTypes.Boot, "Boot" },
      { EquipmentTypes.Accessory, "Accessory" },
    };

    /// <summary>
    /// A lookup table for plural string versions of equipment types.
    /// </summary>
    public static readonly Dictionary<EquipmentTypes, string> EquipmentNamesPlural
      = new Dictionary<EquipmentTypes, string>()
    {
      { EquipmentTypes.Sword, "Swords" },
      { EquipmentTypes.Katana, "Katanas" },
      { EquipmentTypes.Dagger, "Daggers" },
      { EquipmentTypes.Rapier, "Rapiers" },
      { EquipmentTypes.Crossbow, "Crossbows" },
      { EquipmentTypes.Club, "Clubs" },
      { EquipmentTypes.Fist, "Fists" },
      { EquipmentTypes.Book, "Books" },
      { EquipmentTypes.Gun, "Guns" },
      { EquipmentTypes.HeavyArmor, "Heavy armor" },
      { EquipmentTypes.LightArmor, "Light armor" },
      { EquipmentTypes.ClothArmor, "Cloth armor" },
      { EquipmentTypes.Shield, "Shields" },
      { EquipmentTypes.Helmet, "Helmets" },
      { EquipmentTypes.Glove, "Gloves" },
      { EquipmentTypes.Boot, "Boots" },
      { EquipmentTypes.Accessory, "Accessories" },
    };

    /// <summary>
    /// Special miscellaneous flags for equipment.
    /// </summary>
    public class EquipmentFlags
    {
      /// <summary>
      /// 0x1. Whether or not the item requires its materials to be restocked.
      /// </summary>
      public bool CanSellOut { get; set; }

      /// <summary>
      /// 0x20. Whether or not the item's icon is gold.
      /// </summary>
      public bool Rare { get; set; }

      /// <summary>
      /// 0x80. Whehter or not the item is stocked at Napier's Firm at the start of the game.
      /// </summary>
      public bool Starter { get; set; }
    }

    /// <summary>
    /// Forge types. Values are their internal ID.
    /// </summary>
    public enum ForgeTypes
    {
      None      = 0x00,
      ATK       = 0x01,
      Hit       = 0x02,
      Blind     = 0x03,
      Sleep     = 0x04,
      STR       = 0x05,
      TEC       = 0x06,
      VIT       = 0x07,
      AGI       = 0x08,
      LUC       = 0x09,
      Poison    = 0x0A,
      Berserk   = 0x0B, // Replaces panic from the vanilla game.
      Paralyze  = 0x0C,
      WIS       = 0x0D, // Replaces stun from the vanilla game.
      Plague    = 0x0E,
      Curse     = 0x0F,
      HeadBind  = 0x10,
      ArmBind   = 0x11,
      LegBind   = 0x12,
      Crit      = 0x13,
      Fire      = 0x14,
      Ice       = 0x15,
      Volt      = 0x16,
      Petrify   = 0x17,
      Death     = 0x18,
      HP        = 0x1A,
      TP        = 0x1B,
      Cut       = 0x1C,
      Bash      = 0x1D,
      Stab      = 0x1E,
      Speed     = 0x1F,
      Limit     = 0x20
    }

    /// <summary>
    /// The maximum number of forge slots that can be on equipment.
    /// </summary>
    public static readonly int MaximumAmountOfForges = 9;

    /// <summary>
    /// Constructor for creating an Equipment object from equipitemtable.tbl.
    /// </summary>
    /// <param name="index">What this item's index in the total table is.</param>
    /// <param name="input">The BinaryReader for the input file.</param>
    /// <param name="equipItemNames">The Table object for equipitemnametable.tbl.</param>
    /// <param name="equipItemDescriptions">The MBM object for equipitemexpbattle.mbm.</param>
    public Equipment(int index, BinaryReader input, Table equipItemNames, MBM equipItemDescriptions)
    {
      Index = index;
      EquipmentNames = equipItemNames;
      EquipmentDescriptions = equipItemDescriptions;
      Type = (EquipmentTypes)input.ReadByte();
      Accuracy = input.ReadByte();
      int damageTypeBitfield = input.ReadUInt16();
      DamageType = new DamageType()
      {
        Cut = (damageTypeBitfield & 1) == 1,
        Bash = (damageTypeBitfield & 2) == 2,
        Stab = (damageTypeBitfield & 4) == 4,
        Fire = (damageTypeBitfield & 8) == 8,
        Ice = (damageTypeBitfield & 16) == 16,
        Volt = (damageTypeBitfield & 32) == 32,
        Almighty = (damageTypeBitfield & 64) == 64,
        NoPenalty = (damageTypeBitfield & 128) == 128,
      };
      ATK = input.ReadInt16();
      DEF = input.ReadInt16();
      MAT = input.ReadInt16();
      MDF = input.ReadInt16();
      // Skip 0xE unnecessary bytes.
      input.ReadBytes(0xE);
      StatBonuses = new StatBlock()
      {
        HP = input.ReadByte(),
        TP = input.ReadByte(),
        STR = input.ReadByte(),
        VIT = input.ReadByte(),
        AGI = input.ReadByte(),
        LUC = input.ReadByte(),
        TEC = input.ReadByte(),
        WIS = input.ReadByte()
      };
      Speed = input.ReadInt16();
      input.ReadInt16(); // This is the table's "is weapon" value.
      int classBitfield = input.ReadUInt16();
      ClassesThatCanEquip = new PlayerClasses()
      {
        Princess = (classBitfield & 1) == 1,
        Gladiator = (classBitfield & 2) == 2,
        Hoplite = (classBitfield & 4) == 4,
        Buccaneer = (classBitfield & 8) == 8,
        Ninja = (classBitfield & 16) == 16,
        Monk = (classBitfield & 32) == 32,
        Zodiac = (classBitfield & 64) == 64,
        Wildling = (classBitfield & 128) == 128,
        Arbalist = (classBitfield & 256) == 256,
        Farmer = (classBitfield & 1024) == 1024,
        Shogun = (classBitfield & 2048) == 2048,
        Yggdroid = (classBitfield & 4096) == 4096,
      };
      int flagsBitfiled = input.ReadUInt16();
      Flags = new EquipmentFlags()
      {
        CanSellOut = (flagsBitfiled & 0x1) == 0x1,
        Rare = (flagsBitfiled & 0x20) == 0x20,
        Starter = (flagsBitfiled & 0x80) == 0x80
      };
      ForgeSlots = input.ReadByte();
      Forges = new List<ForgeTypes>();
      for (int forgeIndex = 0; forgeIndex < MaximumAmountOfForges; forgeIndex += 1)
      {
        Forges.Add((ForgeTypes)input.ReadByte());
      }
      Price = input.ReadInt32();
      input.ReadInt32(); // "Sell price." Dummy column in EO3.
    }

    public override string ToString()
    {
      return Name;
    }
  }
}
