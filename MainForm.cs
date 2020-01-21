using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EO3EquipmentEdit.Data;
using OriginTablets.Types;
using EO3EquipmentEdit.TextPreview;
using System.IO;

namespace EO3EquipmentEdit
{
  public partial class MainForm : Form
  {
    /// <summary>
    /// The list of equipment items from the loaded table.
    /// </summary>
    readonly BindingList<Equipment> EquipmentTable;

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
      EquipmentTable = new BindingList<Equipment>(equipment);
      EquipmentNames = equipmentNames;
      EquipmentDescriptions = equipmentDescriptions;
      CheckDataLengths();

      // Form preparation.
      InitializeComponent();
      AddEquipmentTypesToFilter();
      AddEquipmentTypesToTypeDropdown();
      PopulateEquipmentList(null, null);

      // Assign event handlers to various form element events.
      // Both of these have that handler set, since changing the
      // filter's type nulls out the selected index on the list.
      includeDummyItems.CheckedChanged += PopulateEquipmentList;
      equipmentTypeFilter.SelectedIndexChanged += PopulateEquipmentList;
      SetEquipmentListEventHandlers();
      itemName.TextChanged += UpdateItemNameAndPreviewOnEquipmentNameChanged;
      SetATKDEFEntryEventHandlers();

      // Load the fonts.
      Font8px = Newtonsoft.Json.JsonConvert.DeserializeObject(
        string.Join("", System.IO.File.ReadAllLines("Resources/Font/Font8x8.eo3font.json")), 
        typeof(EO3Font)) 
        as EO3Font;
      Font8px.TexturePath = "Resources/Font/Font8x8.eo3font.png";
      Font10px = Newtonsoft.Json.JsonConvert.DeserializeObject(
        string.Join("", System.IO.File.ReadAllLines("Resources/Font/Font10x10.eo3font.json")),
        typeof(EO3Font))
        as EO3Font;
      Font10px.TexturePath = "Resources/Font/Font10x10.eo3font.png";
      Font12px = Newtonsoft.Json.JsonConvert.DeserializeObject(
        string.Join("", System.IO.File.ReadAllLines("Resources/Font/Font12x12.eo3font.json")),
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
    }

    /// <summary>
    /// Registers all of the event handlers for the equipment list.
    /// </summary>
    private void SetEquipmentListEventHandlers()
    {
      equipmentList.SelectedIndexChanged += EnableOrDisableElementsBasedOnEquipmentListStatus;
      equipmentList.SelectedIndexChanged += SetNameControlsOnEquipmentChanged;
      equipmentList.SelectedIndexChanged += UpdateItemTypeDropdownOnEquipmentChanged;
      equipmentList.SelectedIndexChanged += SetATKDEFLabelsBasedOnIfEquipmentIsAWeapon;
      equipmentList.SelectedIndexChanged += SetATKDEFValuesOnEquipmentChanged;
    }

    /// <summary>
    /// Removes all of the event handlers for the equipment list.
    /// </summary>
    private void RemoveEquipmentListEventHandlers()
    {
      equipmentList.SelectedIndexChanged -= EnableOrDisableElementsBasedOnEquipmentListStatus;
      equipmentList.SelectedIndexChanged -= SetNameControlsOnEquipmentChanged;
      equipmentList.SelectedIndexChanged -= UpdateItemTypeDropdownOnEquipmentChanged;
      equipmentList.SelectedIndexChanged -= SetATKDEFLabelsBasedOnIfEquipmentIsAWeapon;
      equipmentList.SelectedIndexChanged -= SetATKDEFValuesOnEquipmentChanged;
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
      equipmentTypeFilter.Items.Add("All equipment");
      foreach (string singularName in Equipment.EquipmentNamesPlural.Values)
      {
        equipmentTypeFilter.Items.Add(singularName);
      }
      equipmentTypeFilter.SelectedIndex = 0;
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
    /// Enables or disables various input elements based on if the equipment list is null or not.
    /// </summary>
    private void EnableOrDisableElementsBasedOnEquipmentListStatus(object sender, EventArgs eventArgs)
    {
      if (SelectedEquipment != null)
      {
        // Name box.
        itemName.Enabled = true;
        // Item type selector.
        itemType.Enabled = true;
      }
      else
      {
        // Name box.
        itemName.Text = string.Empty;
        itemName.Enabled = false;
        // Item type selector.
        itemType.Enabled = false;
      }
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
        // TODO: Remove event handlers tied to itemType before we do this.
        itemType.SelectedIndex = (int)SelectedEquipment.Type - 1;
        // TODO: Restore the event handlers we temporarily disabled.
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
        // TODO: Temporarily disable applicable handlers for the ATK/DEF entries, so we don't trip them here.
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
        // TODO: Re-enable the handlers we disabled above.
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
  }
}
