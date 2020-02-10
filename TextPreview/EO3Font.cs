using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace EO3EquipmentEdit.TextPreview
{
  /// <summary>
  /// Contains all of the information about an EO3 font, extracted from font2png.
  /// </summary>
  public class EO3Font : List<EO3Character>
  {
    /// <summary>
    /// The amount of pixels between lines.
    /// </summary>
    private readonly int LineSpacing = 0;

    private string _TexturePath;

    /// <summary>
    /// Where the font's texture is stored.
    /// </summary>
    public string TexturePath
    {
      get => _TexturePath;
      // When the texture path is set, load the texture at that path.
      set
      {
        _TexturePath = value;
        Texture = new Bitmap(_TexturePath);
        // If we haven't gotten the GlyphSize yet, calculate it.
        int charactersPerRow = (int)Math.Ceiling(Math.Sqrt(Count));
        if (GlyphSize == -1)
        {
          GlyphSize = Texture.Width / charactersPerRow;
        }
      }
    }

    /// <summary>
    /// The bitmap that contains the actual glyph pixels for the font.
    /// </summary>
    private Bitmap Texture;

    /// <summary>
    /// How big a given glyph is; both height and weight.
    /// </summary>
    private int GlyphSize = -1;

    /// <summary>
    /// Gets the bitmap for a character from the font texture.
    /// </summary>
    /// <param name="character">The character to get the bitmap for.</param>
    /// <returns>The bitmap for the requested character.</returns>
    public Bitmap GetCharacter(char character)
    {
      // The EO3Character for the requested character.
      var characterInfo = this.FirstOrDefault(characterData => characterData.Character == character);
      if (characterInfo != null)
      {
        // What the character's index is.
        var characterIndex = this.IndexOf(characterInfo);
        // How many characters are stored on a row in the sheet.
        int charactersPerRow = (int)Math.Ceiling(Math.Sqrt(Count));
        // Where we start on the texture sheet.
        int startingX = (characterIndex % charactersPerRow * GlyphSize) + characterInfo.LeftBound;
        int startingY = ((int)Math.Floor((double)(characterIndex / charactersPerRow))) * GlyphSize;
        // The area representation of all the math we just did.
        var cropArea = new Rectangle(startingX, startingY, characterInfo.Width, GlyphSize);
        return Texture.Clone(cropArea, System.Drawing.Imaging.PixelFormat.DontCare);
      }
      // If we got an unrecognized character, return a 0x0 image.
      else
      {
        return new Bitmap(1, 1);
      }
    }

    /// <summary>
    /// Gets a bitmap representing the requested string, drawn in the font.
    /// </summary>
    /// <param name="input">The string to be drawn.</param>
    /// <returns>A bitmap representation of that string.</returns>
    public Bitmap GetString(string input)
    {
      // The width of the resulting image.
      int width = 0;
      // The height of the resulting image.
      int height = 0;
      // Get the width of the image by finding the horizontally-longest line.
      var lineMeasurements = new List<int>();
      foreach (char character in input)
      {
        if (character != '\n')
        {
          var characterInfo = this.FirstOrDefault(storedCharacterInfo => storedCharacterInfo.Character == character);
          // Break out if characterInfo is null, meaning we got some weird character we can't parse.
          if (characterInfo == null) { break; }
          // Spaces are 2 pixels wide, all other characters have 1 pixel between each other.
          if (character != ' ')
          {
            width += characterInfo.Width + 1;
          }
          else
          {
            width += characterInfo.Width;
          }
        }
        // When we hit a new line, record the width, and reset width for the next line.
        else
        {
          lineMeasurements.Add(width);
          width = 0;
        }
      }
      // If the string didn't end with a newline, add the final measurement to the list.
      if (input.EndsWith("\n") == false)
      {
        lineMeasurements.Add(width);
      }
      int longestWidth = 1;
      if (lineMeasurements.Count > 0) { longestWidth = lineMeasurements.Max(); }
      height = lineMeasurements.Count * (GlyphSize + LineSpacing);
      // In case we end up with a completely empty string, floor the width and height at 1px.
      if (longestWidth <= 0) { longestWidth = 1; }
      if (height <= 0) { height = 1; }
      var result = new Bitmap(longestWidth, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
      // Get the characters, and paste them into the result.
      using (var graphics = Graphics.FromImage(result))
      {
        // Where we are in the output image.
        int xPos = 0;
        int yPos = 0;
        foreach (char character in input)
        {
          if (character != '\n')
          {
            var characterBitmap = GetCharacter(character);
            graphics.DrawImage(characterBitmap, xPos, yPos);
            // See the above note on spaces.
            if (character != ' ')
            {
              xPos += characterBitmap.Width + 1;
            }
            else if (character == ' ')
            {
              xPos += characterBitmap.Width;
            }
          }
          // When we hit newlines, reset the horizontal position, and shift the vertical position down.
          else
          {
            xPos = 0;
            yPos += GlyphSize + LineSpacing;
          }
        }
      }
      return result;
    }
  }

  /// <summary>
  /// Contains the information on a given character in an EO3 font.
  /// </summary>
  public class EO3Character
  {
    /// <summary>
    /// What character this represents.
    /// </summary>
    public char Character { get; set; }

    /// <summary>
    /// Where the leftmost pixels of the character are.
    /// </summary>
    public int LeftBound { get; set; }

    /// <summary>
    /// Where the topmost pixels of the character are.
    /// </summary>
    public int UpperBound { get; set; }

    /// <summary>
    /// How wide the character is.
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// How tall the character is.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// For deserialization.
    /// </summary>
    public EO3Character() { }

    /// <summary>
    /// For proper construction.
    /// </summary>
    /// <param name="character">The character.</param>
    /// <param name="width">The character's width.</param>
    /// <param name="height">The character's height.</param>
    public EO3Character(char character, int width, int height)
    {
      Character = character;
      Width = width;
      Height = height;
    }
  }
}