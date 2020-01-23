using EO3EquipmentEdit.Data;
using EO3EquipmentEdit.TextPreview;
using OriginTablets.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace EO3EquipmentEdit
{
  public partial class MainForm : Form
  {
    /// <summary>
    /// The list of equipment items from the loaded table.
    /// </summary>
    readonly List<Equipment> EquipmentTable;

    /// <summary>
    /// The Table containing equipment names.
    /// </summary>
    readonly Table EquipmentNames;

    /// <summary>
    /// The MBM containing equipment descriptions.
    /// </summary>
    readonly MBM EquipmentDescriptions;

    /// <summary>
    /// What equipment type the filter is currently set to.
    /// Note: this will return Dummy if All is selected.
    /// </summary>
    Equipment.EquipmentTypes FilteredEquipmentType => (Equipment.EquipmentTypes)equipmentTypeFilter.SelectedIndex;

    Equipment.EquipmentTypes SelectedEquipmentType => (Equipment.EquipmentTypes)itemType.SelectedIndex;

    /// <summary>
    /// Syntactic sugar for the currently-selected equipment.
    /// </summary>
    Equipment SelectedEquipment => equipmentList.SelectedItem as Equipment;

    // The fonts.
    readonly EO3Font Font8px;
    readonly EO3Font Font10px;
    readonly EO3Font Font12px;

    // Controls that we can't create in Designer go here.
    // Use camelCase for these, as is standard with Designer controls.
#pragma warning disable IDE0069 // Disposable fields should be disposed
    readonly ItemNamePreview namePreview;
#pragma warning restore IDE0069 // Disposable fields should be disposed

    /// <summary>
    /// Don't use this.
    /// </summary>
    public MainForm()
    {
      InitializeComponent();
    }

    /// <summary>
    /// The real constructor for MainForm.
    /// </summary>
    /// <param name="equipment">The list of equipment items for the loaded table.</param>
    /// <param name="equipmentNames">The Table for equipment names.</param>
    /// <param name="equipmentDescriptions">The MBM for equipment descriptions.</param>
    public MainForm(List<Equipment> equipment, Table equipmentNames, MBM equipmentDescriptions)
    {
      // Data preparation.
      EquipmentTable = equipment;
      EquipmentNames = equipmentNames;
      EquipmentDescriptions = equipmentDescriptions;
      CheckDataLengths();

      // Form preparation.
      InitializeComponent();
      // Assign event handlers to various form element events.
      SetIncludeDummyCheckboxEventHandlers();
      SetEquipmentTypeFilterEventHandlers();
      SetEquipmentListEventHandlers();
      SetItemNameEntryEventHandlers();
      SetItemTypeDropdownEventHandlers();
      SetATKDEFEntryEventHandlers();
      SetStatBonusEventHandlers();
      SetPriceEntryEventHandlers();
      SetCanEquipEventHandlers();
      SetAccuracyEventHandlers();
      // Load the fonts.
      Font8px = Newtonsoft.Json.JsonConvert.DeserializeObject(
        string.Join("", File.ReadAllLines("Resources/Font/Font8x8.eo3font.json")),
        typeof(EO3Font))
        as EO3Font;
      Font8px.TexturePath = "Resources/Font/Font8x8.eo3font.png";
      Font10px = Newtonsoft.Json.JsonConvert.DeserializeObject(
        string.Join("", File.ReadAllLines("Resources/Font/Font10x10.eo3font.json")),
        typeof(EO3Font))
        as EO3Font;
      Font10px.TexturePath = "Resources/Font/Font10x10.eo3font.png";
      Font12px = Newtonsoft.Json.JsonConvert.DeserializeObject(
        string.Join("", File.ReadAllLines("Resources/Font/Font12x12.eo3font.json")),
        typeof(EO3Font))
        as EO3Font;
      Font12px.TexturePath = "Resources/Font/Font12x12.eo3font.png";
      // Create the item name preview. This is done here instead of in Designer because
      // we need to pass the preview the font it needs at construction time. Safety and all that.
      namePreview = new ItemNamePreview(Font10px);
      // Centers the preview in the panel.
      int previewX = (namePreviewPanel.Width / 2) - (namePreview.Width / 2);
      int previewY = (namePreviewPanel.Height / 2) - (namePreview.Height / 2);
      namePreview.Location = new Point(previewX, previewY);
      namePreviewPanel.Controls.Add(namePreview);
      // Further form preparation.
      AddEquipmentTypesToFilter();
      AddEquipmentTypesToTypeDropdown();
      PopulateEquipmentList(null, null);
    }

    /// <summary>
    /// Registers all of the event handlers for the equipment list.
    /// </summary>
    private void SetEquipmentListEventHandlers()
    {
      equipmentList.SelectedIndexChanged += SetNameControlsOnEquipmentChanged;
      equipmentList.SelectedIndexChanged += UpdateItemTypeDropdownOnEquipmentChanged;
      equipmentList.SelectedIndexChanged += SetATKDEFLabelsBasedOnIfEquipmentIsAWeapon;
      equipmentList.SelectedIndexChanged += SetATKDEFValuesOnEquipmentChanged;
      equipmentList.SelectedIndexChanged += UpdateStatBonusValuesOnEquipmentChanged;
      equipmentList.SelectedIndexChanged += UpdatePriceOnEquipmentChanged;
      equipmentList.SelectedIndexChanged += UpdatePrincessCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged += UpdateGladiatorCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged += UpdateHopliteCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged += UpdateBuccaneerCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged += UpdateNinjaCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged += UpdateMonkCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged += UpdateZodiacCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged += UpdateWildlingCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged += UpdateArbalistCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged += UpdateFarmerCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged += UpdateShogunCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged += UpdateYggdroidCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged += UpdateConsumesMaterialsOnEquipmentChanged;
      equipmentList.SelectedIndexChanged += UpdateGoldIconOnEquipmentChanged;
      equipmentList.SelectedIndexChanged += UpdateStarterEquipmentOnEquipmentChanged;
      equipmentList.SelectedIndexChanged += UpdateAccuracyEntryOnEquipmentChanged;
    }

    /// <summary>
    /// Removes all of the event handlers for the equipment list.
    /// </summary>
    private void RemoveEquipmentListEventHandlers()
    {
      equipmentList.SelectedIndexChanged -= SetNameControlsOnEquipmentChanged;
      equipmentList.SelectedIndexChanged -= UpdateItemTypeDropdownOnEquipmentChanged;
      equipmentList.SelectedIndexChanged -= SetATKDEFLabelsBasedOnIfEquipmentIsAWeapon;
      equipmentList.SelectedIndexChanged -= SetATKDEFValuesOnEquipmentChanged;
      equipmentList.SelectedIndexChanged -= UpdateStatBonusValuesOnEquipmentChanged;
      equipmentList.SelectedIndexChanged -= UpdatePriceOnEquipmentChanged;
      equipmentList.SelectedIndexChanged -= UpdatePrincessCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged -= UpdateGladiatorCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged -= UpdateHopliteCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged -= UpdateBuccaneerCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged -= UpdateNinjaCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged -= UpdateMonkCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged -= UpdateZodiacCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged -= UpdateWildlingCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged -= UpdateArbalistCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged -= UpdateFarmerCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged -= UpdateShogunCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged -= UpdateYggdroidCanEquipOnEquipmentChanged;
      equipmentList.SelectedIndexChanged -= UpdateConsumesMaterialsOnEquipmentChanged;
      equipmentList.SelectedIndexChanged -= UpdateGoldIconOnEquipmentChanged;
      equipmentList.SelectedIndexChanged -= UpdateStarterEquipmentOnEquipmentChanged;
      equipmentList.SelectedIndexChanged -= UpdateAccuracyEntryOnEquipmentChanged;
    }

    /// <summary>
    /// Registers all of the event handlers for the ATK/DEF entries.
    /// </summary>
    private void SetATKDEFEntryEventHandlers()
    {
      physicalEntry.ValueChanged += UpdateEquipmentATKDEFValues;
      magicEntry.ValueChanged += UpdateEquipmentATKDEFValues;
    }

    /// <summary>
    /// Removes all of the event handlers for the ATK/DEF entries.
    /// </summary>
    private void RemoveATKDEFEntryEventHandlers()
    {
      physicalEntry.ValueChanged -= UpdateEquipmentATKDEFValues;
      magicEntry.ValueChanged -= UpdateEquipmentATKDEFValues;
    }

    /// <summary>
    /// Registers all of the event handlers for the "include dummy" checkbox.
    /// </summary>
    private void SetIncludeDummyCheckboxEventHandlers()
    {
      includeDummyItems.CheckedChanged += PopulateEquipmentList;
    }

    /// <summary>
    /// Removes all of the event handlers for the "include dummy" checkbox.
    /// </summary>
    private void RemoveIncludeDummyCheckboxEventHandlers()
    {
      includeDummyItems.CheckedChanged -= PopulateEquipmentList;
    }

    /// <summary>
    /// Registers all of the event handlers for the equipment type filter.
    /// </summary>
    private void SetEquipmentTypeFilterEventHandlers()
    {
      equipmentTypeFilter.SelectedIndexChanged += PopulateEquipmentList;
    }

    /// <summary>
    /// Removes all of the event handlers for the equipment type filter.
    /// </summary>
    private void RemoveEquipmentTypeFilterEventHandlers()
    {
      equipmentTypeFilter.SelectedIndexChanged -= PopulateEquipmentList;
    }

    /// <summary>
    /// Registers all of the event handlers for the item name entry;
    /// </summary>
    private void SetItemNameEntryEventHandlers()
    {
      itemName.TextChanged += UpdateItemNameAndPreviewOnEquipmentNameChanged;
    }

    /// <summary>
    /// Removes all of the event handlers for the item name entry;
    /// </summary>
    private void RemoveItemNameEntryEventHandlers()
    {
      itemName.TextChanged -= UpdateItemNameAndPreviewOnEquipmentNameChanged;
    }

    /// <summary>
    /// Registers all of the event handlers for the item type dropdown.
    /// </summary>
    private void SetItemTypeDropdownEventHandlers()
    {
      itemType.SelectedIndexChanged += UpdateItemTypeOnDropdownChanged;
    }

    /// <summary>
    /// Removes all of the event handlers for the item type dropdown.
    /// </summary>
    private void RemoveItemTypeDropdownEventHandlers()
    {
      itemType.SelectedIndexChanged -= UpdateItemTypeOnDropdownChanged;
    }

    /// <summary>
    /// Registers all of the event handlers for the stat bonus entries.
    /// </summary>
    private void SetStatBonusEventHandlers()
    {
      HPEntry.ValueChanged += UpdateEquipmentHPBonusOnEntryChanged;
      TPEntry.ValueChanged += UpdateEquipmentTPBonusOnEntryChanged;
      STREntry.ValueChanged += UpdateEquipmentSTRBonusOnEntryChanged;
      TECEntry.ValueChanged += UpdateEquipmentTECBonusOnEntryChanged;
      VITEntry.ValueChanged += UpdateEquipmentVITBonusOnEntryChanged;
      WISEntry.ValueChanged += UpdateEquipmentAGIBonusOnEntryChanged;
      AGIEntry.ValueChanged += UpdateEquipmentAGIBonusOnEntryChanged;
      LUCEntry.ValueChanged += UpdateEquipmentLUCBonusOnEntryChanged;
    }

    /// <summary>
    /// Removes all of the event handlers for the stat bonus entries.
    /// </summary>
    private void RemoveStatBonusEventHandlers()
    {
      HPEntry.ValueChanged -= UpdateEquipmentHPBonusOnEntryChanged;
      TPEntry.ValueChanged -= UpdateEquipmentTPBonusOnEntryChanged;
      STREntry.ValueChanged -= UpdateEquipmentSTRBonusOnEntryChanged;
      TECEntry.ValueChanged -= UpdateEquipmentTECBonusOnEntryChanged;
      VITEntry.ValueChanged -= UpdateEquipmentVITBonusOnEntryChanged;
      WISEntry.ValueChanged -= UpdateEquipmentAGIBonusOnEntryChanged;
      AGIEntry.ValueChanged -= UpdateEquipmentAGIBonusOnEntryChanged;
      LUCEntry.ValueChanged -= UpdateEquipmentLUCBonusOnEntryChanged;
    }

    /// <summary>
    /// Registers all of the event handlers for the price entry.
    /// </summary>
    private void SetPriceEntryEventHandlers()
    {
      priceEntry.ValueChanged += SetPriceOnPriceEntryValueChanged;
    }

    /// <summary>
    /// Removes all of the event handlers for the price entry.
    /// </summary>
    private void RemovePriceEntryEventHandlers()
    {
      priceEntry.ValueChanged -= SetPriceOnPriceEntryValueChanged;
    }

    /// <summary>
    /// Sets all of the event handlers for the various can equip checkboxes.
    /// </summary>
    private void SetCanEquipEventHandlers()
    {
      princess.CheckedChanged += UpdateEquipmentCanEquipWhenPrincessCheckedChange;
      gladiator.CheckedChanged += UpdateEquipmentCanEquipWhenGladiatorCheckedChange;
      hoplite.CheckedChanged += UpdateEquipmentCanEquipWhenHopliteCheckedChange;
      buccaneer.CheckedChanged += UpdateEquipmentCanEquipWhenBuccaneerCheckedChange;
      ninja.CheckedChanged += UpdateEquipmentCanEquipWhenNinjaCheckedChange;
      monk.CheckedChanged += UpdateEquipmentCanEquipWhenMonkCheckedChange;
      zodiac.CheckedChanged += UpdateEquipmentCanEquipWhenZodiacCheckedChange;
      wildling.CheckedChanged += UpdateEquipmentCanEquipWhenWildlingCheckedChange;
      arbalist.CheckedChanged += UpdateEquipmentCanEquipWhenArbalistCheckedChange;
      farmer.CheckedChanged += UpdateEquipmentCanEquipWhenFarmerCheckedChange;
      shogun.CheckedChanged += UpdateEquipmentCanEquipWhenShogunCheckedChange;
      yggdroid.CheckedChanged += UpdateEquipmentCanEquipWhenYggdroidCheckedChange;
    }

    /// <summary>
    /// Removes all of the event handlers for the various can equip checkboxes.
    /// </summary>
    private void RemoveCanEquipEventHandlers()
    {
      princess.CheckedChanged -= UpdateEquipmentCanEquipWhenPrincessCheckedChange;
      gladiator.CheckedChanged -= UpdateEquipmentCanEquipWhenGladiatorCheckedChange;
      hoplite.CheckedChanged -= UpdateEquipmentCanEquipWhenHopliteCheckedChange;
      buccaneer.CheckedChanged -= UpdateEquipmentCanEquipWhenBuccaneerCheckedChange;
      ninja.CheckedChanged -= UpdateEquipmentCanEquipWhenNinjaCheckedChange;
      monk.CheckedChanged -= UpdateEquipmentCanEquipWhenMonkCheckedChange;
      zodiac.CheckedChanged -= UpdateEquipmentCanEquipWhenZodiacCheckedChange;
      wildling.CheckedChanged -= UpdateEquipmentCanEquipWhenWildlingCheckedChange;
      arbalist.CheckedChanged -= UpdateEquipmentCanEquipWhenArbalistCheckedChange;
      farmer.CheckedChanged -= UpdateEquipmentCanEquipWhenFarmerCheckedChange;
      shogun.CheckedChanged -= UpdateEquipmentCanEquipWhenShogunCheckedChange;
      yggdroid.CheckedChanged -= UpdateEquipmentCanEquipWhenYggdroidCheckedChange;
    }

    /// <summary>
    /// Sets all of the event handlers for the various flag checkboxes.
    /// </summary>
    private void SetFlagsEventHandlers()
    {
      consumesMaterials.CheckedChanged += UpdateEquipmentConsumesMaterialsOnCheckedChanged;
      goldIcon.CheckedChanged += UpdateEquipmentGoldIconOnCheckedChanged;
      starterEquipment.CheckedChanged += UpdateEquipmentStarterOnCheckedChanged;
    }

    /// <summary>
    /// Removes all of the event handlers for the various flag checkboxes.
    /// </summary>
    private void RemoveFlagsEventHandlers()
    {
      consumesMaterials.CheckedChanged -= UpdateEquipmentConsumesMaterialsOnCheckedChanged;
      goldIcon.CheckedChanged -= UpdateEquipmentGoldIconOnCheckedChanged;
      starterEquipment.CheckedChanged -= UpdateEquipmentStarterOnCheckedChanged;
    }

    /// <summary>
    /// Registers the event handlers for accuracy stuff.
    /// </summary>
    private void SetAccuracyEventHandlers()
    {
      accuracyEntry.ValueChanged += UpdateEquipmentAccuracyOnEntryChanged;
    }

    /// <summary>
    /// Removes the event handlers for accuracy stuff.
    /// </summary>
    private void RemoveAccuracyEventHandlers()
    {
      accuracyEntry.ValueChanged -= UpdateEquipmentAccuracyOnEntryChanged;
    }

    /// <summary>
    /// This function ensures that, if the equipment name table and/or description file are shorter than
    /// the actual equipment table, they have dummy entries added to them, to remove the need to check for
    /// that later in the program.
    /// </summary>
    private void CheckDataLengths()
    {
      // Name table checking.
      if (EquipmentNames.Count < EquipmentTable.Count)
      {
        for (int dummyEntryIndex = EquipmentNames.Count; dummyEntryIndex < EquipmentTable.Count; dummyEntryIndex += 1)
        {
          EquipmentNames.Add("ダミー");
        }
      }
      // Description file checking.
      if (EquipmentDescriptions.Count < EquipmentTable.Count)
      {
        for (int dummyEntryIndex = EquipmentDescriptions.Count; dummyEntryIndex < EquipmentTable.Count; dummyEntryIndex += 1)
        {
          EquipmentDescriptions.Add("ダミー[80 01]");
        }
      }
    }

    /// <summary>
    /// Adds all of the equipment types to the filter dropdown, plus an "All" type.
    /// </summary>
    private void AddEquipmentTypesToFilter()
    {
      RemoveEquipmentTypeFilterEventHandlers();
      equipmentTypeFilter.Items.Add("All equipment");
      foreach (string singularName in Equipment.EquipmentNamesPlural.Values.Skip(1))
      {
        equipmentTypeFilter.Items.Add(singularName);
      }
      equipmentTypeFilter.SelectedIndex = 0;
      SetEquipmentTypeFilterEventHandlers();
    }

    /// <summary>
    /// Adds all of the equipment types to the type dropdown.
    /// </summary>
    private void AddEquipmentTypesToTypeDropdown()
    {
      foreach (string singularName in Equipment.EquipmentNamesSingular.Values)
      {
        itemType.Items.Add(singularName);
      }
      itemType.SelectedIndex = 0;
    }

    /// <summary>
    /// Populate the equipment list, based on the filter and state of the dummy checkbox.
    /// </summary>
    private void PopulateEquipmentList(object sender, EventArgs eventArgs)
    {
      // Cloth armor filtering is intensely annoying to handle due to the fact that Summer Tweed and
      // Bikini Armor come way before any other equipment in the list. Rather than add a lot of hard-coded
      // exceptions for that one type, just disable dummy item filtering for cloth armor for now.
      // Maybe a new solution can be figured out at some point in the future.
      if (FilteredEquipmentType == Equipment.EquipmentTypes.ClothArmor)
      {
        includeDummyItems.Checked = false;
        includeDummyItems.Enabled = false;
      }
      else
      {
        includeDummyItems.Enabled = true;
      }
      // qualifyingEquipment will, at the end of this, be populated only by
      // equipment that fits the filtered equipment type. We clone EquipmentTable
      // here, since we perform operations such as clearing out here.
      var qualifyingEquipment = new List<Equipment>(EquipmentTable);
      // If the filter's index is not Dummy (read: All), then we need to filter to only one equipment type.
      // Don't run this on the Fist type, since no items with that type exist at the moment.
      if (FilteredEquipmentType != Equipment.EquipmentTypes.Dummy
        && FilteredEquipmentType != Equipment.EquipmentTypes.Fist)
      {
        // If "include dummies" is checked, then we need to also check for the dummy type.
        // It's also prudent to find the first item that isn't of the dummy type or the
        // selected time, and trim the list to all items before that.
        if (includeDummyItems.Checked == true)
        {
          int indexOfFirstSelectedItemType = qualifyingEquipment.IndexOf(
            qualifyingEquipment.First(item => item.Type == FilteredEquipmentType));
          // Since accessories are at the very end of the list, and no item type comes after them,
          // just set this index to the end of the list, if we're filtering to accessories.
          int indexOfFirstNonDummyAndNonSelectedItemType = 0;
          if (FilteredEquipmentType == Equipment.EquipmentTypes.Accessory)
          {
            indexOfFirstNonDummyAndNonSelectedItemType = qualifyingEquipment.Count - 1;
          }
          else
          {
            indexOfFirstNonDummyAndNonSelectedItemType = qualifyingEquipment.IndexOf(
              qualifyingEquipment
                .Skip(indexOfFirstSelectedItemType)
                .First(item =>
                  (item.Type != FilteredEquipmentType)
                  && item.Type != Equipment.EquipmentTypes.Dummy));
          }
          int numberOfItemsToTake = indexOfFirstNonDummyAndNonSelectedItemType - indexOfFirstSelectedItemType;
          qualifyingEquipment = qualifyingEquipment
            .Skip(indexOfFirstSelectedItemType)
            .Take(numberOfItemsToTake)
            .Where(item => (item.Type == FilteredEquipmentType)
              || (item.Type == Equipment.EquipmentTypes.Dummy))
            .ToList();
        }
        // The equivalent logic for when "include dummies" isn't checked is much simpler.
        else
        {
          qualifyingEquipment = qualifyingEquipment
            .Where(item => item.Type == FilteredEquipmentType)
            .ToList();
        }
      }
      // If we were asked to filter to the Fist type, then just empty everything out.
      // This can be changed if Fist is changed to a proper weapon type.
      else if (FilteredEquipmentType == Equipment.EquipmentTypes.Fist)
      {
        qualifyingEquipment.Clear();
      }
      // If the "include dummy" checkbox is not checked, we need to filter out weapons
      // whose name is any of the known dummy names.
      var knownDummyNames = new string[] { "NONE", "Dummy", "ダミー" };
      if (includeDummyItems.Checked == false)
      {
        qualifyingEquipment = qualifyingEquipment
          .Where(item => knownDummyNames.Contains(item.Name) == false)
          .ToList();
      }
      // Once we've done our filtering, clear out the equipment list, and populate it
      // with the list we've filtered down to.
      equipmentList.Items.Clear();
      equipmentList.Items.AddRange(qualifyingEquipment.ToArray());
      equipmentList.SelectedIndex = 0;
    }

    /// <summary>
    /// Refreshes the equipment list's contents, and resets its index back to what it was before refreshing.
    /// </summary>
    private void RefreshEquipmentList()
    {
      // Make sure we don't trip event handlers when refreshing.
      RemoveEquipmentListEventHandlers();
      int indexBeforeRefresh = equipmentList.SelectedIndex;
      PopulateEquipmentList(null, null);
      equipmentList.SelectedIndex = indexBeforeRefresh;
      // We need to re-enable event handlers before returning from this.
      SetEquipmentListEventHandlers();
    }

    /// <summary>
    /// Sets the name entry box, as well as the item name preview, when the selected item is changed.
    /// </summary>
    private void SetNameControlsOnEquipmentChanged(object sender, EventArgs eventArgs)
    {
      if (equipmentList.SelectedItem != null)
      {
        // Disable handlers for itemName's text being changed, so we don't trip it.
        itemName.TextChanged -= UpdateItemNameAndPreviewOnEquipmentNameChanged;
        string equipmentName = SelectedEquipment.Name;
        itemName.Text = equipmentName;
        namePreview.Text = equipmentName;
        // Re-enable handlers we disabled above.
        itemName.TextChanged += UpdateItemNameAndPreviewOnEquipmentNameChanged;
      }
    }

    /// <summary>
    /// Updates both the item's internal name and its game text preview when its name is changed in the text box.
    /// </summary>
    private void UpdateItemNameAndPreviewOnEquipmentNameChanged(object sender, EventArgs eventArgs)
    {
      string newName = itemName.Text;
      SelectedEquipment.Name = newName;
      namePreview.Text = newName;
      RefreshEquipmentList();
    }

    /// <summary>
    /// Sets the item type dropdown to the appropriate entry when equipment is changed.
    /// </summary>
    private void UpdateItemTypeDropdownOnEquipmentChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        RemoveEquipmentTypeFilterEventHandlers();
        itemType.SelectedIndex = (int)SelectedEquipment.Type;
        SetEquipmentTypeFilterEventHandlers();
      }
    }

    /// <summary>
    /// Sets the selected item's type when the type dropdown is changed.
    /// </summary>
    private void UpdateItemTypeOnDropdownChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        RemoveItemTypeDropdownEventHandlers();
        SelectedEquipment.Type = SelectedEquipmentType;
        SetItemTypeDropdownEventHandlers();
      }
    }
    
    /// <summary>
    /// Sets the basic value labels to PATK/MATK or PDEF/MDEF based on if the selected equipment is a weapon or not.
    /// </summary>
    private void SetATKDEFLabelsBasedOnIfEquipmentIsAWeapon(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        if (SelectedEquipment.IsWeapon == true)
        {
          physicalLabel.Text = "PATK";
          magicLabel.Text = "MATK";
        }
        else
        {
          physicalLabel.Text = "PDEF";
          magicLabel.Text = "MDEF";
        }
      }
    }

    /// <summary>
    /// Sets the values of the ATK/DEF entries based on the new selected equipment.
    /// </summary>
    private void SetATKDEFValuesOnEquipmentChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        RemoveATKDEFEntryEventHandlers();
        if (SelectedEquipment.IsWeapon == true)
        {
          physicalEntry.Value = SelectedEquipment.ATK;
          magicEntry.Value = SelectedEquipment.MAT;
        }
        else
        {
          physicalEntry.Value = SelectedEquipment.DEF;
          magicEntry.Value = SelectedEquipment.MDF;
        }
        SetATKDEFEntryEventHandlers();
      }
    }

    /// <summary>
    /// Updates the current item's ATK/DEF when their respective entries are changed.
    /// </summary>
    private void UpdateEquipmentATKDEFValues(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        if (SelectedEquipment.IsWeapon == true)
        {
          SelectedEquipment.ATK = (int)physicalEntry.Value;
          SelectedEquipment.MAT = (int)magicEntry.Value;
        }
        else
        {
          SelectedEquipment.DEF = (int)physicalEntry.Value;
          SelectedEquipment.MDF = (int)magicEntry.Value;
        }
      }
    }

    /// <summary>
    /// Sets the stat bonus entries' values when the equipment is changed.
    /// </summary>
    private void UpdateStatBonusValuesOnEquipmentChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        RemoveStatBonusEventHandlers();
        HPEntry.Value = SelectedEquipment.StatBonuses.HP;
        TPEntry.Value = SelectedEquipment.StatBonuses.TP;
        STREntry.Value = SelectedEquipment.StatBonuses.STR;
        TECEntry.Value = SelectedEquipment.StatBonuses.TEC;
        VITEntry.Value = SelectedEquipment.StatBonuses.VIT;
        WISEntry.Value = SelectedEquipment.StatBonuses.WIS;
        AGIEntry.Value = SelectedEquipment.StatBonuses.AGI;
        LUCEntry.Value = SelectedEquipment.StatBonuses.LUC;
        SetStatBonusEventHandlers();
      }
    }

    /// <summary>
    /// Updates the selected equpiment's HP bonus when that entry is changed.
    /// </summary>
    private void UpdateEquipmentHPBonusOnEntryChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.StatBonuses.HP = (int)HPEntry.Value;
      }
    }

    /// <summary>
    /// Updates the selected equpiment's TP bonus when that entry is changed.
    /// </summary>
    private void UpdateEquipmentTPBonusOnEntryChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.StatBonuses.TP = (int)TPEntry.Value;
      }
    }

    /// <summary>
    /// Updates the selected equpiment's STR bonus when that entry is changed.
    /// </summary>
    private void UpdateEquipmentSTRBonusOnEntryChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.StatBonuses.STR = (int)STREntry.Value;
      }
    }

    /// <summary>
    /// Updates the selected equpiment's TEC bonus when that entry is changed.
    /// </summary>
    private void UpdateEquipmentTECBonusOnEntryChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.StatBonuses.TEC = (int)TECEntry.Value;
      }
    }

    /// <summary>
    /// Updates the selected equpiment's VIT bonus when that entry is changed.
    /// </summary>
    private void UpdateEquipmentVITBonusOnEntryChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.StatBonuses.VIT = (int)VITEntry.Value;
      }
    }

    /// <summary>
    /// Updates the selected equpiment's WIS bonus when that entry is changed.
    /// </summary>
    private void UpdateEquipmentWISBonusOnEntryChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.StatBonuses.WIS = (int)WISEntry.Value;
      }
    }

    /// <summary>
    /// Updates the selected equpiment's AGI bonus when that entry is changed.
    /// </summary>
    private void UpdateEquipmentAGIBonusOnEntryChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.StatBonuses.AGI = (int)AGIEntry.Value;
      }
    }

    /// <summary>
    /// Updates the selected equpiment's LUC bonus when that entry is changed.
    /// </summary>
    private void UpdateEquipmentLUCBonusOnEntryChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.StatBonuses.LUC = (int)LUCEntry.Value;
      }
    }

    /// <summary>
    /// Updates the price entry's value when the equipment is changed.
    /// </summary>
    private void UpdatePriceOnEquipmentChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        RemovePriceEntryEventHandlers();
        priceEntry.Value = SelectedEquipment.Price;
        SetPriceEntryEventHandlers();
      }
    }

    /// <summary>
    /// Sets the currently selected item's price when the price entry's value is changed.
    /// </summary>
    private void SetPriceOnPriceEntryValueChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.Price = (int)priceEntry.Value;
      }
    }

    /// <summary>
    /// Updates the Princess can equip checkbox when the selected equipment is changed.
    /// </summary>
    private void UpdatePrincessCanEquipOnEquipmentChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        RemoveCanEquipEventHandlers();
        princess.Checked = SelectedEquipment.ClassesThatCanEquip.Princess;
        SetCanEquipEventHandlers();
      }
    }

    /// <summary>
    /// Updates the Gladiator can equip checkbox when the selected equipment is changed.
    /// </summary>
    private void UpdateGladiatorCanEquipOnEquipmentChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        RemoveCanEquipEventHandlers();
        gladiator.Checked = SelectedEquipment.ClassesThatCanEquip.Gladiator;
        SetCanEquipEventHandlers();
      }
    }

    /// <summary>
    /// Updates the Hoplite can equip checkbox when the selected equipment is changed.
    /// </summary>
    private void UpdateHopliteCanEquipOnEquipmentChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        RemoveCanEquipEventHandlers();
        hoplite.Checked = SelectedEquipment.ClassesThatCanEquip.Hoplite;
        SetCanEquipEventHandlers();
      }
    }

    /// <summary>
    /// Updates the Buccaneer can equip checkbox when the selected equipment is changed.
    /// </summary>
    private void UpdateBuccaneerCanEquipOnEquipmentChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        RemoveCanEquipEventHandlers();
        buccaneer.Checked = SelectedEquipment.ClassesThatCanEquip.Buccaneer;
        SetCanEquipEventHandlers();
      }
    }

    /// <summary>
    /// Updates the Ninja can equip checkbox when the selected equipment is changed.
    /// </summary>
    private void UpdateNinjaCanEquipOnEquipmentChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        RemoveCanEquipEventHandlers();
        ninja.Checked = SelectedEquipment.ClassesThatCanEquip.Ninja;
        SetCanEquipEventHandlers();
      }
    }

    /// <summary>
    /// Updates the Monk can equip checkbox when the selected equipment is changed.
    /// </summary>
    private void UpdateMonkCanEquipOnEquipmentChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        RemoveCanEquipEventHandlers();
        monk.Checked = SelectedEquipment.ClassesThatCanEquip.Monk;
        SetCanEquipEventHandlers();
      }
    }

    /// <summary>
    /// Updates the Zodiac can equip checkbox when the selected equipment is changed.
    /// </summary>
    private void UpdateZodiacCanEquipOnEquipmentChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        RemoveCanEquipEventHandlers();
        zodiac.Checked = SelectedEquipment.ClassesThatCanEquip.Zodiac;
        SetCanEquipEventHandlers();
      }
    }

    /// <summary>
    /// Updates the Wildling can equip checkbox when the selected equipment is changed.
    /// </summary>
    private void UpdateWildlingCanEquipOnEquipmentChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        RemoveCanEquipEventHandlers();
        wildling.Checked = SelectedEquipment.ClassesThatCanEquip.Wildling;
        SetCanEquipEventHandlers();
      }
    }

    /// <summary>
    /// Updates the Arbalist can equip checkbox when the selected equipment is changed.
    /// </summary>
    private void UpdateArbalistCanEquipOnEquipmentChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        RemoveCanEquipEventHandlers();
        arbalist.Checked = SelectedEquipment.ClassesThatCanEquip.Arbalist;
        SetCanEquipEventHandlers();
      }
    }

    /// <summary>
    /// Updates the Farmer can equip checkbox when the selected equipment is changed.
    /// </summary>
    private void UpdateFarmerCanEquipOnEquipmentChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        RemoveCanEquipEventHandlers();
        farmer.Checked = SelectedEquipment.ClassesThatCanEquip.Farmer;
        SetCanEquipEventHandlers();
      }
    }

    /// <summary>
    /// Updates the Shogun can equip checkbox when the selected equipment is changed.
    /// </summary>
    private void UpdateShogunCanEquipOnEquipmentChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        RemoveCanEquipEventHandlers();
        shogun.Checked = SelectedEquipment.ClassesThatCanEquip.Shogun;
        SetCanEquipEventHandlers();
      }
    }

    /// <summary>
    /// Updates the Yggdroid can equip checkbox when the selected equipment is changed.
    /// </summary>
    private void UpdateYggdroidCanEquipOnEquipmentChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        RemoveCanEquipEventHandlers();
        yggdroid.Checked = SelectedEquipment.ClassesThatCanEquip.Yggdroid;
        SetCanEquipEventHandlers();
      }
    }

    /// <summary>
    /// Updates whether or not Princesses can equip the current selected item, based on the status of its checkbox.
    /// </summary>
    private void UpdateEquipmentCanEquipWhenPrincessCheckedChange(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.ClassesThatCanEquip.Princess = princess.Checked;
      }
    }

    /// <summary>
    /// Updates whether or not Gladiators can equip the current selected item, based on the status of its checkbox.
    /// </summary>
    private void UpdateEquipmentCanEquipWhenGladiatorCheckedChange(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.ClassesThatCanEquip.Gladiator = gladiator.Checked;
      }
    }

    /// <summary>
    /// Updates whether or not Hoplites can equip the current selected item, based on the status of its checkbox.
    /// </summary>
    private void UpdateEquipmentCanEquipWhenHopliteCheckedChange(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.ClassesThatCanEquip.Hoplite = hoplite.Checked;
      }
    }

    /// <summary>
    /// Updates whether or not Buccaneers can equip the current selected item, based on the status of its checkbox.
    /// </summary>
    private void UpdateEquipmentCanEquipWhenBuccaneerCheckedChange(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.ClassesThatCanEquip.Buccaneer = buccaneer.Checked;
      }
    }

    /// <summary>
    /// Updates whether or not Ninjas can equip the current selected item, based on the status of its checkbox.
    /// </summary>
    private void UpdateEquipmentCanEquipWhenNinjaCheckedChange(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.ClassesThatCanEquip.Ninja = ninja.Checked;
      }
    }

    /// <summary>
    /// Updates whether or not Monks can equip the current selected item, based on the status of its checkbox.
    /// </summary>
    private void UpdateEquipmentCanEquipWhenMonkCheckedChange(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.ClassesThatCanEquip.Monk = monk.Checked;
      }
    }

    /// <summary>
    /// Updates whether or not Zodiacs can equip the current selected item, based on the status of its checkbox.
    /// </summary>
    private void UpdateEquipmentCanEquipWhenZodiacCheckedChange(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.ClassesThatCanEquip.Zodiac = zodiac.Checked;
      }
    }

    /// <summary>
    /// Updates whether or not Wildlings can equip the current selected item, based on the status of its checkbox.
    /// </summary>
    private void UpdateEquipmentCanEquipWhenWildlingCheckedChange(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.ClassesThatCanEquip.Wildling = wildling.Checked;
      }
    }

    /// <summary>
    /// Updates whether or not Arbalists can equip the current selected item, based on the status of its checkbox.
    /// </summary>
    private void UpdateEquipmentCanEquipWhenArbalistCheckedChange(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.ClassesThatCanEquip.Arbalist = arbalist.Checked;
      }
    }

    /// <summary>
    /// Updates whether or not Farmers can equip the current selected item, based on the status of its checkbox.
    /// </summary>
    private void UpdateEquipmentCanEquipWhenFarmerCheckedChange(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.ClassesThatCanEquip.Farmer = farmer.Checked;
      }
    }

    /// <summary>
    /// Updates whether or not Shoguns can equip the current selected item, based on the status of its checkbox.
    /// </summary>
    private void UpdateEquipmentCanEquipWhenShogunCheckedChange(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.ClassesThatCanEquip.Shogun = shogun.Checked;
      }
    }

    /// <summary>
    /// Updates whether or not Yggdroids can equip the current selected item, based on the status of its checkbox.
    /// </summary>
    private void UpdateEquipmentCanEquipWhenYggdroidCheckedChange(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.ClassesThatCanEquip.Yggdroid = yggdroid.Checked;
      }
    }

    /// <summary>
    /// Updates the consumes materials checkbox based on the current equipment's flags.
    /// </summary>
    private void UpdateConsumesMaterialsOnEquipmentChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        RemoveFlagsEventHandlers();
        consumesMaterials.Checked = SelectedEquipment.Flags.CanSellOut;
        SetFlagsEventHandlers();
      }
    }

    /// <summary>
    /// Updates the gold icon checkbox based on the current equipment's flags.
    /// </summary>
    private void UpdateGoldIconOnEquipmentChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        RemoveFlagsEventHandlers();
        goldIcon.Checked = SelectedEquipment.Flags.Rare;
        SetFlagsEventHandlers();
      }
    }

    /// <summary>
    /// Updates the starter equipment checkbox based on the current equipment's flags.
    /// </summary>
    private void UpdateStarterEquipmentOnEquipmentChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        RemoveFlagsEventHandlers();
        starterEquipment.Checked = SelectedEquipment.Flags.Starter;
        SetFlagsEventHandlers();
      }
    }

    /// <summary>
    /// Updates the selected equipment's consumes materials flag when the checkbox is changed.
    /// </summary>
    private void UpdateEquipmentConsumesMaterialsOnCheckedChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.Flags.CanSellOut = consumesMaterials.Checked;
      }
    }

    /// <summary>
    /// Updates the selected equipment's gold icon flag when the checkbox is changed.
    /// </summary>
    private void UpdateEquipmentGoldIconOnCheckedChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.Flags.Rare = goldIcon.Checked;
      }
    }

    /// <summary>
    /// Updates the selected equipment's starter equipment flag when the checkbox is changed.
    /// </summary>
    private void UpdateEquipmentStarterOnCheckedChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.Flags.Starter = starterEquipment.Checked;
      }
    }

    /// <summary>
    /// The event handler for the File -> Save menu item being clicked.
    /// </summary>
    private void FileSaveClicked(object sender, EventArgs eventArgs)
    {
      using (var openDialog = new CommonOpenFileDialog())
      {
        openDialog.IsFolderPicker = true;
        openDialog.AllowNonFileSystemItems = true;
        if (openDialog.ShowDialog() == CommonFileDialogResult.Ok)
        {
          DataIO.WriteEquipmentData(openDialog.FileName, EquipmentTable, EquipmentNames, EquipmentDescriptions);
        }
      }
    }

    /// <summary>
    /// Updates the accuracy entry's value to the selected equipment's accuracy.
    /// </summary>
    private void UpdateAccuracyEntryOnEquipmentChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        RemoveAccuracyEventHandlers();
        accuracyEntry.Value = SelectedEquipment.Accuracy;
        SetAccuracyEventHandlers();
      }
    }

    /// <summary>
    /// Updates the selected equipment's accuracy value when the entry is changed.
    /// </summary>
    private void UpdateEquipmentAccuracyOnEntryChanged(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        SelectedEquipment.Accuracy = (int)accuracyEntry.Value;
      }
    }
  }
}
