using System;

/// <summary>
/// Represents a fraction, or rational number, with a top and bottom component.
/// </summary>
public class Fraction
{
    private int _top;
    private int _bottom;

    /// <summary>
    /// Creates a fraction for 1/1.
    /// </summary>
    public Fraction()
    {
        // Default to 1/1
        _top = 1;
        _bottom = 1;
    }

    /// <summary>
    /// Creates a fraction for the provided whole number.
    /// </summary>
    /// <param name="wholeNumber"></param>
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    /// <summary>
    /// Creates a fraction for the provided top and bottom numbers.
    /// </summary>
    /// <param name="top">The numerator</param>
    /// <param name="bottom">The denominator</param>
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    /// <summary>
    /// Returns a fraction in the form "top/bottom".
    /// </summary>
    /// <returns></returns>
    public string GetFractionString()
    {
        // Notice that this is not stored as a member variable.
        // Is is just a temporary, local variable that will be recomputed each time this is called.
        string text = $"{_top}/{_bottom}";
        return text;
    }

    /// <summary>
    /// Returns the decimal value of the fraction.
    /// </summary>
    /// <returns></returns>
    public double GetDecimalValue()
    {
        // Notice that this is not stored as a member variable.
        // Is will be recomputed each time this is called.
        return (double)_top / (double)_bottom;
    }
}