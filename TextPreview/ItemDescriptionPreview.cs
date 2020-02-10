using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EO3EquipmentEdit.Data;
using System.Text.RegularExpressions;

namespace EO3EquipmentEdit.TextPreview
{
  public partial class ItemDescriptionPreview : PictureBox
  {
    /// <summary>
    /// The font to use.
    /// </summary>
    readonly new EO3Font Font;

    private Equipment _Equipment;

    /// <summary>
    /// The currently selected equipment.
    /// </summary>
    public Equipment Equipment
    {
      get => _Equipment;
      set
      {
        _Equipment = value;
        if (Image != null) { Image.Dispose(); }
        Image = Font.GetString(DescriptionPreviewText);
      }
    }

    /// <summary>
    /// Gets a version of the equipment's description that replaces linebreak
    /// control codes with linebreaks, and strips all other control codes.
    /// </summary>
    private string DescriptionPreviewText => Regex.Replace(
        _Equipment.Description
        .Replace("[80 01]", "\n"),
      "\\[.. ..\\]",
      "");

    /// <summary>
    /// The color of the background.
    /// </summary>
    private SolidBrush BackgroundBrush = new SolidBrush(Color.White);

    /// <summary>
    /// Where to draw the background to.
    /// </summary>
    private Rectangle BackgroundArea = new Rectangle(0, 0, 234, 40);

    /// <summary>
    /// The color of the area of the text box that text should not go into, because that's where forges are.
    /// </summary>
    private SolidBrush RedZoneBrush = new SolidBrush(Color.Red);

    /// <summary>
    /// The area to draw the red zone over.
    /// </summary>
    private Rectangle RedZoneArea = new Rectangle(148, 26, 86, 14);

    /// <summary>
    /// Where to start drawing text at.
    /// </summary>
    private Point TextStartingPoint = new Point(8, 2);

    /// <summary>
    /// The only constructor you should use for ItemNamePreview.
    /// </summary>
    /// <param name="font">The 10px font we use for item name previews.</param>
    public ItemDescriptionPreview(EO3Font font)
    {
      Font = font;
      Size = new Size(BackgroundArea.Width, BackgroundArea.Height);
    }

    protected override void OnPaint(PaintEventArgs eventArgs)
    {
      eventArgs.Graphics.FillRectangle(BackgroundBrush, BackgroundArea);
      eventArgs.Graphics.FillRectangle(RedZoneBrush, RedZoneArea);
      if (Image != null) { eventArgs.Graphics.DrawImage(Image, TextStartingPoint); }
    }

    /// <summary>
    /// Refreshes the current description string.
    /// </summary>
    public void RefreshDescription(object sender, EventArgs eventArgs)
    {
      if (Image != null) { Image.Dispose(); }
      Image = Font.GetString(DescriptionPreviewText);
    }
  }
}
